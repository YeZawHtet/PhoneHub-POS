using Microsoft.Reporting.WinForms;
using POS.Services.SaleDetail;
using System;
using System.Data;
using System.Windows.Forms;
namespace POS.APP.Views.Sales
{
    public partial class ReceiptForm : Form
    {
        SaleDetailService saleDetailService = new SaleDetailService();
        DataTable receiptData = new DataTable();
        public ReceiptForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// load data in Receipt
        /// </summary>
        /// <param name="lastInsertID"></param>
        /// <returns></returns>
        public DataTable LoadReceipt(int lastInsertID)
        {
            receiptData = saleDetailService.GetSaleDetailsBySaleId(lastInsertID);
            return receiptData;
        }
        /// <summary>
        /// DownloadButton Operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// initial load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rvReceipt_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = receiptData;
            rvReceipt.LocalReport.DataSources.Add(reportDataSource);
            rvReceipt.LocalReport.ReportPath = @"..\..\Views\Sales\Receipt.rdlc";
            rvReceipt.RefreshReport();
        }
    }
}