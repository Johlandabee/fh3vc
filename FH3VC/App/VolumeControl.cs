using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;

namespace ForzaVolumeControl.App {
    public partial class VolumeControl : Form {
        private CoreAudioDevice _device;
        private bool _searchRunning;
        private IAudioSession _session;

        const string BINARY_NAME = "forza_x64_release_final.exe";

        public VolumeControl() {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e) {
            _searchRunning = false;

            volumeLabel.Text = $"Volume: {volumeLevel.Value}%";
            volumeLevel.Enabled = false;

            SetStatus("Initializing...");

            var getDevice = new Task<CoreAudioDevice>(() => {
                var controller = new CoreAudioController();
                return controller.DefaultPlaybackDevice;
            });
            
            getDevice.ContinueWith(t => {
                _device = t.Result;
                updateTimer.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
            
            getDevice.Start();            
        }

        private async void Search() {
            if (_searchRunning) return;

            _searchRunning = true;
            SetStatus("Searching game session");

            _session = null;
            while (_session == null) {
                _session = await GetAudioSessionAsync(_device);
            }

            _searchRunning = false;
        }

        private async Task<IAudioSession> GetAudioSessionAsync(IAudioSessionEndpoint device) {
            var sessions = await device.SessionController.ActiveSessionsAsync();
            IAudioSession session = null;

            if (sessions?.Count() >= 0) {
                session = sessions.FirstOrDefault(s => Path.GetFileName(s.ExecutablePath) == BINARY_NAME);
            }

            await Task.Delay(300);
            return session;
        }

        public bool IsSessionValid() {
            return _session != null && _session.SessionState == AudioSessionState.Active
                   && Process.GetProcesses().Any(p => p.Id == _session.ProcessId);
        }

        private void OnTimerTick(object sender, EventArgs e) {
            if (IsSessionValid()) {
                SetStatus("OK");
                volumeLevel.Enabled = true;
                volumeLevel.Value = (int) _session.Volume;
                volumeLabel.Text = $"Volume: {volumeLevel.Value}%";
            }
            else {
                volumeLevel.Enabled = false;
                Search();
            }
        }

        private void OnVolumeChanged(object sender, EventArgs e) {
            if (IsSessionValid()) {
                _session.Volume = volumeLevel.Value;
                volumeLabel.Text = $"Volume: {volumeLevel.Value}%";
            }
            else {
                volumeLevel.Enabled = false;
                Search();
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }


        private void SetStatus(string status) {
            statusLabel.Text = $"Status: {status}";
            statusLabel.ForeColor = status == "OK" ? Color.Green : Color.Black;
        }
    }
}