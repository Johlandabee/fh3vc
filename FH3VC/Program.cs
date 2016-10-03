using System;
using System.Windows.Forms;
using ForzaVolumeControl.App;

namespace ForzaVolumeControl {
    internal class Program {
        [STAThread]
        private static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var context = new Context()) {
                Application.Run(context);
            }
        }
    }
}
