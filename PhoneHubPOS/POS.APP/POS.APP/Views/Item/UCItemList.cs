using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using POS.Services.Item;
using OfficeOpenXml;
using POS.Services.Category;
using POS.Entities.Item;
using POS.Entities.Stock;
using POS.Services.Stock;
using System.Globalization;

namespace POS.APP.Views.Item
{
    public partial class UCItemList : UserControl
    {
        private ItemService itemService = new ItemService();
        private CategorySercive categorySercive = new CategorySercive();
        private StockService stockService = new StockService();

        // Pagination variables
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private int totalPages;
        private DataTable filteredDt = null;

        // Public property to store the Login ID
        public int LoginID
        { get; set; }
        public UCItemList(int id)
        {
            InitializeComponent();
            this.LoginID = id;
        }

        // Event handler for the UCItemList load
        private void UCItemList_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        // Method to bind data to the grid
        private void BindGrid()
        {
            DataTable dt = itemService.GetWithName();
            int totalItems = dt.Rows.Count;
            if (totalItems != 0)
            {
                totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                if (currentPage < 1)
                    currentPage = 1;
                else if (currentPage > totalPages)
                    currentPage = totalPages;
                DataTable paginatedDt = GetPaginatedData(dt);
                dgvItemList.DataSource = paginatedDt;
                dgvItemList.CellFormatting += dgvItemList_CellFormatting;
                lblPageNumber.Text = $"Page {currentPage} of {totalPages}";

                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;

                btnFirst.Enabled = currentPage > 1;
                btnLast.Enabled = currentPage < totalPages;
            }
            txtSearch.Text = "";
            DataView dv = dt.DefaultView;
            dv.RowFilter = "";
            filteredDt = null;
        }

        // Method to update the "No." column values in a DataTable
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

