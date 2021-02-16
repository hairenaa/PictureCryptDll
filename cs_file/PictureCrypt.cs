using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PictureHandler_dll
{
    public abstract class PictureCrypt : PictureBase
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

        protected Bitmap cuBmp;
        protected IntPtr ptr;
        protected BitmapData cuBmpdata;

        //protected  int[] CipherArray
        //{
        //    get;
        //    set;
        //}


        protected Bitmap BuileBitmap(byte[] rgbValues)
        {
            Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
            cuBmp.UnlockBits(cuBmpdata);
            return cuBmp;
        }

        protected byte[] GetRgbValues()
        {
            cuBmp = this.Image as Bitmap;

            if (cuBmp != null)
            {

                Rectangle rect = new Rectangle(0, 0, cuBmp.Width, cuBmp.Height);
                cuBmpdata = cuBmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                ptr = cuBmpdata.Scan0;
                int length = cuBmp.Height * cuBmp.Width * 3;
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




        protected byte[] Crypt(byte[] rgb_values, double cipherU, double cipherX0, int n)
        {

            double x = LogisticCrypt(cipherU, cipherX0, 2000);
            int key;
            for (int i = 0; i + 3 < rgb_values.Length; i += 3)
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






        protected double LogisticCrypt(double u, double x, int n)
        {
            for (int i = 0; i < n; i++)
            {
                x = u * x * (1 - x);
            }
            return x;
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                CipherU = 0;
                CipherX0 = 0;
                N = 0;
                cuBmpdata = null;
                ptr = IntPtr.Zero;
            }
            cuBmp.Dispose();

        }


    }
}
