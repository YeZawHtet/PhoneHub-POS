namespace POS.APP.Views.Sales
{
    partial class PaymentForm
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
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.lblClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.BackColor = System.Drawing.Color.Black;
            this.txtPayAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPayAmount.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayAmount.ForeColor = System.Drawing.Color.White;
            this.txtPayAmount.Location = new System.Drawing.Point(2, 9);
            this.txtPayAmount.MaxLength = 10;
            this.txtPayAmount.Multiline = true;
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(208, 33);
            this.txtPayAmount.TabIndex = 1;
            this.txtPayAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPayAmount_KeyDown);
            this.txtPayAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayAmount_KeyPress);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(130)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.Red;
            this.lblClose.Location = new System.Drawing.Point(216, -2);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(42, 55);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(257, 47);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.txtPayAmount);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(580, 270);
            this.Name = "PaymentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PaymentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Label lblClose;
    }
}