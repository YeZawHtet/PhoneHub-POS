namespace POS.APP.Views.Supplier
{
    partial class UCSupplierList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnADD = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblTwo = new System.Windows.Forms.Label();
            this.lblOf = new System.Windows.Forms.Label();
            this.lblOne = new System.Windows.Forms.Label();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.pnTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLast.Location = new System.Drawing.Point(692, 461);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(80, 32);
            this.btnLast.TabIndex = 8;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(237, 116);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 32);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Clear";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(16, 120);
            this.txtSearch.MaxLength = 30;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnADD
            // 
            this.btnADD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnADD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnADD.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADD.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnADD.Location = new System.Drawing.Point(929, 114);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(120, 32);
            this.btnADD.TabIndex = 63;
            this.btnADD.Text = "Add";
            this.btnADD.UseVisualStyleBackColor = false;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFirst.Location = new System.Drawing.Point(274, 461);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(80, 32);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDownload.Location = new System.Drawing.Point(14, 461);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(120, 32);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpload.Location = new System.Drawing.Point(929, 456);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(120, 32);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Location = new System.Drawing.Point(606, 461);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 32);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrevious.Location = new System.Drawing.Point(360, 461);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(80, 32);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblTwo
            // 
            this.lblTwo.AutoSize = true;
            this.lblTwo.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTwo.Location = new System.Drawing.Point(568, 468);
            this.lblTwo.Name = "lblTwo";
            this.lblTwo.Size = new System.Drawing.Size(17, 18);
            this.lblTwo.TabIndex = 58;
            this.lblTwo.Text = "0";
            // 
            // lblOf
            // 
            this.lblOf.AutoSize = true;
            this.lblOf.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOf.Location = new System.Drawing.Point(539, 468);
            this.lblOf.Name = "lblOf";
            this.lblOf.Size = new System.Drawing.Size(23, 18);
            this.lblOf.TabIndex = 57;
            this.lblOf.Text = "Of";
            // 
            // lblOne
            // 
            this.lblOne.AutoSize = true;
            this.lblOne.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOne.Location = new System.Drawing.Point(516, 468);
            this.lblOne.Name = "lblOne";
            this.lblOne.Size = new System.Drawing.Size(17, 18);
            this.lblOne.TabIndex = 56;
            this.lblOne.Text = "0";
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.AllowUserToAddRows = false;
            this.dgvSupplier.AllowUserToDeleteRows = false;
            this.dgvSupplier.AllowUserToResizeColumns = false;
            this.dgvSupplier.AllowUserToResizeRows = false;
            this.dgvSupplier.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.dgvSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.SupplierID,
            this.supplier_name,
            this.Phone,
            this.Email,
            this.Address});
            this.dgvSupplier.EnableHeadersVisualStyles = false;
            this.dgvSupplier.Location = new System.Drawing.Point(16, 166);
            this.dgvSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            this.dgvSupplier.RowHeadersVisible = false;
            this.dgvSupplier.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSupplier.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSupplier.RowTemplate.Height = 24;
            this.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplier.Size = new System.Drawing.Size(1033, 265);
            this.dgvSupplier.TabIndex = 3;
            this.dgvSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellDoubleClick);
            // 
            // No
            // 
            this.No.DataPropertyName = "SerialNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.FillWeight = 253.8071F;
            this.No.HeaderText = "No.";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SupplierID
            // 
            this.SupplierID.DataPropertyName = "supplier_id";
            this.SupplierID.HeaderText = "SupplierID";
            this.SupplierID.MinimumWidth = 6;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            this.SupplierID.Visible = false;
            this.SupplierID.Width = 200;
            // 
            // supplier_name
            // 
            this.supplier_name.DataPropertyName = "name";
            this.supplier_name.FillWeight = 243.4031F;
            this.supplier_name.HeaderText = "Name";
            this.supplier_name.MinimumWidth = 6;
            this.supplier_name.Name = "supplier_name";
            this.supplier_name.ReadOnly = true;
            this.supplier_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.supplier_name.Width = 200;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "phone";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Phone.DefaultCellStyle = dataGridViewCellStyle3;
            this.Phone.FillWeight = 0.02590317F;
            this.Phone.HeaderText = "Phone Number";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Phone.Width = 200;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "email";
            this.Email.FillWeight = 0.2547718F;
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Email.Width = 200;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "address";
            this.Address.FillWeight = 2.509128F;
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Address.Width = 330;
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(103)))), ((int)(((byte)(108)))));
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1062, 50);
            this.pnTitle.TabIndex = 69;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(11, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(127, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Supplier List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 70;
            this.label1.Text = "Search Here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "Page";
            // 
            // UCSupplierList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblTwo);
            this.Controls.Add(this.lblOf);
            this.Controls.Add(this.lblOne);
            this.Controls.Add(this.dgvSupplier);
            this.Name = "UCSupplierList";
            this.Size = new System.Drawing.Size(1062, 573);
            this.Load += new System.EventHandler(this.UCSupplierList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblTwo;
        private System.Windows.Forms.Label lblOf;
        private System.Windows.Forms.Label lblOne;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}
