using OmarStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Actions
{
    public class ConditionsActions<T>
    {
        T _value;

        public static bool HasConditions(T t)
        {
            return true;
        }
    }
}
