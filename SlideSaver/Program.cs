using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            // For preview mode we need to set a single form using the handle of the parent window making the call
            ImageQueue queue = GetQueue();
            SlideShowForm form = new SlideShowForm(queue);
            form.SetPreviewMode(handle);

            queue.ForceEnqueue(1);
            RunSlideShow(new List<Form>() { form });
        }

        static void FullScreen()
        {
            // For full screen we need to init a form for each screen; all forms can read from a single queue
            ImageQueue queue = GetQueue();
            List<Form> forms = new List<Form>();
            foreach (Screen screen in Screen.AllScreens)
            {
                SlideShowForm form = new SlideShowForm(queue);
                forms.Add(form);
                form.Bounds = screen.Bounds;
            }

            queue.ForceEnqueue(Screen.AllScreens.Count());
            RunSlideShow(forms);
        }

        /// <summary>
        /// Runs the slide show in a program loop by invoking Refresh and triggering Paint on all of the following forms
        /// <para>Triggers an event every 5 seconds with a 3 second start delay</para>
        /// </summary>
        /// <param name="forms">The forms to paint</param>
        private static void RunSlideShow(List<Form> forms)
        {
            // Hook into the form closing event of all forms since that will be our cue to terminate
            foreach(Form form in forms)
            {
                form.FormClosing += OnFormClosing;
            }

            // The Running flag is set to false by the OnFormClosing event handler
            Running = true;
            DateTime lastDraw = DateTime.MinValue;
            while (Running)
            {
                if (DateTime.Now.Subtract(lastDraw).TotalSeconds >= 5)
                {
                    lastDraw = DateTime.Now;
                    foreach (Form form in forms)
                    {
                        // This is a hack but works; Refresh actually forces the forms to queue up their respective Paint events
                        form.Show();
                        form.Refresh();
                    }
                }
                Thread.Sleep(10);
                Application.DoEvents(); // Evil! :)
            }

            // We do not know which form triggered the Close event; we need to close them all before the application terminates
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
            // Read SlideSaver config from the registry and init the ImageQueue for the slide show
            Config config = Utils.LoadConfig();
            ImageQueue queue = new ImageQueue(config.BasePath, config.IncludeSubdirectories, config.SequenceMode, 10);
            return queue;
        }
    }
}
