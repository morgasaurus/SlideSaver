using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideSaver
{
    /// <summary>
    /// Represents a form used to show a slide show on a single monitor
    /// </summary>
    public partial class SlideShowForm : Form
    {
        /// <summary>
        /// Creates a new SlideShowForm instance and initializes the designer elements
        /// </summary>
        public SlideShowForm()
        {
            InitializeComponent();
        }

        #region Props
        /// <summary>
        /// Gets or sets the base path used to find photos for the slideshow
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether to include subdirectories of the base path for pictures
        /// </summary>
        public bool IncludeSubdirectories { get; set; }

        /// <summary>
        /// Gets or sets the sequence mode of the slide show
        /// </summary>
        public SequenceMode SequenceMode { get; set; }

        /// <summary>
        /// Paths to the photos to display
        /// </summary>
        private List<string> PhotoPaths;

        /// <summary>
        /// Gets or sets a flag indicating we are in preview mode
        /// </summary>
        public bool PreviewMode = true;
        #endregion Props

        #region EventHandlers
        private void SlideShowForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
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
        #endregion EventHandlers

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
                Application.Exit();
            }
        }
    }
}
