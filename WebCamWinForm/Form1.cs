using Azure.Storage.Blobs;
using BasicAudio;
using DirectShowLib;
using FFMpegCore;
using IronQr;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCamWinForm2020
{
    public partial class Form1 : Form
    {
        bool isCameraRunning = false;
        VideoCapture capture;
        Recording audioRecorder;
        private SemaphoreSlim semaphore = new SemaphoreSlim(3); // Limiting to 3 concurrent tasks
        private QrReader qrReader = new QrReader();
        Mat frame;
        Bitmap imageAlternate;
        Bitmap image;
        bool isUsingImageAlternate = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            var videoDevices = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));
            foreach (var device in videoDevices)
            {
                ddlVideoDevices.Items.Add(device.Name);
            }
        }

        private async void btnRecord_Click(object sender, EventArgs e)
        {
            if (ddlVideoDevices.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a video device as the Video Source.", "Video Source Not Defined", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isCameraRunning)
            {
                lblStatus.Text = "Starting recording...";

                StartCamera();
                recordingTimer.Enabled = true;
                recordingTimer.Start();

                lblStatus.Text = "Recording...";
            }
            else
            {
                StopCamera();
                lblStatus.Text = "Recording ended.";

                await OutputRecordingAsync();
            }
        }

        private void StartCamera()
        {
            DisposeCameraResources();

            isCameraRunning = true;

            btnRecord.Text = "Stop";

            int deviceIndex = ddlVideoDevices.SelectedIndex;
            capture = new VideoCapture(deviceIndex);
            capture.Open(deviceIndex);

        }

        private void StopCamera()
        {
            isCameraRunning = false;

            btnRecord.Text = "Start";

            recordingTimer.Stop();
            recordingTimer.Enabled = false;

            DisposeCaptureResources();
        }

        private void StopMicrophone()
        {
            audioRecorder.StopRecording();
        }

        private static async Task OutputRecordingAsync()
        {
        }

        private void DisposeCameraResources()
        {
            if (frame != null)
            {
                frame.Dispose();
            }

            if (image != null)
            {
                image.Dispose();
            }

            if (imageAlternate != null)
            {
                imageAlternate.Dispose();
            }
        }

        private void DisposeCaptureResources()
        {
            if (capture != null)
            {
                capture.Release();
                capture.Dispose();
            }
        }

        private async Task readQRAsync(Bitmap im)
        {
            if (!await semaphore.WaitAsync(TimeSpan.Zero)) // Attempt to acquire semaphore without waiting
            {
                textBox1.Text = "Semaphore is full, skipping frame...";
                return;
            }
            try
            {
                IEnumerable<QrResult> asyncResults = await qrReader.ReadAsync(new QrImageInput(im)); // Async version
                textBox1.Text = "Reading QR Code...";
                foreach (var res in asyncResults)
                {
                    textBox2.Text = res.Value;
                }
            }
            finally
            {
                semaphore.Release(); // Release semaphore
            }
        }

        private void readQR(Bitmap im)
        {
            IEnumerable<QrResult> asyncResults = qrReader.Read(new QrImageInput(im)); // Async version
            textBox1.Text = "Reading QR Code...";
            foreach (var res in asyncResults)
            {
                if (!String.IsNullOrEmpty(res.Value))
                {
                    textBox2.Text = res.Value;
                }
            }
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            if (capture.IsOpened())
            {
                try
                {
                    frame = new Mat();
                    capture.Read(frame);
                    if (frame != null)
                    {
                        if (imageAlternate == null)
                        {
                            isUsingImageAlternate = true;
                            imageAlternate = BitmapConverter.ToBitmap(frame);
                        }
                        else if (image == null)
                        {
                            isUsingImageAlternate = false;
                            image = BitmapConverter.ToBitmap(frame);
                        }
                        var im = isUsingImageAlternate ? imageAlternate : image;
                        pictureBox1.Image = im;
                        readQRAsync(im);
                    }
                }
                catch (Exception)
                {
                    pictureBox1.Image = null;
                }
                finally
                {
                    if (frame != null)
                    {
                        frame.Dispose();
                    }

                    if (isUsingImageAlternate && image != null)
                    {
                        image.Dispose();
                        image = null;
                    }
                    else if (!isUsingImageAlternate && imageAlternate != null)
                    {
                        imageAlternate.Dispose();
                        imageAlternate = null;
                    }
                }
            }
        }

        private void ddlVideoDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
