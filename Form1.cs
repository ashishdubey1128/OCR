using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
//Emgu References
using Emgu.CV;
using Emgu.CV.Aruco;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Cuda;


using Emgu.CV.OCR;


namespace Emgu_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult result = openFileDialog1.ShowDialog();
            ////if (result == DialogResult.OK)
            ////{
                Image<Bgr, Byte> inputImage = new Image<Bgr, byte>("D:\\a.jpg");

                
                var grayscale = new Image<Gray, byte>(inputImage.ToBitmap());
                CvInvoke.Threshold(grayscale, grayscale, 219, 255, ThresholdType.BinaryInv);
                pictureBox1.Image = grayscale.ToBitmap();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                grayscale.Save("convertedImage.jpg");

                var img = new Bitmap("convertedImage.jpg");
                var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                var page = ocr.Process(img);
               textBox1.Text = page.GetText();
            //}
        }

            }
        }
    
    


