# PictureCryptFramework
Use it to encrypt the image or decrypt it
# how to use it:

```
 private void button1_Click(object sender, EventArgs e)
        {

            using (PictureCrypt pc = new PictureEnCrypt(pictureBox1.Image, 3.9, 0.6))
            {
                pc.HandleCryptMethod();
                ///如果直接执行保存操作可以不用clone
                ///而像这样
                ///给pictureBox1.Image赋值
                ///必须先要clone出Image对象才能再给pictureBox1.Image赋值
                ///因为using后会释放HandledImage对象
                Image i = pc.HandledImage.Clone() as Image;
                pictureBox1.Image = i;
                ///保存操作
               // SaveImageFile(i, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + "handled.png");

            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
           ///在文件中读取bitmap 
           // Bitmap b = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + "handled.png");
            using (PictureCrypt pc = new PictureDeCrypt(pictureBox1.Image, 3.9, 0.6))
            {
                
                pc.HandleCryptMethod();
                ///如果直接执行保存操作可以不用clone
                ///而像这样
                ///给pictureBox1.Image赋值
                ///必须先要clone出Image对象才能再给pictureBox1.Image赋值
                ///因为using后会释放HandledImage对象
                Image i = pc.HandledImage.Clone() as Image;
                pictureBox1.Image = i;
                ///保存操作
                //SaveImageFile(i, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + "handled1.png");
            }

            
            

        }


        public void SaveImageFile(Image image, string despath)
        {
            ///需要根据文件扩展名来获取ImageFormat
            ///如本示例中为ImageFormat.Png
            image.Save(despath, ImageFormat.Png);
            
           


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
