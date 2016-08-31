using OmarStory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStoryBuilder
{
    public class Model
    {
        public string DbProvider = "System.Data.SQLite";
        public string CnnString = "Data Source=..\\..\\..\\OmarStory\\bin\\OmarStoryData.db";

        public List<ObjectData> AllObjects { get; set; }
        public List<CharacterData> AllChars { get; set; }
        public List<StatusData> AllStatuses { get; set; }
        public List<BackgroundData> AllBackgrounds { get; set; }
        public List<DialogData> AllDialogs { get; set; }
        public List<DecisionData> AllDecisions { get; set; }

        public Model()
        {
            AllChars = new List<CharacterData>();
            AllObjects = new List<ObjectData>();
            AllStatuses = new List<StatusData>();
            AllBackgrounds = new List<BackgroundData>();
            AllDialogs = new List<DialogData>();
            AllDecisions = new List<DecisionData>();
        }
    }
}
