using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PictureHandler
{
    class PictureEnCrypt : PictureCrypt
    {


        public PictureEnCrypt(Image image,double cipherU,double cipherX0,int n=5)
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
            byte[] rgbValues = GetRgbValues(out ptr,out cuBmpdate,out cuBmp);
            if (rgbValues != null)
            {
               
                byte[] newRgbvalues = Crypt(rgbValues,this.CipherU,this.CipherX0,this.N);
                Bitmap reBmp = BuileBitmap(newRgbvalues, ptr, cuBmp, cuBmpdate);
                BitmapStack.Push(reBmp);
                this.HandledImage = reBmp;
                
            }
            else
            {
                return;   
            }


        }




       


        
       



        //private int[] GetRandomCipherArray(int pixelCount)
        //{
        //    int cipherArraycount = pixelCount;
        //    int[] cipherArray = new int[cipherArraycount];
        //    Random ran = new Random(DateTime.Now.Millisecond);
        //    for (int j = 0; j < cipherArraycount; j++)
        //    {
        //       cipherArray[j] = ran.Next(0, 255);
        //    }
        //    return cipherArray;
        //}



        //private Bitmap BuilecipherBitmap(int[] cipherArray)
        //{
        //    IntPtr ptr;
        //    BitmapData data;
        //    Bitmap bmp;
        //    byte[]rgbs = GetRgbValues(out ptr, out data, out bmp);
        //    for (int x=0;x < rgbs.Length; x ++)
        //    {
        //        rgbs[x] = (byte)cipherArray[x];

        //    }

        //   return BuileBitmap(rgbs, ptr, bmp, data);
        //}


    }
}
