namespace Avengers.Presentacion.Cashbook
{
    partial class ViewIncomes
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
            this.dgvIncomes = new System.Windows.Forms.DataGridView();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblTypes = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblConcept = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.txtConcept = new System.Windows.Forms.TextBox();
            this.dateRangeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateRangeTo = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTituloView = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chkSource = new System.Windows.Forms.CheckBox();
            this.chkType = new System.Windows.Forms.CheckBox();
            this.chkDateFrom = new System.Windows.Forms.CheckBox();
            this.chkDateTo = new System.Windows.Forms.CheckBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.btnEject = new System.Windows.Forms.Button();
            this.txtRegistros = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIncomes
            // 
            this.dgvIncomes.AllowUserToAddRows = false;
            this.dgvIncomes.AllowUserToDeleteRows = false;
            this.dgvIncomes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIncomes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncomes.Location = new System.Drawing.Point(24, 140);
            this.dgvIncomes.Name = "dgvIncomes";
            this.dgvIncomes.RowHeadersVisible = false;
            this.dgvIncomes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncomes.Size = new System.Drawing.Size(1102, 199);
            this.dgvIncomes.TabIndex = 0;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(2, 47);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(61, 16);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Source:";
            // 
            // lblTypes
            // 
            this.lblTypes.AutoSize = true;
            this.lblTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypes.Location = new System.Drawing.Point(293, 43);
            this.lblTypes.Name = "lblTypes";
            this.lblTypes.Size = new System.Drawing.Size(56, 16);
            this.lblTypes.TabIndex = 2;
            this.lblTypes.Text = "Types:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(537, 44);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(63, 16);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Amount:";
            // 
            // lblConcept
            // 
            this.lblConcept.AutoSize = true;
            this.lblConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcept.Location = new System.Drawing.Point(2, 95);
            this.lblConcept.Name = "lblConcept";
            this.lblConcept.Size = new System.Drawing.Size(69, 16);
            this.lblConcept.TabIndex = 4;
            this.lblConcept.Text = "Concept:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(549, 91);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 16);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(293, 95);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(47, 16);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "From:";
            // 
            // cmbSource
            // 
            this.cmbSource.Enabled = false;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(77, 44);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(159, 21);
            this.cmbSource.TabIndex = 8;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // cmbTypes
            // 
            this.cmbTypes.DropDownWidth = 159;
            this.cmbTypes.Enabled = false;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Location = new System.Drawing.Point(376, 42);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(155, 21);
            this.cmbTypes.TabIndex = 9;
            this.cmbTypes.SelectedIndexChanged += new System.EventHandler(this.cmbTypes_SelectedIndexChanged);
            // 
            // txtConcept
            // 
            this.txtConcept.Location = new System.Drawing.Point(77, 91);
            this.txtConcept.Name = "txtConcept";
            this.txtConcept.Size = new System.Drawing.Size(159, 20);
            this.txtConcept.TabIndex = 10;
            this.txtConcept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConceptKeyUP);
            // 
            // dateRangeFrom
            // 
            this.dateRangeFrom.Checked = false;
            this.dateRangeFrom.Enabled = false;
            this.dateRangeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRangeFrom.Location = new System.Drawing.Point(376, 91);
            this.dateRangeFrom.Name = "dateRangeFrom";
            this.dateRangeFrom.Size = new System.Drawing.Size(110, 20);
            this.dateRangeFrom.TabIndex = 12;
            this.dateRangeFrom.ValueChanged += new System.EventHandler(this.dateRangeFromValueChanged);
            // 
            // dateRangeTo
            // 
            this.dateRangeTo.Checked = false;
            this.dateRangeTo.Enabled = false;
            this.dateRangeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRangeTo.Location = new System.Drawing.Point(644, 88);
            this.dateRangeTo.Name = "dateRangeTo";
            this.dateRangeTo.Size = new System.Drawing.Size(110, 20);
            this.dateRangeTo.TabIndex = 13;
            this.dateRangeTo.ValueChanged += new System.EventHandler(this.dateRangeToVAlueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(889, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(889, 82);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTituloView
            // 
            this.lblTituloView.AutoSize = true;
            this.lblTituloView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloView.Location = new System.Drawing.Point(525, 4);
            this.lblTituloView.Name = "lblTituloView";
            this.lblTituloView.Size = new System.Drawing.Size(0, 24);
            this.lblTituloView.TabIndex = 17;
            // 
            // chkSource
            // 
            this.chkSource.AutoSize = true;
            this.chkSource.Location = new System.Drawing.Point(56, 49);
            this.chkSource.Name = "chkSource";
            this.chkSource.Size = new System.Drawing.Size(15, 14);
            this.chkSource.TabIndex = 18;
            this.chkSource.UseVisualStyleBackColor = true;
            this.chkSource.CheckedChanged += new System.EventHandler(this.chkSource_CheckedChanged);
            // 
            // chkType
            // 
            this.chkType.AutoSize = true;
            this.chkType.Location = new System.Drawing.Point(355, 47);
            this.chkType.Name = "chkType";
            this.chkType.Size = new System.Drawing.Size(15, 14);
            this.chkType.TabIndex = 19;
            this.chkType.UseVisualStyleBackColor = true;
            this.chkType.CheckedChanged += new System.EventHandler(this.chkTypes_CheckedChanged);
            // 
            // chkDateFrom
            // 
            this.chkDateFrom.AutoSize = true;
            this.chkDateFrom.Location = new System.Drawing.Point(355, 97);
            this.chkDateFrom.Name = "chkDateFrom";
            this.chkDateFrom.Size = new System.Drawing.Size(15, 14);
            this.chkDateFrom.TabIndex = 20;
            this.chkDateFrom.UseVisualStyleBackColor = true;
            this.chkDateFrom.CheckedChanged += new System.EventHandler(this.chkDateFrom_CheckedChanged);
            // 
            // chkDateTo
            // 
            this.chkDateTo.AutoSize = true;
            this.chkDateTo.Location = new System.Drawing.Point(623, 91);
            this.chkDateTo.Name = "chkDateTo";
            this.chkDateTo.Size = new System.Drawing.Size(15, 14);
            this.chkDateTo.TabIndex = 21;
            this.chkDateTo.UseVisualStyleBackColor = true;
            this.chkDateTo.CheckedChanged += new System.EventHandler(this.chkDateTo_CheckedChanged);
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Location = new System.Drawing.Point(746, 36);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 22;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(623, 40);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(96, 20);
            this.txtAmount.TabIndex = 23;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // btnEject
            // 
            this.btnEject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEject.Location = new System.Drawing.Point(993, 36);
            this.btnEject.Name = "btnEject";
            this.btnEject.Size = new System.Drawing.Size(79, 23);
            this.btnEject.TabIndex = 24;
            this.btnEject.Text = "Ejecutar";
            this.btnEject.UseVisualStyleBackColor = true;
            this.btnEject.Click += new System.EventHandler(this.btnEject_Click);
            // 
            // txtRegistros
            // 
            this.txtRegistros.Location = new System.Drawing.Point(1086, 36);
            this.txtRegistros.Name = "txtRegistros";
            this.txtRegistros.Size = new System.Drawing.Size(40, 20);
            this.txtRegistros.TabIndex = 25;
            // 
            // ViewIncomes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 344);
            this.Controls.Add(this.txtRegistros);
            this.Controls.Add(this.btnEject);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.chkDateTo);
            this.Controls.Add(this.chkDateFrom);
            this.Controls.Add(this.chkType);
            this.Controls.Add(this.chkSource);
            this.Controls.Add(this.lblTituloView);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dateRangeTo);
            this.Controls.Add(this.dateRangeFrom);
            this.Controls.Add(this.txtConcept);
            this.Controls.Add(this.cmbTypes);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblConcept);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTypes);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.dgvIncomes);
            this.Name = "ViewIncomes";
            this.Shown += new System.EventHandler(this.Incomes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvIncomes;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblTypes;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblConcept;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.TextBox txtConcept;
        public System.Windows.Forms.DateTimePicker dateRangeFrom;
        public System.Windows.Forms.DateTimePicker dateRangeTo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTituloView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox chkSource;
        private System.Windows.Forms.CheckBox chkType;
        private System.Windows.Forms.CheckBox chkDateFrom;
        private System.Windows.Forms.CheckBox chkDateTo;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.TextBox txtAmount;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button btnEject;
        private System.Windows.Forms.TextBox txtRegistros;
    }
}