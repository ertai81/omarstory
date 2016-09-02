using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Classes
{
    public class Result
    {
        public Result(string raw)
        {
            Raw = raw;
        }

        public string Raw { get; set; }

        public string Code
        {
            get
            {
                return Raw.Substring(0, 1);
            }
        }

        public string Action
        {
            get
            {
                return IsInventoryUpdate ? Raw.Substring(1, 1) : string.Empty;
            }
        }

        public int Id
        {
            get
            {
                int indexBegin = IsInventoryUpdate ? 2 : 1;
                return Converters.Support.ToInt(Raw.Substring(indexBegin,4));
            }
        }

        public bool IsInventoryUpdate
        {
            get
            {
                return Raw.Length > 5;
            }
        }

        public bool IsStatusUpdate
        {
            get
            {
                return Code == "S";
            }
        }
    }
}
