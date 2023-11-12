using OfficeOpenXml;
using POS.Services.SaleDetail;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace POS.APP.Views.Sales
{
    public partial class UCSalesList : UserControl
    {
        SaleDetailService saleDetailService = new SaleDetailService();
        DataTable paginatedDt = new DataTable();
        private DataTable filteredDt = null;
        DataTable exportDt = new DataTable();
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private int totalRowCount = 0;
        private int totalPages;
        public int staff_id { get; set; }
        public string staff_name { get; set; }
        public UCSalesList(int staff_id, string staffname)
        {
            InitializeComponent();
            this.staff_id = staff_id;
            this.staff_name = staffname;
        }
        /// <summary>
        /// Initial Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSalesList_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            dgvSaleList.AutoGenerateColumns = false;
            BindGrid();
        }
        /// <summary>
        /// Populate Data in DataGridView
        /// </summary>
        private void BindGrid()
        {
            if (filteredDt != null)
            {
                exportDt = filteredDt;
            }
            else
            {
                exportDt = saleDetailService.GetWithName();
            }

            totalRowCount = exportDt.Rows.Count; // Update the total row count
            int totalItems = totalRowCount;
            if (totalItems != 0)
            {
                totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                if (currentPage < 1)
                    currentPage = 1;
                else if (currentPage > totalPages)
                    currentPage = totalPages;
                paginatedDt = GetPaginatedData(exportDt);
                dgvSaleList.DataSource = paginatedDt;
                lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
                UpdatePaginationButtons();
            }
        }
        /// <summary>
        /// Retrieve only Pagination Data in DataGridView
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Previous Control for Pination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                BindGrid();
            }
        }
        /// <summary>
        /// Back Control for Pination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                BindGrid();
            }
        }
        /// <summary>
        /// Download Button Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "Sale Data.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                if (filteredDt != null)
                {
                    ExportDataTableToExcel(filteredDt, filePath);
                }
                else
                {
                    ExportDataTableToExcel(exportDt, filePath);
                }

                MessageBox.Show("Excel file downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Export data to excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        private void ExportDataTableToExcel(DataTable data, string filePath)
        {
            // List of column names to exclude from the export
            List<string> columnsToExclude = new List<string>
    {
        "RowNum",
        "sale_id",
        "Action",
        "staff_id",
        "total_amount",
        "staff_role"
    };

            // Create a copy of the DataTable to avoid modifying the original data
            DataTable exportData = data.Copy();

            // Remove the columns from the DataTable
            foreach (var column in columnsToExclude)
            {
                if (exportData.Columns.Contains(column))
                {
                    exportData.Columns.Remove(column);
                }
            }
            if (exportData != null)
            {
                if (exportData.Columns.Contains("sale_date"))
                {
                    // Create an ExcelPackage and export the modified DataTable
                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("SaleList");

                    // Set custom header names for the Excel columns
                    worksheet.Cells[1, 1].Value = "Invoice No.";
                    worksheet.Cells[1, 2].Value = "Staff Name";
                    worksheet.Cells[1, 3].Value = "Customer Name";
                    worksheet.Cells[1, 4].Value = "Item Name";
                    worksheet.Cells[1, 5].Value = "Unit Price";
                    worksheet.Cells[1, 6].Value = "Quantity";
                    worksheet.Cells[1, 7].Value = "Sub Total";
                    worksheet.Cells[1, 8].Value = "Sale Date";

                    int dataRow = 2;

                    // Iterate through each row and export data
                    foreach (DataRow row in exportData.Rows)
                    {
                        // Export other columns as needed
                        worksheet.Cells[dataRow, 1].Value = row["invoice_no"];
                        worksheet.Cells[dataRow, 2].Value = row["staffname"];
                        worksheet.Cells[dataRow, 3].Value = row["CustomerName"];
                        worksheet.Cells[dataRow, 4].Value = row["ItemName"];
                        worksheet.Cells[dataRow, 6].Value = row["quantity"];
                        decimal unitPrice = Convert.ToDecimal(row["unit_price"]);
                        string formattedUnitPrice = unitPrice.ToString("");
                        worksheet.Cells[dataRow, 5].Value = unitPrice;
                        decimal subTotal = Convert.ToDecimal(row["SubTotal"]);
                        string formattedSubTotal = subTotal.ToString("");
                        worksheet.Cells[dataRow, 7].Value = subTotal;
                        // Format the sale_date column
                        if (row["sale_date"] != DBNull.Value && DateTime.TryParse(row["sale_date"].ToString(), out DateTime saleDate))
                        {
                            worksheet.Cells[dataRow, 8].Value = saleDate.ToString("yyyy-MM-dd hh:mm tt");
                        }
                        else
                        {
                            worksheet.Cells[dataRow, 8].Value = row["sale_date"];
                        }

                        dataRow++;
                    }
                    worksheet.Cells.AutoFitColumns();
                    package.SaveAs(new FileInfo(filePath));
                }
            }
        }
        /// <summary>
        /// FirstPage of pagination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            BindGrid();
        }
        /// <summary>
        /// Last page of pagination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            BindGrid();
        }
        /// <summary>
        /// Search Opeartions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 100)
            {
                MessageBox.Show("Please enter a correct item name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }
            string searchKeyword = txtSearch.Text.Trim();
            DataTable dt = saleDetailService.GetWithName();
            DataView dv = dt.DefaultView;
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                // Convert the search keyword to a string
                string searchKeywordString = searchKeyword.ToString();

                // Create a filter for string columns using LIKE
                dv.RowFilter = $"CustomerName LIKE '%{searchKeywordString}%' " +
                               $"OR ItemName LIKE '%{searchKeywordString}%' " +
                               $"OR StaffName LIKE '%{searchKeywordString}%' " +
                               $"OR CONVERT(sale_date, 'System.String') LIKE '%{searchKeywordString}%' " +
                               $"OR invoice_no LIKE '%{searchKeywordString}%'";

                dv.RowFilter += $" OR CONVERT(formatted_unit_price, 'System.String') LIKE '%{searchKeywordString}%' " +
                             $"OR CONVERT(formatted_total_amount, 'System.String') LIKE '%{searchKeywordString}%' " +
                             $"OR CONVERT(formatted_SubTotal, 'System.String') LIKE '%{searchKeywordString}%' " +
                              $"OR CONVERT(quantity, 'System.String') LIKE '%{searchKeywordString}%' ";
            }

            int totalItems = dv.Count;
            totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            currentPage = 1;

            filteredDt = dv.ToTable();
            DataTable paginatedDt = GetPaginatedData(filteredDt);
            dgvSaleList.DataSource = paginatedDt;
            if (totalItems == 0) lblPageNumber.Text = "Page 0 of 0";
            else lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
            UpdatePaginationButtons();
        }
        /// <summary>
        /// Pagination button controls
        /// </summary>
        private void UpdatePaginationButtons()
        {
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnFirst.Enabled = currentPage > 1;
            btnLast.Enabled = currentPage < totalPages;
        }
        /// <summary>
        /// Reset Data when clear search
        /// </summary>
        private void ResetData()
        {
            txtSearch.Clear();
            txtSearch.Focus();
            string searchKeyword = txtSearch.Text.Trim();
            DataTable dt = saleDetailService.GetWithName();
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Empty;
            int totalItems = dv.Count;
            totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            currentPage = 1;
            filteredDt = dv.ToTable();
            DataTable paginatedDt = GetPaginatedData(filteredDt);
            dgvSaleList.DataSource = paginatedDt;
            lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
            UpdatePaginationButtons();
        }
        /// <summary>
        /// Clear Button Opeartions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetData();
        }
        /// <summary>
        /// Go Back to Sale Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoBacktoSale_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCSales ucSales = new UCSales(staff_id, staff_name);
            this.Controls.Add(ucSales);
        }
        /// <summary>
        /// Cell double click operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int intSaleID = Convert.ToInt32(dgvSaleList.CurrentRow.Cells["SaleID"].Value);
                string strStaffName = dgvSaleList.CurrentRow.Cells["StaffName"].Value.ToString();
                string strInvoiceID = dgvSaleList.CurrentRow.Cells["invoice"].Value.ToString();
                string strCustomerName = dgvSaleList.CurrentRow.Cells["CustomerName"].Value.ToString();
                string strSaleDate = dgvSaleList.CurrentRow.Cells["SaleDate"].Value.ToString();
                decimal decTotalAmount = Convert.ToDecimal(dgvSaleList.CurrentRow.Cells["TotalAmount"].Value);
                UCInvoiceDetails ucInvoiceDetails = new UCInvoiceDetails(staff_id, staff_name, intSaleID, strStaffName, strSaleDate, decTotalAmount, strInvoiceID, strCustomerName);
                this.Controls.Clear();
                this.Controls.Add(ucInvoiceDetails);
            }
        }
        /// <summary>
        /// prevent entering single quote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a single quote ('), ASCII code 39
            if (e.KeyChar == 39)
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

    }
}