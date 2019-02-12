namespace Avengers.Presentacion.Cashbook.PPayment
{
    partial class TakePPayment
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
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtConcep = new System.Windows.Forms.TextBox();
            this.lblConcep = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbIncomes = new System.Windows.Forms.ComboBox();
            this.lblIncomes = new System.Windows.Forms.Label();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rbComplete = new System.Windows.Forms.RadioButton();
            this.rbPartial = new System.Windows.Forms.RadioButton();
            this.lblTPayment = new System.Windows.Forms.Label();
            this.lblOf = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dateDto = new System.Windows.Forms.DateTimePicker();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUser.Location = new System.Drawing.Point(54, 42);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(47, 20);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User:";
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtUser.Location = new System.Drawing.Point(155, 42);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(43, 20);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "User";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDate.Location = new System.Drawing.Point(54, 74);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 20);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(73, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(352, 466);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtConcep
            // 
            this.txtConcep.Location = new System.Drawing.Point(159, 324);
            this.txtConcep.Multiline = true;
            this.txtConcep.Name = "txtConcep";
            this.txtConcep.Size = new System.Drawing.Size(268, 85);
            this.txtConcep.TabIndex = 17;
            // 
            // lblConcep
            // 
            this.lblConcep.AutoSize = true;
            this.lblConcep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcep.Location = new System.Drawing.Point(55, 324);
            this.lblConcep.Name = "lblConcep";
            this.lblConcep.Size = new System.Drawing.Size(69, 20);
            this.lblConcep.TabIndex = 16;
            this.lblConcep.Text = "Concept";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(159, 282);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 15;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(54, 282);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(65, 20);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "Amount";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.Enabled = false;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(159, 243);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(268, 21);
            this.cmbSource.TabIndex = 13;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(54, 244);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(60, 20);
            this.lblSource.TabIndex = 12;
            this.lblSource.Text = "Source";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(159, 209);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(268, 21);
            this.cmbType.TabIndex = 21;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(55, 210);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 20;
            this.lblType.Text = "Type";
            // 
            // cmbIncomes
            // 
            this.cmbIncomes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomes.FormattingEnabled = true;
            this.cmbIncomes.Location = new System.Drawing.Point(199, 174);
            this.cmbIncomes.Name = "cmbIncomes";
            this.cmbIncomes.Size = new System.Drawing.Size(228, 21);
            this.cmbIncomes.TabIndex = 23;
            // 
            // lblIncomes
            // 
            this.lblIncomes.AutoSize = true;
            this.lblIncomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomes.Location = new System.Drawing.Point(54, 172);
            this.lblIncomes.Name = "lblIncomes";
            this.lblIncomes.Size = new System.Drawing.Size(125, 20);
            this.lblIncomes.TabIndex = 22;
            this.lblIncomes.Text = "Incomes Source";
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rbComplete);
            this.gbType.Controls.Add(this.rbPartial);
            this.gbType.Location = new System.Drawing.Point(199, 106);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(228, 49);
            this.gbType.TabIndex = 24;
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
            this.rbComplete.CheckedChanged += new System.EventHandler(this.rbComplete_CheckedChanged);
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
            // lblTPayment
            // 
            this.lblTPayment.AutoSize = true;
            this.lblTPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPayment.Location = new System.Drawing.Point(55, 124);
            this.lblTPayment.Name = "lblTPayment";
            this.lblTPayment.Size = new System.Drawing.Size(105, 20);
            this.lblTPayment.TabIndex = 25;
            this.lblTPayment.Text = "Payment type";
            // 
            // lblOf
            // 
            this.lblOf.AutoSize = true;
            this.lblOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOf.Location = new System.Drawing.Point(306, 282);
            this.lblOf.Name = "lblOf";
            this.lblOf.Size = new System.Drawing.Size(23, 20);
            this.lblOf.TabIndex = 26;
            this.lblOf.Text = "of";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(335, 282);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(92, 20);
            this.txtTotal.TabIndex = 27;
            // 
            // dateDto
            // 
            this.dateDto.Enabled = false;
            this.dateDto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDto.Location = new System.Drawing.Point(159, 74);
            this.dateDto.Name = "dateDto";
            this.dateDto.Size = new System.Drawing.Size(268, 20);
            this.dateDto.TabIndex = 28;
            // 
            // TakePPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 508);
            this.Controls.Add(this.dateDto);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblOf);
            this.Controls.Add(this.lblTPayment);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.cmbIncomes);
            this.Controls.Add(this.lblIncomes);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtConcep);
            this.Controls.Add(this.lblConcep);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Name = "TakePPayment";
            this.Text = "TakePPayment";
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtConcep;
        private System.Windows.Forms.Label lblConcep;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbIncomes;
        private System.Windows.Forms.Label lblIncomes;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.Label lblTPayment;
        private System.Windows.Forms.RadioButton rbComplete;
        private System.Windows.Forms.RadioButton rbPartial;
        private System.Windows.Forms.Label lblOf;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DateTimePicker dateDto;
    }
}