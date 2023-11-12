namespace POS.APP.Views.MainPOS
{
    partial class FrmMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesCRUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCRUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesCRUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffCRUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerCRUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierCRUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnUC = new System.Windows.Forms.Panel();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.purchasesToolStripMenuItem,
            this.staffToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 50, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(160, 606);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip2";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.dashboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashboardToolStripMenuItem.Image")));
            this.dashboardToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 50, 5, 10);
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(133, 43);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesCRUDToolStripMenuItem,
            this.salesListingToolStripMenuItem});
            this.salesToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salesToolStripMenuItem.Image")));
            this.salesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.salesToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(133, 43);
            this.salesToolStripMenuItem.Text = "Sales         ";
            // 
            // salesCRUDToolStripMenuItem
            // 
            this.salesCRUDToolStripMenuItem.Name = "salesCRUDToolStripMenuItem";
            this.salesCRUDToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.salesCRUDToolStripMenuItem.Text = "Sales Item";
            this.salesCRUDToolStripMenuItem.Click += new System.EventHandler(this.salesCRUDToolStripMenuItem_Click);
            // 
            // salesListingToolStripMenuItem
            // 
            this.salesListingToolStripMenuItem.Name = "salesListingToolStripMenuItem";
            this.salesListingToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.salesListingToolStripMenuItem.Text = "Sales Listing";
            this.salesListingToolStripMenuItem.Click += new System.EventHandler(this.salesListingToolStripMenuItem_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.itemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCRUDToolStripMenuItem,
            this.itemListingToolStripMenuItem,
            this.categoryToolStripMenuItem,
            this.categoryListingToolStripMenuItem});
            this.itemToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.itemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("itemToolStripMenuItem.Image")));
            this.itemToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(135, 43);
            this.itemToolStripMenuItem.Text = "Item           ";
            // 
            // itemCRUDToolStripMenuItem
            // 
            this.itemCRUDToolStripMenuItem.Name = "itemCRUDToolStripMenuItem";
            this.itemCRUDToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.itemCRUDToolStripMenuItem.Text = "Item";
            this.itemCRUDToolStripMenuItem.Click += new System.EventHandler(this.itemCRUDToolStripMenuItem_Click);
            // 
            // itemListingToolStripMenuItem
            // 
            this.itemListingToolStripMenuItem.Name = "itemListingToolStripMenuItem";
            this.itemListingToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.itemListingToolStripMenuItem.Text = "Item Listing";
            this.itemListingToolStripMenuItem.Click += new System.EventHandler(this.itemListingToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // categoryListingToolStripMenuItem
            // 
            this.categoryListingToolStripMenuItem.AutoSize = false;
            this.categoryListingToolStripMenuItem.Name = "categoryListingToolStripMenuItem";
            this.categoryListingToolStripMenuItem.Size = new System.Drawing.Size(217, 28);
            this.categoryListingToolStripMenuItem.Text = "Category Listing";
            this.categoryListingToolStripMenuItem.Click += new System.EventHandler(this.categoryListingToolStripMenuItem_Click);
            // 
            // purchasesToolStripMenuItem
            // 
            this.purchasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchasesCRUDToolStripMenuItem,
            this.purchasesListingToolStripMenuItem});
            this.purchasesToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("purchasesToolStripMenuItem.Image")));
            this.purchasesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.purchasesToolStripMenuItem.Name = "purchasesToolStripMenuItem";
            this.purchasesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.purchasesToolStripMenuItem.Size = new System.Drawing.Size(135, 43);
            this.purchasesToolStripMenuItem.Text = "Purchase   ";
            // 
            // purchasesCRUDToolStripMenuItem
            // 
            this.purchasesCRUDToolStripMenuItem.Name = "purchasesCRUDToolStripMenuItem";
            this.purchasesCRUDToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.purchasesCRUDToolStripMenuItem.Text = "Purchase Item";
            this.purchasesCRUDToolStripMenuItem.Click += new System.EventHandler(this.purchasesCRUDToolStripMenuItem_Click);
            // 
            // purchasesListingToolStripMenuItem
            // 
            this.purchasesListingToolStripMenuItem.Name = "purchasesListingToolStripMenuItem";
            this.purchasesListingToolStripMenuItem.Size = new System.Drawing.Size(230, 28);
            this.purchasesListingToolStripMenuItem.Text = "Purchases Listing";
            this.purchasesListingToolStripMenuItem.Click += new System.EventHandler(this.purchasesListingToolStripMenuItem_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffCRUDToolStripMenuItem,
            this.staffListingToolStripMenuItem});
            this.staffToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("staffToolStripMenuItem.Image")));
            this.staffToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(133, 43);
            this.staffToolStripMenuItem.Text = "Staff          ";
            // 
            // staffCRUDToolStripMenuItem
            // 
            this.staffCRUDToolStripMenuItem.Name = "staffCRUDToolStripMenuItem";
            this.staffCRUDToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.staffCRUDToolStripMenuItem.Text = "Staff";
            this.staffCRUDToolStripMenuItem.Click += new System.EventHandler(this.staffCRUDToolStripMenuItem_Click);
            // 
            // staffListingToolStripMenuItem
            // 
            this.staffListingToolStripMenuItem.Name = "staffListingToolStripMenuItem";
            this.staffListingToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.staffListingToolStripMenuItem.Text = "Staff Listing";
            this.staffListingToolStripMenuItem.Click += new System.EventHandler(this.staffListingToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerCRUDToolStripMenuItem,
            this.customerListingToolStripMenuItem});
            this.customerToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.customerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("customerToolStripMenuItem.Image")));
            this.customerToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(134, 43);
            this.customerToolStripMenuItem.Text = "Customer  ";
            // 
            // customerCRUDToolStripMenuItem
            // 
            this.customerCRUDToolStripMenuItem.Name = "customerCRUDToolStripMenuItem";
            this.customerCRUDToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.customerCRUDToolStripMenuItem.Text = "Customer";
            this.customerCRUDToolStripMenuItem.Click += new System.EventHandler(this.customerCRUDToolStripMenuItem_Click);
            // 
            // customerListingToolStripMenuItem
            // 
            this.customerListingToolStripMenuItem.Name = "customerListingToolStripMenuItem";
            this.customerListingToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.customerListingToolStripMenuItem.Text = "Customer Listing";
            this.customerListingToolStripMenuItem.Click += new System.EventHandler(this.customerListingToolStripMenuItem_Click);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierCRUDToolStripMenuItem,
            this.supplierListingToolStripMenuItem});
            this.supplierToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14.25F);
            this.supplierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("supplierToolStripMenuItem.Image")));
            this.supplierToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(136, 43);
            this.supplierToolStripMenuItem.Text = "Supplier     ";
            // 
            // supplierCRUDToolStripMenuItem
            // 
            this.supplierCRUDToolStripMenuItem.Name = "supplierCRUDToolStripMenuItem";
            this.supplierCRUDToolStripMenuItem.Size = new System.Drawing.Size(211, 28);
            this.supplierCRUDToolStripMenuItem.Text = "Supplier";
            this.supplierCRUDToolStripMenuItem.Click += new System.EventHandler(this.supplierCRUDToolStripMenuItem_Click);
            // 
            // supplierListingToolStripMenuItem
            // 
            this.supplierListingToolStripMenuItem.Name = "supplierListingToolStripMenuItem";
            this.supplierListingToolStripMenuItem.Size = new System.Drawing.Size(211, 28);
            this.supplierListingToolStripMenuItem.Text = "Supplier Listing";
            this.supplierListingToolStripMenuItem.Click += new System.EventHandler(this.supplierListingToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 14F);
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 30, 10, 0);
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(128, 43);
            this.logoutToolStripMenuItem.Text = "LogOut     ";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // pnUC
            // 
            this.pnUC.Location = new System.Drawing.Point(163, 0);
            this.pnUC.Name = "pnUC";
            this.pnUC.Size = new System.Drawing.Size(1062, 573);
            this.pnUC.TabIndex = 11;
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoEllipsis = true;
            this.lblStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.lblStaffName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStaffName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.Location = new System.Drawing.Point(0, 0);
            this.lblStaffName.Margin = new System.Windows.Forms.Padding(3, 15, 3, 10);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(145, 42);
            this.lblStaffName.TabIndex = 13;
            this.lblStaffName.Text = "Staff Name\r\n";
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.panel1.Controls.Add(this.lblStaffName);
            this.panel1.Location = new System.Drawing.Point(12, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 42);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(51, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(1228, 606);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnUC);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemCRUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesCRUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesCRUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffCRUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerCRUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierCRUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryListingToolStripMenuItem;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel pnUC;
    }
}