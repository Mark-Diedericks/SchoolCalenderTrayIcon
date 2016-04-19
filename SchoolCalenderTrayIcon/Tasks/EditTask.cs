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
    public partial class EditTask : Form
    {
        private Program.Task originalTask;
        private Program.Task editedTask;
        private List<Program.Task> tasks;

        public EditTask(List<Program.Task> tasks)
        {
            InitializeComponent();
            this.ActiveControl = this.name;

            tasks.Sort((x, y) => DateTime.Compare(x.time, y.time));
            this.tasks = tasks;

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

            this.OK.Click += new EventHandler(editTask);
            this.selection.SelectedIndexChanged +=new EventHandler(selectionChanged);
            this.time.Value = System.DateTime.Now;
            this.date.Value = System.DateTime.Now.Date;
            this.aDate.Value = System.DateTime.Now.Date;
            this.aTime.Value = System.DateTime.Now;

            refreshSelection();
        }

        public void selectionChanged(Object sender, EventArgs args)
        {
            refreshSelection();
        }

        public void refreshSelection()
        {
            this.originalTask = tasks[this.selection.SelectedIndex];
            this.name.Text = this.originalTask.name;
            this.details.Text = this.originalTask.details;
            this.date.Value = this.originalTask.time.Date;
            this.time.Value = this.originalTask.time;
            this.aDate.Value = this.originalTask.alarm.Date;
            this.aTime.Value = this.originalTask.alarm;
        }

        public void editTask(Object sender, EventArgs args)
        {
            this.originalTask = tasks[this.selection.SelectedIndex];

            DateTime taskTime = date.Value.Date.AddHours(time.Value.Hour).AddMinutes(time.Value.Minute);
            DateTime alarmTime = aDate.Value.Date.AddHours(aTime.Value.Hour).AddMinutes(aTime.Value.Minute);
            editedTask = Program.getProgram().initializeTask(taskTime);
            editedTask.name = name.Text;
            editedTask.details = details.Text;
            editedTask.time = taskTime;
            editedTask.alarm = alarmTime;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        public Program.Task getOriginalTask()
        {
            return originalTask;
        }

        public Program.Task getEditedTask()
        {
            return editedTask;
        }
    }
}
