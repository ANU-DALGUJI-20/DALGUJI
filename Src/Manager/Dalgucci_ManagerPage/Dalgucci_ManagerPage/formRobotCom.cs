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
        MJPEGStream Robot1;
        MJPEGStream Robot2;
        public formRobotCom()
        {
            InitializeComponent();
            Robot1 = new MJPEGStream("http://192.168.0.192:8081");
            Robot1.NewFrame += Robot1_NewFrame;
            //captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            //stream.NewFrame += stream_NewFrame;
            Robot1.Start();
            timer1.Start();


            Robot2 = new MJPEGStream("http://192.168.0.192:8083");
            Robot2.NewFrame += Robot2_NewFrame;
            //captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            //stream.NewFrame += stream_NewFrame;
            Robot2.Start();
            timer2.Start();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void Robot1_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            //CCTV.Image = bmp;
            CCTV.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Robot2_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            //CCTV.Image = bmp;
            CCTV2.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void formRobotCom_Load(object sender, EventArgs e)
        {
            //stream.Start();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void formRobotCom_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stream.Stop();
            if (Robot1.IsRunning)
                Robot1.Stop();

            else if (Robot2.IsRunning)
                Robot2.Stop();
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

        private void CCTV2_Click(object sender, EventArgs e)
        {

        }



        private void TextTest2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CCTV2.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)CCTV2.Image);
                if (result != null)
                {
                    TextTest2.Text = result.ToString();
                    //timer1.Stop();
                    //if (stream.IsRunning)
                    //    stream.Stop();
                }
            }
        }
    }
}
