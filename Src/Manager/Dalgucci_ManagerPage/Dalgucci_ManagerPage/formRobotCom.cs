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
        }

        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            CCTV.Image = bmp;
        }

        private void formRobotCom_Load(object sender, EventArgs e)
        {
            stream.Start();
        }

        private void formRobotCom_FormClosing(object sender, FormClosingEventArgs e)
        {
            stream.Stop();
        }
    }
}
