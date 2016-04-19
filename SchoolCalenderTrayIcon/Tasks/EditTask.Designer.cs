namespace SchoolCalendarTrayIcon.Tasks
{
    partial class EditTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTask));
            this.panel1 = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.selection = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.aTime = new System.Windows.Forms.DateTimePicker();
            this.aDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.OK);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Location = new System.Drawing.Point(-5, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 50);
            this.panel1.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(528, 9);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(128, 32);
            this.OK.TabIndex = 1;
            this.OK.Text = "Save";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(368, 9);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(128, 32);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // selection
            // 
            this.selection.FormattingEnabled = true;
            this.selection.ItemHeight = 20;
            this.selection.Location = new System.Drawing.Point(0, 0);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(204, 184);
            this.selection.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(466, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Time:";
            // 
            // aTime
            // 
            this.aTime.CustomFormat = "HH:mm";
            this.aTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.aTime.Location = new System.Drawing.Point(534, 141);
            this.aTime.Name = "aTime";
            this.aTime.ShowUpDown = true;
            this.aTime.Size = new System.Drawing.Size(128, 26);
            this.aTime.TabIndex = 23;
            this.aTime.Value = new System.DateTime(2016, 3, 4, 11, 56, 37, 670);
            // 
            // aDate
            // 
            this.aDate.CustomFormat = "MM/dd/yyyy";
            this.aDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.aDate.Location = new System.Drawing.Point(332, 141);
            this.aDate.Name = "aDate";
            this.aDate.ShowUpDown = true;
            this.aDate.Size = new System.Drawing.Size(128, 26);
            this.aDate.TabIndex = 22;
            this.aDate.Value = new System.DateTime(2016, 3, 4, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(210, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Alarm Date:";
            // 
            // time
            // 
            this.time.CustomFormat = "HH:mm";
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time.Location = new System.Drawing.Point(534, 97);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(128, 26);
            this.time.TabIndex = 20;
            this.time.Value = new System.DateTime(2016, 3, 4, 11, 56, 37, 666);
            // 
            // date
            // 
            this.date.CustomFormat = "MM/dd/yyyy";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(332, 97);
            this.date.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.ShowUpDown = true;
            this.date.Size = new System.Drawing.Size(128, 26);
            this.date.TabIndex = 19;
            this.date.Value = new System.DateTime(2016, 3, 4, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(466, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Due Date:";
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(332, 53);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(330, 26);
            this.details.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Details:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(332, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(330, 26);
            this.name.TabIndex = 13;
            // 
            // EditTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(678, 228);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.aTime);
            this.Controls.Add(this.aDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.time);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.details);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 284);
            this.MinimumSize = new System.Drawing.Size(700, 284);
            this.Name = "EditTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit A Task";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.ListBox selection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker aTime;
        private System.Windows.Forms.DateTimePicker aDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox details;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
    }
}