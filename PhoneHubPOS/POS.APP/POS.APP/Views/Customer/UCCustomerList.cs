using OfficeOpenXml;
using POS.Entities.Customer;
using POS.Services.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace POS.APP.Views.Customer
{
    public partial class UCCustomerList : UserControl
    {
        CustomerService customerService = new CustomerService();
        private int LoginStaffID, currentPage = 1, totalPages, rowsPerPage = 10;
        private DataTable filteredDt = null;
        public UCCustomerList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initial Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCustomerList_Load(object sender, EventArgs e)
        {
            dgvUserList.AutoGenerateColumns = false;
            getNumberOfRecords();
            UpdateNavigationButtons();
            BindGrid();
        }
        /// <summary>
        /// Get total row
        /// </summary>
        public void getNumberOfRecords()
        {
            int numOfRows = customerService.GetCustomerCount();
            totalPages = (int)Math.Ceiling((double)numOfRows / rowsPerPage);
        }
        /// <summary>
        /// dgvUserList CellDoubleClick Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = Convert.ToInt32(dgvUserList.CurrentRow.Cells["CustomerID"].Value);
            if (e.RowIndex > -1)
            {
                UCCustomer ucUser = new UCCustomer();
                ucUser.ID = Convert.ToInt32(dgvUserList.CurrentRow.Cells["CustomerID"].Value);
                ucUser.SetLoginID(LoginStaffID);
                this.Controls.Clear();
                this.Controls.Add(ucUser);
            }
        }
        /// <summary>
        /// button Next Click
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
            UpdateNavigationButtons();
        }
        /// <summary>
        /// Button Previous Click
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
            UpdateNavigationButtons();
        }
        /// <summary>
        /// Update Pagination Buttons
        /// </summary>
        private void UpdateNavigationButtons()
        {
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnFirst.Enabled = currentPage > 1;
            btnLast.Enabled = currentPage < totalPages;
        }
        /// <summary>
        /// Clear button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            txtSearch.Focus();
            BindGrid();
        }
        /// <summary>
        /// Search Opearations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Count() > 30)
            {
                MessageBox.Show("Please Enter correct Customer name within 30 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }
            string searchKeyword = txtSearch.Text.Trim();
            DataTable dt = customerService.GetWithName();
            DataView dv = dt.DefaultView;
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                dv.RowFilter = $"name LIKE '%{searchKeyword}%' OR address LIKE '%{searchKeyword}%' OR email LIKE '%{searchKeyword}%' OR phone LIKE '%{searchKeyword}%'";
            }
            int totalItems = dv.Count;
            totalPages = (int)Math.Ceiling((double)totalItems / rowsPerPage);
            currentPage = 1;
            filteredDt = dv.ToTable();
            DataTable paginatedDt = GetPaginatedData(filteredDt);
            dgvUserList.DataSource = paginatedDt;
            UpdateNavigationButtons();
            if (totalItems == 0) lblPageNumber.Text = "Page 0 of 0";
            else lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
        }
        /// <summary>
        /// Retrieve Paginate Data
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <returns></returns>
        private DataTable GetPaginatedData(DataTable sourceTable)
        {
            int startIndex = (currentPage - 1) * rowsPerPage;
            int endIndex = Math.Min(startIndex + rowsPerPage, sourceTable.Rows.Count);
            DataTable paginatedDt = sourceTable.Clone();

            for (int i = startIndex; i < endIndex; i++)
            {
                paginatedDt.ImportRow(sourceTable.Rows[i]);
            }
            return paginatedDt;
        }
        /// <summary>
        /// Upload Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                // Adding file size and row limit validation
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeInBytes = fileInfo.Length;
                long fileSizeInKB = fileSizeInBytes / 1024;
                int maxFileSizeKB = 1024;
                if (fileSizeInKB > maxFileSizeKB)
                {
                    MessageBox.Show("The selected Excel file exceeds the maximum allowed size.", "File Size Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Defining the first row columns name
                List<string> expectedColumnNames = new List<string>
        {
            "Name",
            "Email",
            "Phone",
            "Address"
        };
                using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    if (worksheet.Dimension == null)
                    {
                        MessageBox.Show("The selected Excel file is empty.", "Empty File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    List<string> errorlist = new List<string>();

                    // Read the header row from the Excel file
                    List<string> headerColumnNames = new List<string>();
                    for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                    {
                        string headerCellValue = worksheet.Cells[worksheet.Dimension.Start.Row, col].Value?.ToString();
                        headerColumnNames.Add(headerCellValue);
                    }

                    // Check if the header column names match the expected column names
                    if (!AreColumnNamesMatching(expectedColumnNames, headerColumnNames))
                    {
                        MessageBox.Show("The column names in the Excel file do not match the expected column names.", "Column Name Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Maintain a HashSet to store unique emails encountered in the Excel file
                    HashSet<string> uniqueEmails = new HashSet<string>();
                    for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string name = worksheet.Cells[row, 1].Value?.ToString();
                        string email = worksheet.Cells[row, 2].Value?.ToString();
                        string phone = worksheet.Cells[row, 3].Value?.ToString();
                        string address = worksheet.Cells[row, 4].Value?.ToString();
                        List<string> rowErrors = new List<string>();
                        if (string.IsNullOrWhiteSpace(name) || name.Length > 30)
                        {
                            if (string.IsNullOrWhiteSpace(name)) rowErrors.Add("Null in Name column");
                            else rowErrors.Add("Invalid data in Name column");
                        }
                        if (string.Equals(name, "NULL", StringComparison.OrdinalIgnoreCase)) rowErrors.Add("Name column cannot be 'NULL'.");
                        if (string.IsNullOrWhiteSpace(email) || email.Length > 30 || !TestEmail(email))
                        {
                            if (string.IsNullOrWhiteSpace(email)) rowErrors.Add("Null in Email column");
                            else rowErrors.Add("Invalid data in Email column");
                        }
                        int count = customerService.GetUserCount(email);
                        if (count >= 1) rowErrors.Add("Already existed Email.");
                        else
                        {
                            // Check for duplicate email within the Excel file
                            if (email != null)
                            {
                                if (uniqueEmails.Contains(email))
                                    rowErrors.Add("Duplicate Email within the Excel file.");
                                else
                                    // Add the email to the HashSet to track uniqueness
                                    uniqueEmails.Add(email);
                            }
                        }
                        if (string.IsNullOrWhiteSpace(phone) || !IsValidPhoneNumber(phone))
                        {
                            if (string.IsNullOrWhiteSpace(phone))
                            {
                                rowErrors.Add("Null in Phone column");
                            }
                            else
                                rowErrors.Add("Invalid data in Phone column");
                        }
                        if (string.IsNullOrWhiteSpace(address) || address.Length > 200)
                        {
                            if (string.IsNullOrWhiteSpace(address)) rowErrors.Add("Null in Address column");
                            else rowErrors.Add("Invalid data in Address column");
                        }
                        if (string.Equals(address, "NULL", StringComparison.OrdinalIgnoreCase)) rowErrors.Add("Address column cannot be 'NULL'.");
                        if (rowErrors.Count > 0)
                        {
                            string errorMessage = $"Errors in line {row}: {string.Join(", ", rowErrors)}";
                            errorlist.Add(errorMessage);
                        }
                    }
                    if (errorlist.Count > 0)
                    {
                        string errorMessage = "The following errors occurred during upload:\n" +
                                              string.Join("\n", errorlist);
                        MessageBox.Show(errorMessage, "Customer Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        CustomerEntity customerEntity = new CustomerEntity();
                        for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                        {
                            customerEntity.name = worksheet.Cells[row, 1].Value.ToString();
                            customerEntity.email = worksheet.Cells[row, 2].Value?.ToString();
                            customerEntity.phone = worksheet.Cells[row, 3].Value?.ToString();
                            customerEntity.address = worksheet.Cells[row, 4].Value?.ToString();
                            customerEntity.created_staff_id = LoginStaffID;
                            customerEntity.updated_staff_id = LoginStaffID;
                            customerEntity.created_datetime = DateTime.Now;
                            customerEntity.updated_datetime = DateTime.Now;
                            customerService.Insert(customerEntity);
                        }
                        MessageBox.Show("Customer Data Uploaded successfully!", "Success Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGrid();
                        dgvUserList.Refresh();
                    }
                }
            }
        }
        /// <summary>
        /// Email Validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool TestEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$");
            Match match = reg.Match(email);
            return match.Success;
        }
        private bool AreColumnNamesMatching(List<string> expectedColumnNames, List<string> headerColumnNames)
        {
            // Check if the number of columns match first
            if (expectedColumnNames.Count != headerColumnNames.Count)
            {
                return false;
            }

            // Check if each column name matches
            for (int i = 0; i < expectedColumnNames.Count; i++)
            {
                if (!string.Equals(expectedColumnNames[i], headerColumnNames[i], StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            // All column names match
            return true;
        }
        /// <summary>
        /// check Phone Nubmer
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string strpattern = @"^(09|9)[0-9 \-\(\)\.]*$";

            if (Regex.IsMatch(phoneNumber, strpattern) && phoneNumber.Count(char.IsDigit) > 10 && phoneNumber.Count(char.IsDigit) < 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Last Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            BindGrid();
            UpdateNavigationButtons();
        }
        /// <summary>
        /// First Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            BindGrid();
            UpdateNavigationButtons();
        }
        /// <summary>
        /// Download Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "Customer Data.xlsx"
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
                    DataTable dataToExport = customerService.GetWithName();
                    ExportDataTableToExcel(dataToExport, filePath);
                }

                MessageBox.Show("Excel file downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Prevent entering single quote
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
        /// <summary>
        /// Export Data to Excel file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        private void ExportDataTableToExcel(DataTable data, string filePath)
        {
            // List of column names to exclude from the export
            List<string> columnsToExclude = new List<string>
    {
        "RowNum",
        "customer_id"
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

            // Create an ExcelPackage and export the modified DataTable
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("CustomerList");

            // Set custom header names for the Excel columns
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Email";
            worksheet.Cells[1, 3].Value = "Phone";
            worksheet.Cells[1, 4].Value = "Address";
            worksheet.Cells["A2"].LoadFromDataTable(exportData, false);

            // Auto-fit columns
            worksheet.Cells.AutoFitColumns();
            package.SaveAs(new FileInfo(filePath));
        }
        /// <summary>
        /// Add button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnADD_Click(object sender, EventArgs e)
        {
            UCCustomer uCCustomer = new UCCustomer();
            this.Controls.Clear();
            this.Controls.Add(uCCustomer);
        }
        /// <summary>
        /// Bind Data to Datagridview
        /// </summary>
        private void BindGrid()
        {
            DataTable dt = new DataTable();
            if (filteredDt != null)
            {
                dt = filteredDt;
            }
            else
            {
                dt = customerService.GetWithName();
            }

            int totalItems = dt.Rows.Count;
            if (totalItems != 0)
            {
                totalPages = (int)Math.Ceiling((double)totalItems / rowsPerPage);
                if (currentPage < 1)
                    currentPage = 1;
                else if (currentPage > totalPages)
                    currentPage = totalPages;
                DataTable paginatedDt = GetPaginatedData(dt);
                dgvUserList.DataSource = paginatedDt;
                lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
            }
        }
        /// <summary>     
        /// Get Login Staff ID
        /// </summary>
        /// <param name="login_id"></param>
        public void SetLoginID(int login_id)
        {
            LoginStaffID = login_id;
        }
    }
}