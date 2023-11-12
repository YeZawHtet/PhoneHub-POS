using POS.Entities.Category;
using POS.Services.Category;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.APP.Views.Category
{
    public partial class UCCategory : UserControl
    {
        /// <summary>
        /// Gets or sets the login ID of the user.
        /// </summary>
        public int LoginID
        { get; set; }

        /// <summary>
        /// Sets the category ID for this control.
        /// </summary>
        public string categoryId
        { set { hdCategoryId.Text = value; } }

        CategorySercive categorySercive = new CategorySercive();
        public UCCategory(int id)
        {
            InitializeComponent();
            this.LoginID = id;
        }

        // Event handler for the "Add" button click.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate user inputs
            if (!ValidateInputs())
            {
                return;  
            };
            // Call the AddorUpdate method to add or update a category
            AddorUpdate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UCCategoryList ucCategoryList = new UCCategoryList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucCategoryList);  // back to the category list view.
        }

        //UCCategory user control load
        private void UCCategory_Load(object sender, EventArgs e)
        {
            BindData();
            BtnControl();
        }

        // Method to control button states 
        private void BtnControl()
        {
            if (String.IsNullOrEmpty(hdCategoryId.Text))
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

        // Method to bind UI elements with category data
        private void BindData()
        {
            if (!String.IsNullOrEmpty(hdCategoryId.Text))
            {
                DataTable dt = categorySercive.Get(Convert.ToInt32(hdCategoryId.Text));
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["name"].ToString();
                    txtDescription.Text = dt.Rows[0]["description"].ToString();
                }
            }
        }

        // Method to validate user inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Length > 100)
            {
                MessageBox.Show("Please enter a valid name (100 words limit).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtDescription.Text.Length > 200)
            {
                txtDescription.Focus();
                MessageBox.Show("Please enter a valid description (200 characters limit!).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Method to add or update a category
        private void AddorUpdate()
        {
            // Create a CategoryEntity object with user input data
            CategoryEntity categoryEntity = CreateData();
            bool success = false;

            // Check if it's an add or update operation
            if (String.IsNullOrEmpty(hdCategoryId.Text))
            {
                // Check if the category name already exists
                int itemCount = categorySercive.GetItemCount(txtName.Text);
                if (itemCount > 0)
                {
                    MessageBox.Show("Sorry, but the category you're trying to add already exists in the database. Please choose a different category name or update the existing one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
                else
                {
                    // Insert the new category
                    success = categorySercive.Insert(categoryEntity);
                    if (success)
                    {
                        MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                // Update the category data
                success = categorySercive.Update(categoryEntity);
                if (success)
                {
                    MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK);
                }
            }

            //Go back to UCCategoryList
            UCCategoryList ucCategoryList = new UCCategoryList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucCategoryList);
        }

        // Method to create a CategoryEntity object from user input
        private CategoryEntity CreateData()
        {
            CategoryEntity categoryEntity = new CategoryEntity();
            if (!String.IsNullOrEmpty(hdCategoryId.Text))
            {
                // For updates
                categoryEntity.categoryId = Convert.ToInt32(hdCategoryId.Text);
                categoryEntity.name = txtName.Text;
                categoryEntity.description = txtDescription.Text;
                categoryEntity.updatedDatetime = DateTime.Now;
                categoryEntity.updatedStaffId = LoginID;
            }
            else
            {
                // For New
                categoryEntity.name = txtName.Text;
                categoryEntity.description = txtDescription.Text;
                categoryEntity.createdStaffId = LoginID;
                categoryEntity.createdDatetime = DateTime.Now;
                categoryEntity.updatedStaffId = LoginID;
                categoryEntity.updatedDatetime = DateTime.Now;
            }
            return categoryEntity;
        }

        // Event handler for the "Delete" button click.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete the category 
            bool success = categorySercive.Delete(Convert.ToInt32(hdCategoryId.Text));
            if (success)
            {
                MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK);
            }

            //Go back to UCCategoryList
            UCCategoryList ucCategoryList = new UCCategoryList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucCategoryList);
        }

        // Event handler for the "Clear" button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the text fields
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}