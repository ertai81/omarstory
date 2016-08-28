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
        public static IEnumerable<Char> AllChars { get; set; }
        public static IEnumerable<Object> AllObjects { get; set; }
        public static IEnumerable<Status> AllStatuses { get; set; }
        public static IEnumerable<Background> AllBackgrounds { get; set; }
    }
}
