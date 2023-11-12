using POS.APP.Views.Dashboard;
using POS.APP.Views.MainPOS;
using POS.Services.Staff;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POS.APP.Views.Login
{
    public partial class LoginForm : Form
    {
        StaffService staffService = new StaffService();
        string password, name; int staff_id;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string staff_email = txtEmail.Text;
            string staff_password = txtPassword.Text;
            if (string.IsNullOrEmpty(staff_email) && string.IsNullOrEmpty(staff_password))
            {
                MessageBox.Show("Please input UserName and Password.", "Required UserName and Password ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(staff_email))
            {
                MessageBox.Show("Please input UserName.", "Required UserName ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (!TestEmail(staff_email) || !(staff_email.EndsWith("@gmail.com")))
            {
                MessageBox.Show("Incorrect Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Text = "";
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(staff_password))
            {
                MessageBox.Show("Please input Password.", "Required Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            else if (staff_password.Length < 8)
            {
                MessageBox.Show("Please input Password at least 8 characters.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            else
            {
                int count = staffService.GetUserCount(staff_email);
                if (count != 1)
                {
                    MessageBox.Show("Invalid UserName and Password.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearData();
                }
                else
                {
                    var key = "c#groupproject11/09/2023";
                    int staffID = staffService.GetStaffID(staff_email);
                    DataTable dt = staffService.GetStaffPassword(staffID);
                    if (dt.Rows.Count > 0)
                    {
                        staff_id = Convert.ToInt32(dt.Rows[0]["staff_id"].ToString());
                        password = dt.Rows[0]["password"].ToString();
                        name = dt.Rows[0]["staffname"].ToString();
                    }
                    string decryptedString = AesOperation.DecryptString(key, password);
                    if (decryptedString == txtPassword.Text)
                    {
                        FrmMenu frmMenu = new FrmMenu(staff_id, name);
                        UCDashboard uCDashboard = new UCDashboard(staff_id, name);
                        frmMenu.Show();
                        frmMenu.pnUC.Controls.Add(uCDashboard);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                }
            }
        }

        private bool TestEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$");
            Match match = reg.Match(email);
            return match.Success;
        }

        private void ClearData()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtEmail.Focus();
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            CodeResent codeResendForm = new CodeResent(txtEmail.Text);
            codeResendForm.Show();
            this.Hide();
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
