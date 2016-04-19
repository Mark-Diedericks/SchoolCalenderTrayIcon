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
    public partial class Compass_Schedule : Form
    {
        public Compass_Schedule()
        {
            InitializeComponent();
            this.textBox1.Click += new EventHandler(textBox_Click);
            this.help.Click += new EventHandler(help_Click);
            this.fromFile.Click += new EventHandler(browse_Click);
        }

        private void textBox_Click(Object sender, EventArgs args)
        {
            textBox1.Focus();
        }

        private void browse_Click(Object sender, EventArgs args)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Calendar Files (*.ics)|*.ics";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                    textBox1.Text = ofd.FileName;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
        }

        private void help_Click(Object sender, EventArgs args)
        {
            Help help = new Help();
            try
            {
                help.ShowDialog(this);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
        }
    }
}
