using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolCalendarTrayIcon
{
    public partial class SettingsForm : Form
    {
        public string link;
        public SettingsForm()
        {
            InitializeComponent();
            link = Properties.Settings.Default.CompassLink;
            this.apply.Click += new EventHandler(onApply);
            this.linkBtn.Click += new EventHandler(onLink);
            this.reset.Click += new EventHandler(onReset);
        }

        public void onReset(Object sender, EventArgs args)
        {
            timeCheck.Checked = true;
            timeToCheck.Checked = true;
            amPmCheck.Checked = true;
            simpleCheck.Checked = true;
            endsCheck.Checked = true;

            sync();
            Properties.Settings.Default.Save();
        }

        public void sync()
        {
            Properties.Settings.Default.Times = timeCheck.Checked;
            Properties.Settings.Default.TimeTo = timeToCheck.Checked;
            Properties.Settings.Default.AMPM = amPmCheck.Checked;
            Properties.Settings.Default.SimpleInfo = simpleCheck.Checked;
            Properties.Settings.Default.Ends = endsCheck.Checked;
        }

        public void onApply(Object sender, EventArgs args)
        {
            sync();
            Properties.Settings.Default.Save();
        }

        public void onLink(Object sender, EventArgs args)
        {
            Compass_Schedule testDialog = new Compass_Schedule();

            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                link = testDialog.textBox1.Text;
            }

            if (Program.checkFile(link)) Properties.Settings.Default.CompassLink = link;

            testDialog.Dispose();

            Program.getProgram().reload();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            timeCheck.Checked = Properties.Settings.Default.Times;
            timeToCheck.Checked = Properties.Settings.Default.TimeTo;
            amPmCheck.Checked = Properties.Settings.Default.AMPM;
            simpleCheck.Checked = Properties.Settings.Default.SimpleInfo;
            endsCheck.Checked = Properties.Settings.Default.Ends;
        }
    }
}
