using OmarStory.Classes;
using OmarStory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Actions
{
    public class DecisionActions //: ICondition<Decision>
    {
        Decision Decision;

        public DecisionActions(Decision decision)
        {
            Decision = decision;
        }

        public bool HasConditions()
        {
            if (Decision.Condition != null && Decision.Condition != string.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
