namespace SchoolCalendarTrayIcon
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.abortion = new System.Windows.Forms.Button();
            this.okay = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timeCheck = new System.Windows.Forms.CheckBox();
            this.amPmCheck = new System.Windows.Forms.CheckBox();
            this.linkBtn = new System.Windows.Forms.Button();
            this.timeToCheck = new System.Windows.Forms.CheckBox();
            this.simpleCheck = new System.Windows.Forms.CheckBox();
            this.reset = new System.Windows.Forms.Button();
            this.endsCheck = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // abortion
            // 
            this.abortion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.abortion.Location = new System.Drawing.Point(16, 14);
            this.abortion.Name = "abortion";
            this.abortion.Size = new System.Drawing.Size(128, 32);
            this.abortion.TabIndex = 0;
            this.abortion.Text = "Cancel";
            this.abortion.UseVisualStyleBackColor = true;
            // 
            // okay
            // 
            this.okay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okay.Location = new System.Drawing.Point(161, 14);
            this.okay.Name = "okay";
            this.okay.Size = new System.Drawing.Size(128, 32);
            this.okay.TabIndex = 1;
            this.okay.Text = "OK";
            this.okay.UseVisualStyleBackColor = true;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(305, 14);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(128, 32);
            this.apply.TabIndex = 2;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.abortion);
            this.panel1.Controls.Add(this.apply);
            this.panel1.Controls.Add(this.okay);
            this.panel1.Location = new System.Drawing.Point(-5, 196);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel1.Size = new System.Drawing.Size(454, 60);
            this.panel1.TabIndex = 3;
            // 
            // timeCheck
            // 
            this.timeCheck.AutoSize = true;
            this.timeCheck.Location = new System.Drawing.Point(8, 18);
            this.timeCheck.Name = "timeCheck";
            this.timeCheck.Size = new System.Drawing.Size(183, 24);
            this.timeCheck.TabIndex = 4;
            this.timeCheck.Text = "Show starting times?";
            this.toolTip1.SetToolTip(this.timeCheck, "Choose whether to show or hide starting times of events, if disabled the ending t" +
                    "imes of events while also be hidden.");
            this.timeCheck.UseVisualStyleBackColor = true;
            // 
            // amPmCheck
            // 
            this.amPmCheck.AutoSize = true;
            this.amPmCheck.Location = new System.Drawing.Point(8, 60);
            this.amPmCheck.Name = "amPmCheck";
            this.amPmCheck.Size = new System.Drawing.Size(192, 24);
            this.amPmCheck.TabIndex = 5;
            this.amPmCheck.Text = "Inculde AM/PM suffix?";
            this.toolTip4.SetToolTip(this.amPmCheck, "Choose whether to inclue the AM/PM suffix in times.");
            this.amPmCheck.UseVisualStyleBackColor = true;
            // 
            // linkBtn
            // 
            this.linkBtn.Location = new System.Drawing.Point(14, 144);
            this.linkBtn.Name = "linkBtn";
            this.linkBtn.Size = new System.Drawing.Size(192, 32);
            this.linkBtn.TabIndex = 6;
            this.linkBtn.Text = "Change Calendar";
            this.toolTip6.SetToolTip(this.linkBtn, "Change the URL or File Location for your calendar.");
            this.linkBtn.UseVisualStyleBackColor = true;
            // 
            // timeToCheck
            // 
            this.timeToCheck.AutoSize = true;
            this.timeToCheck.Location = new System.Drawing.Point(220, 18);
            this.timeToCheck.Name = "timeToCheck";
            this.timeToCheck.Size = new System.Drawing.Size(224, 24);
            this.timeToCheck.TabIndex = 7;
            this.timeToCheck.Text = "Display time to next event?";
            this.toolTip2.SetToolTip(this.timeToCheck, "Choose whether to show or hide the time until the next event.");
            this.timeToCheck.UseVisualStyleBackColor = true;
            // 
            // simpleCheck
            // 
            this.simpleCheck.AutoSize = true;
            this.simpleCheck.Location = new System.Drawing.Point(220, 60);
            this.simpleCheck.Name = "simpleCheck";
            this.simpleCheck.Size = new System.Drawing.Size(169, 24);
            this.simpleCheck.TabIndex = 8;
            this.simpleCheck.Text = "Simple Event Info?";
            this.toolTip3.SetToolTip(this.simpleCheck, "Choose whether to show an advanced or simple event info popup.");
            this.simpleCheck.UseVisualStyleBackColor = true;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(234, 144);
            this.reset.MaximumSize = new System.Drawing.Size(192, 32);
            this.reset.MinimumSize = new System.Drawing.Size(192, 32);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(192, 32);
            this.reset.TabIndex = 9;
            this.reset.Text = "Reset Settings";
            this.toolTip7.SetToolTip(this.reset, "Reset all settings to their defaults excluding your calendar URL or File Location" +
                    ".");
            this.reset.UseVisualStyleBackColor = true;
            // 
            // endsCheck
            // 
            this.endsCheck.AutoSize = true;
            this.endsCheck.Location = new System.Drawing.Point(8, 102);
            this.endsCheck.Name = "endsCheck";
            this.endsCheck.Size = new System.Drawing.Size(178, 24);
            this.endsCheck.TabIndex = 10;
            this.endsCheck.Text = "Show ending times?";
            this.toolTip5.SetToolTip(this.endsCheck, "Choose whether to show the ending times of events.");
            this.endsCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.abortion;
            this.ClientSize = new System.Drawing.Size(444, 250);
            this.Controls.Add(this.endsCheck);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.simpleCheck);
            this.Controls.Add(this.timeToCheck);
            this.Controls.Add(this.linkBtn);
            this.Controls.Add(this.amPmCheck);
            this.Controls.Add(this.timeCheck);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(450, 290);
            this.MinimumSize = new System.Drawing.Size(450, 290);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button abortion;
        private System.Windows.Forms.Button okay;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button linkBtn;
        public System.Windows.Forms.CheckBox timeCheck;
        public System.Windows.Forms.CheckBox amPmCheck;
        private System.Windows.Forms.CheckBox timeToCheck;
        public System.Windows.Forms.CheckBox simpleCheck;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.CheckBox endsCheck;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip7;
        private System.Windows.Forms.ToolTip toolTip5;
    }
}