using OmarStory.Classes;
using OmarStory.Data;
using OmarStory.Interfaces;
using OmarStory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Actions
{
    public class DecisionActions : CommonActions, ICondition<DecisionData>, IResult<DecisionData>
    {
        DecisionData Decision;
        MainViewModel ViewModel;

        public DecisionActions(MainViewModel viewModel, DecisionData decision)
        {
            ViewModel = viewModel;
            Decision = decision;
        }

        #region Conditions
        public bool HasConditions()
        {
            if (Decision.Condition != null && Decision.Condition != string.Empty)
            {
                return true;
            }
            return false;
        }

        public Result AnalizeConditions()
        {
            List<Condition> conditions = Converters.Deserialize.ToListConditions(Decision.Condition).ToList();

            foreach (Condition cond in conditions)
            {
                Result result = CheckCondition(cond);

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
        #endregion

        #region Result
        public void AnalizeResults(bool showPopUpMessages = true)
        {
            AnalizeResults(ViewModel, Decision.Result, showPopUpMessages);
        }
        #endregion
    }
}
