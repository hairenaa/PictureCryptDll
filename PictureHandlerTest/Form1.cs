using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PictureHandler_dll;


namespace PictureHandlerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (PictureCrypt pc = new PictureEnCrypt(pictureBox1.Image, 3.9, 0.6))
            {
                pc.HandleCryptMethod();
                pictureBox1.Image = pc.HandledImage.Clone() as Image;
            }
            
            
            
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (PictureCrypt pc = new PictureDeCrypt(pictureBox1.Image, 3.9, 0.6))
            {
                pc.HandleCryptMethod();
                pictureBox1.Image = pc.HandledImage.Clone() as Image;
            }

            
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (PictureCompressionBase pcb = new PictureCompression(pictureBox1.Image))
            {
                pcb.CompressionORDeCompressionHandleMethod();
                pictureBox1.Image = pcb.HandledImage.Clone() as Image;
                //pcb.HandledImage.Save("your path", pcb.OutedImageCodecInfo, pcb.OutedEncoderParameters);
                //You need to save it and then open it in the file to use this class to compress again
            }

        }
    }
}
