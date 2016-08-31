using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Resources
{
    static class CharImagesList
    {
        public static Dictionary<string, Bitmap> GetBitmap = new Dictionary<string, Bitmap>()
        {
            { "Mujer", Resources.Images.Mujer },
            { "Omar", Resources.Images.Omar },
            { "Iñaki", Resources.Images.Inaki },
            { "Narrador", Resources.Images.Narrador }
        };
    }
}
