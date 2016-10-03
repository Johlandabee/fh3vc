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
            this.volumeLevel = new System.Windows.Forms.TrackBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.volumeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.volumeLevel)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // volumeLevel
            // 
            this.volumeLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeLevel.Enabled = false;
            this.volumeLevel.Location = new System.Drawing.Point(0, 0);
            this.volumeLevel.Maximum = 100;
            this.volumeLevel.Name = "volumeLevel";
            this.volumeLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.volumeLevel.Size = new System.Drawing.Size(272, 50);
            this.volumeLevel.TabIndex = 0;
            this.volumeLevel.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeLevel.ValueChanged += new System.EventHandler(this.OnVolumeChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.volumeLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 28);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(272, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(79, 17);
            this.statusLabel.Text = "Status: Empty";
            // 
            // volumeLabel
            // 
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(81, 17);
            this.volumeLabel.Text = "Volume: 100%";
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 300;
            this.updateTimer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // VolumeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 50);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.volumeLevel);
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
            this.Text = "Forza Horizon 3 Volume Control";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.volumeLevel)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar volumeLevel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel volumeLabel;
        private System.Windows.Forms.Timer updateTimer;
    }
}