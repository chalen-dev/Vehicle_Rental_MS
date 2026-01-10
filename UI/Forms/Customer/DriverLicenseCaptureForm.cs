using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace VRMS.UI.Forms.Customer
{
    public partial class DriverLicenseCaptureForm : Form
    {
        // =============================
        // CAMERA FIELDS
        // =============================
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice? videoSource;
        private Bitmap? capturedImage;
        private bool isCameraRunning;

        // =============================
        // IMAGE ADJUSTMENTS
        // =============================
        private float brightness = 1.0f;
        private float contrast = 1.0f;
        private int rotationAngle = 0;

        public DriverLicenseCaptureForm()
        {
            InitializeComponent();
            InitializeCamera();
            FormClosing += DriverLicenseCaptureForm_FormClosing;
        }

        // ==================================================
        // CAMERA INITIALIZATION
        // ==================================================
        private void InitializeCamera()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    lblStatus.Text = "Status: No camera found!";
                    btnStartCamera.Enabled = false;
                    return;
                }

                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;

                lblStatus.Text = $"Status: Camera ready ({videoDevices[0].Name})";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Camera Error");
                btnStartCamera.Enabled = false;
            }
        }

        // ==================================================
        // FRAME HANDLER (SAFE UI UPDATE)
        // ==================================================
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs e)
        {
            if (picCameraPreview.IsDisposed || !picCameraPreview.IsHandleCreated)
                return;

            Bitmap frame = (Bitmap)e.Frame.Clone();

            try
            {
                picCameraPreview.BeginInvoke(new Action(() =>
                {
                    if (picCameraPreview.IsDisposed)
                    {
                        frame.Dispose();
                        return;
                    }

                    picCameraPreview.Image?.Dispose();
                    picCameraPreview.Image = frame;
                }));
            }
            catch
            {
                frame.Dispose();
            }
        }

        // ==================================================
        // START / STOP CAMERA
        // ==================================================
        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            if (videoSource == null || isCameraRunning)
                return;

            videoSource.Start();
            isCameraRunning = true;

            btnStartCamera.Enabled = false;
            btnStopCamera.Enabled = true;
            btnCapture.Enabled = true;

            lblStatus.Text = "Status: Camera running";
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

        // 🔥 HARD STOP — THIS IS THE IMPORTANT PART
        private void StopCamera()
        {
            if (videoSource == null)
                return;

            try
            {
                videoSource.NewFrame -= VideoSource_NewFrame;

                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }
            }
            catch
            {
                // ignore shutdown errors
            }
            finally
            {
                videoSource = null;
                isCameraRunning = false;
            }

            if (!picCameraPreview.IsDisposed)
            {
                picCameraPreview.Image?.Dispose();
                picCameraPreview.Image = null;
            }

            btnStartCamera.Enabled = true;
            btnStopCamera.Enabled = false;
            btnCapture.Enabled = false;

            lblStatus.Text = "Status: Camera stopped";
        }

        // ==================================================
        // CAPTURE IMAGE
        // ==================================================
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (picCameraPreview.Image == null)
                return;

            capturedImage?.Dispose();
            capturedImage = new Bitmap(picCameraPreview.Image);

            picCapturedImage.Image?.Dispose();
            picCapturedImage.Image = new Bitmap(capturedImage);

            btnSave.Enabled = true;
            btnRetake.Enabled = true;
            lblPreviewInfo.Text = "Driver's License Captured";
        }

        private void btnRetake_Click(object sender, EventArgs e)
        {
            capturedImage?.Dispose();
            capturedImage = null;

            picCapturedImage.Image?.Dispose();
            picCapturedImage.Image = null;

            btnSave.Enabled = false;
            btnRetake.Enabled = false;
            lblPreviewInfo.Text = "Captured image will appear here";
        }

        // ==================================================
        // SAVE IMAGE (FORCE CAMERA OFF FIRST)
        // ==================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (capturedImage == null)
                return;

            using SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp",
                FileName = $"DriverLicense_{DateTime.Now:yyyyMMdd_HHmmss}"
            };

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            ImageFormat format = Path.GetExtension(dlg.FileName).ToLower() switch
            {
                ".png" => ImageFormat.Png,
                ".bmp" => ImageFormat.Bmp,
                _ => ImageFormat.Jpeg
            };

            using Bitmap finalImage = ApplyAdjustments(capturedImage);
            finalImage.Save(dlg.FileName, format);

            // 🔥 FORCE CAMERA SHUTDOWN
            StopCamera();

            DialogResult = DialogResult.OK;
            Close();
        }

        // ==================================================
        // IMAGE ADJUSTMENTS
        // ==================================================
        private Bitmap ApplyAdjustments(Bitmap original)
        {
            Bitmap adjusted = new Bitmap(original);

            if (rotationAngle != 0)
                adjusted.RotateFlip(GetRotationFlip());

            if (brightness != 1.0f || contrast != 1.0f)
                adjusted = AdjustBrightnessContrast(adjusted, brightness, contrast);

            return adjusted;
        }

        private RotateFlipType GetRotationFlip() => rotationAngle switch
        {
            90 => RotateFlipType.Rotate90FlipNone,
            180 => RotateFlipType.Rotate180FlipNone,
            270 => RotateFlipType.Rotate270FlipNone,
            _ => RotateFlipType.RotateNoneFlipNone
        };

        private Bitmap AdjustBrightnessContrast(Bitmap image, float b, float c)
        {
            Bitmap adjusted = new Bitmap(image.Width, image.Height);

            using Graphics g = Graphics.FromImage(adjusted);
            using ImageAttributes attr = new ImageAttributes();

            float[][] matrix =
            {
                new float[] { c, 0, 0, 0, 0 },
                new float[] { 0, c, 0, 0, 0 },
                new float[] { 0, 0, c, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { b, b, b, 0, 1 }
            };

            attr.SetColorMatrix(new ColorMatrix(matrix));

            g.DrawImage(
                image,
                new Rectangle(0, 0, image.Width, image.Height),
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel,
                attr
            );

            return adjusted;
        }

        // ==================================================
        // ROTATION / ADJUST BUTTONS
        // ==================================================
        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (capturedImage == null)
                return;

            rotationAngle = (rotationAngle + 90) % 360;

            picCapturedImage.Image?.Dispose();
            Bitmap rotated = new Bitmap(capturedImage);
            rotated.RotateFlip(GetRotationFlip());
            picCapturedImage.Image = rotated;
        }

        private void btnBrightness_Click(object sender, EventArgs e)
        {
            brightness = brightness >= 2.0f ? 0.5f : brightness + 0.1f;
            RefreshPreview();
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {
            contrast = contrast >= 2.0f ? 0.5f : contrast + 0.1f;
            RefreshPreview();
        }

        private void RefreshPreview()
        {
            if (capturedImage == null)
                return;

            picCapturedImage.Image?.Dispose();
            picCapturedImage.Image = ApplyAdjustments(capturedImage);
        }

        // ==================================================
        // CLEAN EXIT
        // ==================================================
        private void DriverLicenseCaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
            capturedImage?.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StopCamera();
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
