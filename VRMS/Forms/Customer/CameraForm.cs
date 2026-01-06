using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace VRMS.Forms
{
    public partial class CameraForm : Form
    {
        // Public property to hold the result
        public Image CapturedImage { get; private set; }

        // AForge objects
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private bool isStopping = false;

        public CameraForm()
        {
            InitializeComponent();
        }

        // Placeholder for the Capture Button
        private void BtnCapture_Click(object sender, EventArgs e)
        {
            // Logic goes here
        }

        // Placeholder for the Camera Selection dropdown
        private void cbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic goes here
        }

        // Handles cleanup when the form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}