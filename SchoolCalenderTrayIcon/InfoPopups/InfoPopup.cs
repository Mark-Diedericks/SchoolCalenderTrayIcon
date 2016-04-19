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
    public partial class InfoPopup : Form
    {
        public InfoPopup()
        {
            InitializeComponent();
            changeDate();
        }

        public void changeDate()
        {
            Program.CalendarDay day = Program.getProgram().getEventsForDate(System.DateTime.Now);
            Program.PeriodStruct currentPeriod = Program.getProgram().getPeriodAtCurrentTime(day);

            string timeTo = (currentPeriod.startTime - System.DateTime.Now).ToString().Substring(0, 5);
            if (currentPeriod.startTime <= System.DateTime.Now)
            {
                timeTo = "Now";
            }

            int biggest = 100;

            if (Properties.Settings.Default.TimeTo) title.Text = currentPeriod.name + " " + currentPeriod.room + " - " + timeTo;
            else title.Text = currentPeriod.name + " " + currentPeriod.room;

            Font bigFont = new Font("Microsoft Sans Serif", 10.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            Font smallFont = new Font("Microsoft Sans Serif", 8.0f, GraphicsUnit.Pixel);
            if (getWidth(title.Text, bigFont) >= biggest)
                biggest = getWidth(title.Text, bigFont);

            periodContents.Text = "";
            string line = "";
            for (int i = 0; i < day.names.Count; i++)
            {
                line = "";
                line += day.names[i] + " " + day.rooms[i];
                if (Properties.Settings.Default.Times)
                {
                    if (Properties.Settings.Default.AMPM)
                        line += " - " + day.times[i];
                    else
                        line += " - " + day.times[i].Replace("AM", "").Replace("PM", "");

                    if (Properties.Settings.Default.Ends)
                    {
                        if (Properties.Settings.Default.AMPM)
                            line += " - " + day.ends[i];
                        else
                            line += " - " + day.ends[i].Replace("AM", "").Replace("PM", "");
                    }
                }

                if (getWidth(line, smallFont) >= biggest)
                    biggest = getWidth(line, smallFont);
                periodContents.Text += line + System.Environment.NewLine;
            }

            Height = (30 * day.names.Count) + 40;
            title.Text += "   " + biggest;
            Width = (int)((float)biggest * 2.1f) + 40;
            periodContents.Height = (30 * day.names.Count) + 64;
        }

        private int getWidth(string input, Font font)
        {
            try
            {
                return (int)TextRenderer.MeasureText(input, font).Width;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
                return input.Length * 5;
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
    }
}
