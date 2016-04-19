namespace SchoolCalendarTrayIcon
{
    partial class Compass_Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compass_Schedule));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.canc = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.fromFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "textBox1";
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 63);
            this.textBox1.MaximumSize = new System.Drawing.Size(460, 26);
            this.textBox1.MinimumSize = new System.Drawing.Size(460, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(460, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your calendar URL or choose a calendar file:";
            // 
            // canc
            // 
            this.canc.AccessibleName = "CANC";
            this.canc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canc.Location = new System.Drawing.Point(50, 120);
            this.canc.Name = "canc";
            this.canc.Size = new System.Drawing.Size(128, 32);
            this.canc.TabIndex = 2;
            this.canc.Text = "CANCEL";
            this.canc.UseVisualStyleBackColor = true;
            // 
            // help
            // 
            this.help.AccessibleName = "HELP";
            this.help.Location = new System.Drawing.Point(225, 120);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(128, 32);
            this.help.TabIndex = 3;
            this.help.Text = "HELP";
            this.help.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(400, 120);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(128, 32);
            this.ok.TabIndex = 4;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // fromFile
            // 
            this.fromFile.CausesValidation = false;
            this.fromFile.Location = new System.Drawing.Point(480, 60);
            this.fromFile.Name = "fromFile";
            this.fromFile.Size = new System.Drawing.Size(80, 32);
            this.fromFile.TabIndex = 5;
            this.fromFile.Text = "Browse";
            this.fromFile.UseVisualStyleBackColor = true;
            // 
            // Compass_Schedule
            // 
            this.AcceptButton = this.ok;
            this.AccessibleName = "OK";
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(578, 164);
            this.Controls.Add(this.fromFile);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.help);
            this.Controls.Add(this.canc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 220);
            this.MinimumSize = new System.Drawing.Size(600, 220);
            this.Name = "Compass_Schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar Location";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button canc;
        public System.Windows.Forms.Button help;
        public System.Windows.Forms.Button ok;
        public System.Windows.Forms.Button fromFile;
    }
}