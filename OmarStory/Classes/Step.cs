using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Classes
{
    public class Step
    {
        public string Code { get; set; }
        public int Id { get; set; }

        public Step(Result result)
        {
            Code = result.Code;
            Id = result.Id;
        }

        public bool IsDecision()
        {
            return Code == "Q";
        }
    }
}
