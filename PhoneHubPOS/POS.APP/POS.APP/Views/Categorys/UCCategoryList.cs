using OfficeOpenXml;
using POS.APP.Views.Item;
using POS.Entities.Category;
using POS.Services.Category;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS.APP.Views.Category
{
    public partial class UCCategoryList : UserControl
    {
        // Public property to store the Login ID
        public int LoginID
        { get; set; }

        private CategorySercive categorySercive = new CategorySercive();

        //variables for pagination
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private int totalPages;
        private DataTable filteredDt = null;
        public UCCategoryList(int id)
        {
            InitializeComponent();
            this.LoginID = id;
        }

        // Event handler for the "Add" button click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // back to the UCCategory .
            UCCategory uccategory = new UCCategory(LoginID);
            this.Controls.Clear();
            this.Controls.Add(uccategory);
        }

        //UCCategoryList user control load
        private void UCCategoryList_Load(object sender, EventArgs e)
        {
            // Bind data to the grid
            BindGrid();
        }

        // Method to bind data to the grid
        private void BindGrid()
        {
            // Retrieve category data
            DataTable dt = categorySercive.GetWithName();
            int totalItems = dt.Rows.Count;
            if (totalItems != 0)
            {
                // Calculate total pages for pagination
                totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                if (currentPage < 1)
                    currentPage = 1;
                else if (currentPage > totalPages)
                    currentPage = totalPages;

                // Get paginated data and bind it to the DataGridView
                DataTable paginatedDt = GetPaginatedData(dt);
                dgvCategory.DataSource = paginatedDt;
                lblPageNumber.Text = $"Page {currentPage} of {totalPages}";

                // Enable or disable pagination buttons
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
                btnFirst.Enabled = currentPage > 1;
                btnLast.Enabled = currentPage < totalPages;
            }
            // Clear the search textbox and filtered data
            txtSearch.Text = "";
            DataView dv = dt.DefaultView;
            dv.RowFilter = "";
            filteredDt = null;
        }

        // Method to retrieve paginated data from DataTable
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

        // Event handler for the "Download" button click
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                // Open a SaveFileDialog to choose the Excel file save location
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = "CategoryList.xlsx"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    DataTable dataToExport = new DataTable();

                    // Check if a search filter is applied
                    if (txtSearch.Text != "")
                    {
                        dataToExport = ModifyDataTableForExport(filteredDt);
                    }
                    else
                    {
                        dataToExport = ModifyDataTableForExport(categorySercive.GetWithName());
                    }
                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("CategoryList");
                    worksheet.Cells.LoadFromDataTable(dataToExport, true);
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

                    // Save the Excel file
                    package.SaveAs(new FileInfo(filePath));
                    MessageBox.Show("Excel file downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while downloading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to modify DataTable columns for export
        private DataTable ModifyDataTableForExport(DataTable inputTable)
        {
            DataTable modifiedTable = inputTable.Clone();

            modifiedTable.Columns["RowNum"].ColumnName = "No.";
            modifiedTable.Columns["name"].ColumnName = "Name";
            modifiedTable.Columns["description"].ColumnName = "Description";
            modifiedTable.Columns.Remove("category_id");
            int rowNum = 1;
            foreach (DataRow row in inputTable.Rows)
            {
                DataRow newRow = modifiedTable.NewRow();
                newRow["No."] = rowNum++;
                newRow["Name"] = row["name"];
                newRow["Description"] = row["description"];
                modifiedTable.Rows.Add(newRow);
            }
            return modifiedTable;
        }

        // Event handler for the "Upload" button click
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    List<string> errorlist = new List<string>();
                    for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string name = worksheet.Cells[row, 2].Value?.ToString();
                        string description = worksheet.Cells[row, 3].Value?.ToString();

                        //Check Validation for Excel upload
                        bool isValid = true;
                        string errorMessage = $"Errors in line {row}\n";
                        if (string.IsNullOrWhiteSpace(description) || description.Length > 200)
                        {
                            isValid = false;
                            errorMessage += "> Invalid Data in description column.\n";
                        }
                        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
                        {
                            isValid = false;
                            errorMessage += "> Invalid Data in Name column.\n\n";
                        }
                        int isExist = categorySercive.GetItemCount(name);
                        if (isExist > 0)
                        {
                            isValid = false;
                            errorMessage += "> The category name is already exist.\n\n";
                        }

                        if (!isValid)
                        {
                            errorlist.Add(errorMessage);
                        }
                    }

                    if (errorlist.Count > 0)
                    {
                        string errorMessage = string.Join("\n", errorlist);
                        MessageBox.Show(errorMessage, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Insert valid data into the database
                        CategoryEntity categoryEntity = new CategoryEntity();
                        for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                        {
                            categoryEntity.name = worksheet.Cells[row, 2].Value.ToString();
                            categoryEntity.description = worksheet.Cells[row, 3].Value?.ToString();
                            categoryEntity.createdStaffId = LoginID;
                            categoryEntity.updatedStaffId = LoginID;
                            categoryEntity.createdDatetime = DateTime.Now;
                            categoryEntity.updatedDatetime = DateTime.Now;
                            categorySercive.Insert(categoryEntity);
                        }
                        MessageBox.Show("Uploaded successfully!");
                        BindGrid();
                    }
                }
            }
        }

        // Event handler for cell double click in the DataGridView
        private void dgvCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int categoryId = Convert.ToInt32(dgvCategory.Rows[e.RowIndex].Cells["gcCategoryId"].Value);
                // Go to UCCategory view 
                UCCategory uCCategory = new UCCategory(LoginID);
                uCCategory.categoryId = categoryId.ToString();
                uCCategory.LoginID = LoginID;
                this.Controls.Clear();
                this.Controls.Add(uCCategory);

            }
        }

        // Event handler for text change in the search textbox
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Handle the input text count
            if (txtSearch.Text.Count() > 40)
            {
                MessageBox.Show("Please Enter correct category name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }
            string searchKeyword = txtSearch.Text.Trim();
            DataTable dt = categorySercive.GetWithName();
            DataView dv = dt.DefaultView;

            // Search condition
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                dv.RowFilter = $"name LIKE '%{searchKeyword}%' OR description LIKE '%{searchKeyword}%'";
            }
            dv.Sort = "RowNum ASC";
            int totalItems = dv.Count;
            totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            currentPage = 1;
            filteredDt = dv.ToTable();
            UpdateRowNumColumn(filteredDt);
            DataTable paginatedDt = GetPaginatedData(filteredDt);
            dgvCategory.DataSource = paginatedDt;
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

        // Method to update the "No." column values
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

        // Event handler for the "Clear" button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        // Event handler for the "Back" button click
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Go back to the UCItems view
            this.Controls.Clear();
            UCItems ucItems = new UCItems(LoginID);
            ucItems.LoginID = LoginID;
            this.Controls.Add(ucItems);
        }

        // Event handler for text input in the search textbox to prevent the input'
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                e.Handled = true;
            }
        }
    }
}