using ForzaVolumeControl.App;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ForzaVolumeControl {
    internal class Program {
        private const string AppGuid = "9F334466-5ACA-43E6-8761-A6CC7D21A5D4";

        [STAThread]
        private static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var mutex = new Mutex(false, $"Global\\{AppGuid}")) {
                if (!mutex.WaitOne(0, false)) return;
                Application.Run(new Context());
            }
        }
    }
}