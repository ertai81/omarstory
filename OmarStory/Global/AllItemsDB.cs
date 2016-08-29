using OmarStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Global
{
    public static class AllItemsDB
    {
        public static List<Char> AllChars { get; set; }
        public static List<Object> AllObjects { get; set; }
        public static List<Status> AllStatuses { get; set; }
        public static List<Background> AllBackgrounds { get; set; }
    }
}
