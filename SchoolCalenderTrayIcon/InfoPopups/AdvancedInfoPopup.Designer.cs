namespace SchoolCalendarTrayIcon
{
    partial class AdvancedInfoPopup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedInfoPopup));
            this.monthCal = new System.Windows.Forms.MonthCalendar();
            this.title = new System.Windows.Forms.Label();
            this.periodContents = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.taskBtn = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.TaskAdd = new System.Windows.Forms.Button();
            this.TaskTake = new System.Windows.Forms.Button();
            this.TaskEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // monthCal
            // 
            this.monthCal.Location = new System.Drawing.Point(-2, -3);
            this.monthCal.MaximumSize = new System.Drawing.Size(311, 252);
            this.monthCal.MaxSelectionCount = 1;
            this.monthCal.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.monthCal.MinimumSize = new System.Drawing.Size(311, 252);
            this.monthCal.Name = "monthCal";
            this.monthCal.TabIndex = 1;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(8, 258);
            this.title.MaximumSize = new System.Drawing.Size(215, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(54, 25);
            this.title.TabIndex = 2;
            this.title.Text = "Title";
            this.toolTip1.SetToolTip(this.title, "Name and Location of next event as well as the time until the event (optional).");
            // 
            // periodContents
            // 
            this.periodContents.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.periodContents.Cursor = System.Windows.Forms.Cursors.Default;
            this.periodContents.ForeColor = System.Drawing.SystemColors.GrayText;
            this.periodContents.Location = new System.Drawing.Point(-1, 290);
            this.periodContents.MaximumSize = new System.Drawing.Size(310, 148);
            this.periodContents.MinimumSize = new System.Drawing.Size(266, 148);
            this.periodContents.Multiline = true;
            this.periodContents.Name = "periodContents";
            this.periodContents.ReadOnly = true;
            this.periodContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.periodContents.Size = new System.Drawing.Size(310, 148);
            this.periodContents.TabIndex = 3;
            this.periodContents.Text = "Contents";
            this.periodContents.WordWrap = false;
            // 
            // taskBtn
            // 
            this.taskBtn.Location = new System.Drawing.Point(230, 254);
            this.taskBtn.Name = "taskBtn";
            this.taskBtn.Size = new System.Drawing.Size(70, 30);
            this.taskBtn.TabIndex = 4;
            this.taskBtn.Text = "Tasks";
            this.taskBtn.UseVisualStyleBackColor = true;
            // 
            // TaskAdd
            // 
            this.TaskAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskAdd.Location = new System.Drawing.Point(270, 306);
            this.TaskAdd.Name = "TaskAdd";
            this.TaskAdd.Size = new System.Drawing.Size(32, 32);
            this.TaskAdd.TabIndex = 5;
            this.TaskAdd.Text = "+";
            this.TaskAdd.UseVisualStyleBackColor = true;
            this.TaskAdd.Visible = false;
            // 
            // TaskTake
            // 
            this.TaskTake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskTake.Location = new System.Drawing.Point(270, 348);
            this.TaskTake.Name = "TaskTake";
            this.TaskTake.Size = new System.Drawing.Size(32, 32);
            this.TaskTake.TabIndex = 6;
            this.TaskTake.Text = "-";
            this.TaskTake.UseVisualStyleBackColor = true;
            this.TaskTake.Visible = false;
            // 
            // TaskEdit
            // 
            this.TaskEdit.Image = global::SchoolCalendarTrayIcon.Properties.Resources.edit;
            this.TaskEdit.Location = new System.Drawing.Point(270, 390);
            this.TaskEdit.Name = "TaskEdit";
            this.TaskEdit.Size = new System.Drawing.Size(32, 32);
            this.TaskEdit.TabIndex = 7;
            this.TaskEdit.UseVisualStyleBackColor = true;
            this.TaskEdit.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(-4, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 1);
            this.panel1.TabIndex = 8;
            // 
            // AdvancedInfoPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(307, 438);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TaskEdit);
            this.Controls.Add(this.TaskTake);
            this.Controls.Add(this.TaskAdd);
            this.Controls.Add(this.taskBtn);
            this.Controls.Add(this.periodContents);
            this.Controls.Add(this.title);
            this.Controls.Add(this.monthCal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(313, 478);
            this.MinimumSize = new System.Drawing.Size(313, 478);
            this.Name = "AdvancedInfoPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MonthCalendar monthCal;
        private System.Windows.Forms.Label title;
        public System.Windows.Forms.TextBox periodContents;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button taskBtn;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button TaskAdd;
        private System.Windows.Forms.Button TaskTake;
        private System.Windows.Forms.Button TaskEdit;
        private System.Windows.Forms.Panel panel1;

    }
}