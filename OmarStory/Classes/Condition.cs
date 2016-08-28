using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Classes
{
    public class Condition
    {
        public Condition(string raw)
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

        public bool IsHave
        {
            get
            {
                return Raw.Substring(1, 1) == "Y" ? true : false;
            }
        }

        public int Id
        {
            get
            {
                return Converters.Support.ToInt(Raw.Substring(2,4));
            }
        }

        public Result AlternateResult
        {
            get
            {
                return new Result(Raw.Substring(6));
            }
        }
    }
}
