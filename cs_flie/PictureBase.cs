using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureHandler
{
    abstract class PictureBase
    {
        public Image Image
        {
            get;
            set;
        }

       public Image HandledImage
        {
            get;
            set;
        }

        Stack<Bitmap> bitmapStack = new Stack<Bitmap>();

        protected Stack<Bitmap> BitmapStack
        {
            get
            {
                return bitmapStack;
            }

            set
            {
                bitmapStack = value;
            }
        }

        public virtual Bitmap Withdraw()
        {
            BitmapStack.Pop();
            Bitmap bmp = BitmapStack.Peek();
            return bmp;

        }
    }
}
