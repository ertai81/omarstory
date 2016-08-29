using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Interfaces
{
    interface ICondition
    {
        string Condition { get; }

        bool HasConditions<T>();

        void CheckConditions<T>();
    }
}
