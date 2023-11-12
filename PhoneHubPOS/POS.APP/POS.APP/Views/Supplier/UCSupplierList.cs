using OfficeOpenXml;
using POS.Entities.Supplier;
using POS.Services.Staff;
using POS.Services.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.APP.Views.Supplier
{
    public partial class UCSupplierList : UserControl
    {
        private SupplierService supplierService = new SupplierService();
        private int LoginStaffID, currentPage = 1, totalPages, rowsPerPage = 10, totalRecords, first, last;
        private int totalSearchRecords, searchtotalPages;
        private int currentSearchPage = 1;

        public UCSupplierList(int login_id)
        {
            InitializeComponent();
            LoginStaffID = login_id;
        }

        private void UCSupplierList_Load(object sender, EventArgs e)
        {
            lblOne.Text = "1";
            page_load();
        }

        private void page_load()
        {
            totalRecords = supplierService.GetSupplierCount();
            getNumberOfRecords();
            BindGrid();
            UpdateButtons();
            UpdateLabelTwo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            lblOne.Text = "1";
            page_load();

        }

        private void PerformSearch()
        {
            string searchValue = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue))
            {
                totalSearchRecords = supplierService.GetSearchData(searchValue);

                if (totalSearchRecords > 0)
                {
                    lblOne.Text = "1";
                    currentSearchPage = 1;
                    searchgetNumberOfRecords(); 
                    SearchBindGrid();
                    UpdateLabelTwo();
                    UpdateButtons();
                }
                else if (totalSearchRecords == 0)
                {
                    lblOne.Text = "0";
                    lblTwo.Text = "0";
                    currentSearchPage = 0;
                    searchgetNumberOfRecords();
                    SearchBindGrid();
                    UpdateLabelTwo();
                    UpdateButtons();
                }
            }
            else
            {
                lblOne.Text = "1";
                BindGrid();
                currentPage = 1;
                currentSearchPage = 1; 
                searchtotalPages = 0;
                UpdateLabelTwo(); 
                UpdateButtons(); 
            }
        }

        public void searchgetNumberOfRecords()
        {
            int numOfRows = supplierService.GetSearchData(txtSearch.Text.Trim());
            totalPages = (int)Math.Ceiling((double)numOfRows / rowsPerPage);
            lblTwo.Text = totalPages.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                lblOne.Text = currentPage.ToString();
                if (txtSearch.Text == "")
                {
                    BindGrid();
                }
                else
                {
                    SearchBindGrid();
                }
            }
            UpdateButtons();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                lblOne.Text = currentPage.ToString();
                if (txtSearch.Text == "")
                {
                    BindGrid();
                }
                else
                {
                    SearchBindGrid();
                }
            }
            UpdateButtons();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            UCSupplier ucSupplier = new UCSupplier(LoginStaffID);
            this.Controls.Clear();
            this.Controls.Add(ucSupplier);
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = Convert.ToInt32(dgvSupplier.CurrentRow.Cells["supplierID"].Value);
            if (e.RowIndex > -1)
            {
                UCSupplier ucUser = new UCSupplier(LoginStaffID);
                ucUser.ID = Convert.ToInt32(dgvSupplier.CurrentRow.Cells["supplierID"].Value);
                this.Controls.Clear();
                this.Controls.Add(ucUser);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Back)
            {
                lblOne.Text = "1";
                page_load();
                e.Handled = true;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = (searchtotalPages > 0) ? searchtotalPages : totalPages;
            lblOne.Text = currentPage.ToString();
            if (txtSearch.Text == "")
            {
                BindGrid();
            }
            else
            {
                SearchBindGrid();
            }
            UpdateButtons();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            lblOne.Text = currentPage.ToString();
            if (txtSearch.Text == "")
            {
                BindGrid();
            }
            else
            {
                SearchBindGrid();
            }
            UpdateButtons();
        }

        public void getNumberOfRecords()
        {
            int numOfRows = supplierService.GetSupplierCount();
            totalPages = (int)Math.Ceiling((double)numOfRows / rowsPerPage);
            lblTwo.Text = totalPages.ToString();
        }

        private DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SerialNumber", typeof(int));
            dataTable.Columns.Add("supplier_id", typeof(int));
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("phone", typeof(string));
            dataTable.Columns.Add("email", typeof(string));
            dataTable.Columns.Add("address", typeof(string));
            return dataTable;
        }

        private void InsertToDataTable
            (DataTable dataTable, DataTable dt, int first)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int supplierID = Convert.ToInt32(dt.Rows[i]["supplier_id"]);
                string supplier_name = Convert.ToString(dt.Rows[i]["name"]);
                string supplier_phone = Convert.ToString(dt.Rows[i]["phone"]);
                string supplier_email = Convert.ToString(dt.Rows[i]["email"]);
                string supplier_address = Convert.ToString(dt.Rows[i]["address"]);
                int serialNumber = first + i;

                dataTable.Rows.Add(serialNumber, supplierID, supplier_name, supplier_phone, supplier_email, supplier_address);
            }
        }

        public void BindGrid()
        {
            first = (currentPage - 1) * rowsPerPage + 1;
            last = Math.Min(currentPage * rowsPerPage, totalRecords);

            DataTable dataTable = CreateDataTable();
            DataTable dt = supplierService.GetRowNumber(first, last);
            InsertToDataTable(dataTable, dt, first);

            dgvSupplier.DataSource = dataTable;
        }

        public void SearchBindGrid()
        {
            first = (currentPage - 1) * rowsPerPage + 1;
            last = Math.Min(currentPage * rowsPerPage, totalSearchRecords);

            DataTable dataTable = CreateDataTable();
            DataTable dt = supplierService.GetSearchDataWithPage(txtSearch.Text.Trim(), first, last);
            InsertToDataTable(dataTable, dt, first);

            dgvSupplier.DataSource = dataTable;
        }

        private void UpdateButtons()
        {
            if (searchtotalPages > 0)
            {
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < searchtotalPages;
                btnFirst.Enabled = currentPage > 1;
                btnLast.Enabled = currentPage < searchtotalPages;
            }
            else
            {
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
                btnFirst.Enabled = currentPage > 1;
                btnLast.Enabled = currentPage < totalPages;
            }
        }

        private void UpdateLabelTwo()
        {
            lblTwo.Text = (searchtotalPages > 0) ? searchtotalPages.ToString() : totalPages.ToString();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("No.", typeof(int));
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Phone", typeof(string));
                    dataTable.Columns.Add("Email", typeof(string));
                    dataTable.Columns.Add("Address", typeof(string));
                    DataTable dt = (txtSearch.Text == "") ? supplierService.GetAll() : supplierService.GetSearchDataWithAll(txtSearch.Text.Trim());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string supplier_name = Convert.ToString(dt.Rows[i]["name"]);
                        string supplier_phone = Convert.ToString(dt.Rows[i]["phone"]);
                        string supplier_email = Convert.ToString(dt.Rows[i]["email"]);
                        string supplier_address = Convert.ToString(dt.Rows[i]["address"]);
                        int serialNumber = i + 1;
                        dataTable.Rows.Add(serialNumber, supplier_name, supplier_phone, supplier_email, supplier_address);
                    }
                    ExportAllDataToExcel(filePath, dataTable);
                    MessageBox.Show("Downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ExportAllDataToExcel(string filePath, DataTable allData)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells["A1"].LoadFromDataTable(allData, true);
                for (int i = 1; i <= worksheet.Dimension.End.Column; i++)
                {
                    worksheet.Column(i).AutoFit();
                }
                package.SaveAs(new FileInfo(filePath));
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    if (ValidateExcel(filePath, out List<string> errorList))
                    {
                        InsertData(filePath);
                        MessageBox.Show("Uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        page_load();
                    }
                    else
                    {
                        string errorMessage = string.Join("\n", errorList);
                        MessageBox.Show(errorMessage, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool ValidateExcel(string filePath, out List<string> errorList)
        {
            errorList = new List<string>();

            try
            {
                using (var excelPackage = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.First();
                    if (!IsValidWorksheet(worksheet, out string errorMessage))
                    {
                        errorList.Add(errorMessage);
                        return false;
                    }
                    if (!IsValidHeader(worksheet, out errorMessage))
                    {
                        errorList.Add(errorMessage);
                        return false;
                    }
                    if (!ValidateData(worksheet, out errorList))
                    {
                        errorList.Add(errorMessage);
                        return false;
                    }
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorList.Add("An error occurred: " + ex.Message);
                return false;
            }
        }

        private bool IsValidWorksheet(ExcelWorksheet worksheet, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (worksheet.Dimension == null || worksheet.Dimension.End.Row < 2)
            {
                errorMessage = "Excelsheet is empty and does not contain data.";
                return false;
            }

            return true;
        }

        private bool IsValidHeader(ExcelWorksheet worksheet, out string errorMessage)
        {
            errorMessage = string.Empty;
            var columnHeaders = GetColumnHeaders();
            var headerRow = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
            foreach (var columnHeader in columnHeaders)
            {
                var matchingCell = headerRow.FirstOrDefault(cell => cell.Text.Equals(columnHeader, StringComparison.OrdinalIgnoreCase));
                if (matchingCell == null)
                {
                    errorMessage = $"Excelsheet is missing the column header: {columnHeader}.";
                    return false;
                }
            }
            return true;
        }

        private List<string> GetColumnHeaders()
        {
            List<string> columnHeaders = new List<string>
                    {
                        "No.",
                        "Name",
                        "Phone Number",
                        "Email",
                        "Address"
                    };
            return columnHeaders;
        }

        private void InsertData(string filePath)
        {

            SupplierService supplierService = new SupplierService();
            using (var excelPackage = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = excelPackage.Workbook.Worksheets.First();
                for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    SupplierEntity supplierEntity = new SupplierEntity();
                    supplierEntity.name = worksheet.Cells[row, 2].Value?.ToString();
                    string phone = worksheet.Cells[row, 3].Value.ToString();
                    if (phone.Length > 0 && phone[0] != '0')
                    {
                        phone = "0" + phone;
                    }
                    supplierEntity.phone = phone;
                    supplierEntity.email = worksheet.Cells[row, 4].Value?.ToString();
                    supplierEntity.address = worksheet.Cells[row, 5].Value?.ToString();
                    supplierEntity.createdStaffId = LoginStaffID;
                    supplierEntity.updatedStaffId = LoginStaffID;
                    supplierEntity.createdDatetime = DateTime.Now;
                    supplierEntity.updatedDatetime = DateTime.Now;
                    try
                    {
                        supplierService.Insert(supplierEntity);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting data for row {row}: {ex.Message}", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
        }

        private bool ValidateData(ExcelWorksheet worksheet, out List<string> errorList)
        {
            errorList = new List<string>();
            int totalRows = worksheet.Dimension.End.Row;

            for (int row = worksheet.Dimension.Start.Row + 1; row <= totalRows; row++)
            {
                string name = worksheet.Cells[row, 2].Value?.ToString();
                string phone = worksheet.Cells[row, 3].Value?.ToString();
                string email = worksheet.Cells[row, 4].Value?.ToString();
                string address = worksheet.Cells[row, 5].Value?.ToString();

                List<string> rowErrors = new List<string>();

                if (string.IsNullOrWhiteSpace(name) || name.Length > 30)
                {
                    rowErrors.Add($"Invalid data in row {row}, (Name)");
                }

                if (string.IsNullOrWhiteSpace(email) || email.Length > 30 || !TestEmail(email))
                {
                    rowErrors.Add($"Invalid data in row {row}, (Email)");
                }

                if (string.IsNullOrWhiteSpace(phone) || phone.Length <= 0 || phone.Length < 10 || phone.Length > 12 || !phone.All(char.IsDigit) || !IsValidPhoneNumber(phone))
                {
                    rowErrors.Add($"Invalid data in row {row}, (Phone)");
                }

                if (string.IsNullOrWhiteSpace(address))
                {
                    rowErrors.Add($"Invalid data in row {row}, (Address)");
                }
                else if (address.Length > 225)
                {
                    rowErrors.Add($"Invalid data in row {row}, (Address). Maximum length exceeded.");
                }
                int isExistName;
                if (name.Contains(" "))
                {
                    isExistName = supplierService.GetNameCount(name.Replace(" ", ""));
                }
                else
                {
                    isExistName = supplierService.GetNameCount(name);
                }
                if (isExistName > 0)
                {
                    rowErrors.Add($"The name in row {row} {name} already exists in the database.");
                }
                int isExistEmail = supplierService.GetSupplierCount(email);
                if (isExistEmail > 0)
                {
                    rowErrors.Add($"The email in row {row} {email} already exists in the database.");
                }

                if (rowErrors.Count > 0)
                {
                    errorList.AddRange(rowErrors);
                }
            }

            return errorList.Count == 0;
        }

        private bool TestEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$");
            Match match = reg.Match(email);
            return match.Success;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string strpattern = @"^[0|9][0-9 \-\(\)\.]*[1-9][0-9 \-\(\)\.]*$";

            if (Regex.IsMatch(phoneNumber, strpattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

