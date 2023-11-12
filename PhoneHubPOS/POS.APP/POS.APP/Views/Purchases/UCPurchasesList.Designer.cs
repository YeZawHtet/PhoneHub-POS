namespace POS.APP.Views.Purchases
{
    partial class UCPurchasesList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPurchasesList));
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnGoBacktoSale = new System.Windows.Forms.Button();
            this.dgvPurchaseDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPurchaseList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcPurchaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcSupplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcPurchase_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete_option = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(103)))), ((int)(((byte)(108)))));
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Location = new System.Drawing.Point(2, 2);
            this.pnTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1079, 50);
            this.pnTitle.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(0, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Purchase History";
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.lblPageNumber.Location = new System.Drawing.Point(485, 510);
            this.lblPageNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(84, 18);
            this.lblPageNumber.TabIndex = 31;
            this.lblPageNumber.Text = "page 0 of 0";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Location = new System.Drawing.Point(580, 503);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(92, 32);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrevious.Location = new System.Drawing.Point(376, 503);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(92, 32);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDownload.Location = new System.Drawing.Point(8, 503);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(131, 32);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.btnLast.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLast.Location = new System.Drawing.Point(677, 503);
            this.btnLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(92, 32);
            this.btnLast.TabIndex = 8;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.btnFirst.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFirst.Location = new System.Drawing.Point(279, 503);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(92, 32);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnGoBacktoSale
            // 
            this.btnGoBacktoSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnGoBacktoSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBacktoSale.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBacktoSale.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGoBacktoSale.Location = new System.Drawing.Point(860, 503);
            this.btnGoBacktoSale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGoBacktoSale.Name = "btnGoBacktoSale";
            this.btnGoBacktoSale.Size = new System.Drawing.Size(170, 32);
            this.btnGoBacktoSale.TabIndex = 9;
            this.btnGoBacktoSale.Text = "Go Back To Purchase";
            this.btnGoBacktoSale.UseVisualStyleBackColor = false;
            this.btnGoBacktoSale.Click += new System.EventHandler(this.btnGoBacktoSale_Click);
            // 
            // dgvPurchaseDetail
            // 
            this.dgvPurchaseDetail.AllowUserToAddRows = false;
            this.dgvPurchaseDetail.AllowUserToDeleteRows = false;
            this.dgvPurchaseDetail.AllowUserToOrderColumns = true;
            this.dgvPurchaseDetail.AllowUserToResizeColumns = false;
            this.dgvPurchaseDetail.AllowUserToResizeRows = false;
            this.dgvPurchaseDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchaseDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(164)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(164)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.unit_price});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPurchaseDetail.EnableHeadersVisualStyles = false;
            this.dgvPurchaseDetail.Location = new System.Drawing.Point(7, 188);
            this.dgvPurchaseDetail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPurchaseDetail.Name = "dgvPurchaseDetail";
            this.dgvPurchaseDetail.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPurchaseDetail.RowHeadersVisible = false;
            this.dgvPurchaseDetail.RowHeadersWidth = 51;
            this.dgvPurchaseDetail.RowTemplate.Height = 24;
            this.dgvPurchaseDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseDetail.Size = new System.Drawing.Size(1022, 264);
            this.dgvPurchaseDetail.TabIndex = 54;
            this.dgvPurchaseDetail.Visible = false;
            this.dgvPurchaseDetail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPurchaseDetail_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RowNum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.FillWeight = 25F;
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "purchase_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "Purchase Id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "item_name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.FillWeight = 25F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.FillWeight = 25F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // unit_price
            // 
            this.unit_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unit_price.DataPropertyName = "unit_price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.unit_price.DefaultCellStyle = dataGridViewCellStyle5;
            this.unit_price.FillWeight = 25F;
            this.unit_price.HeaderText = "Unit Price";
            this.unit_price.MinimumWidth = 6;
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            // 
            // dgvPurchaseList
            // 
            this.dgvPurchaseList.AllowUserToAddRows = false;
            this.dgvPurchaseList.AllowUserToDeleteRows = false;
            this.dgvPurchaseList.AllowUserToOrderColumns = true;
            this.dgvPurchaseList.AllowUserToResizeColumns = false;
            this.dgvPurchaseList.AllowUserToResizeRows = false;
            this.dgvPurchaseList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.dgvPurchaseList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.gcPurchaseId,
            this.invoice_id,
            this.name,
            this.gcSupplier_name,
            this.gcPurchase_date,
            this.TotalAmount,
            this.delete_option});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseList.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvPurchaseList.EnableHeadersVisualStyles = false;
            this.dgvPurchaseList.Location = new System.Drawing.Point(8, 188);
            this.dgvPurchaseList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPurchaseList.Name = "dgvPurchaseList";
            this.dgvPurchaseList.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseList.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvPurchaseList.RowHeadersVisible = false;
            this.dgvPurchaseList.RowHeadersWidth = 51;
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            this.dgvPurchaseList.RowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvPurchaseList.RowTemplate.Height = 24;
            this.dgvPurchaseList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvPurchaseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseList.Size = new System.Drawing.Size(1022, 264);
            this.dgvPurchaseList.TabIndex = 64;
            this.dgvPurchaseList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseList_CellContentClick_1);
            this.dgvPurchaseList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPurchaseList_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "Search Here";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(247, 101);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 32);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(22, 101);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(898, 101);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(133, 32);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.No.DataPropertyName = "RowNum";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle9;
            this.No.FillWeight = 10F;
            this.No.HeaderText = "No.";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // gcPurchaseId
            // 
            this.gcPurchaseId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gcPurchaseId.DataPropertyName = "purchase_id";
            this.gcPurchaseId.HeaderText = "Purchase ID";
            this.gcPurchaseId.MinimumWidth = 6;
            this.gcPurchaseId.Name = "gcPurchaseId";
            this.gcPurchaseId.ReadOnly = true;
            this.gcPurchaseId.Visible = false;
            // 
            // invoice_id
            // 
            this.invoice_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.invoice_id.DataPropertyName = "invoice_no";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.invoice_id.DefaultCellStyle = dataGridViewCellStyle10;
            this.invoice_id.FillWeight = 15F;
            this.invoice_id.HeaderText = "Invoice No.";
            this.invoice_id.MinimumWidth = 6;
            this.invoice_id.Name = "invoice_id";
            this.invoice_id.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "staff_name";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name.DefaultCellStyle = dataGridViewCellStyle11;
            this.name.FillWeight = 15F;
            this.name.HeaderText = "Staff Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // gcSupplier_name
            // 
            this.gcSupplier_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gcSupplier_name.DataPropertyName = "supplier_name";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gcSupplier_name.DefaultCellStyle = dataGridViewCellStyle12;
            this.gcSupplier_name.FillWeight = 15F;
            this.gcSupplier_name.HeaderText = "Supplier Name";
            this.gcSupplier_name.MinimumWidth = 6;
            this.gcSupplier_name.Name = "gcSupplier_name";
            this.gcSupplier_name.ReadOnly = true;
            // 
            // gcPurchase_date
            // 
            this.gcPurchase_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gcPurchase_date.DataPropertyName = "purchase_date";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gcPurchase_date.DefaultCellStyle = dataGridViewCellStyle13;
            this.gcPurchase_date.FillWeight = 15F;
            this.gcPurchase_date.HeaderText = "Purchase Date";
            this.gcPurchase_date.MinimumWidth = 6;
            this.gcPurchase_date.Name = "gcPurchase_date";
            this.gcPurchase_date.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalAmount.DataPropertyName = "total_amount";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalAmount.DefaultCellStyle = dataGridViewCellStyle14;
            this.TotalAmount.FillWeight = 20F;
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // delete_option
            // 
            this.delete_option.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delete_option.FillWeight = 10F;
            this.delete_option.HeaderText = "Delete";
            this.delete_option.Image = ((System.Drawing.Image)(resources.GetObject("delete_option.Image")));
            this.delete_option.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.delete_option.MinimumWidth = 6;
            this.delete_option.Name = "delete_option";
            this.delete_option.ReadOnly = true;
            this.delete_option.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete_option.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UCPurchasesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvPurchaseList);
            this.Controls.Add(this.dgvPurchaseDetail);
            this.Controls.Add(this.btnGoBacktoSale);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.pnTitle);
            this.Name = "UCPurchasesList";
            this.Size = new System.Drawing.Size(1084, 561);
            this.Load += new System.EventHandler(this.UCPurchasesList_Load);
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnGoBacktoSale;
        private System.Windows.Forms.DataGridView dgvPurchaseDetail;
        private System.Windows.Forms.DataGridView dgvPurchaseList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcPurchaseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcSupplier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcPurchase_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewImageColumn delete_option;
    }
}
