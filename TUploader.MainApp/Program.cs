using System;
using System.Windows.Forms;

namespace TUploader.MainApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool result;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, nameof(TUploader), out result);

            if (!result)
            {
                MessageBox.Show("Another instance is already running.");
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
