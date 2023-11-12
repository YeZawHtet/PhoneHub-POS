using POS.APP.Views.Item;
using POS.Services.Item;
using POS.Services.Purchase;
using POS.Services.Sale;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace POS.APP.Views.Dashboard
{
    public partial class UCDashboard : UserControl
    {
        // Public property to store the Login ID
        public int LoginID
        { get; set; }
        public string LoginName { get; set; }

        private DataTable dt;
        SaleService saleService = new SaleService();
        PurchaseService purchaseService = new PurchaseService();
        ItemService itemService = new ItemService();
        public UCDashboard(int id, string name)
        {
            InitializeComponent();
            this.LoginID = id;
            this.LoginName = name;
        }

        // Event handler for the UCDashboard load
        private void UCDashboard_Load(object sender, EventArgs e)
        {
            // Bind the filter combo box
            BindCbo();
            // Bind Data Grip
            BindGrid();
            // Bind data to the Chart 
            BindChart();
            // Bind total sale data for today 
            BindSaleToday();
            // Bind best selling item for the week 
            BindBestSellingItem();
        }

        // Method to bind combo box
        private void BindCbo()
        {
            cbofilter.Items.AddRange(new string[] { "Most Sell", "Least Sell", "Out of Stock", "Low Quantity" });
            cbofilter.SelectedIndexChanged += cbofilter_SelectedIndexChanged;
            cbofilter.SelectedItem = "Most Sell";
        }

        // Method to display the total sales for today
        private void BindSaleToday()
        {
            decimal totalSalesToday = saleService.GetTotalSalesForToday();
            lblSaleToday.Text = totalSalesToday.ToString("N0");
        }

        // Method to display the best-selling item
        private void BindBestSellingItem()
        {
            string bestSellingItem = saleService.BestSellingForlastWeek();
            lblItem.Text = bestSellingItem.ToString();
        }

        // Method to bind data to the grid
        private void BindGrid()
        {
            dt = itemService.GetItemReport();
            dgvItemReport.DataSource = dt;
        }

        // Method to bind data to the chart
        private void BindChart()
        {
            DateTime today = DateTime.Now;
            DateTime startOfWeek = today.AddDays(-7);
            DateTime endOfWeek = today;

            DataTable salesData = saleService.GetSalesData(startOfWeek, endOfWeek);
            DataTable purchaseData = purchaseService.GetPurchaseData(startOfWeek, endOfWeek);

            chartSalesAndPurchase.Series.Clear();

            Series salesSeries = new Series("Sales");
            salesSeries.Points.DataBind(salesData.AsEnumerable(), "DayOfWeek", "TotalAmount", "");
            salesSeries.ChartType = SeriesChartType.Column;
            salesSeries.Color = System.Drawing.Color.Orange;

            Series purchaseSeries = new Series("Purchases");
            purchaseSeries.Points.DataBind(purchaseData.AsEnumerable(), "DayOfWeek", "TotalAmount", "");
            purchaseSeries.ChartType = SeriesChartType.Column;
            purchaseSeries.Color = System.Drawing.Color.Blue;

            chartSalesAndPurchase.Series.Add(salesSeries);
            chartSalesAndPurchase.Series.Add(purchaseSeries);

            chartSalesAndPurchase.ChartAreas[0].AxisX.Interval = 1;
            chartSalesAndPurchase.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartSalesAndPurchase.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chartSalesAndPurchase.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            chartSalesAndPurchase.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            string[] dayLabels = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            for (int i = 0; i < dayLabels.Length; i++)
            {
                chartSalesAndPurchase.ChartAreas[0].AxisX.CustomLabels.Add(
                    i + 1 - 0.5, i + 1 + 0.5, dayLabels[i]);
            }
            chartSalesAndPurchase.ChartAreas[0].AxisY.Minimum = 0;
        }  

        // Event handler for the filter combo box selection change
        private void cbofilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbofilter.SelectedIndex != -1)
            {
                string selectedFilter = cbofilter.SelectedItem.ToString();
                dt = itemService.GetItemReport();
                DataView dv = dt.DefaultView;
                // Check condition for combo box selection
                switch (selectedFilter)
                {
                    case "Out of Stock":
                        dv.RowFilter = "quantity = 0";
                        GetDgv(dv);
                        break;

                    case "Low Quantity":
                        dv.RowFilter = "quantity > 0 AND quantity < 10";
                        GetDgv(dv);
                        break;

                    case "Most Sell":
                        dv.Sort = "sell DESC";
                        GetDgv(dv);
                        break;

                    case "Least Sell":
                        dv.Sort = "sell ASC";
                        GetDgv(dv);
                        break;

                    default:
                        dv.RowFilter = string.Empty;
                        dv.Sort = string.Empty;
                        break;
                }
            }
        }

        // Method to update the DataGridView with filtered data
        private void GetDgv(DataView dv)
        {
            DataTable filteredDt = dv.ToTable();
            UpdateRowNumColumn(filteredDt);
            dgvItemReport.DataSource = filteredDt;

        }

        // Method to update the "No." column values in a DataTable
        private void UpdateRowNumColumn(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i]["RowNum"] = i + 1;
            }
        }

        // Event handler for the "Add Item" button click
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Go to UCItemList
            UCItemList ucItemList = new UCItemList(LoginID);
            this.Controls.Clear();
            this.Controls.Add(ucItemList);
        }

        // Event handler for cell formatting in data grip view to change price format
        private void dgvItemReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvItemReport.Columns[e.ColumnIndex].Name == "Price")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal numericValue))
                {
                    e.Value = numericValue.ToString("N0", CultureInfo.InvariantCulture);
                    e.FormattingApplied = true;
                }
            }
            if (dgvItemReport.Columns[e.ColumnIndex].Name == "gcEarning")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal numericValue))
                {
                    e.Value = numericValue.ToString("N0", CultureInfo.InvariantCulture);
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
