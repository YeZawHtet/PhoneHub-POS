using System.Windows.Forms;
namespace POS.APP.Views.Sales
{
    public partial class PaymentForm : Form
    {
        public decimal decPayAmount = 0;
        public PaymentForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Confirm payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (decimal.TryParse(txtPayAmount.Text, out decimal decPayAmount1))
                {
                    decPayAmount = decPayAmount1;
                    string formatPaymentAmount = decPayAmount1.ToString("#,##0");
                    DialogResult result = MessageBox.Show($"Payment Amount: {formatPaymentAmount}", "Payment Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        // The user clicked "OK," close the form
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // The user clicked "Cancel," allow them to retype in the textbox
                        txtPayAmount.Text = "";
                        txtPayAmount.Focus();
                    }
                }
                else
                {
                    // Handle invalid input (non-numeric or incorrectly formatted input)
                    MessageBox.Show("Invalid payment amount. Please enter a valid numeric amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPayAmount.Text = "";
                }
            }
        }
        /// <summary>
        /// control to ensure digits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If it's not a numeric digit or a control key, suppress the key press.
                e.Handled = true;
            }
        }
        /// <summary>
        /// close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}