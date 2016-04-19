using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Configuration;

namespace SchoolCalendarTrayIcon
{
    /*
            public string name;
            public string details;
            public DateTime time;
            public DateTime alarm;
     */

    class TaskConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] parts = ((string)value).Split(new char[] { ',' });
                Program.Task task = new Program.Task();
                task.name = parts[0];
                task.details = parts.Length > 1 ? parts[1] : null;
                task.time = parts.Length > 2 ? Convert.ToDateTime(parts[2]) : System.DateTime.Now;
                task.alarm = parts.Length > 3 ? Convert.ToDateTime(parts[3]) : System.DateTime.Now;
                return task;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
    object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                Program.Task task = value as Program.Task;
                return string.Format("{0},{1},{2},{3}", task.name, task.details, task.time.ToString(), task.alarm.ToString());
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
