using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using PassHelper.Forms;

namespace PassHelper.App {

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            if (Environment.OSVersion.Version.Major >= 6) {
                SetProcessDPIAware();
            }

            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            MessageBox.Show(
                e.Exception.Message, 
                "Error", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
