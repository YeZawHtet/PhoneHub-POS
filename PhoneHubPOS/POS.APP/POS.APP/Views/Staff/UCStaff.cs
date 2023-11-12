using POS.APP.Views.MainPOS;
using POS.Entities.Staff;
using POS.Services.Staff;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POS.APP.Views.Staff
{
    public partial class UCStaff : UserControl
    {
        private int staff_id;
        public int ID
        {
            set
            {
                staff_id = value;
            }
        }

        StaffService staffService = new StaffService();
        private int LoginStaffID; short staff_role;string validateEmail = "", validateName = "";
        public UCStaff(int login_id)
        {
            InitializeComponent();
            LoginStaffID = login_id;
        }

        private void UCStaff_Load(object sender, EventArgs e)
        {
            staff_role = staffService.GetStaffRole(LoginStaffID);
            if (staff_id != 0)
            {
                btnClear.Enabled = false;
            }
            rdoAdmin.Checked = true;
            BtnControl();
            BindData();
            txtPassword.UseSystemPasswordChar = true;
        }

        private bool TestEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$");
            Match match = reg.Match(email);
            return match.Success;
        }

        private void AddorUpdate()
        {
            UCStaffList ucStaffList = new UCStaffList(LoginStaffID);
            StaffEntity staffEntity = CreateData();
            bool success = false;
            if (staff_id == 0)
            {
                success = staffService.Insert(staffEntity);
                if (success)
                {
                    string staffName = txtStaffName.Text;
                    MessageBox.Show($"{staffName} has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearData();
            }
            else
            {
                success = staffService.Update(staffEntity);
                if (success)
                {
                    MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.ParentForm != null)
                    {
                        Label lblStaffname = this.ParentForm.Controls.Find("lblStaffname", true).FirstOrDefault() as Label;
                        if (lblStaffname != null)
                        {
                            // Update the label text with the new staff name
                            lblStaffname.Text = txtStaffName.Text;
                        }
                    }

                }
                ClearData();
            }
            this.Controls.Clear();
            this.Controls.Add(ucStaffList);
        }

        private StaffEntity CreateData()
        {
            var key = "c#groupproject11/09/2023";
            StaffEntity staffEntity = new StaffEntity(); ;
            if (staff_id != 0)
            {
                staffEntity.staff_id = Convert.ToInt32(staff_id);
                DataTable dt = staffService.Get(staff_id);
                if(dt.Rows.Count > 0)
                {
                    validateName = dt.Rows[0]["staffname"].ToString().Replace(" ", "").ToLower();
                    validateEmail = dt.Rows[0]["email"].ToString();
                }
                
            }
            if (btnADD.Text == "Update")
            {
                int emailCount = staffService.GetUserCount(txtEmail.Text.Trim());
                int staffNameCount;
                if (txtStaffName.Text.Contains(" "))
                {
                    staffNameCount = staffService.GetUserNameCount(txtStaffName.Text.Replace(" ", ""));
                }
                else
                {
                    staffNameCount = staffService.GetUserNameCount(txtStaffName.Text);
                }

                if (staffNameCount >= 1 && validateName != txtStaffName.Text.Replace(" ", "").ToLower())
                {
                    MessageBox.Show("Already existed StaffName.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffName.Text = "";
                    txtStaffName.Focus();
                   
                }
                if (emailCount >= 1 && validateEmail != txtEmail.Text)
                {
                    MessageBox.Show("Already existed Email.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    txtEmail.Focus();
                }
            }
            staffEntity.staffname = txtStaffName.Text;
            string password = AesOperation.EncryptString(key, txtPassword.Text);
            staffEntity.password = password;
            staffEntity.email = txtEmail.Text;
            if (rdoAdmin.Checked)
            {
                staff_role = 1;
            }
            else { staff_role = 0; }
            staffEntity.phone = txtPhone.Text;
            staffEntity.address = txtAddress.Text;
            staffEntity.staff_role = (short)staff_role;
            staffEntity.created_staff_id = LoginStaffID;
            staffEntity.updated_staff_id = LoginStaffID;
            staffEntity.created_datetime = DateTime.Now;
            staffEntity.updated_datetime = DateTime.Now;
            return staffEntity;
        }

        private void BindData()
        {
            if (staff_id != 0)
            {
                DataTable dt = staffService.Get(staff_id);

                if (dt.Rows.Count > 0)
                {
                    var key = "c#groupproject11/09/2023";
                    txtStaffName.Text = dt.Rows[0]["staffname"].ToString();
                    string encryptedString = dt.Rows[0]["password"].ToString();
                    txtPassword.Text = AesOperation.DecryptString(key, encryptedString);
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    txtPhone.Text = dt.Rows[0]["phone"].ToString();
                    txtAddress.Text = dt.Rows[0]["address"].ToString();
                    short staff_role = (short)dt.Rows[0]["staff_role"];
                    if (staff_role == 1)
                    {
                        rdoAdmin.Checked = true;
                    }
                    else { rdoCashier.Checked = true; }
                }
            }
        }

        private void BtnControl()
        {
            if (staff_id == 0)
            {
                btnADD.Text = "Add";
                btnDelete.Enabled = false;
            }
            else
            {
                if (staff_role == 1)
                {
                    if (staff_id != LoginStaffID)
                    {
                        txtStaffName.Enabled = false;
                        txtPassword.Enabled = false;
                        txtEmail.Enabled = false;
                        ckbPassword.Enabled = false;
                        txtPhone.Enabled = false;
                        txtAddress.Enabled = false;
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        if (staff_id != 1)
                        {
                            btnDelete.Enabled = false;
                        }
                        rdoAdmin.Enabled = false;
                        rdoCashier.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    btnADD.Text = "Update";
                }
                else
                {
                    btnADD.Text = "Update";
                    btnDelete.Enabled = false;
                    rdoAdmin.Enabled = false;
                    rdoCashier.Enabled = false;
                }
            }
        }

        private void ClearData()
        {
            txtStaffName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text ="";
            txtAddress.Text = "";
            rdoAdmin.Checked = true;
            btnADD.Text = "Add";
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStaffName.Text) && string.IsNullOrEmpty(txtPassword.Text) && string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please input Information.", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStaffName.Focus();
            }
            else if (string.IsNullOrEmpty(txtStaffName.Text))
            {
                MessageBox.Show("Please input Staff Name.", "Required StaffName ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStaffName.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input Password.", "Required Password ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
            else if (txtPassword.Text.Length < 8 || txtPassword.Text.Length > 20)
            {
                MessageBox.Show("Please input Password at least 8 characters and at most 20 characters.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please input Email.", "Required Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (!TestEmail(txtEmail.Text) || !(txtEmail.Text.EndsWith("@gmail.com")))
            {
                MessageBox.Show("Please input a correct Gmail address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
 
                int emailCount = staffService.GetUserCount(txtEmail.Text.Trim());
                int staffNameCount;
                if (txtStaffName.Text.Contains(" "))
                {
                    staffNameCount = staffService.GetUserNameCount(txtStaffName.Text.Replace(" ", ""));
                }
                else
                {
                    staffNameCount = staffService.GetUserNameCount(txtStaffName.Text);
                }
                
                if (staffNameCount >= 1 && btnADD.Text == "Add")
                {
                    MessageBox.Show("Already existed StaffName.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffName.Text = "";
                    txtStaffName.Focus();
                    return;
                }
                if (emailCount >= 1 && btnADD.Text == "Add")
                {
                    MessageBox.Show("Already existed Email.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    return;
                }
                AddorUpdate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UCStaffList ucStaffList = new UCStaffList(LoginStaffID);
            if (staff_id == 1)
            {
                MessageBox.Show("Unsuccessful Delete.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearData();
            }
            else
            {
                bool success = staffService.Delete(staff_id, LoginStaffID, DateTime.Now);
                if (success)
                {
                    MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearData();
            }
            this.Controls.Clear();
            this.Controls.Add(ucStaffList);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ckbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UCStaffList ucStaffList = new UCStaffList(LoginStaffID);
            this.Controls.Clear();
            this.Controls.Add(ucStaffList);
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
    }
}
