using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace SchoolCalendarTrayIcon
{
    public class Program : Form
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                if (Environment.OSVersion.Version.Major >= 6)
                    SetProcessDPIAware();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                program = new Program();
                Application.Run(program);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
        }
 
        private NotifyIcon  trayIcon;
        private ContextMenu trayMenu;
        private Dictionary<DateTime, CalendarDay> days;
        private DateTime startingTime;
        private PeriodStruct currentPeriod;
        private InfoPopup infoPopup;
        private AdvancedInfoPopup advancedInfoPopup;
        private SettingsForm settingsForm;
        private List<Task> tasks;
        private List<Task> alarms;
        private System.ComponentModel.BackgroundWorker bw;
        public DateTime today;

        private static Program program;

        public Program()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Uninstall", OnUninstallExit);
            trayMenu.MenuItems.Add("Settings", onSettings);
            trayMenu.MenuItems.Add("Exit", OnExit);
            trayIcon = new NotifyIcon();
            trayIcon.Click += new System.EventHandler(onClicky);
            trayIcon.MouseMove += new MouseEventHandler(onMovey);
            today = System.DateTime.Now;
            tasks = new List<Task>();
            tasks.Sort((x, y) => DateTime.Compare(x.time, y.time));
            alarms = tasks;
            alarms.Sort((x, y) => DateTime.Compare(x.alarm, y.alarm));

            //Properties.Settings.Default.Tasks = tasks[0];

            if (Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\SchoolCalendarTrayIcon.exe" != System.Reflection.Assembly.GetExecutingAssembly().Location && "C:\\Users\\DIE0003\\Documents\\Visual Studio 2010\\Projects\\SchoolCalenderTrayIcon\\SchoolCalenderTrayIcon\\bin\\Debug\\SchoolCalendarTrayIcon.exe" != System.Reflection.Assembly.GetExecutingAssembly().Location)
            {
                createShortcut();
                if (System.Windows.Forms.MessageBox.Show("School Calendar Tray Icon has been installed. Would you like to run it now?") == DialogResult.OK)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\SchoolCalendarTrayIcon.exe");
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.Write(e.Message);
                    }
                }
                try
                {
                    Environment.Exit(0);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Write(e.Message);
                }
            }

            days = LoadPeriods();

            bw = new System.ComponentModel.BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new System.ComponentModel.DoWorkEventHandler(background_work);
            
            startingTime = System.DateTime.Now;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            bw.RunWorkerAsync();
        }

        public static Program getProgram()
        {
            return program;
        }

        /* SETTINGS */
        public void onSettings(Object sender, EventArgs args)
        {
            closeForms();
            settingsForm = new SettingsForm();
            
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                settingsForm.sync();
                Properties.Settings.Default.Save();
            }

            settingsForm.Dispose();
        }

        /* HIGH DPI */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /* BACKGROUND WORK */
        public void background_work(object sender, System.ComponentModel.DoWorkEventArgs args)
        {
            System.ComponentModel.BackgroundWorker b = sender as System.ComponentModel.BackgroundWorker;
            int i = 0;
            Boolean cancel = false;

            while (cancel == false)
            {
                if ((b.CancellationPending == true))
                {
                    cancel = true;
                    break;
                }
                else
                {
                    i++;
                    if (i >= 10)
                    {
                        today = System.DateTime.Now;
                        reload();

                        try
                        {
                            if (advancedInfoPopup != null)
                                advancedInfoPopup.refreshTasks(getTasks(System.DateTime.Now));
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.Write(e.Message);
                        }

                        i = 0;
                    }

                    tasks.Sort((x, y) => DateTime.Compare(x.time, y.time));
                    alarms = tasks;
                    alarms.Sort((x, y) => DateTime.Compare(x.alarm, y.alarm));
                    List<Task> newAlarms = new List<Task>();
                    String tasksNotification = "";

                    for(int j = 0; j < alarms.Count; j++)
                    {
                        if (alarms[j].alarm <= System.DateTime.Now && alarms[j].alarm >= System.DateTime.Now.Date)
                        {
                            string timeTo = (alarms[j].time - System.DateTime.Now).ToString().Substring(0, 5);
                            if (alarms[j].time.Date == System.DateTime.Now.Date)
                            {
                                if (alarms[j].time <= System.DateTime.Now)
                                    timeTo = " - Now";
                            }
                            else
                            {
                                timeTo = "";
                            }

                            try
                            {
                                tasksNotification += alarms[j].name + " (" + alarms[j].time.ToString().Substring(10).Replace(":00 ", " ") + ") is due in: " + timeTo + System.Environment.NewLine;
                                System.Diagnostics.Debug.Write(alarms[j].name + System.Environment.NewLine);
                            }
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.Write(e.Message);
                            }
                        }
                        else if (alarms[j].alarm > System.DateTime.Now)
                        {
                            newAlarms.Add(alarms[j]);
                        }
                    }

                    alarms = newAlarms;
                    tasks = alarms;

                    if (tasksNotification != "")
                    {
                        try
                        {
                            trayIcon.ShowBalloonTip(15000, "Task Notification", tasksNotification, ToolTipIcon.None);
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.Write(e.Message);
                        }
                    }

                    refreshIcon(getEventsForDate(today));

                    try
                    {
                        b.ReportProgress(1);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.Write(e.Message);
                    }
                    System.Threading.Thread.Sleep(30000);
                }
            }

            args.Cancel = true;

            try
            {
                b.ReportProgress(100);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
        }

        public void reload()
        {
            days = LoadPeriods();
            refreshIcon(getEventsForDate(today));
        }

        /* SHORTCUT */
        public void createShortcut()
        {
            try
            {
                File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\SchoolCalendarTrayIcon.exe", true);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
        }

        /* CLICKY */

        public void onClicky(Object sender, EventArgs args)
        {
            if (infoPopup != null || advancedInfoPopup != null)
            {
                if (infoPopup != null) infoPopup.Dispose();
                if (advancedInfoPopup != null) advancedInfoPopup.Dispose();

                infoPopup = null;
                advancedInfoPopup = null;
                return;
            }

            try
            {
                if (Properties.Settings.Default.SimpleInfo)
                {
                    infoPopup = new InfoPopup();
                    infoPopup.SetDesktopLocation(MousePosition.X - infoPopup.Width / 2, Screen.PrimaryScreen.WorkingArea.Height - infoPopup.Height - 20);

                    infoPopup.Show(this);
                    infoPopup.Focus();
                }
                else
                {
                    advancedInfoPopup = new AdvancedInfoPopup();
                    advancedInfoPopup.SetDesktopLocation(MousePosition.X - advancedInfoPopup.Width / 2, Screen.PrimaryScreen.WorkingArea.Height - advancedInfoPopup.Height - 20);

                    advancedInfoPopup.Show(this);
                    advancedInfoPopup.Focus();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
        }

        public void onMovey(Object sender, MouseEventArgs args)
        {
            refreshIcon(getEventsForDate(today));
        }

        /* INIT */

        public Dictionary<DateTime, CalendarDay> LoadPeriods()
        {
            System.Diagnostics.Debug.Write("Update" + System.Environment.NewLine);

            if (Properties.Settings.Default.CompassLink == "Nil" || "C:\\Users\\DIE0003\\Documents\\Visual Studio 2010\\Projects\\SchoolCalenderTrayIcon\\SchoolCalenderTrayIcon\\bin\\Debug\\SchoolCalendarTrayIcon.exe" == System.Reflection.Assembly.GetExecutingAssembly().Location)
            {
                Compass_Schedule link = new Compass_Schedule();
                if (link.ShowDialog(this) == DialogResult.OK)
                {
                    Properties.Settings.Default.CompassLink = link.textBox1.Text;
                }
                else
                {
                    Properties.Settings.Default.CompassLink = "";
                }

                link.Dispose();
            }

            if (!checkFile(Properties.Settings.Default.CompassLink))
            {
                OnErrorExit();
            }

            Properties.Settings.Default.Save();

            string url = Properties.Settings.Default.CompassLink;
            string[] periodsText = splitCalender(readCalender(url));
            Dictionary<DateTime, CalendarDay> days = new Dictionary<DateTime, CalendarDay>();

            if (periodsText == null)
            {
                MessageBox.Show("Currently unable to load your calendar, School Calendar Tray Icon will continue to attempt loading your calendar.", "School Calendar Tray Icon Error");
            }

            PeriodStruct[] periods = CreatePeriods(periodsText).ToArray();
            string nl = System.Environment.NewLine;

            for (int i = 0; i < periods.Length; i++ )
            {
                if (periods[i].name.Contains("."))
                    periods[i].name = periods[i].name.Split(".".ToCharArray())[0];
                try
                {
                    periods[i].name = System.Text.RegularExpressions.Regex.Replace(periods[i].name, "[0-9]", "");
                    periods[i].name = periods[i].name.Replace("/", "");
                    periods[i].name = periods[i].name.Replace("\\", "");

                    if (days.ContainsKey(periods[i].startTime.Date))
                    {
                        days[periods[i].startTime.Date].periods.Add(periods[i]);
                    }
                    else
                    {
                        days.Add(periods[i].startTime.Date, initializeCalendarDay(periods[i].startTime.Date));
                        days[periods[i].startTime.Date].periods.Add(periods[i]);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Write(e.Message);
                }
            }

            foreach (KeyValuePair<DateTime, CalendarDay> day in days)
            {
                day.Value.periods.Sort((x, y) => DateTime.Compare(x.startTime, y.startTime));

                for (int i = 0; i < day.Value.periods.Count; i++)
                {
                    day.Value.names.Add(day.Value.periods[i].name);
                    day.Value.rooms.Add(day.Value.periods[i].room);
                    day.Value.times.Add(day.Value.periods[i].startTime.ToString().Substring(10).Replace(":00 ", " "));
                    day.Value.ends.Add(day.Value.periods[i].endTime.ToString().Substring(10).Replace(":00 ", " "));
                }
            }

            System.Diagnostics.Debug.Write(days.Count.ToString() + System.Environment.NewLine);
            return days;
        }

        public CalendarDay getEventsForDate(DateTime date)
        {
            if(days.ContainsKey(date.Date))
            {
                return days[date.Date];
            }

            System.Diagnostics.Debug.Write("Day Not Found: " + date.ToString() + System.Environment.NewLine);

            return createBlankDay();
        }

        public List<Task> getAllTasks()
        {
            return tasks;
        }

        public void addTask(Task task)
        {
            tasks.Add(task);
            tasks.Sort((x, y) => DateTime.Compare(x.time, y.time));
            alarms = tasks;
            alarms.Sort((x, y) => DateTime.Compare(x.alarm, y.alarm));
        }

        public void removeTask(Task task)
        {
            tasks.Remove(task);
            tasks.Sort((x, y) => DateTime.Compare(x.time, y.time));
            alarms = tasks;
            alarms.Sort((x, y) => DateTime.Compare(x.alarm, y.alarm));
        }

        public void editTask(Task originalTask, Task editedTask)
        {
            int i = tasks.IndexOf(originalTask);
            tasks[i] = editedTask;
            tasks.Sort((x, y) => DateTime.Compare(x.time, y.time));
            alarms = tasks;
            alarms.Sort((x, y) => DateTime.Compare(x.alarm, y.alarm));
        }

        public List<Task> getTasks(DateTime date)
        {
            List<Task> after = new List<Task>();
            foreach(Task task in getAllTasks())
            {
                if(task.time >= date.Date)
                {
                    after.Add(task);
                }
            }

            after.Sort((x, y) => DateTime.Compare(x.time, y.time));

            return after;
        }

        public Task getCurrentTask(DateTime date)
        {
            return getTasks(date)[getTasks(date).Count - 1];
        }

        public PeriodStruct getPeriodAtCurrentTime(CalendarDay day)
        {
            PeriodStruct current = initializePeriodStruct(day.date);

            for (int i = 0; i < day.periods.Count; i++)
            {
                DateTime endTime = day.periods[i].endTime;
                if (i < day.periods.Count - 1) endTime = day.periods[i + 1].switchTime;

                if (checkTime(day.periods[i], endTime.TimeOfDay, System.DateTime.Now.TimeOfDay))
                {
                    if (i < day.periods.Count - 1)
                    {
                        current = day.periods[i + 1];
                    }
                    else
                    {
                        current = day.periods[i];
                    }
                }
            }

            if (current.name == "Nil")
            {
                if (System.DateTime.Now <= day.periods[0].startTime)
                {
                    current = day.periods[0];
                }
                else if (System.DateTime.Now >= day.periods[day.periods.Count - 1].endTime)
                {
                    current = day.periods[day.periods.Count - 1];
                }
            }

            return current;
        }

        public static bool checkFile(string path)
        {
            if (IsLocalPath(path))
            {
                return File.Exists(path);
            }
            else if (checkUrl(path))
            {
                return true;
            }

            return false;
        }

        public static bool checkUrl(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsLocalPath(string p)
        {
            if (p.StartsWith("http"))
            {
                return false;
            }

            try
            {
                return new Uri(p).IsFile;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
                return !checkUrl(p);
            }
        }

        public void refreshIcon(CalendarDay day)
        {
            currentPeriod = initializePeriodStruct(day.date);
            string nl = System.Environment.NewLine;

            currentPeriod = getPeriodAtCurrentTime(day);

            trayIcon.Icon = GetIcon(currentPeriod.name, currentPeriod.room);
        }


        /* TIME */

        public Boolean checkDate(PeriodStruct period, DateTime current) 
        {
            return period.startTime.Date == current.Date;
        }

        public Boolean checkTime(PeriodStruct period, TimeSpan endTime, TimeSpan current)
        {
            if (current >= period.switchTime.TimeOfDay && current <= endTime)
            {
                return true;
            }

            return false;
        }

        /* PERIODS AND COMPLETION */

        public List<PeriodStruct> CreatePeriods(string[] periodText)
        {
            List<PeriodStruct> periods = new List<PeriodStruct>();

            for (int i = 1; i < periodText.Length; i++)
            {
                PeriodStruct ps = new PeriodStruct();
                List<string> lines = periodText[i].Split(new[] { '\r', '\n' }).ToList();
                for (int j = 0; j < lines.Count; j++)
                {
                    try
                    {
                        if (String.IsNullOrWhiteSpace(lines[j])) lines.RemoveAt(j);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.Write(e.Message);
                    }
                }
                ps.name = identifyName(lines.ToArray());
                ps.room = identifyRoom(lines.ToArray());
                ps.startTime = identifyStart(lines.ToArray());
                ps.switchTime = ps.startTime;
                ps.switchTime.AddMinutes(5);
                ps.endTime = identifyEnd(lines.ToArray());
                periods.Add(ps);
            }

            periods.Sort((x, y) => DateTime.Compare(x.startTime, y.startTime));

            return periods;
        }

        public DateTime createNullDate()
        {
            return new DateTime(1, 1, 1, 1, 1, 1);
        }

        [System.ComponentModel.TypeConverter(typeof(TaskConverter))]
        [System.Configuration.SettingsSerializeAs(System.Configuration.SettingsSerializeAs.String)]
        public class Task
        {
            public string name;
            public string details;
            public DateTime time;
            public DateTime alarm;
        }

        public Task initializeTask(DateTime date)
        {
            Task task = new Task();
            task.name = "";
            task.details = "";
            task.time = date;
            task.alarm = createNullDate();
            return task;
        }

        public Task createBlankTask()
        {
            Task task = new Task();
            task.name = "Task";
            task.details = "TASK";
            task.time = System.DateTime.Now.Date.AddDays(1);
            return task;
        }

        public struct PeriodStruct
        {
            public string name;
            public string room;
            public DateTime startTime;
            public DateTime switchTime;
            public DateTime endTime;
        }

        public PeriodStruct initializePeriodStruct(DateTime date)
        {
            PeriodStruct period = new PeriodStruct();
            period.name = "None";
            period.room = "";
            period.startTime = date.Date;
            period.switchTime = period.startTime;
            period.endTime = date.Date;
            period.endTime.AddHours(23);
            period.endTime.AddMinutes(59);
            period.endTime.AddSeconds(59);
            return period;
        }

        public struct CalendarDay
        {
            public List<string> names;
            public List<string> rooms;
            public List<string> times;
            public List<string> ends;
            public List<PeriodStruct> periods;
            public DateTime date;
        }

        public CalendarDay initializeCalendarDay(DateTime date)
        {
            CalendarDay day = new CalendarDay();
            day.names = new List<string>();
            day.rooms = new List<string>();
            day.times = new List<string>();
            day.ends = new List<string>();
            day.periods = new List<PeriodStruct>();
            day.date = date.Date;
            return day;
        }

        public CalendarDay createBlankDay()
        {
            CalendarDay day = initializeCalendarDay(System.DateTime.Now.Date.AddDays(1));
            day.periods.Add(initializePeriodStruct(day.date));
            day.names.Add(day.periods[0].name);
            day.rooms.Add(day.periods[0].room);
            day.times.Add(day.periods[0].startTime.ToString().Substring(10).Replace(":00 ", " "));
            day.ends.Add(day.periods[0].endTime.ToString().Substring(10).Replace(":00 ", " "));
            return day;
        }

        public string identifyName(string[] periodData)
        {
            
            try
            {
                for (int i = 0; i < periodData.Length; i++)
                {
                    if(periodData[i].StartsWith("DESCRIPTION:"))
                    {
                        return periodData[i].Replace("DESCRIPTION:", "").Trim();
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            return "";
        }

        public string identifyRoom(string[] periodData)
        {
            try
            {
                for (int i = 0; i < periodData.Length; i++)
                {
                    if (periodData[i].StartsWith("LOCATION:"))
                    {
                        return periodData[i].Replace("LOCATION:", "").Trim();
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            return "";
        }

        public DateTime identifyStart(string[] periodData)
        {
            try
            {
                string newData = "";
                for (int i = 0; i < periodData.Length; i++)
                {
                    if (periodData[i].StartsWith("DTSTART:"))
                    {
                        newData = periodData[i].Replace("DTSTART:", "").Trim();
                    }
                }

                if (newData == "")
                    OnErrorExit();

                DateTime dt = DateTime.ParseExact(newData.Replace("T", "").Replace("Z", ""), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.AdjustToUniversal);
                return dt.ToLocalTime();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }

            return System.DateTime.Now.Date;
        }

        public DateTime identifyEnd(string[] periodData)
        {
            try
            {
                string newData = "";
                for (int i = 0; i < periodData.Length; i++)
                {
                    if (periodData[i].StartsWith("DTEND:"))
                    {
                        newData = periodData[i].Replace("DTEND:", "").Trim();
                    }
                }

                if (newData == "")
                    OnErrorExit();

                DateTime dt = DateTime.ParseExact(newData.Replace("T", "").Replace("Z", ""), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.AdjustToUniversal);
                return dt.ToLocalTime();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            return System.DateTime.Now.Date;
        }

        /* LOADING AND PREPARTION*/

        public string readCalender(string url)
        {
            if (IsLocalPath(url))
            {
                try
                {
                    System.Diagnostics.Debug.Write("\"" + url + "\" is a local file." + System.Environment.NewLine);
                    return File.ReadAllText(url);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Write(e.Message);
                }
            }
            else
            {
                System.Diagnostics.Debug.Write("\"" + url + "\" is an URL." + System.Environment.NewLine);
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    if (System.Windows.Forms.MessageBox.Show("Unable to connect to the internet!") == DialogResult.OK)
                    {
                        System.Diagnostics.Debug.Write("No Valid Connect To The Internet.");
                    }
                    OnErrorExit();
                }
                try
                {
                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        if (System.Windows.Forms.MessageBox.Show("Unable to connect to your compass schedule!") == DialogResult.OK)
                        {
                            System.Diagnostics.Debug.Write("HTTPWebResponse Error: " + response.StatusCode.ToString());
                        }
                        OnErrorExit();
                    }
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    return reader.ReadToEnd();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Write(e.Message);
                }
            }

            return "";
        }

        public string[] splitCalender(string content)
        {
            try
            {
                return content.Split(new[] { "BEGIN:VEVENT" }, StringSplitOptions.None);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            return new[] {""};
        }

        /* GRAPHICS */

        public System.Drawing.Icon GetIcon(string period, string room)
        {
            try
            {
                //Create bitmap, kind of canvas
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(128, 128);

                System.Drawing.Font drawFont = new System.Drawing.Font("Calibri", 32, System.Drawing.FontStyle.Bold);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

                System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                int pl = graphics.MeasureString(period.Substring(0, 4), drawFont).ToSize().Width;
                Boolean three = false;
                if (pl > 128)
                {
                    pl = graphics.MeasureString(period.Substring(0, 3), drawFont).ToSize().Width;
                    three = true;
                }
                int rl = graphics.MeasureString(room, drawFont).ToSize().Width;
                if (!three) graphics.DrawString(period.Substring(0, 4), drawFont, drawBrush, 64 - (pl / 2), 0);
                else graphics.DrawString(period.Substring(0, 3), drawFont, drawBrush, 64 - (pl / 2), 0);
                graphics.DrawString(room, drawFont, drawBrush, 64 - (rl / 2), 64);

                //To Save icon to disk
                //MemoryStream ms = new MemoryStream();
                //bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Icon);

                System.Drawing.Icon createdIcon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());

                drawFont.Dispose();
                drawBrush.Dispose();
                graphics.Dispose();
                bitmap.Dispose();

                return createdIcon;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }

            return System.Drawing.SystemIcons.Error;
        }

        /* ICON STUFF */

        public void closeForms()
        {
            if (infoPopup != null) infoPopup.Dispose();
            if (advancedInfoPopup != null) advancedInfoPopup.Dispose();
            if (settingsForm != null) settingsForm.Dispose();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
 
            base.OnLoad(e);
        }
 
        private void OnExit(object sender, EventArgs e)
        {
            Dispose(true);
            Application.Exit();
        }

        private void OnUninstallExit(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Are you sure you would like to uninstall this program?", "School Calendar Tray Icon", System.Windows.Forms.MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Properties.Settings.Default.CompassLink = "Nil";
                Properties.Settings.Default.AMPM = true;
                Properties.Settings.Default.Times = true;
                Properties.Settings.Default.TimeTo = true;
                Properties.Settings.Default.Save();
                Dispose(true);
                Delete();
                Application.Exit();
            }
        }

        private void OnErrorExit()
        {
            Dispose(true);
            Application.Exit();
        }

        private void Delete()
        {
            File.Delete(Properties.Settings.Default.Tasks);
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"";
            Info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            System.Diagnostics.Process.Start(Info); 
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Visible = false;
                trayIcon.Dispose();
                trayMenu.Dispose();
                bw.CancelAsync();
            }
 
            base.Dispose(isDisposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Program));
            this.SuspendLayout();
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Program";
            this.ResumeLayout(false);

        }
    }
}
