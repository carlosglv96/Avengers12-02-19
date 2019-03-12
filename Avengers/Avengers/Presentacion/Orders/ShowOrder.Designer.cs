namespace Avengers.Presentacion.Orders
{
    partial class ShowOrder
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
            this.lblPedido = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSetPedido = new System.Windows.Forms.Label();
            this.lblSetDate = new System.Windows.Forms.Label();
            this.lblSetCustomer = new System.Windows.Forms.Label();
            this.lblSetPay = new System.Windows.Forms.Label();
            this.lblSetTotal = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.Location = new System.Drawing.Point(25, 23);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(87, 17);
            this.lblPedido.TabIndex = 0;
            this.lblPedido.Text = "N PEDIDO:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(25, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(63, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "FECHA:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(287, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(77, 17);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "CLIENTE:";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPago.Location = new System.Drawing.Point(287, 57);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(116, 17);
            this.lblPago.TabIndex = 3;
            this.lblPago.Text = "FORMA PAGO:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(287, 96);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(64, 17);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "TOTAL:";
            // 
            // lblSetPedido
            // 
            this.lblSetPedido.AutoSize = true;
            this.lblSetPedido.Location = new System.Drawing.Point(129, 27);
            this.lblSetPedido.Name = "lblSetPedido";
            this.lblSetPedido.Size = new System.Drawing.Size(35, 13);
            this.lblSetPedido.TabIndex = 5;
            this.lblSetPedido.Text = "label1";
            // 
            // lblSetDate
            // 
            this.lblSetDate.AutoSize = true;
            this.lblSetDate.Location = new System.Drawing.Point(129, 61);
            this.lblSetDate.Name = "lblSetDate";
            this.lblSetDate.Size = new System.Drawing.Size(35, 13);
            this.lblSetDate.TabIndex = 6;
            this.lblSetDate.Text = "label2";
            // 
            // lblSetCustomer
            // 
            this.lblSetCustomer.AutoSize = true;
            this.lblSetCustomer.Location = new System.Drawing.Point(419, 27);
            this.lblSetCustomer.Name = "lblSetCustomer";
            this.lblSetCustomer.Size = new System.Drawing.Size(35, 13);
            this.lblSetCustomer.TabIndex = 7;
            this.lblSetCustomer.Text = "label3";
            // 
            // lblSetPay
            // 
            this.lblSetPay.AutoSize = true;
            this.lblSetPay.Location = new System.Drawing.Point(419, 61);
            this.lblSetPay.Name = "lblSetPay";
            this.lblSetPay.Size = new System.Drawing.Size(35, 13);
            this.lblSetPay.TabIndex = 8;
            this.lblSetPay.Text = "label4";
            // 
            // lblSetTotal
            // 
            this.lblSetTotal.AutoSize = true;
            this.lblSetTotal.Location = new System.Drawing.Point(419, 98);
            this.lblSetTotal.Name = "lblSetTotal";
            this.lblSetTotal.Size = new System.Drawing.Size(35, 13);
            this.lblSetTotal.TabIndex = 9;
            this.lblSetTotal.Text = "label5";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeColumns = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 143);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(612, 279);
            this.dgvOrders.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(535, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 517);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.lblSetTotal);
            this.Controls.Add(this.lblSetPay);
            this.Controls.Add(this.lblSetCustomer);
            this.Controls.Add(this.lblSetDate);
            this.Controls.Add(this.lblSetPedido);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblPago);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPedido);
            this.Name = "ShowOrder";
            this.Text = "ShowOrder";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSetPedido;
        private System.Windows.Forms.Label lblSetDate;
        private System.Windows.Forms.Label lblSetCustomer;
        private System.Windows.Forms.Label lblSetPay;
        private System.Windows.Forms.Label lblSetTotal;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button button1;
    }
}