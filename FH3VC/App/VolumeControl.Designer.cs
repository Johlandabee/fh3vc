namespace ForzaVolumeControl.App {
    partial class VolumeControl {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VolumeControl));
            this._volumeLevel = new System.Windows.Forms.TrackBar();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._volumeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._updateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._volumeLevel)).BeginInit();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _volumeLevel
            // 
            this._volumeLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._volumeLevel.Enabled = false;
            this._volumeLevel.Location = new System.Drawing.Point(0, 0);
            this._volumeLevel.Maximum = 100;
            this._volumeLevel.Name = "_volumeLevel";
            this._volumeLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._volumeLevel.Size = new System.Drawing.Size(272, 50);
            this._volumeLevel.TabIndex = 0;
            this._volumeLevel.TickStyle = System.Windows.Forms.TickStyle.None;
            this._volumeLevel.ValueChanged += new System.EventHandler(this.HandleVolumeChanged);
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel,
            this._volumeLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 28);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(272, 22);
            this._statusStrip.TabIndex = 3;
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(65, 17);
            this._statusLabel.Text = "Status: null";
            // 
            // _volumeLabel
            // 
            this._volumeLabel.Name = "_volumeLabel";
            this._volumeLabel.Size = new System.Drawing.Size(81, 17);
            this._volumeLabel.Text = "Volume: 100%";
            // 
            // _updateTimer
            // 
            this._updateTimer.Interval = 300;
            this._updateTimer.Tick += new System.EventHandler(this.HandleTimerTick);
            // 
            // VolumeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 50);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._volumeLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(288, 89);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(288, 89);
            this.Name = "VolumeControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Forza Horizon 3 Volume Control";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HandleFormClosing);
            this.Load += new System.EventHandler(this.HandleLoad);
            ((System.ComponentModel.ISupportInitialize)(this._volumeLevel)).EndInit();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar _volumeLevel;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel _volumeLabel;
        private System.Windows.Forms.Timer _updateTimer;
    }
}