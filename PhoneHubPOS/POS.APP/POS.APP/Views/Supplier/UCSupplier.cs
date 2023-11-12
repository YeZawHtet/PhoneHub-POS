using OfficeOpenXml;
using POS.APP.Views.Staff;
using POS.Entities.Supplier;
using POS.Services.Staff;
using POS.Services.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.APP.Views.Supplier
{
    public partial class UCSupplier : UserControl
    {
        SupplierService supplierService = new SupplierService();
        int LoginStaffID;
        private int supplier_id; string validateEmail = "", validateName = "";
        public int ID
        {
            set
            {
                supplier_id = value;
            }
        }

        public UCSupplier(int staff_id)
        {
            InitializeComponent();
            LoginStaffID = staff_id;
        }

        private void UCSupplier_Load(object sender, EventArgs e)
        {
            if (supplier_id != 0)
            {
                btnClear.Enabled = false;
            }
            BtnControl();
            BindData();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please input Information.", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please input Name.", "Required Name ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please input Email.", "Required Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (!TestEmail(txtEmail.Text) || !(txtEmail.Text.EndsWith("@gmail.com")))
            {
                MessageBox.Show("Incorrect Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Text = "";
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text.Length > 11 || !IsValidPhoneNumber(txtPhone.Text) || txtPhone.Text.Length < 11)
            {
                MessageBox.Show("Please input a correct phone number with at least 11 digits.", "Invalid Phone number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Text = "";
                txtPhone.Focus();
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please input Address.", "Required Address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
            }
            else
            {
                int email_count = supplierService.GetSupplierCount(txtEmail.Text.Trim());
                int name_count;
                if (txtName.Text.Contains(" "))
                {
                    name_count = supplierService.GetNameCount(txtName.Text.Replace(" ", ""));
                }
                else
                {
                    name_count = supplierService.GetNameCount(txtName.Text);
                }

                if (name_count >= 1 && btnADD.Text == "Add")
                {
                    MessageBox.Show("Name already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Text = "";
                    txtName.Focus();
                    return;
                }
                if (email_count >= 1 && btnADD.Text == "Add") 
                {
                    MessageBox.Show("The email already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    return;
                }
                AddorUpdate();
            }
        }

        private void AddorUpdate()
        {
            UCSupplierList supplyList = new UCSupplierList(LoginStaffID);
            SupplierEntity supplierEntity = CreateData();
            bool success = false;
            if (supplier_id == 0)
            {
                success = supplierService.Insert(supplierEntity);
                if (success)
                {
                    string Name = txtName.Text;
                    MessageBox.Show($"{Name} has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearData();
            }
            else
            {
                success = supplierService.Update(supplierEntity);
                if (success)
                {
                    MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearData();
            }
            this.Controls.Clear();
            this.Controls.Add(supplyList);
        }

        private SupplierEntity CreateData()
        {
            SupplierEntity supplierEntity = new SupplierEntity(); ;
            if (supplier_id != 0)
            {
                supplierEntity.supplierId = Convert.ToInt32(supplier_id);
                DataTable dt = supplierService.Get(supplier_id);
                if (dt.Rows.Count > 0)
                {
                    validateName = dt.Rows[0]["name"].ToString().Replace(" ", "").ToLower();
                    validateEmail = dt.Rows[0]["email"].ToString();
                }

            }
            if (btnADD.Text == "Update")
            {
                int email_count = supplierService.GetSupplierCount(txtEmail.Text.Trim());
                int name_count;
                if (txtName.Text.Contains(" "))
                {
                    name_count = supplierService.GetNameCount(txtName.Text.Replace(" ", ""));
                }
                else
                {
                    name_count = supplierService.GetNameCount(txtName.Text);
                }

                if (name_count >= 1 && validateName != txtName.Text.Replace(" ", "").ToLower())
                {
                    MessageBox.Show("Already existed StaffName.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Text = "";
                    txtName.Focus();

                }
                if (email_count >= 1 && validateEmail != txtEmail.Text)
                {
                    MessageBox.Show("Already existed Email.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    txtEmail.Focus();
                }
            }
            supplierEntity.name = txtName.Text;
            supplierEntity.email = txtEmail.Text;
            supplierEntity.phone = txtPhone.Text;
            supplierEntity.address = txtAddress.Text;
            supplierEntity.createdStaffId = LoginStaffID;
            supplierEntity.updatedStaffId = LoginStaffID;
            supplierEntity.createdDatetime = DateTime.Now;
            supplierEntity.updatedDatetime = DateTime.Now;
            return supplierEntity;
        }

        private void BindData()
        {
            if (supplier_id != 0)
            {
                DataTable dt = supplierService.Get(supplier_id);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["name"].ToString();
                    txtPhone.Text = dt.Rows[0]["phone"].ToString();
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    txtAddress.Text = dt.Rows[0]["address"].ToString();
                }
            }
        }

        private void BtnControl()
        {
            if (supplier_id == 0)
            {
                btnADD.Text = "Add";
                btnDelete.Enabled = false;
            }
            else
            {
                btnADD.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private bool TestEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$");
            Match match = reg.Match(email);
            return match.Success;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string strpattern = @"^[09][0-9 \-\(\)\.]*[1-9][0-9 \-\(\)\.]*$";

            if (Regex.IsMatch(phoneNumber, strpattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            supplier_id = 0;
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            btnADD.Text = "ADD";
            btnDelete.Enabled = false;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UCSupplierList ucSupplierList = new UCSupplierList(LoginStaffID);
            bool success = supplierService.Delete(supplier_id, LoginStaffID, DateTime.Now);
            if (success)
            {
                MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearData();
            this.Controls.Clear();
            this.Controls.Add(ucSupplierList);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UCSupplierList ucSupplierList = new UCSupplierList(LoginStaffID);
            this.Controls.Clear();
            this.Controls.Add(ucSupplierList);
        }
    }
}
