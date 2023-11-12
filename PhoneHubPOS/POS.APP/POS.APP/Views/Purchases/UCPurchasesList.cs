using OfficeOpenXml;
using POS.Services.Item;
using POS.Services.Purchase;
using POS.Services.PurchaseDetail;
using POS.Services.Staff;
using POS.Services.Stock;
using POS.Services.Supplier;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS.APP.Views.Purchases
{
    public partial class UCPurchasesList : UserControl
    {
        // Variables for pagination
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private int totalPages;

        // Initialize services and data table
        PurchaseService purchaseService = new PurchaseService();
        SupplierService supplierService = new SupplierService();
        PurchaseDetailService PDService = new PurchaseDetailService();
        StaffService staffService = new StaffService();
        StockService stockService = new StockService();
        ItemService itemService = new ItemService();
        private DataTable filteredDt = null;

        // Property to store the login ID
        public int LoginID
        { get; set; }
        public UCPurchasesList(int id)
        {
            InitializeComponent();
            this.LoginID = id;
        }

        // Event handler for UCPurchasesList load
        private void UCPurchasesList_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        // Bind data to DataGridView
        private void BindGrid()
        {
            DataTable dt = purchaseService.GetWithName();
            int totalItems = dt.Rows.Count;
            if (totalItems != 0)
            {
                totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                if (currentPage < 1)
                    currentPage = 1;
                else if (currentPage > totalPages)
                    currentPage = totalPages;
                DataTable paginatedDt = GetPaginatedData(dt);
                dgvPurchaseList.DataSource = paginatedDt;
                dgvPurchaseList.CellFormatting += dgvPurchaseList_CellFormatting;

                lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
                btnFirst.Enabled = currentPage > 1;
                btnLast.Enabled = currentPage < totalPages;
                dgvPurchaseList.Visible = true;
                dgvPurchaseDetail.Visible = false;
            }
            txtSearch.Text = "";
            DataView dv = dt.DefaultView;
            dv.RowFilter = "";
            filteredDt = null;
        }

        // Get a paginated portion of data from DataTable
        private DataTable GetPaginatedData(DataTable sourceTable)
        {
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, sourceTable.Rows.Count);
            DataTable paginatedDt = sourceTable.Clone();

            for (int i = startIndex; i < endIndex; i++)
            {
                paginatedDt.ImportRow(sourceTable.Rows[i]);
            }
            return paginatedDt;
        }

        // Event handler for the "Previous" button click
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                BindGrid();
            }
        }

        // Event handler for the "Next" button click
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                BindGrid();
            }
        }

        // Event handler for the "First" button click
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            BindGrid();
        }

        // Event handler for the "Last" button click
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            BindGrid();
        }

        // Event handler for the "Download" button click to export data to Excel
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = "PurchaseList.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    DataTable dataToExport = new DataTable();
                    if (txtSearch.Text != "")
                    {
                        dataToExport = ModifyDataTableForExport(filteredDt);
                    }
                    else
                    {
                        dataToExport = ModifyDataTableForExport(purchaseService.GetWithName());
                    }

                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("PurchaseList");
                    worksheet.Cells.LoadFromDataTable(dataToExport, true);
                    foreach (DataColumn column in dataToExport.Columns)
                    {
                        if (column.DataType == typeof(DateTime))
                        {
                            worksheet.Column(column.Ordinal + 1).Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                            worksheet.Column(column.Ordinal + 1).AutoFit();
                        }
                    }
                    for (int i = 1; i <= dataToExport.Columns.Count; i++)
                    {
                        var columnName = dataToExport.Columns[i - 1].ColumnName;
                        var maxLength = columnName.Length;
                        foreach (DataRow row in dataToExport.Rows)
                        {
                            var cellValue = row[i - 1].ToString();
                            if (cellValue.Length > maxLength)
                            {
                                maxLength = cellValue.Length;
                            }
                        }
                        int columnWidth = Math.Min(Math.Max(maxLength, columnName.Length) + 2, 50);
                        worksheet.Column(i).Width = columnWidth;
                    }
                    package.SaveAs(new FileInfo(filePath));
                    MessageBox.Show("Excel file downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while downloading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modify DataTable for export (rename columns and format)
        private DataTable ModifyDataTableForExport(DataTable inputTable)
        {
            DataTable modifiedTable = inputTable.Clone();

            modifiedTable.Columns["RowNum"].ColumnName = "No.";
            modifiedTable.Columns["invoice_no"].ColumnName = "Invoice No.";
            modifiedTable.Columns["staff_name"].ColumnName = "Staff Name";
            modifiedTable.Columns["supplier_name"].ColumnName = "Supplier Name";
            modifiedTable.Columns["purchase_date"].ColumnName = "Purchase Date";
            modifiedTable.Columns["total_amount"].ColumnName = "Total Amount";
            modifiedTable.Columns.Remove("purchase_id");
            int rowNum = 1;

            foreach (DataRow row in inputTable.Rows)
            {
                DataRow newRow = modifiedTable.NewRow();
                newRow["No."] = rowNum++;
                newRow["Invoice No."] = row["invoice_no"];
                newRow["Staff Name"] = row["staff_name"];
                newRow["Supplier Name"] = row["supplier_name"];
                newRow["Purchase Date"] = row["purchase_date"];
                newRow["Total Amount"] = row["total_amount"];
                modifiedTable.Rows.Add(newRow);
            }

            return modifiedTable;
        }

        // Event handler for the "Go Back to Sale" button click
        private void btnGoBacktoSale_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCPurchases ucPurchases = new UCPurchases(LoginID);
            ucPurchases.LoginID = LoginID;
            this.Controls.Add(ucPurchases);
        }

        // Event handler for cell content click in the purchase list DataGridView
        private void dgvPurchaseList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPurchaseList.Columns["delete_option"].Index && e.RowIndex >= 0)
            {
                // Delete purchase history
                int purchaseId = Convert.ToInt32(dgvPurchaseList.Rows[e.RowIndex].Cells["gcPurchaseId"].Value);
                DataTable purchaseDetailTable = PDService.Get(purchaseId);

                // check if the quantity can delete
                bool canDelete = true;
                foreach (DataRow detailRow in purchaseDetailTable.Rows)
                {
                    int itemId = (int)detailRow["item_id"];
                    int quantity = (int)detailRow["quantity"];
                    string itemName = itemService.GetNameById(itemId);
                    if (!stockService.IsStockAvailable(itemId, quantity))
                    {
                        canDelete = false;
                        MessageBox.Show($"Cannot delete this purchase history. Insufficient stock for item {itemName}.", "Insufficient stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }

                if (canDelete)
                {
                    foreach (DataRow detailRow in purchaseDetailTable.Rows)
                    {
                        int purchaseDetailId = (int)detailRow["purchase_detail_id"];
                        int itemId = (int)detailRow["item_id"];
                        int quantity = (int)detailRow["quantity"];
                        // Delete Purchase Detail records
                        PDService.Delete(purchaseDetailId);
                        // Reduce Quantity 
                        stockService.ReduceQuantityBaseOnSale(itemId, quantity);
                    }
                    bool success = purchaseService.Delete(purchaseId);
                    if (success)
                    {
                        MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK);
                    }
                    BindGrid();
                }
            }
            else
            {
                int purchaseId = Convert.ToInt32(dgvPurchaseList.Rows[e.RowIndex].Cells["gcPurchaseId"].Value);
                DataTable purchaseDetails = PDService.GetDetail(purchaseId);
                if (purchaseDetails != null && purchaseDetails.Rows.Count > 0)
                {
                    dgvPurchaseDetail.DataSource = purchaseDetails;

                    DataView dv = purchaseDetails.DefaultView;
                    int totalItems = dv.Count;
                    totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                    currentPage = 1;

                    DataTable DTPurchaseDetail = dv.ToTable();
                    DataTable paginatedDt = GetPaginatedData(DTPurchaseDetail);
                    dgvPurchaseDetail.DataSource = paginatedDt;
                    dgvPurchaseDetail.CellFormatting += dgvPurchaseDetail_CellFormatting;

                    lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
                    btnPrevious.Enabled = currentPage > 1;
                    btnNext.Enabled = currentPage < totalPages;
                    btnFirst.Enabled = currentPage > 1;
                    btnLast.Enabled = currentPage < totalPages;
                    dgvPurchaseDetail.Visible = true;
                    dgvPurchaseList.Visible = false;
                }
            }
        }

        // Event handler for the "Clear" button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        // Event handler for the search text box's text change event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Count() > 30)
            {
                MessageBox.Show("Please Enter correct Invoice Number name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }
            string searchKeyword = txtSearch.Text.Trim();

            DataTable dt = purchaseService.GetWithName();
            DataView dv = dt.DefaultView;

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                dv.RowFilter = $"staff_name LIKE '%{searchKeyword}%' " +
                               $"OR supplier_name LIKE '%{searchKeyword}%' " +
                               $"OR CONVERT(purchase_date, 'System.String') LIKE '%{searchKeyword}%' " +
                               $"OR CONVERT(total_amount, 'System.String') LIKE '%{searchKeyword}%' " +
                               $"OR invoice_no LIKE '%{searchKeyword}%'";
            }

            int totalItems = dv.Count;
            totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            currentPage = 1;

            filteredDt = dv.ToTable();
            UpdateRowNumColumn(filteredDt);
            DataTable paginatedDt = GetPaginatedData(filteredDt);
            dgvPurchaseList.DataSource = paginatedDt;
            if (dv.Count == 0)
            {
                lblPageNumber.Text = $"Page 0 of 0";
            }
            else
            {
                lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
            }
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnFirst.Enabled = currentPage > 1;
            btnLast.Enabled = currentPage < totalPages;
        }

        // Update the row number column in the DataTable
        private void UpdateRowNumColumn(DataTable dataTable)
        {
            int startIndex = (currentPage - 1) * itemsPerPage + 1;
            int endIndex = startIndex + itemsPerPage - 1;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i]["RowNum"] = startIndex++;
                if (startIndex > endIndex)
                {
                    break;
                }
            }
        }

        // Event handler for the "Back" button click
        private void btnBack_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        // Event handler for the search text box's key press event
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                e.Handled = true;
            }
        }

        // Event handler for cell formatting in data grip view to change TotalAmount format
        private void dgvPurchaseList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPurchaseList.Columns[e.ColumnIndex].Name == "TotalAmount")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal numericValue))
                {
                    e.Value = numericValue.ToString("N0", CultureInfo.InvariantCulture);
                    e.FormattingApplied = true;
                }
            }
        }

        // Event handler for cell formatting in data grip view to change Price format
        private void dgvPurchaseDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPurchaseDetail.Columns[e.ColumnIndex].Name == "unit_price")
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
