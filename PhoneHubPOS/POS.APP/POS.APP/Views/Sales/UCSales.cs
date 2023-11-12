using POS.APP.Views.Customer;
using POS.Entities.Sale;
using POS.Entities.SaleDetail;
using POS.Services.Customer;
using POS.Services.Item;
using POS.Services.Sale;
using POS.Services.SaleDetail;
using POS.Services.Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace POS.APP.Views.Sales
{
    public partial class UCSales : UserControl
    {
        public int staff_id { get; set; }
        public string staff_name { get; set; }
        ItemService itemService = new ItemService();
        StockService stockService = new StockService();
        CustomerService customerService = new CustomerService();
        string selectedCustomer = null;
        int intLastInsertedSaleID;
        int intQuantity = 1;
        int intRowIndex = -1;
        DataTable dt = new DataTable();
        public UCSales(int staff_id, string staffname)
        {
            InitializeComponent();
            this.staff_id = staff_id;
            this.staff_name = staffname;
        }
        /// <summary>
        /// Initial load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSales_Load(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            string formattedDate = currentTime.ToString("D");
            lblDate.Text = formattedDate;
            ProductLoad();
            CustomerLoad();
        }
        /// <summary>
        /// Adding Row Numbers in DataGridView
        /// </summary>
        private void AddRowNumbersToDataGridView()
        {
            for (int i = 0; i < dgvSaleProduct.Rows.Count; i++)
            {
                dgvSaleProduct.Rows[i].Cells["No"].Value = (i + 1).ToString();
            }
        }
        /// <summary>
        /// Load Product Data
        /// </summary>
        private void ProductLoad()
        {
            dt = itemService.GetAll();
            if (dt.Rows.Count > 0)
            {
                cboChooseProduct.DisplayMember = "name";
                foreach (DataRow row in dt.Rows)
                {
                    cboChooseProduct.Items.Add(row["name"].ToString());
                }
                cboChooseProduct.Enabled = true;
                btnValueAdd.Enabled = true;
                btnValueRemove.Enabled = true;
                if (cboChooseProduct.Items.Count > 0)
                {
                    cboChooseProduct.SelectedIndex = 0;
                }
            }
            else
            {
                cboChooseProduct.Enabled = false;
                btnValueAdd.Enabled = false;
                btnValueRemove.Enabled = false;
            }
        }
        /// <summary>
        /// Load Customer Data
        /// </summary>
        private void CustomerLoad()
        {
            dt = customerService.GetAll();
            if (dt.Rows.Count > 0)
            {
                cboChooseCustomer.DisplayMember = "DisplayText"; // Display the DisplayText property
                foreach (DataRow row in dt.Rows)
                {
                    string strPhone = Convert.ToString(row["phone"]);
                    string name = row["name"].ToString();
                    string displayText = $"{name}  ({strPhone}) "; // Format the display text
                    CustomerInfo customer = new CustomerInfo(strPhone, name, displayText);
                    cboChooseCustomer.Items.Add(customer);
                }
                cboChooseCustomer.Enabled = true;
                if (cboChooseCustomer.Items.Count > 0)
                {
                    cboChooseCustomer.SelectedIndex = 0;
                }
            }
            else
            {
                cboChooseCustomer.Enabled = false;
            }
        }
        /// <summary>
        /// Calculated to get Stock Available Quantity
        /// </summary>
        /// <returns></returns>
        private int CalculateQuantity()
        {
            string strProductName = txtProductName.Text;
            int itemId = itemService.GetIdByName(strProductName);
            int quantity = stockService.GetQuentity(itemId);
            return quantity;
        }
        /// <summary>
        /// Control Quantity Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValueAdd_Click(object sender, EventArgs e)
        {
            int intQuantityFromStock = CalculateQuantity();
            intQuantity += 1;
            txtQuantity.Text = intQuantity.ToString();
            QuantityButtonControls(intQuantity);
        }
        /// <summary>
        /// Control Quantity substract
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValueRemove_Click(object sender, EventArgs e)
        {
            if (intQuantity > 1)
            {
                intQuantity -= 1;
                txtQuantity.Text = intQuantity.ToString();
                QuantityButtonControls(intQuantity);
                if (intQuantity == 1)
                {
                    btnValueRemove.Enabled = false;
                }
                else
                {
                    btnValueAdd.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Control state of Quantity Buttons
        /// </summary>
        /// <param name="intQuantity"></param>
        private void QuantityButtonControls(int intQuantity)
        {
            if (intQuantity >= 1)
            {
                btnValueRemove.Enabled = true;
            }
            else
            {
                btnValueRemove.Enabled = false;
            }
        }
        /// <summary>
        /// Add Button Click Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strProductName = txtProductName.Text.Trim();
            int intProductID = itemService.GetIdByName(strProductName);
            if (cboChooseCustomer.SelectedIndex <= -1)
            {
                MessageBox.Show("To proceed, please load a Customer first.", "Product Loading Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboChooseProduct.SelectedIndex <= -1)
            {
                MessageBox.Show("To proceed, please load a Product first.", "Product Loading Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (intProductID >= 0 && cboChooseCustomer.SelectedIndex != -1 && cboChooseProduct.SelectedIndex != -1)
            {
                // Check if the item is already in the DataGridView
                DataGridViewRow existingRow = null;
                foreach (DataGridViewRow row in dgvSaleProduct.Rows)
                {
                    string productNameInGrid = row.Cells["ProductName"].Value.ToString();
                    if (productNameInGrid == strProductName)
                    {
                        existingRow = row;
                        break;
                    }
                }

                if (existingRow != null)
                {
                    // Product is already in the DataGridView, update the quantity
                    int existingQuantity = (int)existingRow.Cells["Qty"].Value;
                    if (int.TryParse(txtQuantity.Text.Trim(), out int intQuantity))
                    {
                        int newQuantity = existingQuantity + intQuantity;
                        existingRow.Cells["Qty"].Value = newQuantity;
                        stockService.ReduceQuantityBaseOnSale(intProductID, intQuantity);
                        // Update the total for the existing product
                        decimal decPrice = (decimal)existingRow.Cells["Price"].Value;
                        decimal decTotal = decPrice * newQuantity;
                        existingRow.Cells["SubTotal"].Value = decTotal;
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid integer range for the quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Product is not in the DataGridView, add a new row
                    dt = itemService.Get(intProductID);
                    string strDesc = dt.Rows[0]["description"].ToString();

                    if (int.TryParse(txtQuantity.Text.Trim(), out int intQuantity))
                    {
                        int intAvailableQty = CalculateQuantity();
                        if (intAvailableQty > 0)
                        {
                            if (intAvailableQty >= intQuantity)
                            {
                                if (decimal.TryParse(txtPrice.Text.Trim(), out decimal decPrice) && intQuantity != 0)
                                {
                                    decimal decTotal = decPrice * intQuantity;
                                    intRowIndex = dgvSaleProduct.Rows.Add("", strProductName, strDesc, decPrice, intQuantity, decTotal);
                                    stockService.ReduceQuantityBaseOnSale(intProductID, intQuantity);
                                    AddRowNumbersToDataGridView();
                                    ClearFields();
                                }
                                else
                                {
                                    MessageBox.Show("Kindly select a valid quantity amount.", "Quantity Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Only {intAvailableQty} left!", "In Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry, this product is currently out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid integer range for the quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            calculateRowCountAndTotal();
        }
        /// <summary>
        /// Clear Button Click Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        /// <summary>
        /// Clear Fields
        /// </summary>
        private void ClearFields()
        {
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            txtAvailableQuantity.Text = "";
            cboChooseProduct.SelectedIndex = -1;
        }
        /// <summary>
        /// Clear all Fields after payment
        /// </summary>
        private void ClearAllFields()
        {
            dgvSaleProduct.Rows.Clear();
            txtAvailableQuantity.Text = "";
            cboChooseCustomer.SelectedIndex = -1;
            lblTotalItems.Text = "";
            lblTotalAmount.Text = "";
            lblPayment.Text = "";
        }
        /// <summary>
        /// Prevent Entering character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If it's not a numeric digit or a control key, suppress the key press.
                e.Handled = true;
            }
        }
        /// <summary>
        /// Prevent Entering character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If it's not a numeric digit or a control key, suppress the key press.
                e.Handled = true;
            }
        }
        /// <summary>
        /// Payment Button Click Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPayment_Click(object sender, EventArgs e)
        {
            using (PaymentForm paymentForm = new PaymentForm())
            {
                int isHaveProduct = calculateRowCountAndTotal();
                if (isHaveProduct > 0)
                {
                    // Show the PaymentForm as a dialog
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        decimal paymentAmount = paymentForm.decPayAmount;
                        string strFormatePayment = paymentAmount.ToString(" 0");
                        lblPayment.Text = $"{strFormatePayment}";
                        decimal decCharge = CalculateCharge(paymentAmount);

                        if (decCharge < 0)
                        {
                            decimal nonNegativeCharge = Math.Abs(decCharge);
                            string formattedCharge = string.Format("{0:#,##0}", nonNegativeCharge);
                            MessageBox.Show($"Cashier, please ensure you request a payment of {formattedCharge} from the customer.", "Payment Reminder for Cashier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else
                        {
                            intLastInsertedSaleID = InsertSaleRecord();
                            InsertSaleDetailRecord();
                            ClearAllFields();
                            ReceiptForm receiptForm = new ReceiptForm();
                            receiptForm.LoadReceipt(intLastInsertedSaleID);
                            receiptForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Cashier, please ensure there are products available for customers to make payments.", "Product Reminder for Cashier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        /// <summary>
        /// Insert created data to Sale entity return last inserted id
        /// </summary>
        /// <returns></returns>
        private int InsertSaleRecord()
        {
            try
            {
                SaleService saleService = new SaleService();
                SaleEntity saleEntity = CreateDataForSaleInsert();

                // Insert the sale record and check for success
                bool success = saleService.Insert(saleEntity);

                if (success)
                {
                    // Retrieve the last inserted sale ID
                    intLastInsertedSaleID = saleService.GetLastInsertID();
                }
                else
                {
                    // Handle the case where the insertion failed
                    MessageBox.Show("Sale Record Insertion Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return intLastInsertedSaleID;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the operation
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Return -1 to indicate an error
            }
        }
        /// <summary>
        /// Insert Created data to SaleDetail Entity
        /// </summary>
        private void InsertSaleDetailRecord()
        {
            SaleDetailService saleDetailService = new SaleDetailService();
            List<SaleDetailEntity> saleDetailEntities = CreateDataForSaleDetailInsert();
            saleDetailService.Insert(saleDetailEntities);
        }
        /// <summary>
        /// Created Data for Sale
        /// </summary>
        /// <returns></returns>
        private SaleEntity CreateDataForSaleInsert()
        {
            decimal decTotalSum = 0;
            string strCustomerName = selectedCustomer;
            int intCustomerID = customerService.GetIdByName(strCustomerName);

            foreach (DataGridViewRow row in dgvSaleProduct.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    decTotalSum += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            // Format the total amount to remove ".00" if present
            string formattedTotalAmount = decTotalSum.ToString("F2");

            SaleEntity saleEntity = new SaleEntity();
            saleEntity.staff_id = staff_id;
            saleEntity.customer_id = intCustomerID;
            saleEntity.sale_date = DateTime.Now;
            saleEntity.total_amount = decimal.Parse(formattedTotalAmount); // Convert back to decimal
            saleEntity.created_staff_id = 1;
            saleEntity.updated_staff_id = 1;
            saleEntity.created_datetime = DateTime.Now;
            saleEntity.updated_datetime = DateTime.Now;

            return saleEntity;
        }
        /// <summary>
        /// Created Data for SaleDetail
        /// </summary>
        /// <returns></returns>
        private List<SaleDetailEntity> CreateDataForSaleDetailInsert()
        {
            int intSaleID = intLastInsertedSaleID;

            // Initialize a list to store SaleDetailEntity objects
            List<SaleDetailEntity> saleDetailsList = new List<SaleDetailEntity>();

            foreach (DataGridViewRow row in dgvSaleProduct.Rows)
            {
                string strItemName = row.Cells["ProductName"].Value.ToString();
                int intItemID = itemService.GetIdByName(strItemName);
                int intQuantity = Convert.ToInt32(row.Cells["Qty"].Value);

                // Format the unit price to remove ".00" if present
                decimal decUnitPrice = decimal.Parse(Convert.ToDecimal(row.Cells["Price"].Value).ToString("F2"));

                // Create a SaleDetailEntity object for each row and populate it with the retrieved values
                SaleDetailEntity saleDetailEntity = new SaleDetailEntity();
                saleDetailEntity.sale_id = intSaleID;
                saleDetailEntity.item_id = intItemID;
                saleDetailEntity.quantity = intQuantity;
                saleDetailEntity.unit_price = decUnitPrice;

                // Add the SaleDetailEntity object to the list
                saleDetailsList.Add(saleDetailEntity);
            }

            // Return the list of SaleDetailEntity objects
            return saleDetailsList;
        }
        /// <summary>
        /// Getting DataGirdViewRowCount and Total Amount
        /// </summary>
        private int calculateRowCountAndTotal()
        {
            int rowCount = dgvSaleProduct.Rows.Count;
            decimal totalSum = 0;

            foreach (DataGridViewRow row in dgvSaleProduct.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    totalSum += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            // Display the total row count and subtotal total
            lblTotalItems.Text = rowCount.ToString();
            lblTotalAmount.Text = totalSum.ToString("#,##0");
            return rowCount;
        }
        /// <summary>
        /// Calculat Charge 
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public decimal CalculateCharge(decimal payment)
        {
            // Parse the label text values into decimal
            decimal totalAmount = decimal.Parse(lblTotalAmount.Text.Replace("$", ""));
            decimal paymentAmount = decimal.Parse(lblPayment.Text.Replace("$", ""));
            // Calculate the charge
            decimal charge = paymentAmount - totalAmount;
            decimal nonNegativeCharge = Math.Max(charge, 0);
            return charge; // Return the calculated charge
        }
        /// <summary>
        /// Getting Customer base on Choose Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboChooseCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the ComboBox
            if (cboChooseCustomer.SelectedItem is CustomerInfo selectedCustomerInfo)
            {
                selectedCustomer = selectedCustomerInfo.Name; // Get the name property of the selected CustomerInfo object
            }
        }
        /// <summary>
        /// Loading Product Info Base on Choose Product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboChooseProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChooseProduct.SelectedIndex > -1)
            {
                intQuantity = 1;
                txtQuantity.Text = "1";
                btnValueAdd.Enabled = true;
                string strProductName = cboChooseProduct.SelectedItem.ToString().Trim();
                txtProductName.Text = strProductName;
                int intProductID = itemService.GetIdByName(strProductName);
                if (intProductID >= 0)
                {
                    dt = itemService.Get(intProductID);
                    decimal strDesc = (decimal)dt.Rows[0]["price"];
                    txtPrice.Text = string.Format("{0:#,##0}", strDesc);
                }
                //Set Available Quantity
                int quantity = CalculateQuantity();
                txtAvailableQuantity.Text = quantity.ToString();
                if (quantity < 10)
                {
                    txtAvailableQuantity.ForeColor = Color.Red;
                }
                else
                {
                    txtAvailableQuantity.ForeColor = Color.Black;
                }
            }

        }
        /// <summary>
        /// Control to Quantity Textbox value to ensure increase and decrease
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int intQuantityFromText;
            if (int.TryParse(txtQuantity.Text, out intQuantityFromText))
            {
                intQuantity = intQuantityFromText;
            }
        }
        /// <summary>
        /// Return Payment to Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnPayment_Click(object sender, EventArgs e)
        {
            if (HandleSaleItems())
            {
                UCSalesList ucSalesList = new UCSalesList(staff_id, staff_name);
                this.Controls.Clear();
                this.Controls.Add(ucSalesList);
            }

        }
        /// <summary>
        /// dgvSaleProduct Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                {
                    // Get the product name and quantity from the DataGridView
                    string productName = dgvSaleProduct.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                    int quantityToRemove = Convert.ToInt32(dgvSaleProduct.Rows[e.RowIndex].Cells["Qty"].Value);
                    // Remove the selected row from the DataGridView
                    dgvSaleProduct.Rows.RemoveAt(e.RowIndex);
                    calculateRowCountAndTotal();
                    // Restore the quantity to the stock
                    int intProductID = itemService.GetIdByName(productName);
                    if (intProductID >= 0)
                    {
                        stockService.AddQuantityBaseOnSale(intProductID, quantityToRemove);
                    }
                    if (dgvSaleProduct.Rows.Count <= 0)
                    {
                        lblTotalAmount.Text = "0";
                        lblPayment.Text = "0";
                    }
                    AddRowNumbersToDataGridView();
                }
            }
        }
        /// <summary>
        /// Return Item from sale
        /// </summary>
        public bool HandleSaleItems()
        {
            if (dgvSaleProduct.Rows.Count > 0)
            {
                // Ask the user for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to cancel items from the Sale Lists?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Check the user's choice
                if (result == DialogResult.Yes)
                {
                    // Iterate through all rows in the DataGridView (in reverse order)
                    for (int i = dgvSaleProduct.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dgvSaleProduct.Rows[i];
                        // Get the product name and quantity from the row
                        string productName = row.Cells["ProductName"].Value.ToString();
                        int quantityToRemove = Convert.ToInt32(row.Cells["Qty"].Value);
                        // Remove the selected row from the DataGridView
                        dgvSaleProduct.Rows.RemoveAt(i);
                        calculateRowCountAndTotal();
                        // Restore the quantity to the stock
                        int intProductID = itemService.GetIdByName(productName);
                        if (intProductID >= 0)
                        {
                            stockService.AddQuantityBaseOnSale(intProductID, quantityToRemove);
                        }
                    }
                    // Clear the DataGridView
                    dgvSaleProduct.Rows.Clear();
                    calculateRowCountAndTotal();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}