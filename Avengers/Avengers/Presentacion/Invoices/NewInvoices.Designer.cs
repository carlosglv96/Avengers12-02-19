namespace Avengers.Presentacion.Invoices
{
    partial class NewInvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewInvoices));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPriceProduct = new System.Windows.Forms.TextBox();
            this.btnAddProdInvoice = new System.Windows.Forms.Button();
            this.lblPriceProduct = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.btnFindProd = new System.Windows.Forms.Button();
            this.lblAmountInvoice = new System.Windows.Forms.Label();
            this.lblProductInvoice = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.btnFindCust = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomerNewInvoice = new System.Windows.Forms.Label();
            this.lblAddProductInvoice = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddLineInvoice = new System.Windows.Forms.Button();
            this.txtPriceLine = new System.Windows.Forms.TextBox();
            this.lblPriceInvoice = new System.Windows.Forms.Label();
            this.nudAmountLine = new System.Windows.Forms.NumericUpDown();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblAmountLine = new System.Windows.Forms.Label();
            this.lblDescriptionInvoice = new System.Windows.Forms.Label();
            this.lblAddLineInvoice = new System.Windows.Forms.Label();
            this.dgvInv = new System.Windows.Forms.DataGridView();
            this.btnRemoveInvoice = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelInvoice = new System.Windows.Forms.Button();
            this.nudRemove = new System.Windows.Forms.NumericUpDown();
            this.txtTotalNeto = new System.Windows.Forms.TextBox();
            this.lblNeto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtPriceProduct);
            this.panel1.Controls.Add(this.btnAddProdInvoice);
            this.panel1.Controls.Add(this.lblPriceProduct);
            this.panel1.Controls.Add(this.nudAmount);
            this.panel1.Controls.Add(this.btnFindProd);
            this.panel1.Controls.Add(this.lblAmountInvoice);
            this.panel1.Controls.Add(this.lblProductInvoice);
            this.panel1.Controls.Add(this.txtProduct);
            this.panel1.Location = new System.Drawing.Point(12, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 153);
            this.panel1.TabIndex = 0;
            // 
            // txtPriceProduct
            // 
            this.txtPriceProduct.Enabled = false;
            this.txtPriceProduct.Location = new System.Drawing.Point(239, 93);
            this.txtPriceProduct.Name = "txtPriceProduct";
            this.txtPriceProduct.Size = new System.Drawing.Size(102, 20);
            this.txtPriceProduct.TabIndex = 35;
            // 
            // btnAddProdInvoice
            // 
            this.btnAddProdInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProdInvoice.Location = new System.Drawing.Point(259, 118);
            this.btnAddProdInvoice.Name = "btnAddProdInvoice";
            this.btnAddProdInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnAddProdInvoice.TabIndex = 34;
            this.btnAddProdInvoice.Text = "Add";
            this.btnAddProdInvoice.UseVisualStyleBackColor = true;
            this.btnAddProdInvoice.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // lblPriceProduct
            // 
            this.lblPriceProduct.AutoSize = true;
            this.lblPriceProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceProduct.Location = new System.Drawing.Point(180, 97);
            this.lblPriceProduct.Name = "lblPriceProduct";
            this.lblPriceProduct.Size = new System.Drawing.Size(48, 16);
            this.lblPriceProduct.TabIndex = 34;
            this.lblPriceProduct.Text = "Price:";
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(106, 93);
            this.nudAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(47, 20);
            this.nudAmount.TabIndex = 29;
            this.nudAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnFindProd
            // 
            this.btnFindProd.Image = ((System.Drawing.Image)(resources.GetObject("btnFindProd.Image")));
            this.btnFindProd.Location = new System.Drawing.Point(280, 19);
            this.btnFindProd.Name = "btnFindProd";
            this.btnFindProd.Size = new System.Drawing.Size(54, 43);
            this.btnFindProd.TabIndex = 28;
            this.btnFindProd.UseVisualStyleBackColor = true;
            this.btnFindProd.Click += new System.EventHandler(this.btnFindProd_Click);
            // 
            // lblAmountInvoice
            // 
            this.lblAmountInvoice.AutoSize = true;
            this.lblAmountInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInvoice.Location = new System.Drawing.Point(24, 97);
            this.lblAmountInvoice.Name = "lblAmountInvoice";
            this.lblAmountInvoice.Size = new System.Drawing.Size(63, 16);
            this.lblAmountInvoice.TabIndex = 26;
            this.lblAmountInvoice.Text = "Amount:";
            // 
            // lblProductInvoice
            // 
            this.lblProductInvoice.AutoSize = true;
            this.lblProductInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInvoice.Location = new System.Drawing.Point(22, 36);
            this.lblProductInvoice.Name = "lblProductInvoice";
            this.lblProductInvoice.Size = new System.Drawing.Size(65, 16);
            this.lblProductInvoice.TabIndex = 24;
            this.lblProductInvoice.Text = "Product:";
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(93, 36);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(165, 20);
            this.txtProduct.TabIndex = 25;
            // 
            // btnFindCust
            // 
            this.btnFindCust.Image = ((System.Drawing.Image)(resources.GetObject("btnFindCust.Image")));
            this.btnFindCust.Location = new System.Drawing.Point(338, 15);
            this.btnFindCust.Name = "btnFindCust";
            this.btnFindCust.Size = new System.Drawing.Size(54, 45);
            this.btnFindCust.TabIndex = 23;
            this.btnFindCust.UseVisualStyleBackColor = true;
            this.btnFindCust.Click += new System.EventHandler(this.btnFindCust_Click_1);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(120, 30);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(198, 20);
            this.txtCustomer.TabIndex = 22;
            // 
            // lblCustomerNewInvoice
            // 
            this.lblCustomerNewInvoice.AutoSize = true;
            this.lblCustomerNewInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNewInvoice.Location = new System.Drawing.Point(37, 30);
            this.lblCustomerNewInvoice.Name = "lblCustomerNewInvoice";
            this.lblCustomerNewInvoice.Size = new System.Drawing.Size(77, 16);
            this.lblCustomerNewInvoice.TabIndex = 21;
            this.lblCustomerNewInvoice.Text = "Customer:";
            // 
            // lblAddProductInvoice
            // 
            this.lblAddProductInvoice.AutoSize = true;
            this.lblAddProductInvoice.Location = new System.Drawing.Point(12, 74);
            this.lblAddProductInvoice.Name = "lblAddProductInvoice";
            this.lblAddProductInvoice.Size = new System.Drawing.Size(66, 13);
            this.lblAddProductInvoice.TabIndex = 0;
            this.lblAddProductInvoice.Text = "Add Product";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnAddLineInvoice);
            this.panel2.Controls.Add(this.txtPriceLine);
            this.panel2.Controls.Add(this.lblPriceInvoice);
            this.panel2.Controls.Add(this.nudAmountLine);
            this.panel2.Controls.Add(this.txtDesc);
            this.panel2.Controls.Add(this.lblAmountLine);
            this.panel2.Controls.Add(this.lblDescriptionInvoice);
            this.panel2.Location = new System.Drawing.Point(397, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 153);
            this.panel2.TabIndex = 24;
            // 
            // btnAddLineInvoice
            // 
            this.btnAddLineInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLineInvoice.Location = new System.Drawing.Point(235, 118);
            this.btnAddLineInvoice.Name = "btnAddLineInvoice";
            this.btnAddLineInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnAddLineInvoice.TabIndex = 30;
            this.btnAddLineInvoice.Text = "Add";
            this.btnAddLineInvoice.UseVisualStyleBackColor = true;
            this.btnAddLineInvoice.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // txtPriceLine
            // 
            this.txtPriceLine.Location = new System.Drawing.Point(208, 93);
            this.txtPriceLine.Name = "txtPriceLine";
            this.txtPriceLine.Size = new System.Drawing.Size(102, 20);
            this.txtPriceLine.TabIndex = 33;
            // 
            // lblPriceInvoice
            // 
            this.lblPriceInvoice.AutoSize = true;
            this.lblPriceInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceInvoice.Location = new System.Drawing.Point(149, 97);
            this.lblPriceInvoice.Name = "lblPriceInvoice";
            this.lblPriceInvoice.Size = new System.Drawing.Size(48, 16);
            this.lblPriceInvoice.TabIndex = 32;
            this.lblPriceInvoice.Text = "Price:";
            // 
            // nudAmountLine
            // 
            this.nudAmountLine.Location = new System.Drawing.Point(84, 94);
            this.nudAmountLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmountLine.Name = "nudAmountLine";
            this.nudAmountLine.Size = new System.Drawing.Size(47, 20);
            this.nudAmountLine.TabIndex = 31;
            this.nudAmountLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(112, 31);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(196, 56);
            this.txtDesc.TabIndex = 27;
            // 
            // lblAmountLine
            // 
            this.lblAmountLine.AutoSize = true;
            this.lblAmountLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountLine.Location = new System.Drawing.Point(15, 97);
            this.lblAmountLine.Name = "lblAmountLine";
            this.lblAmountLine.Size = new System.Drawing.Size(63, 16);
            this.lblAmountLine.TabIndex = 30;
            this.lblAmountLine.Text = "Amount:";
            // 
            // lblDescriptionInvoice
            // 
            this.lblDescriptionInvoice.AutoSize = true;
            this.lblDescriptionInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionInvoice.Location = new System.Drawing.Point(15, 31);
            this.lblDescriptionInvoice.Name = "lblDescriptionInvoice";
            this.lblDescriptionInvoice.Size = new System.Drawing.Size(91, 16);
            this.lblDescriptionInvoice.TabIndex = 26;
            this.lblDescriptionInvoice.Text = "Description:";
            // 
            // lblAddLineInvoice
            // 
            this.lblAddLineInvoice.AutoSize = true;
            this.lblAddLineInvoice.Location = new System.Drawing.Point(394, 74);
            this.lblAddLineInvoice.Name = "lblAddLineInvoice";
            this.lblAddLineInvoice.Size = new System.Drawing.Size(49, 13);
            this.lblAddLineInvoice.TabIndex = 25;
            this.lblAddLineInvoice.Text = "Add Line";
            // 
            // dgvInv
            // 
            this.dgvInv.AllowUserToAddRows = false;
            this.dgvInv.AllowUserToDeleteRows = false;
            this.dgvInv.AllowUserToResizeColumns = false;
            this.dgvInv.AllowUserToResizeRows = false;
            this.dgvInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInv.Location = new System.Drawing.Point(15, 262);
            this.dgvInv.Name = "dgvInv";
            this.dgvInv.RowHeadersVisible = false;
            this.dgvInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInv.Size = new System.Drawing.Size(712, 245);
            this.dgvInv.TabIndex = 26;
            // 
            // btnRemoveInvoice
            // 
            this.btnRemoveInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveInvoice.Location = new System.Drawing.Point(735, 320);
            this.btnRemoveInvoice.Name = "btnRemoveInvoice";
            this.btnRemoveInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveInvoice.TabIndex = 27;
            this.btnRemoveInvoice.Text = "Remove";
            this.btnRemoveInvoice.UseVisualStyleBackColor = true;
            this.btnRemoveInvoice.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(735, 550);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(81, 20);
            this.txtTotal.TabIndex = 31;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(670, 550);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 16);
            this.lblTotal.TabIndex = 30;
            this.lblTotal.Text = "Total:";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(748, 585);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelInvoice
            // 
            this.btnCancelInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelInvoice.Location = new System.Drawing.Point(620, 585);
            this.btnCancelInvoice.Name = "btnCancelInvoice";
            this.btnCancelInvoice.Size = new System.Drawing.Size(85, 23);
            this.btnCancelInvoice.TabIndex = 28;
            this.btnCancelInvoice.Text = "Cancel";
            this.btnCancelInvoice.UseVisualStyleBackColor = true;
            this.btnCancelInvoice.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudRemove
            // 
            this.nudRemove.Location = new System.Drawing.Point(735, 294);
            this.nudRemove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRemove.Name = "nudRemove";
            this.nudRemove.Size = new System.Drawing.Size(47, 20);
            this.nudRemove.TabIndex = 36;
            this.nudRemove.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTotalNeto
            // 
            this.txtTotalNeto.Enabled = false;
            this.txtTotalNeto.Location = new System.Drawing.Point(574, 550);
            this.txtTotalNeto.Name = "txtTotalNeto";
            this.txtTotalNeto.Size = new System.Drawing.Size(81, 20);
            this.txtTotalNeto.TabIndex = 37;
            // 
            // lblNeto
            // 
            this.lblNeto.AutoSize = true;
            this.lblNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeto.Location = new System.Drawing.Point(471, 554);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(85, 16);
            this.lblNeto.TabIndex = 38;
            this.lblNeto.Text = "Total Neto:";
            // 
            // NewInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 631);
            this.Controls.Add(this.lblNeto);
            this.Controls.Add(this.txtTotalNeto);
            this.Controls.Add(this.nudRemove);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelInvoice);
            this.Controls.Add(this.btnRemoveInvoice);
            this.Controls.Add(this.dgvInv);
            this.Controls.Add(this.lblAddLineInvoice);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblAddProductInvoice);
            this.Controls.Add(this.btnFindCust);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomerNewInvoice);
            this.Name = "NewInvoices";
            this.Text = "NewInvoices";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFindCust;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomerNewInvoice;
        private System.Windows.Forms.Label lblAddProductInvoice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Button btnFindProd;
        private System.Windows.Forms.Label lblAmountInvoice;
        private System.Windows.Forms.Label lblProductInvoice;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAddLineInvoice;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDescriptionInvoice;
        private System.Windows.Forms.NumericUpDown nudAmountLine;
        private System.Windows.Forms.Label lblAmountLine;
        private System.Windows.Forms.Label lblPriceInvoice;
        private System.Windows.Forms.TextBox txtPriceLine;
        private System.Windows.Forms.Button btnAddLineInvoice;
        private System.Windows.Forms.Button btnAddProdInvoice;
        private System.Windows.Forms.DataGridView dgvInv;
        private System.Windows.Forms.Button btnRemoveInvoice;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelInvoice;
        private System.Windows.Forms.TextBox txtPriceProduct;
        private System.Windows.Forms.Label lblPriceProduct;
        private System.Windows.Forms.NumericUpDown nudRemove;
        private System.Windows.Forms.TextBox txtTotalNeto;
        private System.Windows.Forms.Label lblNeto;
    }
}