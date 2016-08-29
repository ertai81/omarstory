using OmarStory.Classes;
using OmarStory.Interfaces;
using OmarStory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Actions
{
    public class DecisionActions : ICondition<Decision>
    {
        Decision Decision;
        MainViewModel ViewModel;

        public DecisionActions(MainViewModel viewModel, Decision decision)
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

        #region Conditions
        public Result AnalizeConditions()
        {
            List<Condition> conditions = Converters.Deserialize.ToListConditions(Decision.Condition).ToList();

            foreach (Condition cond in conditions)
            {
                Result result = AnalizeCondition(cond);

                if (result == null)
                {
                    //Condition checks, we continue
                    continue;
                }
                else
                {
                    //result is not empty -> The alternate result was activated
                    return result;
                }
            }

            //Got to the end of the condition list without any error
            return null;
        }

        private Result AnalizeCondition(Condition condition)
        {
            switch (condition.Code)
            {
                case ("O"):
                    {
                        return AnalizeObject(condition);
                    }
                case ("F"):
                    {
                        return AnalizeFriend(condition);
                    }
                case ("S"):
                    {
                        return AnalizeStatus(condition);
                    }
                default:
                    return null;
            }
        }

        private Result AnalizeObject(Condition condition)
        {
            if (condition.IsHave && Global.Inventory.Objects.Contains(condition.Id)
                || (!condition.IsHave && Global.Inventory.Objects.Contains(condition.Id)
                ))
            {
                return null;
            }
            else
            {
                return condition.AlternateResult;
            }
        }

        private Result AnalizeFriend(Condition condition)
        {
            if (condition.IsHave && Global.Inventory.Friends.Contains(condition.Id)
                || (!condition.IsHave && Global.Inventory.Friends.Contains(condition.Id)
                ))
            {
                return null;
            }
            else
            {
                return condition.AlternateResult;
            }
        }

        private Result AnalizeStatus(Condition condition)
        {
            if (condition.IsHave && Global.Inventory.Statuses.Contains(condition.Id)
                || (!condition.IsHave && Global.Inventory.Statuses.Contains(condition.Id)
                ))
            {
                return null;
            }
            else
            {
                return condition.AlternateResult;
            }
        }
        #endregion
    }
}
