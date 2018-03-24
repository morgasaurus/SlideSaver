using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideSaver
{
    static class Program
    {
        private static bool Running = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // No arguments means run full screen
            if (args.Length == 0)
            {
                FullScreen();
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
                case "/c":
                    Configuration();
                    return;
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
                    FullScreen();
                    return;
            }
        }
                        
        static void Configuration()
        {
            Application.Run(new ConfigForm());
        }

        static void Preview(IntPtr handle)
        {
            ImageQueue queue = GetQueue();
            SlideShowForm form = new SlideShowForm(queue);
            form.SetPreviewMode(handle);
            RunForms(new List<Form>() { form });
        }

        static void FullScreen()
        {
            ImageQueue queue = GetQueue();
            List<Form> forms = new List<Form>();
            foreach (Screen screen in Screen.AllScreens)
            {
                SlideShowForm form = new SlideShowForm(queue);
                forms.Add(form);
                form.Bounds = screen.Bounds;
            }

            RunForms(forms);
        }

        private static void RunForms(List<Form> forms)
        {
            foreach(Form form in forms)
            {
                form.FormClosing += OnFormClosing;
            }

            Running = true;
            DateTime lastDraw = DateTime.Now.Subtract(new TimeSpan(0, 0, 0, 3));
            while (Running)
            {
                if (DateTime.Now.Subtract(lastDraw).TotalSeconds >= 5)
                {
                    lastDraw = DateTime.Now;
                    foreach (Form form in forms)
                    {
                        form.Show();
                        form.Refresh();
                    }
                }
                Thread.Sleep(10);
                Application.DoEvents();
            }

            foreach (Form form in forms)
            {
                form.Close();
            }
        }

        private static void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Running = false;
        }

        static ImageQueue GetQueue()
        {
            Config config = Utils.LoadConfig();
            ImageQueue queue = new ImageQueue(config.BasePath, config.IncludeSubdirectories, config.SequenceMode, 10);
            return queue;
        }
    }
}
