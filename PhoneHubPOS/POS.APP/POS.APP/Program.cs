using OfficeOpenXml;
using POS.APP.Views.Item;
using POS.APP.Views.Login;
using System;
using System.Windows.Forms;

namespace POS.APP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
