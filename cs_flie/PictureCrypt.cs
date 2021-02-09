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
    abstract class PictureCrypt : PictureBase
    {
        public abstract void HandleCryptMethod();

        protected double CipherU
        {
            get;
            set;
        }

        protected double CipherX0
        {
            get;
            set;
        }

        protected int N
        {
            get;
            set;
        }

       


        //protected  int[] CipherArray
        //{
        //    get;
        //    set;
        //}


        protected Bitmap BuileBitmap(byte[] rgbValues, IntPtr ptr, Bitmap cuBmp, BitmapData data)
        {
            Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
            cuBmp.UnlockBits(data);
            return cuBmp;
        }

        protected byte[] GetRgbValues(out IntPtr ptr, out BitmapData cuBmpdata, out Bitmap cuBmp)
        {
            Bitmap bmp = new Bitmap(this.Image);
            cuBmp = bmp.Clone() as Bitmap;
            if (cuBmp != null)
            {

                Rectangle rect = new Rectangle(0, 0, cuBmp.Width, cuBmp.Height);
                cuBmpdata = cuBmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, cuBmp.PixelFormat);
                ptr = cuBmpdata.Scan0;
                int length = cuBmp.Height*cuBmp.Width*4;
                byte[] rgbValues = new byte[length];
                Marshal.Copy(ptr, rgbValues, 0, length);
                return rgbValues;

            }
            else
            {
                ptr = IntPtr.Zero;
                cuBmp = null;
                cuBmpdata = null;
                return null;
            }

        }




        protected byte[] Crypt(byte[] rgb_values, double cipherU,double cipherX0,int n)
        {
            
            double x = LogisticCrypt(cipherU, cipherX0, 2000);
            int key;
            for (int i = 0; i+3 < rgb_values.Length; i += 3)
            {
                
                //R
                x = LogisticCrypt(cipherU, x, n);
                key = Convert.ToInt32(Math.Floor(x * 1000)) % 256;
                rgb_values[i] = (byte)(key ^ rgb_values[i]);
                //G
                x = LogisticCrypt(cipherU, x, n);
                key = Convert.ToInt32(Math.Floor(x * 1000)) % 256;
                rgb_values[i + 1] = (byte)(key ^ rgb_values[i + 1]);
                //B
                x = LogisticCrypt(cipherU, x, n);
                key = Convert.ToInt32(Math.Floor(x * 1000)) % 256;
                rgb_values[i + 2] = (byte)(key ^ rgb_values[i + 2]);


            }

            return rgb_values;

        }


       



        protected double LogisticCrypt(double u,double x,int n)
        {
            for (int i = 0; i < n; i++)
            {
                x = u * x * (1 - x);
            }
            return x;
        }
        
    }
}
