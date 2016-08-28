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

        private bool hasAction
        {
            get
            {
                return Raw.Length > 5;
            }
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
                return hasAction ? Raw.Substring(0, 1) : string.Empty;
            }
        }

        public int Id
        {
            get
            {
                int indexBegin = hasAction ? 2 : 1;
                return Converters.Support.ToInt(Raw.Substring(indexBegin,4));
            }
        }
    }
}
