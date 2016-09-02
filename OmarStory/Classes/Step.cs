using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Classes
{
    public class Step
    {
        public string Raw { get; set; }
        public string Code
        {
            get
            {
                return Raw.Substring(0, 1);
            }
        }

        public int Id
        {
            get
            {
                return Converters.Support.ToInt(Raw.Substring(1, Raw.Length - 1));
            }
        }

        public Step(Result result)
        {
            Raw = result.Raw;
        }

        public bool IsDecision()
        {
            return Code == "Q";
        }
    }
}
