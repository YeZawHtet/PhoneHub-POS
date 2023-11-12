using POS.Entities.Staff;
using POS.Services.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.APP.Views.Login
{
    public partial class ChangePassword : Form
    {
        private string email;
        public ChangePassword(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNew.Text) && string.IsNullOrEmpty(txtConfirm.Text))
            {
                MessageBox.Show("Fill new password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtNew.Text))
            {
                MessageBox.Show("Please input new Password.", "Required Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNew.Focus();
            }
            else if (txtNew.Text.Length < 8)
            {
                MessageBox.Show("Please input Password at least 8 characters.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNew.Text = "";
                txtNew.Focus();
            }
            else if (string.IsNullOrEmpty(txtConfirm.Text))
            {
                MessageBox.Show("Please input confirm Password.", "Required Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirm.Focus();
            }
            else if (txtConfirm.Text.Length < 8)
            {
                MessageBox.Show("Please input Password at least 8 characters.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirm.Text = "";
                txtConfirm.Focus();
            }
            else if (txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show("Your password does not match.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNew.Text = "";
                txtConfirm.Text = "";
                txtConfirm.Focus();
            }
            else
            {
                try
                {
                    var key = "c#groupproject11/09/2023";
                    StaffService staffService = new StaffService();
                    StaffEntity staffEntity = new StaffEntity();
                    int staff_id = staffService.GetStaffID(email);
                    staffEntity.staff_id = staff_id;
                    staffEntity.updated_staff_id = staff_id;
                    staffEntity.updated_datetime = DateTime.Now;
                    string password = AesOperation.EncryptString(key, txtNew.Text);
                    staffEntity.password = password;
                    bool success = false;
                    success = staffService.UpdatePassword(staffEntity);
                    if (success)
                    {
                        MessageBox.Show("Your password is updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNew.Text = "";
                        txtConfirm.Text = "";
                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtNew.UseSystemPasswordChar = true;
            txtConfirm.UseSystemPasswordChar = true;
        }

        private void ckbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbPassword.Checked)
            {
                txtNew.UseSystemPasswordChar = false;
                txtConfirm.UseSystemPasswordChar = false;
            }
            else
            {
                txtNew.UseSystemPasswordChar = true;
                txtConfirm.UseSystemPasswordChar = true;
            }
        }
    }
}
