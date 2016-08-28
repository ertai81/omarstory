using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Resources
{
    public static class Strings
    {
        public static Dictionary<string, string> Codes = new Dictionary<string, string>()
        {
            { "O", "Objeto" },
            { "F", "Amigo" },
            { "S", "Estado" }
        };

        public static Dictionary<string, string> Action = new Dictionary<string, string>()
        {
            { "R", "Ganas" },
            { "L", "Pierdes" }
        };
    }
}
