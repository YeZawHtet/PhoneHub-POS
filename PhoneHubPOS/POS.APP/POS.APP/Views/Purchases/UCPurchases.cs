using POS.Entities.Purchase;
using POS.Entities.PurchaseDetail;
using POS.Entities.Stock;
using POS.Services.Item;
using POS.Services.Purchase;
using POS.Services.PurchaseDetail;
using POS.Services.Stock;
using POS.Services.Supplier;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace POS.APP.Views.Purchases
{
    public partial class UCPurchases : UserControl
    {
        // Property to store the login ID
        public int LoginID
        { get; set; }

        // Variables to store product and supplier information
        private int productId;
        private int supplierId;
        private decimal intPrice;
        private string desc;

        // Initialize services and data table
        SupplierService supplierService = new SupplierService();
        ItemService itemService = new ItemService();
        StockService stockService = new StockService();
        PurchaseService purchaseService = new PurchaseService();
        PurchaseDetailService PDService = new PurchaseDetailService();
        DataTable dt = new DataTable();
        public UCPurchases(int id)
        {
            InitializeComponent();
            this.LoginID = id;
        }

        // Event handler for UCPurchases load
        private void UCPurchases_Load(object sender, EventArgs e)
        {
            BindData();
        }

        // Bind data to supplier and product combo boxes
        private void BindData()
        {
            DataTable dtsupplier = supplierService.GetAll();
            cboSupplier.DataSource = dtsupplier;
            cboSupplier.DisplayMember = "name";
            cboSupplier.ValueMember = "supplier_id";

            DataTable dtitem = itemService.GetAll();
            cboProduct.DataSource = dtitem;
            cboProduct.DisplayMember = "name";
            cboProduct.ValueMember = "item_id";
        }

        // Add row numbers to the DataGridView
        private void AddRowNumbersToDataGridView()
        {
            for (int i = 0; i < dgvPurchase.Rows.Count; i++)
            {
                dgvPurchase.Rows[i].Cells["No"].Value = (i + 1).ToString();
            }
        }

        // Event handler for product selection change
        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Text = "1";
            DataRowView selectedRow = cboProduct.SelectedItem as DataRowView;
            productId = Convert.ToInt32(selectedRow["item_id"]);
            string productName = selectedRow["name"].ToString();
            txtProductName.Text = productName;
            if (productId >= 0)
            {
                dt = itemService.Get(productId);
                intPrice = (decimal)dt.Rows[0]["price"];
                txtPrice.Text = intPrice.ToString("N0");
            }
            btnValueAdd.Enabled = true;
        }

        // Event handler for supplier selection change
        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cboSupplier.SelectedItem as DataRowView;
            supplierId = Convert.ToInt32(selectedRow["supplier_id"]);
        }

        // Event handler for the "Clear" button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Clear input fields
        private void ClearFields()
        {
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }

        // Event handler for the "Add" button click to increse quantity
        private void btnValueAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int currentQuantity))
            {
                currentQuantity++;
                txtQuantity.Text = currentQuantity.ToString();
                btnValueRemove.Enabled = true;
            }
        }

        // Event handler for the "Remove" button click to decrese quantity
        private void btnValueRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int currentQuantity))
            {
                if (currentQuantity > 1)
                {
                    currentQuantity--;

                    txtQuantity.Text = currentQuantity.ToString();
                }
                else
                {
                    btnValueRemove.Enabled = false;
                }
            }
        }

        // Validate user inputs
        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please select a product ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProduct.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please select a product ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProduct.Focus();
                return false;
            }
            if (!int.TryParse(txtQuantity.Text, out int Quantity) || Quantity <= 0 || txtQuantity.Text.Length > 10000)
            {
                MessageBox.Show("Please enter a valid quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }
            return true;
        }

        // Calculate row count and total amount
        private int calculateRowCountAndTotal()
        {
            int rowCount = dgvPurchase.Rows.Count;
            decimal totalSum = 0;
            int totalItem = 0;
            foreach (DataGridViewRow row in dgvPurchase.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    totalSum += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
                if (row.Cells["Qty"].Value != null)
                {
                    totalItem += Convert.ToInt32(row.Cells["Qty"].Value);
                }
            }

            lblTotalItems.Text = totalItem.ToString("N0");
            lblTotalAmount.Text = totalSum.ToString("N0");
            return rowCount;
        }

        // Event handler for the "Add" button click to add products to DataGridView
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                return;
            };
            AddIntoDgv();
        }

        // Add product information to DataGridView
        private void AddIntoDgv()
        {
            int quantity = Convert.ToInt32(txtQuantity.Text);
            string productName = txtProductName.Text.Trim();
            bool productExists = false;
            foreach (DataGridViewRow row in dgvPurchase.Rows)
            {
                if (row.Cells["ProductName"].Value.ToString() == productName)
                {
                    int tempQuantity = Convert.ToInt32(row.Cells["Qty"].Value);
                    quantity = tempQuantity + quantity;
                    intPrice = (decimal)row.Cells["price"].Value;
                    decimal subTotal = quantity * intPrice;
                    row.Cells["Qty"].Value = quantity;
                    row.Cells["SubTotal"].Value = subTotal;
                    calculateRowCountAndTotal();
                    productExists = true;
                    break;
                }
            }
            if (!productExists && productId > 0 && supplierId > 0)
            {
                dt = itemService.Get(productId);
                intPrice = (decimal)dt.Rows[0]["price"];
                desc = dt.Rows[0]["description"].ToString();
                decimal subTotal = quantity * intPrice;
                dgvPurchase.Rows.Add("", productName, desc, intPrice, quantity, subTotal);
                dgvPurchase.CellFormatting += dgvPurchase_CellFormatting;
                AddRowNumbersToDataGridView();
                calculateRowCountAndTotal();
            }
        }

        // Event handler for cell content click in the DataGridView (remove product)
        private void dgvPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvPurchase.Columns["Remove"].Index)
                {
                    // Remove the selected row from the DataGridView
                    dgvPurchase.Rows.RemoveAt(e.RowIndex);
                    calculateRowCountAndTotal();
                }
            }
        }

        // Event handler for the "Save" button click to complete the purchase
        private void btnSave_Click(object sender, EventArgs e)
        {
            int isHaveProduct = calculateRowCountAndTotal();
            if (isHaveProduct == 0)
            {
                MessageBox.Show("Please select a product .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                decimal totalAmount = 0;
                PurchaseEntity purchaseEntity = new PurchaseEntity();
                purchaseEntity.staffId = LoginID;
                purchaseEntity.supplierId = supplierId;
                purchaseEntity.purchaseDate = DateTime.Now;
                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    if (row.Cells["Subtotal"].Value != null)
                    {
                        totalAmount += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    }
                }
                purchaseEntity.totalAmount = totalAmount;
                purchaseEntity.createdStaffId = LoginID;
                purchaseEntity.createdDatetime = DateTime.Now;
                purchaseEntity.updatedStaffId = LoginID;
                purchaseEntity.updatedDatetime = DateTime.Now;

                purchaseService.Insert(purchaseEntity);
                int lastPurchaseId = purchaseService.GetLastPurchaseId();

                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    string strItemName = row.Cells["ProductName"].Value.ToString();
                    int intItemID = itemService.GetIdByName(strItemName);
                    int intQuantity = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal decUnitPrice = Convert.ToDecimal(row.Cells["Price"].Value);

                    PurchaseDetailEntity PDEntity = new PurchaseDetailEntity();
                    PDEntity.purchaseId = lastPurchaseId;
                    PDEntity.itemId = intItemID;
                    PDEntity.quantity = intQuantity;
                    PDEntity.unitPrice = decUnitPrice;
                    PDService.Insert(PDEntity);

                    StockEntity stockEntity = new StockEntity();
                    stockEntity.item_id = intItemID;
                    stockEntity.quantity = intQuantity;
                    stockService.AddQuantityBaseOnSale(intItemID, intQuantity);
                }
                MessageBox.Show("Successfully Save. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                dgvPurchase.Rows.Clear();
                lblTotalItems.Text = "0";
                lblTotalAmount.Text = "0";
            }
        }

        // Event handler for the "Return Payment" button click
        private void btnReturnPayment_Click(object sender, EventArgs e)
        {
            UCPurchasesList ucPurchasesList = new UCPurchasesList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucPurchasesList);
        }

        // Event handler for cell formatting in data grip view to change price and subtotal format
        private void dgvPurchase_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPurchase.Columns[e.ColumnIndex].Name == "Price")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal numericValue))
                {
                    e.Value = numericValue.ToString("N0", CultureInfo.InvariantCulture);
                    e.FormattingApplied = true;
                }
            }
            if (dgvPurchase.Columns[e.ColumnIndex].Name == "SubTotal")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal numericValue))
                {
                    e.Value = numericValue.ToString("N0", CultureInfo.InvariantCulture);
                    e.FormattingApplied = true;
                }
            }
        }
    }
}