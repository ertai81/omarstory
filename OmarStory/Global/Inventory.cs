using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Global
{
    public class Inventory
    {
        List<int> Friends;
        List<int> Objects;
        List<int> Statuses;

        public Inventory()
        {
            Friends = new List<int>();
            Objects = new List<int>();
            Statuses = new List<int>();
        }
    }
}
