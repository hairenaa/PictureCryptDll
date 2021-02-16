using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureHandler_dll
{
    public class PictureCompression : PictureCompressionBase
    {
        public PictureCompression(Image image, int quality = 18, int multiple = 3)
        {
            this.Image = image;
            this.Quality = quality;
            this.Multiple = multiple;

        }

        public override void CompressionORDeCompressionHandleMethod()
        {

            this.HandledImage = GetThumImage(this.Image, this.Quality, this.Multiple);
        }

        private Image GetThumImage(Image Cuimage, int quality, int multiple)
        {
            string mime = GetImageFormatToMineType(this.Image);
            if (mime != null)
            {
                ImageCodecInfo myImageCodeInfo = GetEncoderInfo(mime);
                System.Drawing.Imaging.Encoder myencoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters encoderParams = new EncoderParameters(1);
                EncoderParameter encoderParam = new EncoderParameter(myencoder, quality);
                encoderParams.Param[0] = encoderParam;
                float Width = Cuimage.Width;
                float height = Cuimage.Height;
                Bitmap newImage = new Bitmap((int)(Width / multiple), (int)(height / multiple));
                Graphics g = Graphics.FromImage(newImage);
                g.DrawImage(this.Image, 0, 0, Width / multiple, height / multiple);
                g.Dispose();
                this.OutedImageCodecInfo = myImageCodeInfo;
                this.OutedEncoderParameters = encoderParams;
                return newImage;
            }
            else
            {
                throw new Exception("当前尚不支持该类型图片的压缩");
            }


        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {

            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                {
                    return encoders[j];
                }

            }

            return null;
        }


        private string GetImageFormatToMineType(Image image)
        {
            if (image.RawFormat.Equals(ImageFormat.Jpeg))
            {
                return "image/jpeg";
            }
            else if (image.RawFormat.Equals(ImageFormat.Gif))
            {
                return "image/gift";
            }
            else if (image.RawFormat.Equals(ImageFormat.Png))
            {
                return "image/png";
            }
            else if (image.RawFormat.Equals(ImageFormat.Bmp))
            {
                return "image/bmp";
            }
            else if (image.RawFormat.Equals(ImageFormat.Tiff))
            {
                return "image/tiff";
            }
            else
            {
                return null;
            }


        }


    }
}
