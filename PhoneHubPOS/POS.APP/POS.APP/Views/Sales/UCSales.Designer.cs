namespace POS.APP.Views.Sales
{
    partial class UCSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSales));
            this.btnAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnValueAdd = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnValueRemove = new System.Windows.Forms.Button();
            this.cboChooseProduct = new System.Windows.Forms.ComboBox();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.lblPayment = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChooseCustomer = new System.Windows.Forms.ComboBox();
            this.txtAvailableQuantity = new System.Windows.Forms.TextBox();
            this.btnReturnPayment = new System.Windows.Forms.Button();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvSaleProduct = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Transparent;
            this.btnAdd.Location = new System.Drawing.Point(690, 218);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 32);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(689, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 15);
            this.label11.TabIndex = 56;
            this.label11.Text = "Product Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(88, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Summary";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(145, 92);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(14, 15);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(116, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 19);
            this.label16.TabIndex = 0;
            this.label16.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(116, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 19);
            this.label15.TabIndex = 0;
            this.label15.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total Amount";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(353, 149);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 15);
            this.label18.TabIndex = 57;
            this.label18.Text = "Price";
            // 
            // btnValueAdd
            // 
            this.btnValueAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnValueAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValueAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValueAdd.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValueAdd.ForeColor = System.Drawing.Color.Transparent;
            this.btnValueAdd.Location = new System.Drawing.Point(952, 162);
            this.btnValueAdd.Name = "btnValueAdd";
            this.btnValueAdd.Size = new System.Drawing.Size(40, 32);
            this.btnValueAdd.TabIndex = 7;
            this.btnValueAdd.Text = "+";
            this.btnValueAdd.UseVisualStyleBackColor = false;
            this.btnValueAdd.Click += new System.EventHandler(this.btnValueAdd_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(355, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 15);
            this.label12.TabIndex = 61;
            this.label12.Text = "Choose Product";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(11, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 15);
            this.label13.TabIndex = 62;
            this.label13.Text = "Available Quantity";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(787, 218);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 32);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnValueRemove
            // 
            this.btnValueRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnValueRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValueRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValueRemove.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValueRemove.ForeColor = System.Drawing.Color.Transparent;
            this.btnValueRemove.Location = new System.Drawing.Point(998, 162);
            this.btnValueRemove.Name = "btnValueRemove";
            this.btnValueRemove.Size = new System.Drawing.Size(40, 32);
            this.btnValueRemove.TabIndex = 8;
            this.btnValueRemove.Text = "-";
            this.btnValueRemove.UseVisualStyleBackColor = false;
            this.btnValueRemove.Click += new System.EventHandler(this.btnValueRemove_Click);
            // 
            // cboChooseProduct
            // 
            this.cboChooseProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboChooseProduct.DropDownHeight = 150;
            this.cboChooseProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChooseProduct.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChooseProduct.FormattingEnabled = true;
            this.cboChooseProduct.IntegralHeight = false;
            this.cboChooseProduct.Location = new System.Drawing.Point(358, 95);
            this.cboChooseProduct.Name = "cboChooseProduct";
            this.cboChooseProduct.Size = new System.Drawing.Size(250, 23);
            this.cboChooseProduct.TabIndex = 2;
            this.cboChooseProduct.SelectedIndexChanged += new System.EventHandler(this.cboChooseProduct_SelectedIndexChanged);
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.Location = new System.Drawing.Point(145, 46);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(14, 15);
            this.lblTotalItems.TabIndex = 0;
            this.lblTotalItems.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Items";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(356, 167);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(250, 23);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(689, 168);
            this.txtQuantity.MaxLength = 10;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(250, 23);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(691, 96);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 23);
            this.txtProductName.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Roboto", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(10, 531);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(112, 23);
            this.lblDate.TabIndex = 66;
            this.lblDate.Text = "2023/10/01";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(686, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 59;
            this.label5.Text = "Quantity";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnPayment);
            this.panel1.Controls.Add(this.lblPayment);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblTotalItems);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(789, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 247);
            this.panel1.TabIndex = 76;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.Transparent;
            this.btnPayment.Location = new System.Drawing.Point(52, 184);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(154, 32);
            this.btnPayment.TabIndex = 11;
            this.btnPayment.Text = "Payment && Receipt";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.Location = new System.Drawing.Point(145, 137);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(14, 15);
            this.lblPayment.TabIndex = 0;
            this.lblPayment.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(116, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Payment";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 58;
            this.label3.Text = "Choose Customer";
            // 
            // cboChooseCustomer
            // 
            this.cboChooseCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboChooseCustomer.DropDownHeight = 150;
            this.cboChooseCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChooseCustomer.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChooseCustomer.FormattingEnabled = true;
            this.cboChooseCustomer.IntegralHeight = false;
            this.cboChooseCustomer.Location = new System.Drawing.Point(14, 96);
            this.cboChooseCustomer.Name = "cboChooseCustomer";
            this.cboChooseCustomer.Size = new System.Drawing.Size(250, 23);
            this.cboChooseCustomer.TabIndex = 1;
            this.cboChooseCustomer.SelectedIndexChanged += new System.EventHandler(this.cboChooseCustomer_SelectedIndexChanged);
            // 
            // txtAvailableQuantity
            // 
            this.txtAvailableQuantity.Enabled = false;
            this.txtAvailableQuantity.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvailableQuantity.Location = new System.Drawing.Point(12, 167);
            this.txtAvailableQuantity.Name = "txtAvailableQuantity";
            this.txtAvailableQuantity.Size = new System.Drawing.Size(250, 23);
            this.txtAvailableQuantity.TabIndex = 4;
            this.txtAvailableQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAvailableQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtAvailableQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // btnReturnPayment
            // 
            this.btnReturnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnReturnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnPayment.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnPayment.ForeColor = System.Drawing.Color.Transparent;
            this.btnReturnPayment.Location = new System.Drawing.Point(12, 217);
            this.btnReturnPayment.Name = "btnReturnPayment";
            this.btnReturnPayment.Size = new System.Drawing.Size(130, 32);
            this.btnReturnPayment.TabIndex = 78;
            this.btnReturnPayment.Text = "Return Payment";
            this.btnReturnPayment.UseVisualStyleBackColor = false;
            this.btnReturnPayment.Click += new System.EventHandler(this.btnReturnPayment_Click);
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(103)))), ((int)(((byte)(108)))));
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1062, 50);
            this.pnTitle.TabIndex = 79;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(7, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sales";
            // 
            // dgvSaleProduct
            // 
            this.dgvSaleProduct.AllowUserToAddRows = false;
            this.dgvSaleProduct.AllowUserToResizeColumns = false;
            this.dgvSaleProduct.AllowUserToResizeRows = false;
            this.dgvSaleProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.dgvSaleProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSaleProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ProductName,
            this.Description,
            this.Price,
            this.Qty,
            this.SubTotal,
            this.Remove});
            this.dgvSaleProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleProduct.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvSaleProduct.EnableHeadersVisualStyles = false;
            this.dgvSaleProduct.Location = new System.Drawing.Point(12, 269);
            this.dgvSaleProduct.Name = "dgvSaleProduct";
            this.dgvSaleProduct.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvSaleProduct.RowHeadersVisible = false;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSaleProduct.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvSaleProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleProduct.Size = new System.Drawing.Size(763, 247);
            this.dgvSaleProduct.TabIndex = 80;
            this.dgvSaleProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleProduct_CellContentClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle12;
            this.No.FillWeight = 324.8731F;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 70;
            // 
            // ProductName
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle13;
            this.ProductName.FillWeight = 1.47182F;
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductName.Width = 150;
            // 
            // Description
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Description.DefaultCellStyle = dataGridViewCellStyle14;
            this.Description.FillWeight = 1.47182F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Description.Width = 200;
            // 
            // Price
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle15;
            this.Price.FillWeight = 24.13784F;
            this.Price.HeaderText = "Unit Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Qty
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle16;
            this.Qty.FillWeight = 148.0454F;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Qty.Width = 70;
            // 
            // SubTotal
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = null;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle17;
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Remove";
            this.Remove.Image = ((System.Drawing.Image)(resources.GetObject("Remove.Image")));
            this.Remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remove.Width = 70;
            // 
            // UCSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.dgvSaleProduct);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.btnReturnPayment);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnValueAdd);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnValueRemove);
            this.Controls.Add(this.cboChooseCustomer);
            this.Controls.Add(this.cboChooseProduct);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtAvailableQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "UCSales";
            this.Size = new System.Drawing.Size(1062, 573);
            this.Load += new System.EventHandler(this.UCSales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnValueAdd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnValueRemove;
        private System.Windows.Forms.ComboBox cboChooseProduct;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboChooseCustomer;
        private System.Windows.Forms.TextBox txtAvailableQuantity;
        private System.Windows.Forms.Button btnReturnPayment;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvSaleProduct;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
    }
}
