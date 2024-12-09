namespace C969_Scheduling_App
{
    partial class ManageCustomer
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manageCustLabel = new System.Windows.Forms.Label();
            this.addCustBtn = new System.Windows.Forms.Button();
            this.deleteCustBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGrid,
            this.addressDataGrid,
            this.phoneDataGrid});
            this.dataGridView1.Location = new System.Drawing.Point(96, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(603, 245);
            this.dataGridView1.TabIndex = 0;
            // 
            // nameDataGrid
            // 
            this.nameDataGrid.HeaderText = "Name";
            this.nameDataGrid.Name = "nameDataGrid";
            this.nameDataGrid.Width = 140;
            // 
            // addressDataGrid
            // 
            this.addressDataGrid.HeaderText = "Address";
            this.addressDataGrid.Name = "addressDataGrid";
            this.addressDataGrid.Width = 280;
            // 
            // phoneDataGrid
            // 
            this.phoneDataGrid.HeaderText = "Phone Number";
            this.phoneDataGrid.Name = "phoneDataGrid";
            this.phoneDataGrid.Width = 140;
            // 
            // manageCustLabel
            // 
            this.manageCustLabel.AutoSize = true;
            this.manageCustLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCustLabel.Location = new System.Drawing.Point(301, 55);
            this.manageCustLabel.Name = "manageCustLabel";
            this.manageCustLabel.Size = new System.Drawing.Size(188, 25);
            this.manageCustLabel.TabIndex = 1;
            this.manageCustLabel.Text = "Manage Customer";
            // 
            // addCustBtn
            // 
            this.addCustBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCustBtn.Location = new System.Drawing.Point(96, 334);
            this.addCustBtn.Name = "addCustBtn";
            this.addCustBtn.Size = new System.Drawing.Size(75, 37);
            this.addCustBtn.TabIndex = 2;
            this.addCustBtn.Text = "Add";
            this.addCustBtn.UseVisualStyleBackColor = true;
            // 
            // deleteCustBtn
            // 
            this.deleteCustBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteCustBtn.Location = new System.Drawing.Point(177, 334);
            this.deleteCustBtn.Name = "deleteCustBtn";
            this.deleteCustBtn.Size = new System.Drawing.Size(75, 37);
            this.deleteCustBtn.TabIndex = 3;
            this.deleteCustBtn.Text = "Delete";
            this.deleteCustBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(624, 334);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 37);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // ManageCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.deleteCustBtn);
            this.Controls.Add(this.addCustBtn);
            this.Controls.Add(this.manageCustLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManageCustomer";
            this.Text = "ManageCustomer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGrid;
        private System.Windows.Forms.Label manageCustLabel;
        private System.Windows.Forms.Button addCustBtn;
        private System.Windows.Forms.Button deleteCustBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}