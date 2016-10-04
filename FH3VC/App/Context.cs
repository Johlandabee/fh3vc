using ForzaVolumeControl.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ForzaVolumeControl.App {

    internal class Context : ApplicationContext {
        private readonly NotifyIcon _trayIcon;
        private readonly VolumeControl _volumeControl;

        private const int BallonTimeout = 120;

        public Context() {
            _trayIcon = new NotifyIcon {
                Icon = Resources.AppIcon,
                Visible = true,
                ContextMenu = new ContextMenu {
                    MenuItems = {
                        new MenuItem(Resources.MenuAbout, HandleOpenAbout),
                        new MenuItem(Resources.MenuToggle, HandleToggle),
                        new MenuItem(Resources.MenuExit, HandleExit)
                    }
                },
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipText = Resources.ToTrayInfoText
            };

            _volumeControl = new VolumeControl();
            _trayIcon.MouseClick += HandleClick;

            _trayIcon.ShowBalloonTip(BallonTimeout);
        }

        private void ToggleVolumeControl() {
            if (_volumeControl.Visible) {
                _volumeControl.Hide();
            } else {
                _volumeControl.Location = GetStartLocation();
                _volumeControl.Show();
            }
        }

        private Point GetStartLocation() {
            var bounds = Screen.PrimaryScreen.WorkingArea;
            return new Point(bounds.Width - _volumeControl.Width,
                bounds.Height - _volumeControl.Height);
        }

        private void HandleClick(object sender, MouseEventArgs e) {
            if((e.Button & MouseButtons.Left) != 0)
                ToggleVolumeControl();   
        }

        private void HandleToggle(object sender, EventArgs e) {
            ToggleVolumeControl();
        }

        private static void HandleOpenAbout(object sender, EventArgs e) {
            Process.Start(Resources.AboutLink);
        }

        private void HandleExit(object sender, EventArgs e) {
            _trayIcon.Visible = false;

            _volumeControl.Dispose();
            _trayIcon.Dispose();

            Application.Exit();
        }
    }
}