namespace POS.APP.Views.Dashboard
{
    partial class UCDashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvItemReport = new System.Windows.Forms.DataGridView();
            this.gcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcEarning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbofilter = new System.Windows.Forms.ComboBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.chartSalesAndPurchase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSaleToday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesAndPurchase)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 279);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 34);
            this.label1.TabIndex = 38;
            this.label1.Text = "Items";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(336, 630);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(0, 0);
            this.button2.TabIndex = 48;
            this.button2.Text = "First";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dgvItemReport
            // 
            this.dgvItemReport.AllowUserToAddRows = false;
            this.dgvItemReport.AllowUserToOrderColumns = true;
            this.dgvItemReport.AllowUserToResizeRows = false;
            this.dgvItemReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemReport.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gcNo,
            this.name,
            this.Price,
            this.gcQty,
            this.Sell,
            this.sale_date,
            this.gcEarning});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemReport.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvItemReport.EnableHeadersVisualStyles = false;
            this.dgvItemReport.Location = new System.Drawing.Point(22, 334);
            this.dgvItemReport.Name = "dgvItemReport";
            this.dgvItemReport.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvItemReport.RowHeadersVisible = false;
            this.dgvItemReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemReport.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvItemReport.RowTemplate.Height = 24;
            this.dgvItemReport.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvItemReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemReport.Size = new System.Drawing.Size(1363, 325);
            this.dgvItemReport.TabIndex = 44;
            this.dgvItemReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItemReport_CellFormatting);
            // 
            // gcNo
            // 
            this.gcNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gcNo.DataPropertyName = "RowNum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gcNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.gcNo.FillWeight = 10F;
            this.gcNo.HeaderText = "No.";
            this.gcNo.MinimumWidth = 6;
            this.gcNo.Name = "gcNo";
            this.gcNo.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "item_name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.FillWeight = 25F;
            this.name.HeaderText = "Item Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.DataPropertyName = "price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Price.DefaultCellStyle = dataGridViewCellStyle4;
            this.Price.FillWeight = 20F;
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // gcQty
            // 
            this.gcQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gcQty.DataPropertyName = "quantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gcQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.gcQty.FillWeight = 15F;
            this.gcQty.HeaderText = "Qty";
            this.gcQty.MinimumWidth = 6;
            this.gcQty.Name = "gcQty";
            this.gcQty.ReadOnly = true;
            // 
            // Sell
            // 
            this.Sell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sell.DataPropertyName = "sell";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Sell.DefaultCellStyle = dataGridViewCellStyle6;
            this.Sell.FillWeight = 15F;
            this.Sell.HeaderText = "Sell";
            this.Sell.MinimumWidth = 6;
            this.Sell.Name = "Sell";
            this.Sell.ReadOnly = true;
            // 
            // sale_date
            // 
            this.sale_date.DataPropertyName = "sale_date";
            this.sale_date.HeaderText = "Sale Date";
            this.sale_date.MinimumWidth = 6;
            this.sale_date.Name = "sale_date";
            this.sale_date.ReadOnly = true;
            this.sale_date.Visible = false;
            // 
            // gcEarning
            // 
            this.gcEarning.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gcEarning.DataPropertyName = "earning";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gcEarning.DefaultCellStyle = dataGridViewCellStyle7;
            this.gcEarning.FillWeight = 25F;
            this.gcEarning.HeaderText = "Earning";
            this.gcEarning.MinimumWidth = 6;
            this.gcEarning.Name = "gcEarning";
            this.gcEarning.ReadOnly = true;
            // 
            // cbofilter
            // 
            this.cbofilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofilter.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofilter.FormattingEnabled = true;
            this.cbofilter.Location = new System.Drawing.Point(823, 279);
            this.cbofilter.Name = "cbofilter";
            this.cbofilter.Size = new System.Drawing.Size(218, 28);
            this.cbofilter.TabIndex = 1;
            this.cbofilter.SelectedIndexChanged += new System.EventHandler(this.cbofilter_SelectedIndexChanged);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddItem.Location = new System.Drawing.Point(1132, 274);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(253, 39);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // chartSalesAndPurchase
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSalesAndPurchase.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Roboto", 8F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartSalesAndPurchase.Legends.Add(legend1);
            this.chartSalesAndPurchase.Location = new System.Drawing.Point(68, 3);
            this.chartSalesAndPurchase.Name = "chartSalesAndPurchase";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Sales";
            series1.XValueMember = "DayOfWeek";
            series1.YValueMembers = "TotalAmount";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Purchases";
            this.chartSalesAndPurchase.Series.Add(series1);
            this.chartSalesAndPurchase.Series.Add(series2);
            this.chartSalesAndPurchase.Size = new System.Drawing.Size(616, 274);
            this.chartSalesAndPurchase.TabIndex = 53;
            this.chartSalesAndPurchase.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblSaleToday);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(679, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 126);
            this.panel1.TabIndex = 59;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS.APP.Properties.Resources.coupon;
            this.pictureBox1.Location = new System.Drawing.Point(256, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblSaleToday
            // 
            this.lblSaleToday.AutoSize = true;
            this.lblSaleToday.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleToday.ForeColor = System.Drawing.Color.Black;
            this.lblSaleToday.Location = new System.Drawing.Point(31, 71);
            this.lblSaleToday.Name = "lblSaleToday";
            this.lblSaleToday.Size = new System.Drawing.Size(87, 24);
            this.lblSaleToday.TabIndex = 1;
            this.lblSaleToday.Text = "0000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(31, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sales Today";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblItem);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1035, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 126);
            this.panel2.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Last Week";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::POS.APP.Properties.Resources.best_seller;
            this.pictureBox2.Location = new System.Drawing.Point(267, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Black;
            this.lblItem.Location = new System.Drawing.Point(23, 71);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(51, 24);
            this.lblItem.TabIndex = 1;
            this.lblItem.Text = "item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Best Selling Item For";
            // 
            // UCDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartSalesAndPurchase);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.cbofilter);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvItemReport);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCDashboard";
            this.Size = new System.Drawing.Size(1445, 690);
            this.Load += new System.EventHandler(this.UCDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesAndPurchase)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvItemReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sell;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcEarning;
        private System.Windows.Forms.ComboBox cbofilter;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesAndPurchase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSaleToday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label4;
    }
}
