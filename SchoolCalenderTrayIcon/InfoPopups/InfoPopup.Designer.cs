namespace SchoolCalendarTrayIcon
{
    partial class InfoPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoPopup));
            this.title = new System.Windows.Forms.Label();
            this.periodContents = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.title.Location = new System.Drawing.Point(8, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(54, 25);
            this.title.TabIndex = 0;
            this.title.Text = "Title";
            this.toolTip1.SetToolTip(this.title, "Name and Location of next event as well as the time until the event (optional).");
            // 
            // periodContents
            // 
            this.periodContents.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.periodContents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.periodContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodContents.ForeColor = System.Drawing.SystemColors.GrayText;
            this.periodContents.Location = new System.Drawing.Point(-2, 34);
            this.periodContents.Name = "periodContents";
            this.periodContents.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.periodContents.Size = new System.Drawing.Size(1000, 30);
            this.periodContents.TabIndex = 0;
            this.periodContents.Text = "Contents";
            // 
            // InfoPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 88);
            this.Controls.Add(this.periodContents);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 104);
            this.Name = "InfoPopup";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label title;
        public System.Windows.Forms.Label periodContents;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}