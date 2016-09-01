using OmarStory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OmarStory.Classes
{
    public class Background
    {
        public BackgroundData Data { get; set; }

        public int Id
        {
            get
            {
                return Data.Id;
            }
        }

        public string Name
        {
            get
            {
                return Data.Name;
            }
        }

        public BitmapSource Image { get; set; }

        public Background()
        {
            Data = new BackgroundData();
            Image = null;
        }
    }
}
