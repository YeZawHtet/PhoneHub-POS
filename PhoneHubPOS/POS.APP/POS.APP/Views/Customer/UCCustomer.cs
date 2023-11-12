using POS.Entities.Customer;
using POS.Services.Customer;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace POS.APP.Views.Customer
{
    public partial class UCCustomer : UserControl
    {
        private int customer_id;
        CustomerService customerService = new CustomerService();
        public int ID
        {
            set
            {
                customer_id = value;
            }
        }
        public UCCustomer()
        {
            InitializeComponent();
        }
        private int LoginStaffID;
        /// <summary>
        /// initial load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCustomer_Load(object sender, EventArgs e)
        {
            BindData();
            BtnControl();
        }
        /// <summary>
        /// Add button Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnADD_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            };
            AddorUpdate();
            ClearData();

        }
        private bool ValidateInputs()
        {
            string customerName = txtCustomerName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please input all information.", "Required Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            string pattern = @"[$*@\-+]";

            if (Regex.IsMatch(customerName, pattern))
            {
                MessageBox.Show("Please input a valid Customer Name.", "Invalid Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerName.Text = "";
                txtCustomerName.Focus();
                return false;
            }

            if (!IsValidPhoneNumber(phone) || phone.Length > 11)
            {
                if (!IsValidPhoneNumber(phone))
                {
                    MessageBox.Show("Please input a correct phone number  starts with 09 OR 0.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Text = "";
                    txtPhone.Focus();
                    return false;
                }
                else
                {
                    MessageBox.Show("Please input a correct phone number with at least 11 digits.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Text = "";
                    txtPhone.Focus();
                    return false;
                }
            }

            if (!TestEmail(email) || !email.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Please input a correct Gmail address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Text = "";
                txtEmail.Focus();
                return false;
            }

            int count = customerService.GetUserCount(email);
            bool result = customerService.GetCustomerEmail(email, customer_id);
            if (count >= 1 && btnADD.Text == "Add")
            {
                MessageBox.Show("The email already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (result == true && count >= 2 && btnADD.Text == "Update")
            {
                MessageBox.Show("The email already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (result == false && count >= 1 && btnADD.Text == "Update")
            {
                MessageBox.Show("The email already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check Email Validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool TestEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3}$");
            Match match = reg.Match(email);
            return match.Success;
        }
        /// <summary>
        /// check Phone Nubmer
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string strpattern = @"^(09|9)[0-9 \-\(\)\.]*$";

            if (Regex.IsMatch(phoneNumber, strpattern) && phoneNumber.Count(char.IsDigit) > 10 && phoneNumber.Count(char.IsDigit) < 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Clear textbox data and change button text
        /// </summary>
        private void ClearData()
        {
            if (customer_id > 0)
            {
                customer_id = 0;
            }
            txtCustomerName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            btnADD.Text = "Add";
            btnDelete.Enabled = false;
        }
        /// <summary>
        /// Clear Button Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
            BtnControl();
        }
        /// <summary>
        /// Bind data in textbox fields
        /// </summary>
        private void BindData()
        {
            if (customer_id != 0)
            {
                DataTable dt = customerService.Get(customer_id);

                if (dt.Rows.Count > 0)
                {
                    txtCustomerName.Text = dt.Rows[0]["name"].ToString();
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    txtPhone.Text = dt.Rows[0]["phone"].ToString();
                    txtAddress.Text = dt.Rows[0]["address"].ToString();
                }
            }
        }
        /// <summary>
        /// Delete Customer Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool success = customerService.Delete(customer_id, LoginStaffID, DateTime.Now);
            if (success)
            {
                MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearData();
        }
        /// <summary>
        /// Insert and Update Customer
        /// </summary>
        private void AddorUpdate()
        {
            CustomerEntity customerEntity = CreateData();
            bool success = false;
            if (customer_id == 0)
            {
                success = customerService.Insert(customerEntity);
                if (success)
                {
                    string customerName = txtCustomerName.Text.Trim();
                    MessageBox.Show($"{customerName} has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearData();
            }
            else
            {
                success = customerService.Update(customerEntity);
                if (success)
                {
                    MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearData();
            }
        }
        /// <summary>
        /// set login ID
        /// </summary>
        /// <param name="login_id"></param>
        public void SetLoginID(int login_id)
        {
            LoginStaffID = login_id;
        }
        /// <summary>
        /// create data for customer
        /// </summary>
        /// <returns></returns>
        private CustomerEntity CreateData()
        {

            CustomerEntity customerEntity = new CustomerEntity();
            if (customer_id != 0)
            {
                customerEntity.customer_id = Convert.ToInt32(customer_id);
            }
            customerEntity.name = txtCustomerName.Text.Trim();
            customerEntity.email = txtEmail.Text.Trim();
            customerEntity.phone = txtPhone.Text.Trim();
            customerEntity.address = txtAddress.Text.Trim();
            customerEntity.created_staff_id = LoginStaffID;
            customerEntity.updated_staff_id = LoginStaffID;
            customerEntity.created_datetime = DateTime.Now;
            customerEntity.updated_datetime = DateTime.Now;
            return customerEntity;
        }
        /// <summary>
        /// control button state
        /// </summary>
        private void BtnControl()
        {
            if (customer_id == 0)
            {
                btnADD.Text = "Add";
                if (btnClear.Text == "Cancel")
                {
                    btnClear.Text = "Clear";
                }
                btnDelete.Enabled = false;
            }
            else
            {
                btnADD.Text = "Update";
                btnClear.Text = "Cancel";
                btnDelete.Enabled = true;
            }
        }
        /// <summary>
        /// back button control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            UCCustomerList uCCustomerList = new UCCustomerList();
            this.Controls.Clear();
            this.Controls.Add(uCCustomerList);
        }
        /// <summary>
        /// Control to ensure digit only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If it's not a numeric digit or a control key, suppress the key press.
                e.Handled = true;
            }
        }
    }
}