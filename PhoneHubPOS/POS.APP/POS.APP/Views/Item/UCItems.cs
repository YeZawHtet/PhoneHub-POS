using POS.APP.Views.Category;
using POS.Entities.Item;
using POS.Entities.Stock;
using POS.Services.Category;
using POS.Services.Item;
using POS.Services.Stock;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.APP.Views.Item
{
    public partial class UCItems : UserControl
    {
        // Property to set the item ID
        public string itemId
        { set { hdItemId.Text = value; } }

        // Property to store the login ID
        public int LoginID
        { get; set; }

        // Initialize services and variables
        ItemService itemService = new ItemService();
        CategorySercive categorySercive = new CategorySercive();
        StockService stockService = new StockService();
        private int selectedCategoryId;
        public UCItems(int staffid)
        {
            InitializeComponent();
            this.LoginID = staffid;
        }

        // Event handler for the "Back" button click
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Go back to Item List View
            UCItemList ucItemList = new UCItemList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucItemList);
        }

        // Event handler for the UCItems load
        private void UCItem_Load(object sender, EventArgs e)
        {
            BindData();
            BtnControl();
        }

        // Control button on Add New or Update
        private void BtnControl()
        {
            if (String.IsNullOrEmpty(hdItemId.Text))
            {
                btnAdd.Text = "Add New";
                btnDelete.Enabled = false;
                btnClear.Enabled = true;
            }
            else
            {
                btnAdd.Text = "Update";
                btnDelete.Enabled = true;
                btnClear.Enabled = false;
            }
        }

        // Bind data to the form
        private void BindData()
        {
            DataTable dtCategory = categorySercive.GetData();
            cboCategoty.DataSource = dtCategory;
            cboCategoty.DisplayMember = "name";
            cboCategoty.ValueMember = "category_id";

            if (!String.IsNullOrEmpty(hdItemId.Text))
            {
                DataTable dt = itemService.Get(Convert.ToInt32(hdItemId.Text));
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["name"].ToString();
                    txtDescription.Text = dt.Rows[0]["description"].ToString();
                    txtPrice.Text = dt.Rows[0]["price"].ToString();
                    cboCategoty.SelectedValue = dt.Rows[0]["category_id"].ToString();
                }
            }
        }

        // Event handler for the "Add" button click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            };
            AddorUpdate();
        }


        // Validate user inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Length > 100)
            {
                MessageBox.Show("Please enter a valid name (100 words limit).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0 || txtPrice.Text.Length > 15)
            {
                MessageBox.Show("Please enter a valid price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }
            if (txtDescription.Text.Length > 200)
            {
                txtDescription.Focus();
                MessageBox.Show("Please enter a valid description (200 characters limit!).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboCategoty.SelectedIndex == -1)
            {
                cboCategoty.Focus();
                MessageBox.Show("Please select a category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Add or update item data
        private void AddorUpdate()
        {
            ItemService itemService = new ItemService();
            ItemEntity itemEntity = CreateData();
            bool success = false;

            if (String.IsNullOrEmpty(hdItemId.Text))
            {
                success = itemService.Insert(itemEntity);

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
                if (success)
                {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                }
            }
            else
            {
                success = itemService.Update(itemEntity);
                if (success)
                {
                    MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK);
                }
            }
            UCItemList ucItemList = new UCItemList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucItemList);
        }


        // Create an ItemEntity object from form data
        private ItemEntity CreateData()
        {
            ItemEntity itemEntity = new ItemEntity();

            if (!String.IsNullOrEmpty(hdItemId.Text))
            {
                itemEntity.itemId = Convert.ToInt32(hdItemId.Text);
                itemEntity.name = txtName.Text;
                itemEntity.description = txtDescription.Text;
                itemEntity.price = Convert.ToDecimal(txtPrice.Text);
                itemEntity.categoryId = selectedCategoryId;
                itemEntity.updatedDatetime = DateTime.Now;
                itemEntity.updatedStaffId = LoginID; 
            }
            else
            {
                itemEntity.name = txtName.Text;
                itemEntity.description = txtDescription.Text;
                itemEntity.price = Convert.ToDecimal(txtPrice.Text);
                itemEntity.categoryId = selectedCategoryId;
                itemEntity.createdStaffId = LoginID;
                itemEntity.createdDatetime = DateTime.Now;
                itemEntity.updatedStaffId = LoginID;
                itemEntity.updatedDatetime = DateTime.Now;
            }

            return itemEntity;
        }


        // Event handler for the category selection change
        private void cboCategoty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cboCategoty.SelectedItem as DataRowView;
            selectedCategoryId = Convert.ToInt32(selectedRow["category_id"]);
        }

        // Event handler for the "Delete" button click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete stock
            stockService.Delete(Convert.ToInt32(hdItemId.Text));
            //delete item
            bool success = itemService.Delete(Convert.ToInt32(hdItemId.Text));
            if (success)
            {
                MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK);
            }
            UCItemList ucItemList = new UCItemList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucItemList);
        }

        // Event handler for the "EditCategory" button click
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            // Go to Category List view
            UCCategoryList ucCategoryList = new UCCategoryList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucCategoryList);
        }

        // Event handler for the "Clear" button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear textboxs
            txtName.Text= string.Empty;
            txtDescription.Text= string.Empty;
            txtPrice.Text= string.Empty;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }
    }
}
