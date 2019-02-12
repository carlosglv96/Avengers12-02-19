namespace Avengers.Presentacion.Cashbook.Debts
{
    partial class PayDebt
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
            this.dateDto = new System.Windows.Forms.DateTimePicker();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblOf = new System.Windows.Forms.Label();
            this.lblTPayment = new System.Windows.Forms.Label();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rbComplete = new System.Windows.Forms.RadioButton();
            this.rbPartial = new System.Windows.Forms.RadioButton();
            this.cmbIncomes = new System.Windows.Forms.ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.txtConcep = new System.Windows.Forms.TextBox();
            this.lblConcep = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateDto
            // 
            this.dateDto.Enabled = false;
            this.dateDto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDto.Location = new System.Drawing.Point(194, 50);
            this.dateDto.Name = "dateDto";
            this.dateDto.Size = new System.Drawing.Size(268, 20);
            this.dateDto.TabIndex = 48;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(330, 228);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(92, 20);
            this.txtTotal.TabIndex = 47;
            // 
            // lblOf
            // 
            this.lblOf.AutoSize = true;
            this.lblOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOf.Location = new System.Drawing.Point(301, 228);
            this.lblOf.Name = "lblOf";
            this.lblOf.Size = new System.Drawing.Size(23, 20);
            this.lblOf.TabIndex = 46;
            this.lblOf.Text = "of";
            // 
            // lblTPayment
            // 
            this.lblTPayment.AutoSize = true;
            this.lblTPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPayment.Location = new System.Drawing.Point(50, 101);
            this.lblTPayment.Name = "lblTPayment";
            this.lblTPayment.Size = new System.Drawing.Size(113, 20);
            this.lblTPayment.TabIndex = 45;
            this.lblTPayment.Text = "Payment Type:";
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rbComplete);
            this.gbType.Controls.Add(this.rbPartial);
            this.gbType.Location = new System.Drawing.Point(194, 83);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(228, 49);
            this.gbType.TabIndex = 44;
            this.gbType.TabStop = false;
            // 
            // rbComplete
            // 
            this.rbComplete.AutoSize = true;
            this.rbComplete.Location = new System.Drawing.Point(66, 18);
            this.rbComplete.Name = "rbComplete";
            this.rbComplete.Size = new System.Drawing.Size(69, 17);
            this.rbComplete.TabIndex = 1;
            this.rbComplete.TabStop = true;
            this.rbComplete.Text = "Complete";
            this.rbComplete.UseVisualStyleBackColor = true;
            // 
            // rbPartial
            // 
            this.rbPartial.AutoSize = true;
            this.rbPartial.Location = new System.Drawing.Point(6, 18);
            this.rbPartial.Name = "rbPartial";
            this.rbPartial.Size = new System.Drawing.Size(54, 17);
            this.rbPartial.TabIndex = 0;
            this.rbPartial.TabStop = true;
            this.rbPartial.Text = "Partial";
            this.rbPartial.UseVisualStyleBackColor = true;
            this.rbPartial.CheckedChanged += new System.EventHandler(this.rbPartial_CheckedChanged);
            // 
            // cmbIncomes
            // 
            this.cmbIncomes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomes.FormattingEnabled = true;
            this.cmbIncomes.Location = new System.Drawing.Point(194, 151);
            this.cmbIncomes.Name = "cmbIncomes";
            this.cmbIncomes.Size = new System.Drawing.Size(228, 21);
            this.cmbIncomes.TabIndex = 43;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(49, 149);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(59, 20);
            this.lblTarget.TabIndex = 42;
            this.lblTarget.Text = "Target:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(194, 186);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(228, 21);
            this.cmbType.TabIndex = 41;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(50, 187);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 40;
            this.lblType.Text = "Type";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(68, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(347, 401);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 38;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // txtConcep
            // 
            this.txtConcep.Location = new System.Drawing.Point(194, 270);
            this.txtConcep.Multiline = true;
            this.txtConcep.Name = "txtConcep";
            this.txtConcep.Size = new System.Drawing.Size(228, 85);
            this.txtConcep.TabIndex = 37;
            // 
            // lblConcep
            // 
            this.lblConcep.AutoSize = true;
            this.lblConcep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcep.Location = new System.Drawing.Point(50, 270);
            this.lblConcep.Name = "lblConcep";
            this.lblConcep.Size = new System.Drawing.Size(69, 20);
            this.lblConcep.TabIndex = 36;
            this.lblConcep.Text = "Concept";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(194, 228);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(101, 20);
            this.txtAmount.TabIndex = 35;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(49, 228);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(65, 20);
            this.lblAmount.TabIndex = 34;
            this.lblAmount.Text = "Amount";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDate.Location = new System.Drawing.Point(50, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 20);
            this.lblDate.TabIndex = 31;
            this.lblDate.Text = "Date:";
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtUser.Location = new System.Drawing.Point(196, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(43, 20);
            this.txtUser.TabIndex = 30;
            this.txtUser.Text = "User";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUser.Location = new System.Drawing.Point(49, 19);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(47, 20);
            this.lblUser.TabIndex = 29;
            this.lblUser.Text = "User:";
            // 
            // PayDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 449);
            this.Controls.Add(this.dateDto);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblOf);
            this.Controls.Add(this.lblTPayment);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.cmbIncomes);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtConcep);
            this.Controls.Add(this.lblConcep);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Name = "PayDebt";
            this.Text = "Form1";
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblOf;
        private System.Windows.Forms.Label lblTPayment;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rbComplete;
        private System.Windows.Forms.RadioButton rbPartial;
        private System.Windows.Forms.ComboBox cmbIncomes;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.TextBox txtConcep;
        private System.Windows.Forms.Label lblConcep;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label lblUser;
    }
}