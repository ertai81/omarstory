using OmarStory.DBQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Data
{
    public class DecisionData
    {
        [DbColumn(IsPrimaryKey = true, IsAutoIncrement = true)]
        public int Id { get; set; }

        [DbColumn(IsPrimaryKey = true, IsNotNull = true)]
        public int Option { get; set; }

        [DbColumn(IsNotNull = true)]
        public string Text { get; set; }

        [DbColumn(IsNotNull = true)]
        public string Result { get; set; }

        [DbColumn()]
        public string Condition { get; set; }
    }
}
