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

namespace POS.APP.Views.Item
{
    public partial class logintemp : Form
    {
        public logintemp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var key = "c#groupproject11/09/2023";
            string encryptString = AesOperation.EncryptString(key, textBox1.Text);
            label1.Text = textBox1.Text;
            textBox2.Text = encryptString;
        }
    }
}