        // Method to retrieve paginated data from datatable
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
        // Event handler for Cell Content click for dgvItemList
        private void dgvItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int itemId = Convert.ToInt32(dgvItemList.Rows[e.RowIndex].Cells["gcItemId"].Value);
                if (e.ColumnIndex == dgvItemList.Columns["gcNo"].Index)
                {
                    UCItems ucItem = new UCItems(LoginID);
                    ucItem.itemId = itemId.ToString();
                    this.Controls.Clear();
                    this.Controls.Add(ucItem);
                }
            }
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
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = "ItemList.xlsx"
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
                        dataToExport = ModifyDataTableForExport(itemService.GetWithName());
                    }

                    // Create an Excel package and worksheet
                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ItemList");
                    worksheet.Cells.LoadFromDataTable(dataToExport, true);

                    // Adjust column widths based on content length
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

        // Method to modify DataTable for export to Excel
        private DataTable ModifyDataTableForExport(DataTable inputTable)
        {
            DataTable modifiedTable = inputTable.Clone();

            modifiedTable.Columns["RowNum"].ColumnName = "No.";
            modifiedTable.Columns["name"].ColumnName = "Name";
            modifiedTable.Columns["description"].ColumnName = "Description";
            modifiedTable.Columns["price"].ColumnName = "Price";
            modifiedTable.Columns["category_name"].ColumnName = "Category";
            modifiedTable.Columns.Remove("item_id");
            modifiedTable.Columns.Remove("quantity");
            int rowNum = 1;

            foreach (DataRow row in inputTable.Rows)
            {
                DataRow newRow = modifiedTable.NewRow();
                newRow["No."] = rowNum++;
                newRow["Name"] = row["name"];
                newRow["Description"] = row["description"];
                newRow["Price"] = row["price"];
                newRow["Category"] = row["category_name"];
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
                        string price = worksheet.Cells[row, 4].Value?.ToString();
                        string categoryName = worksheet.Cells[row, 5].Value?.ToString();
                        
                        int categoryId = -1;
                        DataTable categoryTable = categorySercive.GetAll();
                        foreach (DataRow dataRow in categoryTable.Rows)
                        {
                            if (dataRow["name"].ToString() == categoryName)
                            {
                                categoryId = Convert.ToInt32(dataRow["category_id"]);
                                break;
                            }
                        }

                        // Check Validation for upload excel file 
                        bool isValid = true;
                        string errorMessage = $"Errors in line {row}\n";

                        if (string.IsNullOrWhiteSpace(description) || description.Length > 200)
                        {
                            isValid = false;
                            errorMessage += "> Invalid Data in description column\n";
                        }

                        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
                        {
                            isValid = false;
                            errorMessage += "> Invalid Data in Name column\n\n";
                        }

                        if (!decimal.TryParse(price, out decimal Price) || Price <= 0)
                        {
                            isValid = false;
                            errorMessage += "> Invalid Price number.\n";
                        }

                        if (categoryId == -1)
                        {
                            isValid = false;
                            errorMessage += "> Invalid category name.\n";
                        }

                        int existItem = itemService.GetItemCount(name, categoryId);
                        if(existItem > 0)
                        {
                            isValid = false;
                            errorMessage += "> The input item is already exist.\n";
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
                        // Create Entitis for Input
                        ItemEntity itemEntity = new ItemEntity();
                        for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                        {

                            itemEntity.name = worksheet.Cells[row, 2].Value.ToString();
                            itemEntity.description = worksheet.Cells[row, 3].Value?.ToString();
                            itemEntity.price = Convert.ToDecimal(worksheet.Cells[row, 4].Value?.ToString());
                            string categoryName = worksheet.Cells[row, 5].Value?.ToString();
                            itemEntity.createdStaffId = LoginID;
                            itemEntity.updatedStaffId = LoginID;
                            itemEntity.createdDatetime = DateTime.Now;
                            itemEntity.updatedDatetime = DateTime.Now;
                            DataTable categoryTable = categorySercive.GetAll();
                            foreach (DataRow dataRow in categoryTable.Rows)
                            {
                                if (dataRow["name"].ToString() == categoryName)
                                {
                                    itemEntity.categoryId = Convert.ToInt32(dataRow["category_id"]);
                                    break;
                                }
                            }

                            // Insert Item
                            itemService.Insert(itemEntity);

                            int itemID;
                            //Get Last Add Item
                            itemID = itemService.GetLastItem();
                            StockEntity stockEntity = new StockEntity();
                            stockEntity.item_id = itemID;
                            stockEntity.quantity = 0;
                            stockEntity.created_staff_id = LoginID;
                            stockEntity.updated_staff_id = LoginID;
                            stockEntity.created_datetime = DateTime.Now;
                            stockEntity.updated_datetime = DateTime.Now;

                            //Add Stock
                            stockService.Insert(stockEntity);
                        }

                        MessageBox.Show("Uploaded successfully!");
                        BindGrid();
                    }
                }
            }
        }

       

        // Event handler for the "Clear" button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        // Event handler for the "TextChanged" event of the search text box
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Count() > 40)
            {
                MessageBox.Show("Please Enter correct item name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Clear();
            }
            string searchKeyword = txtSearch.Text.Trim();

            DataTable dt = itemService.GetWithName();
            DataView dv = dt.DefaultView;

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                dv.RowFilter = $"name LIKE '%{searchKeyword}%' " +
                               $"OR description LIKE '%{searchKeyword}%' " +
                               $"OR CONVERT(price, 'System.String') LIKE '%{searchKeyword}%' " +
                               $"OR CONVERT(quantity, 'System.String') LIKE '%{searchKeyword}%' " +
                               $"OR category_name LIKE '%{searchKeyword}%'";

            }

            int totalItems = dv.Count;
            totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            currentPage = 1;
            filteredDt = dv.ToTable();
            UpdateRowNumColumn(filteredDt);
            DataTable paginatedDt = GetPaginatedData(filteredDt);
            dgvItemList.DataSource = paginatedDt;
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

        // Event handler for the "CellDoubleClick" event of the DataGridView
        private void dgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int itemId = Convert.ToInt32(dgvItemList.Rows[e.RowIndex].Cells["gcItemId"].Value);

                UCItems ucItem = new UCItems(LoginID);
                ucItem.itemId = itemId.ToString();
                this.Controls.Clear();
                this.Controls.Add(ucItem);
            }
        }

        // Event handler for text input in the search textbox to prevent the input'
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                e.Handled = true;
            }
        }

        // Event handler for cell formatting in data grip view to change price format
        private void dgvItemList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvItemList.Columns[e.ColumnIndex].Name == "price")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal numericValue))
                {
                    e.Value = numericValue.ToString("N0", CultureInfo.InvariantCulture);
                    e.FormattingApplied = true; 
                }
            }
        }
        // Event handler for the "Last" button click
        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            currentPage = 1;
            BindGrid();
        }

        // Event handler for the "Last" button click
        private void btnLast_Click_1(object sender, EventArgs e)
        {
            currentPage = totalPages;
            BindGrid();
        }


        // Event handler for the "Add" button click
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            UCItems ucItem = new UCItems(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucItem);
        }

    }
}
