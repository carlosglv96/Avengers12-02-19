namespace Avengers.Presentacion.Cashbook.PPayment
{
    partial class viewPPayment
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.lblConcept = new System.Windows.Forms.Label();
            this.txtConcep = new System.Windows.Forms.TextBox();
            this.lblAdd = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.dgvPPayment = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkFrom = new System.Windows.Forms.CheckBox();
            this.chkTo = new System.Windows.Forms.CheckBox();
            this.chkSource = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSource.Location = new System.Drawing.Point(35, 25);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(61, 16);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(312, 25);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(63, 16);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Amount:";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(132, 24);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(170, 21);
            this.cmbSource.TabIndex = 2;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(397, 24);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // dateFrom
            // 
            this.dateFrom.Enabled = false;
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(606, 24);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 20);
            this.dateFrom.TabIndex = 4;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(507, 25);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(47, 16);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(507, 64);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 16);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To:";
            // 
            // dateTo
            // 
            this.dateTo.Enabled = false;
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(606, 64);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 20);
            this.dateTo.TabIndex = 6;
            this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
            // 
            // lblConcept
            // 
            this.lblConcept.AutoSize = true;
            this.lblConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblConcept.Location = new System.Drawing.Point(35, 68);
            this.lblConcept.Name = "lblConcept";
            this.lblConcept.Size = new System.Drawing.Size(69, 16);
            this.lblConcept.TabIndex = 8;
            this.lblConcept.Text = "Concept:";
            // 
            // txtConcep
            // 
            this.txtConcep.Location = new System.Drawing.Point(135, 65);
            this.txtConcep.Name = "txtConcep";
            this.txtConcep.Size = new System.Drawing.Size(364, 20);
            this.txtConcep.TabIndex = 9;
            this.txtConcep.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConcep_KeyUp);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAdd.Location = new System.Drawing.Point(855, 24);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(0, 16);
            this.lblAdd.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(845, 156);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnTake
            // 
            this.btnTake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTake.Location = new System.Drawing.Point(845, 196);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(89, 26);
            this.btnTake.TabIndex = 12;
            this.btnTake.Text = "Take Out";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // dgvPPayment
            // 
            this.dgvPPayment.AllowUserToAddRows = false;
            this.dgvPPayment.AllowUserToDeleteRows = false;
            this.dgvPPayment.AllowUserToResizeColumns = false;
            this.dgvPPayment.AllowUserToResizeRows = false;
            this.dgvPPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPPayment.Location = new System.Drawing.Point(47, 137);
            this.dgvPPayment.Name = "dgvPPayment";
            this.dgvPPayment.ReadOnly = true;
            this.dgvPPayment.RowHeadersVisible = false;
            this.dgvPPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPPayment.Size = new System.Drawing.Size(759, 272);
            this.dgvPPayment.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(845, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clean";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkFrom
            // 
            this.chkFrom.AutoSize = true;
            this.chkFrom.Location = new System.Drawing.Point(572, 27);
            this.chkFrom.Name = "chkFrom";
            this.chkFrom.Size = new System.Drawing.Size(15, 14);
            this.chkFrom.TabIndex = 15;
            this.chkFrom.UseVisualStyleBackColor = true;
            this.chkFrom.CheckedChanged += new System.EventHandler(this.chkFrom_CheckedChanged);
            // 
            // chkTo
            // 
            this.chkTo.AutoSize = true;
            this.chkTo.Location = new System.Drawing.Point(572, 67);
            this.chkTo.Name = "chkTo";
            this.chkTo.Size = new System.Drawing.Size(15, 14);
            this.chkTo.TabIndex = 16;
            this.chkTo.UseVisualStyleBackColor = true;
            this.chkTo.CheckedChanged += new System.EventHandler(this.chkTo_CheckedChanged);
            // 
            // chkSource
            // 
            this.chkSource.AutoSize = true;
            this.chkSource.Location = new System.Drawing.Point(103, 27);
            this.chkSource.Name = "chkSource";
            this.chkSource.Size = new System.Drawing.Size(15, 14);
            this.chkSource.TabIndex = 17;
            this.chkSource.UseVisualStyleBackColor = true;
            this.chkSource.CheckedChanged += new System.EventHandler(this.chkSource_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            // 
            // viewPPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 494);
            this.Controls.Add(this.chkSource);
            this.Controls.Add(this.chkTo);
            this.Controls.Add(this.chkFrom);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvPPayment);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.txtConcep);
            this.Controls.Add(this.lblConcept);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblSource);
            this.Name = "viewPPayment";
            this.Text = "PPayment";
            this.Shown += new System.EventHandler(this.PPayment_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label lblConcept;
        private System.Windows.Forms.TextBox txtConcep;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.DataGridView dgvPPayment;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkFrom;
        private System.Windows.Forms.CheckBox chkTo;
        private System.Windows.Forms.CheckBox chkSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}