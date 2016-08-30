using OmarStory.DBQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Data
{
    public class StatusData
    {
        [DbColumn(IsPrimaryKey = true, IsAutoIncrement = true)]
        public int Id { get; set; }

        [DbColumn(IsNotNull = true)]
        public string Name { get; set; }
    }
}
