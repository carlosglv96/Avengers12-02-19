namespace Avengers.Presentacion.Invoices
{
    partial class showContent
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
            this.dgvInv = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInv
            // 
            this.dgvInv.AllowUserToAddRows = false;
            this.dgvInv.AllowUserToResizeColumns = false;
            this.dgvInv.AllowUserToResizeRows = false;
            this.dgvInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInv.Location = new System.Drawing.Point(12, 130);
            this.dgvInv.Name = "dgvInv";
            this.dgvInv.RowHeadersVisible = false;
            this.dgvInv.Size = new System.Drawing.Size(589, 361);
            this.dgvInv.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(517, 527);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 29);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.Location = new System.Drawing.Point(22, 23);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(81, 16);
            this.lblInvoice.TabIndex = 2;
            this.lblInvoice.Text = "ID Invoice:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(22, 91);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(77, 16);
            this.lblCustomer.TabIndex = 3;
            this.lblCustomer.Text = "Customer:";
            // 
            // txtInvoice
            // 
            this.txtInvoice.AutoSize = true;
            this.txtInvoice.Location = new System.Drawing.Point(122, 26);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(16, 13);
            this.txtInvoice.TabIndex = 4;
            this.txtInvoice.Text = "Id";
            // 
            // txtCustomer
            // 
            this.txtCustomer.AutoSize = true;
            this.txtCustomer.Location = new System.Drawing.Point(122, 91);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(51, 13);
            this.txtCustomer.TabIndex = 5;
            this.txtCustomer.Text = "Customer";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(22, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(99, 16);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date Invoice:";
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Location = new System.Drawing.Point(122, 58);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(30, 13);
            this.txtDate.TabIndex = 7;
            this.txtDate.Text = "Date";
            // 
            // showContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 581);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvInv);
            this.Name = "showContent";
            this.Text = "showContent";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInv;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label txtInvoice;
        private System.Windows.Forms.Label txtCustomer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label txtDate;
    }
}