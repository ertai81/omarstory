using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Global
{
    public static class Global
    {
        public const string DbProvider = "System.Data.SQLite";
        public const string CnnString = "Data Source=..\\Data\\OmarStoryData.db";

        public static bool IsLoadingGame = false;
        public static bool IsWaitingForDecision = false;
    }
}
