using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureHandler_dll
{
    public abstract class PictureCompressionBase : PictureBase
    {
        public abstract void CompressionORDeCompressionHandleMethod();

        public int Quality
        {
            get;
            set;
        }


        public int Multiple
        {
            get;
            set;
        }

        public ImageCodecInfo OutedImageCodecInfo
        {
            get;
            protected set;
        }

        public EncoderParameters OutedEncoderParameters
        {
            get;
            protected set;
        }

        //:image/bmp,image/tiff,image/jpeg,image/gift,image/png
        //public enum MimeTypeEnum
        //{
        //    bmp,
        //    tiff,
        //    jpeg,
        //    gift,
        //    png,

        //}

        //public static string GetMimeTypeStr(MimeTypeEnum e)
        //{
        //    return "image/" + e.ToString();

        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                Quality = 0;
                Multiple = 0;
                OutedImageCodecInfo = null;
            }
            OutedEncoderParameters.Dispose();
        }



    }




}
