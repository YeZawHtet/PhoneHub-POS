namespace POS.APP.Views.Sales
{
    partial class ReceiptForm
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
            this.rvReceipt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rvReceipt
            // 
            this.rvReceipt.AllowDrop = true;
            this.rvReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rvReceipt.DocumentMapWidth = 1;
            this.rvReceipt.Location = new System.Drawing.Point(0, 0);
            this.rvReceipt.Name = "rvReceipt";
            this.rvReceipt.ServerReport.BearerToken = null;
            this.rvReceipt.Size = new System.Drawing.Size(621, 500);
            this.rvReceipt.TabIndex = 0;
            this.rvReceipt.Load += new System.EventHandler(this.rvReceipt_Load);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(627, 0);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(157, 511);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Back to Sale";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.rvReceipt);
            this.Name = "ReceiptForm";
            this.Text = "ReceiptForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReceipt;
        private System.Windows.Forms.Button btnDownload;
    }
}