namespace Avengers.Presentacion.Cashbook.Validation
{
    partial class ViewValidation
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
            this.dgvValida = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnValida = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValida)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvValida
            // 
            this.dgvValida.AllowUserToAddRows = false;
            this.dgvValida.AllowUserToDeleteRows = false;
            this.dgvValida.AllowUserToResizeColumns = false;
            this.dgvValida.AllowUserToResizeRows = false;
            this.dgvValida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvValida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValida.Location = new System.Drawing.Point(33, 126);
            this.dgvValida.Name = "dgvValida";
            this.dgvValida.ReadOnly = true;
            this.dgvValida.RowHeadersVisible = false;
            this.dgvValida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValida.Size = new System.Drawing.Size(641, 233);
            this.dgvValida.TabIndex = 0;
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(148, 50);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 20);
            this.date.TabIndex = 1;
            this.date.Value = new System.DateTime(2019, 1, 23, 20, 58, 9, 0);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(58, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // btnValida
            // 
            this.btnValida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValida.Location = new System.Drawing.Point(446, 29);
            this.btnValida.Name = "btnValida";
            this.btnValida.Size = new System.Drawing.Size(103, 67);
            this.btnValida.TabIndex = 3;
            this.btnValida.Text = "Validation";
            this.btnValida.UseVisualStyleBackColor = true;
            this.btnValida.Click += new System.EventHandler(this.btnValida_Click);
            // 
            // ViewValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 438);
            this.Controls.Add(this.btnValida);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dgvValida);
            this.Name = "ViewValidation";
            this.Text = "ViewValidation";
            this.Shown += new System.EventHandler(this.Validation_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvValida;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnValida;
    }
}