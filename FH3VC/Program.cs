using ForzaVolumeControl.App;
using System;
using System.Windows.Forms;

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