namespace C969_Scheduling_App
{
    partial class AppointmentForm
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
            this.apptGridView = new System.Windows.Forms.DataGridView();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.deleteApptBtn = new System.Windows.Forms.Button();
            this.editApptBtn = new System.Windows.Forms.Button();
            this.addApptBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentWeekBtn = new System.Windows.Forms.Button();
            this.currentMonthBtn = new System.Windows.Forms.Button();
            this.allApptBtn = new System.Windows.Forms.Button();
            this.manageCustBtn = new System.Windows.Forms.Button();
            this.signOutBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxTypes = new System.Windows.Forms.CheckBox();
            this.checkBoxSchedule = new System.Windows.Forms.CheckBox();
            this.checkBoxCustomer = new System.Windows.Forms.CheckBox();
            this.submitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.apptGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // apptGridView
            // 
            this.apptGridView.AllowUserToDeleteRows = false;
            this.apptGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptGridView.Location = new System.Drawing.Point(270, 83);
            this.apptGridView.Name = "apptGridView";
            this.apptGridView.ReadOnly = true;
            this.apptGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.apptGridView.Size = new System.Drawing.Size(843, 817);
            this.apptGridView.TabIndex = 0;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(18, 83);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 1;
            // 
            // deleteApptBtn
            // 
            this.deleteApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteApptBtn.Location = new System.Drawing.Point(180, 374);
            this.deleteApptBtn.Name = "deleteApptBtn";
            this.deleteApptBtn.Size = new System.Drawing.Size(65, 58);
            this.deleteApptBtn.TabIndex = 2;
            this.deleteApptBtn.Text = "Delete";
            this.deleteApptBtn.UseVisualStyleBackColor = true;
            this.deleteApptBtn.Click += new System.EventHandler(this.deleteApptBtn_Click);
            // 
            // editApptBtn
            // 
            this.editApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editApptBtn.Location = new System.Drawing.Point(100, 374);
            this.editApptBtn.Name = "editApptBtn";
            this.editApptBtn.Size = new System.Drawing.Size(65, 58);
            this.editApptBtn.TabIndex = 3;
            this.editApptBtn.Text = "Edit";
            this.editApptBtn.UseVisualStyleBackColor = true;
            this.editApptBtn.Click += new System.EventHandler(this.editApptBtn_Click);
            // 
            // addApptBtn
            // 
            this.addApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addApptBtn.Location = new System.Drawing.Point(18, 374);
            this.addApptBtn.Name = "addApptBtn";
            this.addApptBtn.Size = new System.Drawing.Size(65, 58);
            this.addApptBtn.TabIndex = 4;
            this.addApptBtn.Text = "Add";
            this.addApptBtn.UseVisualStyleBackColor = true;
            this.addApptBtn.Click += new System.EventHandler(this.addApptBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Appointments";
            // 
            // currentWeekBtn
            // 
            this.currentWeekBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentWeekBtn.Location = new System.Drawing.Point(612, 24);
            this.currentWeekBtn.Name = "currentWeekBtn";
            this.currentWeekBtn.Size = new System.Drawing.Size(139, 41);
            this.currentWeekBtn.TabIndex = 7;
            this.currentWeekBtn.Text = "Current Week";
            this.currentWeekBtn.UseVisualStyleBackColor = true;
            this.currentWeekBtn.Click += new System.EventHandler(this.currentWeekBtn_Click);
            // 
            // currentMonthBtn
            // 
            this.currentMonthBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMonthBtn.Location = new System.Drawing.Point(793, 24);
            this.currentMonthBtn.Name = "currentMonthBtn";
            this.currentMonthBtn.Size = new System.Drawing.Size(139, 41);
            this.currentMonthBtn.TabIndex = 8;
            this.currentMonthBtn.Text = "Current Month";
            this.currentMonthBtn.UseVisualStyleBackColor = true;
            this.currentMonthBtn.Click += new System.EventHandler(this.currentMonthBtn_Click);
            // 
            // allApptBtn
            // 
            this.allApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allApptBtn.Location = new System.Drawing.Point(974, 24);
            this.allApptBtn.Name = "allApptBtn";
            this.allApptBtn.Size = new System.Drawing.Size(139, 41);
            this.allApptBtn.TabIndex = 9;
            this.allApptBtn.Text = "All Appointments";
            this.allApptBtn.UseVisualStyleBackColor = true;
            this.allApptBtn.Click += new System.EventHandler(this.allApptBtn_Click);
            // 
            // manageCustBtn
            // 
            this.manageCustBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCustBtn.Location = new System.Drawing.Point(18, 449);
            this.manageCustBtn.Name = "manageCustBtn";
            this.manageCustBtn.Size = new System.Drawing.Size(227, 43);
            this.manageCustBtn.TabIndex = 10;
            this.manageCustBtn.Text = "Manage Customer";
            this.manageCustBtn.UseVisualStyleBackColor = true;
            this.manageCustBtn.Click += new System.EventHandler(this.manageCustBtn_Click);
            // 
            // signOutBtn
            // 
            this.signOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutBtn.Location = new System.Drawing.Point(837, 919);
            this.signOutBtn.Name = "signOutBtn";
            this.signOutBtn.Size = new System.Drawing.Size(141, 43);
            this.signOutBtn.TabIndex = 11;
            this.signOutBtn.Text = "Sign Out";
            this.signOutBtn.UseVisualStyleBackColor = true;
            this.signOutBtn.Click += new System.EventHandler(this.signOutBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(984, 919);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(129, 43);
            this.closeBtn.TabIndex = 12;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 660);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "Generate Reports";
            // 
            // checkBoxTypes
            // 
            this.checkBoxTypes.AutoSize = true;
            this.checkBoxTypes.Location = new System.Drawing.Point(35, 710);
            this.checkBoxTypes.Name = "checkBoxTypes";
            this.checkBoxTypes.Size = new System.Drawing.Size(210, 17);
            this.checkBoxTypes.TabIndex = 14;
            this.checkBoxTypes.Text = "Number of appointment types by month";
            this.checkBoxTypes.UseVisualStyleBackColor = true;
            // 
            // checkBoxSchedule
            // 
            this.checkBoxSchedule.AutoSize = true;
            this.checkBoxSchedule.Location = new System.Drawing.Point(35, 733);
            this.checkBoxSchedule.Name = "checkBoxSchedule";
            this.checkBoxSchedule.Size = new System.Drawing.Size(136, 17);
            this.checkBoxSchedule.TabIndex = 15;
            this.checkBoxSchedule.Text = "Schedule for each user";
            this.checkBoxSchedule.UseVisualStyleBackColor = true;
            // 
            // checkBoxCustomer
            // 
            this.checkBoxCustomer.AutoSize = true;
            this.checkBoxCustomer.Location = new System.Drawing.Point(35, 756);
            this.checkBoxCustomer.Name = "checkBoxCustomer";
            this.checkBoxCustomer.Size = new System.Drawing.Size(150, 17);
            this.checkBoxCustomer.TabIndex = 16;
            this.checkBoxCustomer.Text = "Appointments by customer";
            this.checkBoxCustomer.UseVisualStyleBackColor = true;
            // 
            // submitBtn
            // 
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.Location = new System.Drawing.Point(61, 795);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(141, 43);
            this.submitBtn.TabIndex = 17;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 988);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.checkBoxCustomer);
            this.Controls.Add(this.checkBoxSchedule);
            this.Controls.Add(this.checkBoxTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.signOutBtn);
            this.Controls.Add(this.manageCustBtn);
            this.Controls.Add(this.allApptBtn);
            this.Controls.Add(this.currentMonthBtn);
            this.Controls.Add(this.currentWeekBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addApptBtn);
            this.Controls.Add(this.editApptBtn);
            this.Controls.Add(this.deleteApptBtn);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.apptGridView);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.apptGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView apptGridView;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button deleteApptBtn;
        private System.Windows.Forms.Button editApptBtn;
        private System.Windows.Forms.Button addApptBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button currentWeekBtn;
        private System.Windows.Forms.Button currentMonthBtn;
        private System.Windows.Forms.Button allApptBtn;
        private System.Windows.Forms.Button manageCustBtn;
        private System.Windows.Forms.Button signOutBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxTypes;
        private System.Windows.Forms.CheckBox checkBoxSchedule;
        private System.Windows.Forms.CheckBox checkBoxCustomer;
        private System.Windows.Forms.Button submitBtn;
    }
}