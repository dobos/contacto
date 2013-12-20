using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.UI
{
    public class FormSettings
    {
        public string FormName;
        public int Left;
        public int Top;
        public int Width;
        public int Height;
        public System.Windows.Forms.FormWindowState WindowState;

        public FormSettings()
        {
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            FormName = string.Empty;
            Left = 0;
            Top = 0;
            Width = 0;
            Height = 0;
            WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        public void Apply(System.Windows.Forms.Form form)
        {
            if (form.Name == FormName)
            {
                form.SuspendLayout();
                form.Left = Left;
                form.Top = Top;
                form.Width = Width;
                form.Height = Height;
                form.WindowState = WindowState;
                form.ResumeLayout();
            }
        }

        public void Match(System.Windows.Forms.Form form)
        {
            FormName = form.Name;
            Left = form.Left;
            Top = form.Top;
            Width = form.Width;
            Height = form.Height;
            WindowState = form.WindowState;
        }
    }
}
