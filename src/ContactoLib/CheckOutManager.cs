using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Contacto.Lib
{
    public class CheckOutManager : ObjectBase
    {
        public List<Blob> CheckedoutBlobs;

        private FileSystemWatcher watcher;
        private string tempPath;

        public event EventHandler Changed;

        public CheckOutManager()
        {
            CheckedoutBlobs = new List<Blob>();

            tempPath = Util.TempDirName();

            watcher = new FileSystemWatcher(tempPath);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            StartWatching();
        }

        public bool IsCheckedOut(Blob blob)
        {
            // *** ez itt hibát dob, ha elõtte volt preview, azt nem kell nézni
            //if (blob.CheckedOutBy != Guid.Empty)
            //    return true;

            foreach (Blob b in CheckedoutBlobs)
            {
                if (b.Guid == blob.Guid)
                    return true;
            }
            return false;
        }

        public string GetTempfileName(Blob blob)
        {
            string name = Path.GetFileNameWithoutExtension(blob.Filename);
            string ext = Path.GetExtension(blob.Filename);

            int q = 1;
            string fullname;
            while (true)
            {
                fullname = tempPath + name + "[" + q.ToString() + "]" + ext;

                if (File.Exists(fullname))
                {
                    q++;
                    continue;
                }
                else
                    break;
            }

            return fullname;
        }

        public void OpenForPreview(Blob b)
        {
            System.Diagnostics.Process.Start(b.TempFilename);
            b.TempFilename = string.Empty;    // to allow further previews
        }

        public void OpenForPrint(Blob b)
        {
            System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo();

            pinfo.FileName = b.TempFilename;
            pinfo.Verb = "print";

            System.Diagnostics.Process.Start(pinfo);
            
            b.TempFilename = string.Empty;    // to allow further previews
        }

        public void OpenForEdit(Blob b)
        {
            System.Diagnostics.Process.Start(b.TempFilename);
            CheckedoutBlobs.Add(b);
        }

        public void StartWatching()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void StopWatching()
        {
            watcher.EnableRaisingEvents = false;
        }

        public void Cleanup()
        {
            foreach (Blob blob in CheckedoutBlobs)         
            {
                //File.Delete(file);
            }
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                foreach (Blob blob in CheckedoutBlobs)
                {
                    if (blob.TempFilename == e.FullPath &&
                        blob.CheckoutTime != File.GetLastWriteTime(blob.TempFilename))
                    {
                        if (Changed != null)
                            Changed(blob, e);
                    }
                }
            }
        }
    }
}
