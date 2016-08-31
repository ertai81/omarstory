using OmarStory.Classes;
using OmarStory.Data;
using OmarStory.Interfaces;
using OmarStory.ViewModels;
using OmarStory.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Actions
{
    public class DialogActions : CommonActions, ICondition<DialogData>, IResult<DialogData>
    {
        MainViewModel ViewModel;
        DialogData Dialog;

        public DialogActions(MainViewModel viewModel, DialogData dialog)
        {
            ViewModel = viewModel;
            Dialog = dialog;
        }

        #region Conditions
        public bool HasConditions()
        {
            if (Dialog.Condition != null && Dialog.Condition != string.Empty)
            {
                return true;
            }
            return false;
        }

        public Result AnalizeConditions()
        {
            List<Condition> conditions = Converters.Deserialize.ToListConditions(Dialog.Condition).ToList();

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
        public void AnalizeResults()
        {
            AnalizeResults(ViewModel, Dialog.Result);
        }
        #endregion
    }
}
