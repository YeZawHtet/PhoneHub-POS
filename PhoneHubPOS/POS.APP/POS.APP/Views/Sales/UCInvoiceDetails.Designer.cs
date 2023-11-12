namespace POS.APP.Views.Sales
{
    partial class UCInvoiceDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInvoiceData = new System.Windows.Forms.DataGridView();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReturnPayment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGoBacktoSale = new System.Windows.Forms.Button();
            this.lblSaleTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceData)).BeginInit();
            this.pnTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInvoiceData
            // 
            this.dgvInvoiceData.AllowUserToAddRows = false;
            this.dgvInvoiceData.AllowUserToDeleteRows = false;
            this.dgvInvoiceData.AllowUserToOrderColumns = true;
            this.dgvInvoiceData.AllowUserToResizeColumns = false;
            this.dgvInvoiceData.AllowUserToResizeRows = false;
            this.dgvInvoiceData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.dgvInvoiceData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.SaleID,
            this.name,
            this.description,
            this.ItemName,
            this.price,
            this.Quantity,
            this.SubTotal,
            this.TotalAmount,
            this.Invoice,
            this.SaleDate});
            this.dgvInvoiceData.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceData.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvInvoiceData.EnableHeadersVisualStyles = false;
            this.dgvInvoiceData.Location = new System.Drawing.Point(15, 193);
            this.dgvInvoiceData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInvoiceData.Name = "dgvInvoiceData";
            this.dgvInvoiceData.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceData.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvInvoiceData.RowHeadersVisible = false;
            this.dgvInvoiceData.RowHeadersWidth = 51;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.dgvInvoiceData.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvInvoiceData.RowTemplate.Height = 24;
            this.dgvInvoiceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceData.Size = new System.Drawing.Size(1031, 265);
            this.dgvInvoiceData.TabIndex = 1;
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(103)))), ((int)(((byte)(108)))));
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnTitle.ForeColor = System.Drawing.Color.White;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Margin = new System.Windows.Forms.Padding(2);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1062, 50);
            this.pnTitle.TabIndex = 27;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Invoice Details";
            // 
            // btnReturnPayment
            // 
            this.btnReturnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnReturnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnPayment.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturnPayment.Location = new System.Drawing.Point(15, 486);
            this.btnReturnPayment.Name = "btnReturnPayment";
            this.btnReturnPayment.Size = new System.Drawing.Size(130, 32);
            this.btnReturnPayment.TabIndex = 2;
            this.btnReturnPayment.Text = "Return Payment";
            this.btnReturnPayment.UseVisualStyleBackColor = false;
            this.btnReturnPayment.Click += new System.EventHandler(this.btnReturnPayment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 61;
            this.label1.Text = "Invoice No.      :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(336, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 62;
            this.label2.Text = "Customer Name     :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 63;
            this.label3.Text = "Staff Name     :";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceNo.Location = new System.Drawing.Point(115, 71);
            this.lblInvoiceNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblInvoiceNo.Size = new System.Drawing.Size(92, 29);
            this.lblInvoiceNo.TabIndex = 64;
            this.lblInvoiceNo.Text = "lblInvoiceNo";
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffName.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.ForeColor = System.Drawing.Color.Black;
            this.lblStaffName.Location = new System.Drawing.Point(115, 129);
            this.lblStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblStaffName.Size = new System.Drawing.Size(98, 29);
            this.lblStaffName.TabIndex = 65;
            this.lblStaffName.Text = "lblStaffName";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(479, 129);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblCustomerName.Size = new System.Drawing.Size(128, 29);
            this.lblCustomerName.TabIndex = 66;
            this.lblCustomerName.Text = "lblCustomerName";
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.AutoSize = true;
            this.lblSaleDate.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleDate.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleDate.ForeColor = System.Drawing.Color.Black;
            this.lblSaleDate.Location = new System.Drawing.Point(479, 71);
            this.lblSaleDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblSaleDate.Size = new System.Drawing.Size(85, 29);
            this.lblSaleDate.TabIndex = 68;
            this.lblSaleDate.Text = "lblSaleDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(336, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.label5.Size = new System.Drawing.Size(139, 29);
            this.label5.TabIndex = 67;
            this.label5.Text = "Sale Date                   :";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(872, 129);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblTotalAmount.Size = new System.Drawing.Size(111, 29);
            this.lblTotalAmount.TabIndex = 70;
            this.lblTotalAmount.Text = "lblTotalAmount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(736, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.label6.Size = new System.Drawing.Size(121, 29);
            this.label6.TabIndex = 69;
            this.label6.Text = "Total Amount     :";
            // 
            // btnGoBacktoSale
            // 
            this.btnGoBacktoSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnGoBacktoSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoBacktoSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBacktoSale.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBacktoSale.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGoBacktoSale.Location = new System.Drawing.Point(916, 486);
            this.btnGoBacktoSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoBacktoSale.Name = "btnGoBacktoSale";
            this.btnGoBacktoSale.Size = new System.Drawing.Size(130, 32);
            this.btnGoBacktoSale.TabIndex = 3;
            this.btnGoBacktoSale.Text = "Back";
            this.btnGoBacktoSale.UseVisualStyleBackColor = false;
            this.btnGoBacktoSale.Click += new System.EventHandler(this.btnGoBacktoSale_Click);
            // 
            // lblSaleTime
            // 
            this.lblSaleTime.AutoSize = true;
            this.lblSaleTime.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleTime.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleTime.ForeColor = System.Drawing.Color.Black;
            this.lblSaleTime.Location = new System.Drawing.Point(872, 71);
            this.lblSaleTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaleTime.Name = "lblSaleTime";
            this.lblSaleTime.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblSaleTime.Size = new System.Drawing.Size(86, 29);
            this.lblSaleTime.TabIndex = 72;
            this.lblSaleTime.Text = "lblSaleTime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(736, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.label7.Size = new System.Drawing.Size(124, 29);
            this.label7.TabIndex = 71;
            this.label7.Text = "Sale Time             :";
            // 
            // No
            // 
            this.No.DataPropertyName = "RowNum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.FillWeight = 72.52538F;
            this.No.HeaderText = "No.";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 80;
            // 
            // SaleID
            // 
            this.SaleID.DataPropertyName = "sale_id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SaleID.DefaultCellStyle = dataGridViewCellStyle3;
            this.SaleID.HeaderText = "SaleID";
            this.SaleID.MinimumWidth = 6;
            this.SaleID.Name = "SaleID";
            this.SaleID.ReadOnly = true;
            this.SaleID.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "StaffName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name.DefaultCellStyle = dataGridViewCellStyle4;
            this.name.FillWeight = 72.52538F;
            this.name.HeaderText = "Staff Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Visible = false;
            // 
            // description
            // 
            this.description.DataPropertyName = "CustomerName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.description.DefaultCellStyle = dataGridViewCellStyle5;
            this.description.FillWeight = 72.52538F;
            this.description.HeaderText = "Customer Name";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle6;
            this.ItemName.FillWeight = 72.52538F;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemName.Width = 398;
            // 
            // price
            // 
            this.price.DataPropertyName = "unit_price";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.price.DefaultCellStyle = dataGridViewCellStyle7;
            this.price.FillWeight = 72.52538F;
            this.price.HeaderText = "UnitPrice";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle8;
            this.Quantity.FillWeight = 72.52538F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SubTotal
            // 
            this.SubTotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SubTotal.Width = 250;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "total_amount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.TotalAmount.DefaultCellStyle = dataGridViewCellStyle10;
            this.TotalAmount.FillWeight = 72.52538F;
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalAmount.Visible = false;
            // 
            // Invoice
            // 
            this.Invoice.DataPropertyName = "invoice_no";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Invoice.DefaultCellStyle = dataGridViewCellStyle11;
            this.Invoice.HeaderText = "Invoice No.";
            this.Invoice.Name = "Invoice";
            this.Invoice.ReadOnly = true;
            this.Invoice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Invoice.Visible = false;
            // 
            // SaleDate
            // 
            this.SaleDate.DataPropertyName = "sale_date";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SaleDate.DefaultCellStyle = dataGridViewCellStyle12;
            this.SaleDate.FillWeight = 72.52538F;
            this.SaleDate.HeaderText = "Sale Date";
            this.SaleDate.MinimumWidth = 6;
            this.SaleDate.Name = "SaleDate";
            this.SaleDate.ReadOnly = true;
            this.SaleDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SaleDate.Visible = false;
            // 
            // UCInvoiceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSaleTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGoBacktoSale);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSaleDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReturnPayment);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.dgvInvoiceData);
            this.Name = "UCInvoiceDetails";
            this.Size = new System.Drawing.Size(1062, 573);
            this.Load += new System.EventHandler(this.UCInvoiceDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceData)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoiceData;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReturnPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGoBacktoSale;
        private System.Windows.Forms.Label lblSaleTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDate;
    }
}
