using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForzaVolumeControl.Properties;

namespace ForzaVolumeControl.App {

    public partial class VolumeControl : Form {
        private CoreAudioDevice _device;
        private bool _searchRunning;
        private IAudioSession _session;

        private const string BinaryName = "forza_x64_release_final.exe";

        private const int SearchInterval = 300;
        private const int UpdateInterval = 300;

        public VolumeControl() {
            InitializeComponent();

            _searchRunning = false;
            _volumeLevel.Enabled = false;
            _updateTimer.Interval = UpdateInterval;
        }

        private void Init() {
            SetStatusLabel(Resources.StatusInitializing);
            SetVolumeLabel(0);

            var getDevice = new Task<CoreAudioDevice>(() => {
                var controller = new CoreAudioController();
                return controller.DefaultPlaybackDevice;
            });

            getDevice.ContinueWith(t => {
                _device = t.Result;
                _updateTimer.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            getDevice.Start();
        }

        private void SetStatusLabel(string status, Color? color = null) {
            _statusLabel.ForeColor = color ?? Color.Black;
            _statusLabel.Text = $"{Resources.LabelStatus}: {status}";
        }

        private void SetVolumeLabel(int volume) {
            _volumeLabel.Text = $"{Resources.LabelVolume}: {_volumeLevel.Value}%";
        }

        private async void Search() {
            if (_searchRunning) return;

            _searchRunning = true;
            SetStatusLabel(Resources.StatusSearching);

            _session = null;
            while (_session == null) {
                _session = await GetAudioSessionAsync(_device);
            }

            _searchRunning = false;
        }

        private static async Task<IAudioSession> GetAudioSessionAsync(IAudioSessionEndpoint device) {
            var sessions = (await device.SessionController.ActiveSessionsAsync()).ToArray();

            IAudioSession session = null;
            if (sessions.Count() >= 0)
                session = sessions.FirstOrDefault(s => Path.GetFileName(s.ExecutablePath) == BinaryName);

            await Task.Delay(SearchInterval);
            return session;
        }

        public bool IsSessionValid() {
            return _session != null && _session.SessionState == AudioSessionState.Active
                   && Process.GetProcesses().Any(p => p.Id == _session.ProcessId);
        }

        private void UpdateValues() {
            if (IsSessionValid()) {
                SetStatusLabel(Resources.StatusOk, Color.Green);
                _volumeLevel.Enabled = true;
                _volumeLevel.Value = (int)_session.Volume;
                SetVolumeLabel(_volumeLevel.Value);
            } else {
                _volumeLevel.Enabled = false;
                Search();
            }
        }

        private void HandleTimerTick(object sender, EventArgs e) {
            UpdateValues();
        }

        private void HandleLoad(object sender, EventArgs e) {
            Init();
        }

        private void HandleVolumeChanged(object sender, EventArgs e) {
            if (IsSessionValid()) {
                _session.Volume = _volumeLevel.Value;
            } else {
                _volumeLevel.Enabled = false;
                Search();
            }
        }

        private void HandleFormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}