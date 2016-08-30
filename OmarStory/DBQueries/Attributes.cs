using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.DBQueries
{
    /// <summary>
    /// The properties with this attribute will become the columns of the database table.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property)]
    public class DbColumnAttribute : System.Attribute
    {
        public bool IsPrimaryKey { get; set; }
        public bool IsAutoIncrement { get; set; }
        public bool IsIndexed { get; set; }
        public bool IsUnique { get; set; }
        public bool IsNotNull { get; set; }

        public string DefaultValue { get; set; }

        public DbColumnAttribute()
        {
        }
    }

    [System.AttributeUsage(AttributeTargets.Property)]
    public class DbTableAttribute : System.Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Class)]
    public class XmlSerializableAttribute : System.Attribute
    {
    }
}
