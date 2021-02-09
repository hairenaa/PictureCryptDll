using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureHandler
{
    class PictureDeCrypt : PictureCrypt
    {

        public PictureDeCrypt(Image image,double cipherU,double cipherX0,int n=5)
        {
            this.Image = image;
            this.CipherU = cipherU;
            this.CipherX0 = cipherX0;
            this.N = n;
        }

        public override void HandleCryptMethod()
        {
            IntPtr ptr;
            BitmapData cuBmpdate;
            Bitmap cuBmp;
            Bitmap bmp = new Bitmap(this.Image);
            BitmapStack.Push(bmp);
            byte[] rgbValues = GetRgbValues(out ptr, out cuBmpdate, out cuBmp);
            if (rgbValues != null)
            {
                
                byte[] newRgbvalues = Crypt(rgbValues, this.CipherU,this.CipherX0,this.N);
                Bitmap reBmp = BuileBitmap(newRgbvalues, ptr, cuBmp, cuBmpdate);
                BitmapStack.Push(reBmp);
                this.HandledImage = reBmp;
                
            }
            else
            {
                return;
            }

        }


        //private int[] GetCipherArrayFormBmp(Bitmap cihper_image)
        //{
        //    IntPtr ptr;
        //    Bitmap bmp;
        //    BitmapData data;
        //    byte[] rgbs = base.GetRgbValues(out ptr,out data,out bmp);
        //    int[] re = new int[rgbs.Length];
        //    for (int i = 0; i < rgbs.Length; i++)
        //    {
        //       int temp = BitConverter.ToInt32(new byte[] { rgbs[i] }, 0);
        //       re[i] = temp;

        //    }

        //    return re;
            
        //}


        //private void DecryptAction(byte[] rgb_values,int i)
        //{

        //    int iTemp = i;
        //    rgb_values[iTemp] = (byte)(rgb_values[iTemp] * 2 - this.CipherArray[iTemp]);
        //    //iTemp++;
        //    //rgb_values[iTemp] = (byte)(rgb_values[iTemp] * 2 - this.CipherArray[iTemp]);
        //    //iTemp++;
        //    //rgb_values[iTemp] = (byte)(rgb_values[iTemp] * 2 - this.CipherArray[iTemp]);


        //}

      
    }
}
