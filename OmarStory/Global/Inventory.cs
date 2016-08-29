using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Global
{
    public class Inventory
    {
        public static List<int> Friends;
        public static List<int> Objects;
        public static List<int> Statuses;

        public Inventory()
        {
            Friends = new List<int>();
            Objects = new List<int>();
            Statuses = new List<int>();
        }
    }
}
