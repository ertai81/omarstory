using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Resources
{
    static class BackgroundImagesList
    {
        public static Dictionary<string, Bitmap> GetBitmap = new Dictionary<string, Bitmap>()
        {
            { "Aeropuerto", Resources.Images.Aeropuerto }
        };
    }
}
