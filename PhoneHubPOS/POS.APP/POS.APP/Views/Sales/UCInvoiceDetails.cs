using POS.Services.Item;
using POS.Services.Sale;
using POS.Services.SaleDetail;
using POS.Services.Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace POS.APP.Views.Sales
{
    public partial class UCInvoiceDetails : UserControl
    {
        public int staff_id { get; set; }
        public string staff_name { get; set; }
        private int intSaleID;
        private decimal decTotalAmount;
        private string strInvoiceID, strCustomerName, strSaleDate, strStaffName;
        SaleService saleService = new SaleService();
        SaleDetailService saleDetailService = new SaleDetailService();
        ItemService itemService = new ItemService();
        StockService stockService = new StockService();
        List<string> itemNames = new List<string>();
        List<int> quantities = new List<int>();
        public UCInvoiceDetails(int staff_id, string staff_name, int id, string staffname, string saleDate, decimal totalAmount, string invoiceId, string customerName)
        {
            InitializeComponent();
            this.staff_id = staff_id;
            this.staff_name = staff_name;
            this.intSaleID = id;
            this.strStaffName = staffname;
            this.strSaleDate = saleDate;
            this.decTotalAmount = totalAmount;
            this.strInvoiceID = invoiceId;
            this.strCustomerName = customerName;
        }
        /// <summary>
        /// Initial Load Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCInvoiceDetails_Load(object sender, EventArgs e)
        {
            dgvInvoiceData.AutoGenerateColumns = false;
            lblInvoiceNo.Text = strInvoiceID;
            lblCustomerName.Text = strCustomerName;
            if (DateTime.TryParse(strSaleDate, out DateTime saleDateTime))
            {
                // Extract the date and time components
                string datePart = saleDateTime.ToShortDateString();
                string timePart = saleDateTime.ToShortTimeString();
                lblSaleDate.Text = datePart;
                lblSaleTime.Text = timePart;
            }
            lblTotalAmount.Text = string.Format("{0:#,##0}", decTotalAmount);
            lblStaffName.Text = strStaffName;
            DataTable dt = saleDetailService.GetSaleDetailsBySaleId(intSaleID);
            dgvInvoiceData.DataSource = dt;
        }
        /// <summary>
        /// Back to Sale List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoBacktoSale_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCSalesList ucSalesList = new UCSalesList(staff_id, staff_name);
            this.Controls.Add(ucSalesList);
        }
        /// <summary>
        /// Return Payment Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnPayment_Click(object sender, EventArgs e)
        {
            // Display an OK/Cancel confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to return the payment?", "Confirm Return Payment", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                bool success = saleService.ReturnPayment(intSaleID);
                if (success)
                {
                    // Get the product name and quantity from the DataGridView
                    foreach (DataGridViewRow row in dgvInvoiceData.Rows)
                    {
                        if (row.Cells["ItemName"].Value != null && row.Cells["Quantity"].Value != null)
                        {
                            string itemName = row.Cells["ItemName"].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                            itemNames.Add(itemName);
                            quantities.Add(quantity);
                        }
                    }
                    // Restore the quantity to the stock
                    for (int i = 0; i < itemNames.Count; i++)
                    {
                        string productName = itemNames[i];
                        int quantityToRemove = quantities[i];

                        int intProductID = itemService.GetIdByName(productName);
                        if (intProductID >= 0)
                        {
                            stockService.AddQuantityBaseOnSale(intProductID, quantityToRemove);
                        }
                    }
                    MessageBox.Show("Return Payment Successful!", "Return Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Controls.Clear();
                    UCSalesList ucSalesList = new UCSalesList(staff_id, staff_name);
                    this.Controls.Add(ucSalesList);
                }
                else
                {
                    MessageBox.Show("returning payment was not successful", "Return Payment Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                return;
            }

        }
    }
}