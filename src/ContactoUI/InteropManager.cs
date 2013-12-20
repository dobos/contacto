using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Contacto.UI
{
    class InteropManager
    {
        public enum ContentType
        {
            None,
            File,
            FileStreams,
            OutlookItems,
        }

        private ContentType contentType;
        private DragEventArgs dragEventArgs;

        public InteropManager(DragEventArgs e)
        {
            dragEventArgs = e;
            if (e.Data != null)
                DetermineContentType();
        }

        public InteropManager()
        {
        }

        public IDataObject StartDrag(Stream[] streams, string[] filenames)
        {
            // create temp dir and copy files
            string tempPath = Contacto.Lib.Util.TempDirName() + Guid.NewGuid() + Path.DirectorySeparatorChar;
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            for (int i = 0; i < streams.Length; i++)
            {
                filenames[i] = tempPath + filenames[i];

                byte[] buffer = new byte[streams[i].Length];
                streams[i].Read(buffer, 0, buffer.Length);
                using (FileStream outfile = new FileStream(filenames[i], FileMode.Create, FileAccess.ReadWrite))
                {
                    outfile.Write(buffer, 0, buffer.Length);
                    outfile.Close();
                }
            }

            return new DataObject(DataFormats.FileDrop, filenames);
        }

        public MemoryStream[] GetData()
        {
            List<MemoryStream> streams = new List<MemoryStream>();

            if (dragEventArgs != null)
            {
                switch (contentType)
                {
                    case ContentType.File:
                        foreach (string file in GetFilenames())
                        {
                            streams.Add(LoadFile(file));
                        }
                        break;
                    case ContentType.FileStreams:
                        //*** cannot handle multiple files :-(
                        MemoryStream ms = dragEventArgs.Data.GetData("FileContents", true) as MemoryStream;
                        if (ms != null)
                        {
                            streams.Add(ms);
                        }
                        break;
                    case ContentType.OutlookItems:
                        Microsoft.Office.Interop.Outlook.Application outlook = new Microsoft.Office.Interop.Outlook.ApplicationClass();
                        Microsoft.Office.Interop.Outlook.Explorer explorer = outlook.ActiveExplorer();
                        foreach (object item in explorer.Selection)
                        {
                            Microsoft.Office.Interop.Outlook.MailItem mail = explorer.Selection[1] as Microsoft.Office.Interop.Outlook.MailItem;
                            if (mail != null)
                            {
                                Guid g = Guid.NewGuid();
                                string tempfile = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + g + ".msg";
                                mail.SaveAs(tempfile, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSGUnicode);
                                streams.Add(LoadFile(tempfile));
                                File.Delete(tempfile);
                            }
                        }
                        break;
                }

            }

            return streams.ToArray();
        }

        public string[] GetFilenames()
        {
            List<string> filenames;

            if (dragEventArgs != null)
            {
                switch (contentType)
                {
                    case ContentType.File:
                        Array a = dragEventArgs.Data.GetData(DataFormats.FileDrop) as Array;

                        if (a != null)
                        {
                            string[] files = new string[a.Length];
                            a.CopyTo(files, 0);
                            return files;
                        }
                        break;
                    case ContentType.FileStreams:
                        //*** cannot handle multiple files!
                        filenames = new List<string>();

                        MemoryStream ms = dragEventArgs.Data.GetData("FileGroupDescriptor", true) as MemoryStream;
                        if (ms != null)
                        {
                            int count = 0;
                            try
                            {
                                while (true)
                                {
                                    ms.Position = count * 0x100 + 0x4C;
                                    filenames.Add(ReadStringFromMemoryStream(ms, false));
                                    count++;
                                    break;  // cannot handle multiple files!
                                }
                            }
                            catch (System.Exception)
                            {
                            }
                            return filenames.ToArray();
                        }
                        break;
                    case ContentType.OutlookItems:
                        filenames = new List<string>();
                        Microsoft.Office.Interop.Outlook.Application outlook = new Microsoft.Office.Interop.Outlook.ApplicationClass();
                        Microsoft.Office.Interop.Outlook.Explorer explorer = outlook.ActiveExplorer();
                        foreach (object item in explorer.Selection)
                        {
                            Microsoft.Office.Interop.Outlook.MailItem mail = item as Microsoft.Office.Interop.Outlook.MailItem;
                            if (mail != null)
                            {
                                filenames.Add(mail.Subject + ".msg");
                            }
                        }
                        return filenames.ToArray();
                }
            }
            return null;
        }

        private MemoryStream LoadFile(string file)
        {
            using (FileStream infile = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[infile.Length];
                infile.Read(buffer, 0, buffer.Length);
                infile.Close();

                return new MemoryStream(buffer);
            }
        }

        public void EnableDropOnEnter()
        {
            DetermineContentType();

            if (contentType != ContentType.None)
                dragEventArgs.Effect = DragDropEffects.Copy;
            else
                dragEventArgs.Effect = DragDropEffects.None;
        }

        private void DetermineContentType()
        {
            if (!ProcessObjectDescriptor())
            {
                if (dragEventArgs.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    contentType = ContentType.File;
                }
                else if (dragEventArgs.Data.GetDataPresent("FileGroupDescriptor", false) && dragEventArgs.Data.GetDataPresent("FileContents", false))
                {
                    contentType = ContentType.FileStreams;
                }
                else
                {
                    contentType = ContentType.None;
                }
            }
        }

        private bool ProcessObjectDescriptor()
        {
            if (!dragEventArgs.Data.GetDataPresent("Object Descriptor"))
            {
                contentType = ContentType.None;
                return false;
            }

            using (MemoryStream ms = dragEventArgs.Data.GetData("Object Descriptor") as MemoryStream)
            {
                if (ms != null)
                {
                    ms.Seek(0x34, 0);
                    string appname = ReadStringFromMemoryStream(ms, true);

                    switch (appname)
                    {
                        case "Outlook":
                            ms.Seek(0, 0);
                            int v = ms.ReadByte();
                            contentType = ContentType.OutlookItems;
                            return true;
                        default:
                            contentType = ContentType.None;
                            return false;
                    }
                }
                else
                {
                    contentType = ContentType.None;
                    return false;
                }
            }
        }

        private string ReadStringFromMemoryStream(MemoryStream ms, bool unicode)
        {
            StringBuilder sb = new StringBuilder();
            byte[] b;

            if (unicode)
            {
                b = new byte[2];

                while (ms.Read(b, 0, 2) == 2)
                {
                    char c = BitConverter.ToChar(b, 0);
                    if (c == 0) break;
                    sb.Append(c);
                }
            }
            else
            {
                b = new byte[1];

                while (ms.Read(b, 0, 1) == 1)
                {
                    if (b[0] == 0) break;
                    sb.Append(System.Text.Encoding.Default.GetChars(b));
                }
            }

            return sb.ToString();
        }
    }
}
