namespace Avengers.Presentacion.Cashbook
{
    partial class AddIncomes
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
            this.lblSourceAdd = new System.Windows.Forms.Label();
            this.lblTypeAdd = new System.Windows.Forms.Label();
            this.lblDateAdd = new System.Windows.Forms.Label();
            this.lblConceptAdd = new System.Windows.Forms.Label();
            this.lblAmountAdd = new System.Windows.Forms.Label();
            this.lblUserAdd = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.dateIncomes = new System.Windows.Forms.DateTimePicker();
            this.txtConceptIncomes = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSourceAdd
            // 
            this.lblSourceAdd.AutoSize = true;
            this.lblSourceAdd.Location = new System.Drawing.Point(53, 54);
            this.lblSourceAdd.Name = "lblSourceAdd";
            this.lblSourceAdd.Size = new System.Drawing.Size(44, 13);
            this.lblSourceAdd.TabIndex = 0;
            this.lblSourceAdd.Text = "Source:";
            // 
            // lblTypeAdd
            // 
            this.lblTypeAdd.AutoSize = true;
            this.lblTypeAdd.Location = new System.Drawing.Point(318, 54);
            this.lblTypeAdd.Name = "lblTypeAdd";
            this.lblTypeAdd.Size = new System.Drawing.Size(34, 13);
            this.lblTypeAdd.TabIndex = 1;
            this.lblTypeAdd.Text = "Type:";
            // 
            // lblDateAdd
            // 
            this.lblDateAdd.AutoSize = true;
            this.lblDateAdd.Location = new System.Drawing.Point(318, 119);
            this.lblDateAdd.Name = "lblDateAdd";
            this.lblDateAdd.Size = new System.Drawing.Size(33, 13);
            this.lblDateAdd.TabIndex = 2;
            this.lblDateAdd.Text = "Date:";
            // 
            // lblConceptAdd
            // 
            this.lblConceptAdd.AutoSize = true;
            this.lblConceptAdd.Location = new System.Drawing.Point(47, 194);
            this.lblConceptAdd.Name = "lblConceptAdd";
            this.lblConceptAdd.Size = new System.Drawing.Size(50, 13);
            this.lblConceptAdd.TabIndex = 3;
            this.lblConceptAdd.Text = "Concept:";
            // 
            // lblAmountAdd
            // 
            this.lblAmountAdd.AutoSize = true;
            this.lblAmountAdd.Location = new System.Drawing.Point(51, 119);
            this.lblAmountAdd.Name = "lblAmountAdd";
            this.lblAmountAdd.Size = new System.Drawing.Size(46, 13);
            this.lblAmountAdd.TabIndex = 4;
            this.lblAmountAdd.Text = "Amount:";
            // 
            // lblUserAdd
            // 
            this.lblUserAdd.AutoSize = true;
            this.lblUserAdd.Location = new System.Drawing.Point(318, 194);
            this.lblUserAdd.Name = "lblUserAdd";
            this.lblUserAdd.Size = new System.Drawing.Size(32, 13);
            this.lblUserAdd.TabIndex = 5;
            this.lblUserAdd.Text = "User:";
            // 
            // cmbSource
            // 
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(104, 51);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(156, 21);
            this.cmbSource.TabIndex = 6;
            // 
            // cmbTypes
            // 
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Location = new System.Drawing.Point(369, 51);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(151, 21);
            this.cmbTypes.TabIndex = 7;
            // 
            // dateIncomes
            // 
            this.dateIncomes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateIncomes.Location = new System.Drawing.Point(369, 117);
            this.dateIncomes.Name = "dateIncomes";
            this.dateIncomes.Size = new System.Drawing.Size(113, 20);
            this.dateIncomes.TabIndex = 9;
            // 
            // txtConceptIncomes
            // 
            this.txtConceptIncomes.Location = new System.Drawing.Point(104, 194);
            this.txtConceptIncomes.Multiline = true;
            this.txtConceptIncomes.Name = "txtConceptIncomes";
            this.txtConceptIncomes.Size = new System.Drawing.Size(156, 65);
            this.txtConceptIncomes.TabIndex = 10;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(321, 376);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Accept";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(445, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Location = new System.Drawing.Point(369, 193);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblUsuario.TabIndex = 14;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(104, 116);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 15;
            // 
            // AddIncomes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 422);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtConceptIncomes);
            this.Controls.Add(this.dateIncomes);
            this.Controls.Add(this.cmbTypes);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblUserAdd);
            this.Controls.Add(this.lblAmountAdd);
            this.Controls.Add(this.lblConceptAdd);
            this.Controls.Add(this.lblDateAdd);
            this.Controls.Add(this.lblTypeAdd);
            this.Controls.Add(this.lblSourceAdd);
            this.Name = "AddIncomes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourceAdd;
        private System.Windows.Forms.Label lblTypeAdd;
        private System.Windows.Forms.Label lblDateAdd;
        private System.Windows.Forms.Label lblConceptAdd;
        private System.Windows.Forms.Label lblAmountAdd;
        private System.Windows.Forms.Label lblUserAdd;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.DateTimePicker dateIncomes;
        private System.Windows.Forms.TextBox txtConceptIncomes;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtAmount;
    }
}