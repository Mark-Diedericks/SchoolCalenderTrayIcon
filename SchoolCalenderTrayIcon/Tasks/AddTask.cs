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
    public partial class AddTask : Form
    {
        private Program.Task newTask;

        public AddTask()
        {
            InitializeComponent();
            this.ActiveControl = this.name;
            this.OK.Click += new EventHandler(createTask);
            this.time.Value = System.DateTime.Now;
            this.date.Value = System.DateTime.Now.Date;
            this.aDate.Value = System.DateTime.Now.Date;
            this.aTime.Value = System.DateTime.Now;
        }

        private void createTask(Object sender, EventArgs args)
        {
            DateTime taskTime = date.Value.Date.AddHours(time.Value.Hour).AddMinutes(time.Value.Minute);
            DateTime alarmTime = aDate.Value.Date.AddHours(aTime.Value.Hour).AddMinutes(aTime.Value.Minute);
            newTask = Program.getProgram().initializeTask(taskTime);
            newTask.name = name.Text;
            newTask.details = details.Text;
            newTask.time = taskTime;
            newTask.alarm = alarmTime;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        public Program.Task getNewTask()
        {
            return newTask;
        }
    }
}
