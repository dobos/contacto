using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Contacto.Lib
{
    public static class Util
    {
        public static string TempDirName()
        {
            string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            tempPath += Path.DirectorySeparatorChar + "Contacto" + Path.DirectorySeparatorChar + "temp" + Path.DirectorySeparatorChar;
            if (!System.IO.Directory.Exists(tempPath))
                System.IO.Directory.CreateDirectory(tempPath);

            return tempPath;
        }

        public static string SmartDate(DateTime date)
        {
            if (date == DateTime.MinValue)
                return "(nem volt)";


            TimeSpan diff = (DateTime.Now.Date - date.Date);

            if (diff.Days == 0)
            {
                return "ma, " + date.ToShortTimeString();
            }
            if (diff.Days == 1)
            {
                return "tegnap, " + date.ToShortTimeString();
            }
            if (diff.Days == 2)
            {
                return "tegnapelõtt, " + date.ToShortTimeString();
            }
            if (diff.Days == -1)
            {
                return "holnap, " + date.ToShortTimeString();
            }
            if (diff.Days == 1)
            {
                return "holnapután, " + date.ToShortTimeString();
            }

            return date.ToLongDateString();
        }

        public static string UserName(Contacto.Lib.User user)
        {
            if (user != null)
                return user.LastName + " " + user.FirstName + " (" + user.Username + ")";
            else
                return "(nem ismert)";
        }

        public static string SmartFileSize(int size)
        {
            if (size < 0x400)
                return size.ToString() + " B";

            if (size < 0x100000)
                return Math.Round((double)size / 0x400).ToString() + " kB";

            return Math.Round((double)size / 0x400).ToString() + " MB";
        }
    }
}
