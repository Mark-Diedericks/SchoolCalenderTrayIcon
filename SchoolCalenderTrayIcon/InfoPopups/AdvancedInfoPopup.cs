using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SchoolCalendarTrayIcon.Tasks;

namespace SchoolCalendarTrayIcon
{
    public partial class AdvancedInfoPopup : Form
    {
        private bool task;
        private DateTime then;
        private List<Program.Task> tasks;

        public AdvancedInfoPopup()
        {
            InitializeComponent();
            task = false;
            then = System.DateTime.Now;
            changeToDate(this.monthCal.TodayDate);
            refreshTasks(Program.getProgram().getTasks(System.DateTime.Now));
            this.monthCal.DateSelected += new DateRangeEventHandler(date_Change);
            this.taskBtn.Click += new EventHandler(task_Click);
            this.TaskAdd.Click += new EventHandler(addTask);
            this.TaskTake.Click +=new EventHandler(removeTask);
            this.TaskEdit.Click += new EventHandler(editTask);
        }

        private void addTask(Object sender, EventArgs args)
        {
            AddTask at = new AddTask();
            if (at.ShowDialog(this) == DialogResult.OK)
            {
                System.Diagnostics.Debug.Write("TRUE" + System.Environment.NewLine);
                Program.getProgram().addTask(at.getNewTask());
                refreshTasks(Program.getProgram().getTasks(System.DateTime.Now));
                changeToTask();
                this.task = true;
            }
        }

        private void removeTask(Object sender, EventArgs args)
        {
            if (tasks.Count <= 0)
                return;
            RemoveTask rt = new RemoveTask(tasks);
            if (rt.ShowDialog(this) == DialogResult.OK)
            {
                foreach(Program.Task task in rt.getRemovedTasks())
                {
                    Program.getProgram().removeTask(task);
                }
                refreshTasks(Program.getProgram().getTasks(System.DateTime.Now));
                changeToTask();
                this.task = true;
            }
        }

        private void editTask(Object sender, EventArgs args)
        {
            if (tasks.Count <= 0)
                return;
            EditTask et = new EditTask(tasks);
            if (et.ShowDialog(this) == DialogResult.OK)
            {
                Program.getProgram().editTask(et.getOriginalTask(), et.getEditedTask());
                refreshTasks(Program.getProgram().getTasks(System.DateTime.Now));
                changeToTask();
                this.task = true;
            }
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        private void task_Click(Object sender, EventArgs args)
        {
            if (task == false)
            {
                task = true;
                this.taskBtn.Text = "Events";
                changeToTask();
            }
            else
            {
                task = false;
                this.taskBtn.Text = "Tasks";
                changeToDate(then);
            }
        }

        public void refreshTasks(List<Program.Task> tasks)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Program.Task task in tasks)
            {
                DateTime date = task.time.Date;
                dates.Add(date);
            }

            dates.Sort((x, y) => DateTime.Compare(x, y));

            this.tasks = tasks;
            this.monthCal.BoldedDates = dates.ToArray();
        }

        private void date_Change(Object sender, DateRangeEventArgs args)
        {
            DateTime now = System.DateTime.Now;
            then = args.Start.Date;
            then.Add(new TimeSpan(now.Hour, now.Minute, now.Second));
            if(task == false)
                changeToDate(then);
        }

        private void changeToDate(DateTime date)
        {
            this.periodContents.Width = 310;
            this.TaskAdd.Visible = false;
            this.TaskTake.Visible = false;
            this.TaskEdit.Visible = false;

            Program.CalendarDay day = Program.getProgram().getEventsForDate(date);
            Program.PeriodStruct currentPeriod = Program.getProgram().getPeriodAtCurrentTime(day);

            this.toolTip2.SetToolTip(this.periodContents, "");

            string timeTo = " - " + (currentPeriod.startTime - System.DateTime.Now).ToString().Substring(0, 5);
            if (currentPeriod.startTime.Date == System.DateTime.Now.Date)
            {
                if (currentPeriod.startTime <= System.DateTime.Now)
                    timeTo = " - Now";
            }
            else
            {
                timeTo = "";
            }

            if (Properties.Settings.Default.TimeTo) title.Text = currentPeriod.name + " " + currentPeriod.room + timeTo;
            else title.Text = currentPeriod.name + " " + currentPeriod.room;

            periodContents.Text = "";
            for (int i = 0; i < day.names.Count; i++)
            {
                periodContents.Text += day.names[i] + " " + day.rooms[i];
                if (Properties.Settings.Default.Times)
                {
                    if (Properties.Settings.Default.AMPM)
                        periodContents.Text += " - " + day.times[i];
                    else
                        periodContents.Text += " - " + day.times[i].Replace("AM", "").Replace("PM", "");

                    if (Properties.Settings.Default.Ends)
                    {
                        if (Properties.Settings.Default.AMPM)
                            periodContents.Text += " - " + day.ends[i];
                        else
                            periodContents.Text += " - " + day.ends[i].Replace("AM", "").Replace("PM", "");
                    }
                }
                periodContents.Text += System.Environment.NewLine;
            }
        }

        private void changeToTask()
        {
            this.periodContents.Width = 266;
            this.TaskAdd.Visible = true;
            this.TaskTake.Visible = true;
            this.TaskEdit.Visible = true;

            if (Program.getProgram().getTasks(System.DateTime.Now).Count <= 0)
            {
                this.title.Text = "None";
                this.periodContents.Text = "";
                return;
            }

            Program.Task currentTask = Program.getProgram().getCurrentTask(System.DateTime.Now);
            string texts = "";

            foreach (Program.Task task in tasks)
            {
                texts += task.details + System.Environment.NewLine;
            }

            this.toolTip2.SetToolTip(this.periodContents, texts);

            string timeTo = " - " + (currentTask.time - System.DateTime.Now).ToString().Substring(0, 5);
            if (currentTask.time.Date == System.DateTime.Now.Date)
            {
                if (currentTask.time <= System.DateTime.Now)
                    timeTo = " - Now";
            }
            else
            {
                timeTo = "";
            }

            if (Properties.Settings.Default.TimeTo) title.Text = currentTask.name + timeTo;
            else title.Text = currentTask.name;

            periodContents.Text = "";
            for (int i = 0; i < tasks.Count; i++)
            {
                periodContents.Text += tasks[i].name;
                if (Properties.Settings.Default.Times)
                {
                    if (Properties.Settings.Default.AMPM)
                        periodContents.Text += " - " + tasks[i].time.ToString().Replace(":00 ", " ");
                    else
                        periodContents.Text += " - " + tasks[i].time.ToString().Replace(":00 ", " ").Replace("AM", "").Replace("PM", "");
                }
                periodContents.Text += System.Environment.NewLine;
            }
        }
    }
}
