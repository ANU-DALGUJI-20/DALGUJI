using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Dalgucci_ManagerPage
{
    public partial class formRobotCom : Form
    {
        MJPEGStream stream;
        public formRobotCom()
        {
            InitializeComponent();
            stream = new MJPEGStream("http://192.168.0.192:8081");
            stream.NewFrame += stream_NewFrame;
            //captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            //stream.NewFrame += stream_NewFrame;
            stream.Start();
            timer1.Start();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            //CCTV.Image = bmp;
            CCTV.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void formRobotCom_Load(object sender, EventArgs e)
        {
            //stream.Start();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void formRobotCom_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stream.Stop();
            if (stream.IsRunning)
                stream.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CCTV.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)CCTV.Image);
                if (result != null)
                {
                    testTextBox.Text = result.ToString();
                    //timer1.Stop();
                    //if (stream.IsRunning)
                    //    stream.Stop();
                }
            }
        }
    }
}
