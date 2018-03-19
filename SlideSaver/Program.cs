using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // No arguments means run configuration
            if (args.Length == 0)
            {
                Configuration();
                return;
            }

            // Otherwise parse arguments
            string arg1 = null;
            string arg2 = null;
            if (args.Length >= 2)
            {
                arg1 = args[0].ToLower().Trim();
                arg2 = args[1].ToLower().Trim();
            }
            else
            {
                string[] split = args[0].Split(':');
                arg1 = split[0].ToLower().Trim();
                if (split.Length >= 2)
                {
                    arg2 = split[1].ToLower().Trim();
                }
            }

            switch (arg1)
            {
                case "/p":
                    long handle;
                    if (long.TryParse(arg2, out handle))
                    {
                        Preview(new IntPtr(handle));
                    }
                    return;
                case "/s":
                    FullScreen();
                    return;
                default:
                    Configuration();
                    return;
            }
        }
                        
        static void Configuration()
        {
            Application.Run(new ConfigForm());
        }

        static void Preview(IntPtr handle)
        {
            SlideShowForm form = new SlideShowForm();
            form.SetPreviewMode(handle);
            Application.Run(form);
        }

        static void FullScreen()
        {
            foreach(Screen screen in Screen.AllScreens)
            {
                SlideShowForm form = new SlideShowForm();
                form.Bounds = screen.Bounds;
                form.Show();
            }
            Application.Run();
        }
    }
}
