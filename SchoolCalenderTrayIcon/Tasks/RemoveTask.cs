using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolCalendarTrayIcon.Tasks
{
    public partial class RemoveTask : Form
    {

        private List<Program.Task> tasks;
        private List<Program.Task> removedTasks;

        public RemoveTask(List<Program.Task> tasks)
        {
            InitializeComponent();
            this.ActiveControl = this.selection;

            tasks.Sort((x, y) => DateTime.Compare(x.time, y.time));
            this.tasks = tasks;
            this.removedTasks = new List<Program.Task>();

            this.selection.Items.Clear();
            string text;

            for (int i = 0; i < tasks.Count; i++)
            {
                text = "";
                text += tasks[i].name;
                if (Properties.Settings.Default.Times)
                {
                    if (Properties.Settings.Default.AMPM)
                        text += " - " + tasks[i].time.ToString().Replace(":00 ", " ");
                    else
                        text += " - " + tasks[i].time.ToString().Replace(":00 ", " ").Replace("AM", "").Replace("PM", "");
                }
                this.selection.Items.Add(text);
            }

            this.selection.SelectedIndex = 0;
            this.remove.Click += new EventHandler(remove_Click);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (this.selection.SelectedIndex < 0)
                return;
            this.removedTasks.Add(tasks[this.selection.SelectedIndex]);
            this.tasks.Remove(tasks[this.selection.SelectedIndex]);
            this.selection.Items.Clear();
            string text;
            for (int i = 0; i < tasks.Count; i++)
            {
                text = "";
                text += tasks[i].name;
                if (Properties.Settings.Default.Times)
                {
                    if (Properties.Settings.Default.AMPM)
                        text += " - " + tasks[i].time.ToString().Replace(":00 ", " ");
                    else
                        text += " - " + tasks[i].time.ToString().Replace(":00 ", " ").Replace("AM", "").Replace("PM", "");
                }
                this.selection.Items.Add(text);
            }
        }

        public List<Program.Task> getRemovedTasks()
        {
            try
            {
                return removedTasks;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            return new List<Program.Task>();
        }
    }
}
