using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideSaver
{
    /// <summary>
    /// Represents a form used to show a slide show on a single monitor
    /// <para>To advance to the next photo invoke Refresh from the thread creating this instance</para>
    /// </summary>
    public partial class SlideShowForm : Form
    {
        /// <summary>
        /// Creates a new SlideShowForm instance which will pull from the specified image queue
        /// </summary>
        public SlideShowForm(ImageQueue queue)
        {
            InitializeComponent();
            Queue = queue;
            KeyPreview = true;
        }

        #region Props
        private ImageQueue Queue;
        private Point MouseLocation;        
        private bool PreviewMode = false;
        #endregion Props

        #region EventHandlers
        private void SlideShowForm_Load(object sender, EventArgs e)
        {
            if (!PreviewMode)
            {
                Cursor.Hide();
                TopMost = true;
            }
        }

        private void SlideShowForm_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void SlideShowForm_MouseClick(object sender, MouseEventArgs e)
        {
            Quit();
        }

        private void SlideShowForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Quit();
        }

        private void SlideShowForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseLocation.IsEmpty)
            {
                if (Math.Abs(MouseLocation.X - e.X) > 5 || Math.Abs(MouseLocation.Y - e.Y) > 5)
                {
                    Quit();
                }
            }
            MouseLocation = e.Location;
        }

        private void SlideShowForm_Paint(object sender, PaintEventArgs e)
        {
            Image image = Queue.Dequeue();
            ClearScreen(e.Graphics);

            // If the queue provided no image display error text
            if (image == null)
            {
                string message = "Failed to load images.\r\nMaybe the folder contains no image files?\r\nCheck SlideSaver settings.";

                Font font = new Font("Arial", 32);
                SolidBrush brush = new SolidBrush(Color.Red);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                Rectangle rect = new Rectangle(0, 0, Bounds.Width, Bounds.Height);

                e.Graphics.DrawString(message, font, brush, rect, format);
                return;
            }
            
            // If the width and height of the image match the bounds go ahead and draw
            if (Bounds.Width == image.Width && Bounds.Height == image.Height)
            {
                e.Graphics.DrawImage(image, new Point(0, 0));
                return;
            }

            // Otherwise we need to scale; let's find out how
            double screenRatio = (double)Bounds.Width / (double)Bounds.Height;
            double imageRatio = (double)image.Width / (double)image.Height;

            // Set some scaling modes
            e.Graphics.CompositingMode = CompositingMode.SourceCopy;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (screenRatio < imageRatio)
            {
                // Scale by X
                double scale = (double)Bounds.Width / (double)image.Width;
                int width = Bounds.Width;
                int height = (int)((double)image.Height * scale);
                int y = (Bounds.Height - height) / 2;
                Rectangle rect = new Rectangle(0, y, width, height);
                e.Graphics.DrawImage(image, rect);                
            }
            else
            {
                // Scale by Y
                double scale = (double)Bounds.Height / (double)image.Height;
                int height = Bounds.Height;
                int width = (int)((double)image.Width * scale);
                int x = (Bounds.Width - width) / 2;
                Rectangle rect = new Rectangle(x, 0, width, height);
                e.Graphics.DrawImage(image, rect);
            }
        }
        #endregion EventHandlers
        
        private void ClearScreen(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black), Bounds);
            g.FillRectangle(new SolidBrush(Color.Black), Bounds);
        }

        /// <summary>
        /// Sets the parent of this window in case the screen saver is started in preview mode
        /// </summary>
        /// <param name="parentHandle">Handle to the parent</param>
        public void SetPreviewMode(IntPtr parentHandle)
        {
            // Set the preview windows as the parent of this window
            Utils.SetParent(Handle, parentHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            Utils.SetWindowLong(Handle, -16, new IntPtr(Utils.GetWindowLong(Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle parentRect;
            Utils.GetClientRect(parentHandle, out parentRect);
            Size = parentRect.Size;
            Location = new Point(0, 0);

            PreviewMode = true;
        }

        /// <summary>
        /// Tells the screen saver to quit
        /// </summary>
        public void Quit()
        {
            if (!PreviewMode)
            {
                Close();
            }
        }
    }
}
