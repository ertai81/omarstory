using OmarStory.Data;
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
        public static List<CharacterData> AllChars { get; set; }
        public static List<Data.ObjectData> AllObjects { get; set; }
        public static List<StatusData> AllStatuses { get; set; }
        public static List<BackgroundData> AllBackgrounds { get; set; }
    }
}
