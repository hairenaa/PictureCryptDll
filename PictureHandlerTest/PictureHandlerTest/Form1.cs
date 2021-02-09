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
            PictureCrypt pc = new PictureEnCrypt(pictureBox1.Image, 3.7, 0.6);
            pc.HandleCryptMethod();
            pictureBox1.Image = pc.HandledImage;
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureCrypt pc = new PictureDeCrypt(pictureBox1.Image, 3.7, 0.6);
            pc.HandleCryptMethod();
            pictureBox1.Image = pc.HandledImage;

        }
    }
}
