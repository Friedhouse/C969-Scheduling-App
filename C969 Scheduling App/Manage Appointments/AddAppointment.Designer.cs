namespace C969_Scheduling_App.Manage_Appointments
{
    partial class AddAppointment
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
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.Custlabel = new System.Windows.Forms.Label();
            this.cancelApptBtn = new System.Windows.Forms.Button();
            this.saveApptBtn = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.addApptLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.comboCustBox = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textBoxType
            // 
            this.textBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxType.Location = new System.Drawing.Point(93, 137);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(235, 20);
            this.textBoxType.TabIndex = 51;
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLabel.Location = new System.Drawing.Point(44, 214);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(38, 20);
            this.endLabel.TabIndex = 50;
            this.endLabel.Text = "End";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(43, 175);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(44, 20);
            this.startLabel.TabIndex = 48;
            this.startLabel.Text = "Start";
            // 
            // Custlabel
            // 
            this.Custlabel.AutoSize = true;
            this.Custlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Custlabel.Location = new System.Drawing.Point(43, 255);
            this.Custlabel.Name = "Custlabel";
            this.Custlabel.Size = new System.Drawing.Size(78, 20);
            this.Custlabel.TabIndex = 45;
            this.Custlabel.Text = "Customer";
            // 
            // cancelApptBtn
            // 
            this.cancelApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelApptBtn.Location = new System.Drawing.Point(264, 386);
            this.cancelApptBtn.Name = "cancelApptBtn";
            this.cancelApptBtn.Size = new System.Drawing.Size(80, 37);
            this.cancelApptBtn.TabIndex = 42;
            this.cancelApptBtn.Text = "Cancel";
            this.cancelApptBtn.UseVisualStyleBackColor = true;
            this.cancelApptBtn.Click += new System.EventHandler(this.cancelApptBtn_Click);
            // 
            // saveApptBtn
            // 
            this.saveApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveApptBtn.Location = new System.Drawing.Point(178, 386);
            this.saveApptBtn.Name = "saveApptBtn";
            this.saveApptBtn.Size = new System.Drawing.Size(80, 37);
            this.saveApptBtn.TabIndex = 41;
            this.saveApptBtn.Text = "Save";
            this.saveApptBtn.UseVisualStyleBackColor = true;
            this.saveApptBtn.Click += new System.EventHandler(this.saveApptBtn_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(138, 295);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(189, 73);
            this.textBoxDescription.TabIndex = 40;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxTitle.Location = new System.Drawing.Point(93, 97);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(235, 20);
            this.textBoxTitle.TabIndex = 39;
            // 
            // addApptLabel
            // 
            this.addApptLabel.AutoSize = true;
            this.addApptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addApptLabel.Location = new System.Drawing.Point(106, 44);
            this.addApptLabel.Name = "addApptLabel";
            this.addApptLabel.Size = new System.Drawing.Size(176, 25);
            this.addApptLabel.TabIndex = 38;
            this.addApptLabel.Text = "Add Appointment";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(43, 135);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(43, 20);
            this.typeLabel.TabIndex = 37;
            this.typeLabel.Text = "Type";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(43, 321);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(89, 20);
            this.DescriptionLabel.TabIndex = 36;
            this.DescriptionLabel.Text = "Description";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(43, 95);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(38, 20);
            this.titleLabel.TabIndex = 35;
            this.titleLabel.Text = "Title";
            // 
            // comboCustBox
            // 
            this.comboCustBox.FormattingEnabled = true;
            this.comboCustBox.Location = new System.Drawing.Point(138, 255);
            this.comboCustBox.Name = "comboCustBox";
            this.comboCustBox.Size = new System.Drawing.Size(189, 21);
            this.comboCustBox.TabIndex = 52;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(93, 175);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerStart.TabIndex = 53;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(94, 214);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerEnd.TabIndex = 54;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 476);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboCustBox);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.Custlabel);
            this.Controls.Add(this.cancelApptBtn);
            this.Controls.Add(this.saveApptBtn);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.addApptLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "AddAppointment";
            this.Text = "AddAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label Custlabel;
        private System.Windows.Forms.Button cancelApptBtn;
        private System.Windows.Forms.Button saveApptBtn;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label addApptLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox comboCustBox;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
    }
}