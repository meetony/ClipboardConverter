using System.Threading;

namespace ClipboardConverter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Mutex mutex = new Mutex(false, "_ClipboardConverter");
            bool locked = false;
            try
            {
                try
                {
                    locked = mutex.WaitOne(0, false);
                }
                catch (System.Threading.AbandonedMutexException)
                {
                    locked = true;
                }

                if (!locked) return;

                ApplicationConfiguration.Initialize();
                MainForm f1 = new MainForm();
                Application.Run();
            }
            finally
            {
                if (locked) mutex.ReleaseMutex();
                mutex.Close();
            }
        }
    }
}