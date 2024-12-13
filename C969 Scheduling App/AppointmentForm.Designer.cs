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
            ((System.ComponentModel.ISupportInitialize)(this.apptGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // apptGridView
            // 
            this.apptGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptGridView.Location = new System.Drawing.Point(257, 78);
            this.apptGridView.Name = "apptGridView";
            this.apptGridView.Size = new System.Drawing.Size(1825, 817);
            this.apptGridView.TabIndex = 0;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(18, 78);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 1;
            // 
            // deleteApptBtn
            // 
            this.deleteApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteApptBtn.Location = new System.Drawing.Point(180, 366);
            this.deleteApptBtn.Name = "deleteApptBtn";
            this.deleteApptBtn.Size = new System.Drawing.Size(65, 58);
            this.deleteApptBtn.TabIndex = 2;
            this.deleteApptBtn.Text = "Delete";
            this.deleteApptBtn.UseVisualStyleBackColor = true;
            // 
            // editApptBtn
            // 
            this.editApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editApptBtn.Location = new System.Drawing.Point(100, 366);
            this.editApptBtn.Name = "editApptBtn";
            this.editApptBtn.Size = new System.Drawing.Size(65, 58);
            this.editApptBtn.TabIndex = 3;
            this.editApptBtn.Text = "Edit";
            this.editApptBtn.UseVisualStyleBackColor = true;
            // 
            // addApptBtn
            // 
            this.addApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addApptBtn.Location = new System.Drawing.Point(18, 366);
            this.addApptBtn.Name = "addApptBtn";
            this.addApptBtn.Size = new System.Drawing.Size(65, 58);
            this.addApptBtn.TabIndex = 4;
            this.addApptBtn.Text = "Add";
            this.addApptBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Appointments";
            // 
            // currentWeekBtn
            // 
            this.currentWeekBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentWeekBtn.Location = new System.Drawing.Point(477, 19);
            this.currentWeekBtn.Name = "currentWeekBtn";
            this.currentWeekBtn.Size = new System.Drawing.Size(139, 41);
            this.currentWeekBtn.TabIndex = 7;
            this.currentWeekBtn.Text = "Current Week";
            this.currentWeekBtn.UseVisualStyleBackColor = true;
            // 
            // currentMonthBtn
            // 
            this.currentMonthBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMonthBtn.Location = new System.Drawing.Point(648, 19);
            this.currentMonthBtn.Name = "currentMonthBtn";
            this.currentMonthBtn.Size = new System.Drawing.Size(139, 41);
            this.currentMonthBtn.TabIndex = 8;
            this.currentMonthBtn.Text = "Current Month";
            this.currentMonthBtn.UseVisualStyleBackColor = true;
            // 
            // allApptBtn
            // 
            this.allApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allApptBtn.Location = new System.Drawing.Point(819, 19);
            this.allApptBtn.Name = "allApptBtn";
            this.allApptBtn.Size = new System.Drawing.Size(139, 41);
            this.allApptBtn.TabIndex = 9;
            this.allApptBtn.Text = "All Appointments";
            this.allApptBtn.UseVisualStyleBackColor = true;
            // 
            // manageCustBtn
            // 
            this.manageCustBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCustBtn.Location = new System.Drawing.Point(18, 441);
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
            this.signOutBtn.Location = new System.Drawing.Point(1806, 901);
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
            this.closeBtn.Location = new System.Drawing.Point(1953, 901);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(129, 43);
            this.closeBtn.TabIndex = 12;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2094, 1001);
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
    }
}