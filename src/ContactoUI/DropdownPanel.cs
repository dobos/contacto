using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class DropdownPanel : ScrollableControl
    {
        public enum DropdownState
        {
            Open,
            Closed
        }

        //private int headerHeight = 18;
        private DropdownState state = DropdownState.Closed;

        [Browsable(true)]
        public DropdownState State
        {
            get { return state; }
            set
            {
                state = value;
                Refresh();
            }
        }

        public DropdownPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int headerHeight = Padding.Top;

            if (state == DropdownState.Closed)
            {
                this.Height = headerHeight;
            }
            else
            {
                int max = headerHeight;

                foreach (Control c in Controls)
                {
                    max = Math.Max(max, c.Bottom);
                }

                this.Height = max;
            }

            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(new Point(0, 0), new Size(this.Width, headerHeight - 2));


            Brush b = new LinearGradientBrush(r, SystemColors.Control, SystemColors.InactiveCaption, 90);
            g.FillRectangle(b, r);

            if (state == DropdownState.Closed)
            {
                Pen p = new Pen(SystemColors.ControlText);
                g.DrawLine(p, 0, headerHeight, this.Width, headerHeight);
            }

            if (Text != null)
            {
                StringFormat f = StringFormat.GenericDefault;
                f.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, this.Font, Brushes.Black, r, f);
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (state == DropdownState.Closed)
            {
                State = DropdownState.Open;
            }
            else
            {
                State = DropdownState.Closed;
            }

            base.OnDoubleClick(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            Refresh();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            Refresh();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            Refresh();
        }
    }
}
