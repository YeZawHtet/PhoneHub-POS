using POS.Services.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.APP.Views.Login
{
    public partial class CodeResent : Form
    {
        StaffService staffService = new StaffService();
        string email = "";
        private int randomNumber;

        public CodeResent(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CodeResent_Load(object sender, EventArgs e)
        {
            txtEmail.Text = email;
            txtCode.Enabled = false;
            btnVerify.Enabled = false;
        }

        private void btnCodeSent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Fill your email to send recovery code.", "Requied Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!TestEmail(txtEmail.Text) || !(txtEmail.Text.Contains("@gmail.com")))
            {
                MessageBox.Show("Incorrect Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Text = "";
                txtEmail.Focus();
            }
            else
            {
                try
                {
                    string sendEmail = txtEmail.Text;
                    int count = staffService.GetUserCount(sendEmail);
                    if (count == 1)
                    {
                        SendEmail(sendEmail);
                        txtCode.Enabled = true;
                        btnVerify.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Email is invalid.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending email: " + ex.Message);
                }
            }
        }

        private bool TestEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$");
            Match match = reg.Match(email);
            return match.Success;
        }

        public void SendEmail(string email)
        {
            try
            {
                Random random = new Random();
                randomNumber = random.Next(100000, 999999);
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("testsharpmail2023@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Password reset code";
                string mail = "Your code is: " + randomNumber.ToString();
                message.Body = mail;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("testsharpmail2023@gmail.com", "ajrqdthflwizyeoy");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("Verification code sent successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == randomNumber.ToString())
            {
                ChangePassword reset = new ChangePassword(txtEmail.Text);
                reset.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your code does not match.", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Text = "";
                btnCodeSent.Text = "Code send again";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
