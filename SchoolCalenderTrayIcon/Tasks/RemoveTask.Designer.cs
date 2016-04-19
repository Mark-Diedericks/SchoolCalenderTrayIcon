namespace SchoolCalendarTrayIcon.Tasks
{
    partial class RemoveTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveTask));
            this.panel1 = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.selection = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.OK);
            this.panel1.Controls.Add(this.remove);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Location = new System.Drawing.Point(-5, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 50);
            this.panel1.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(334, 9);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(128, 32);
            this.OK.TabIndex = 2;
            this.OK.Text = "Done";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(182, 9);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(128, 32);
            this.remove.TabIndex = 1;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(30, 9);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(128, 32);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // selection
            // 
            this.selection.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selection.FormattingEnabled = true;
            this.selection.HorizontalScrollbar = true;
            this.selection.ItemHeight = 20;
            this.selection.Location = new System.Drawing.Point(0, 0);
            this.selection.Name = "selection";
            this.selection.ScrollAlwaysVisible = true;
            this.selection.Size = new System.Drawing.Size(478, 180);
            this.selection.TabIndex = 1;
            // 
            // RemoveTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(478, 228);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 284);
            this.MinimumSize = new System.Drawing.Size(500, 284);
            this.Name = "RemoveTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove A Task";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ListBox selection;
        private System.Windows.Forms.Button OK;
    }
}