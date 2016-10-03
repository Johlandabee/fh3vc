using System;
using System.Windows.Forms;
using ForzaVolumeControl.Properties;

namespace ForzaVolumeControl.App {
    internal class Context : ApplicationContext {
        private readonly NotifyIcon _trayIcon;
        private readonly VolumeControl _volumeControl;

        public Context() {
            _trayIcon = new NotifyIcon {
                Icon = Resources.AppIcon,
                Visible = true,
                ContextMenu = new ContextMenu {
                    MenuItems = {
                        new MenuItem("About", ShowAbout),
                        new MenuItem("Show", ShowVolumeControl),
                        new MenuItem("Exit", Exit)
                    }
                }
            };

            _volumeControl = new VolumeControl();
            _trayIcon.DoubleClick += ShowVolumeControl;
        }

        private void ShowVolumeControl(object sender, EventArgs e) {
            _volumeControl.StartPosition = FormStartPosition.Manual;

            var mousePos = Control.MousePosition;
            mousePos.Y -= _volumeControl.Height;

            _volumeControl.Location = mousePos;
            _volumeControl.Show();
        }

        private void ShowAbout(object sender, EventArgs e) {
            
        }

        private void Exit(object sender, EventArgs e) {
            _trayIcon.Visible = false;
            Application.Exit();
        }
    }
}