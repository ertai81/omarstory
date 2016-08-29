using OmarStory.Classes;
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
    public class DialogActions : ICondition<CharDialog>
    {
        MainViewModel ViewModel;
        CharDialog Dialog;

        public DialogActions(MainViewModel viewModel, CharDialog dialog)
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
            switch(condition.Code)
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
            if (     condition.IsHave && Global.Inventory.Objects.Contains(condition.Id)
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

        #region Result
        public void AnalizeResult()
        {
            List<Result> results = Converters.Deserialize.ToListResults(Dialog.Result).ToList();

            //Gets the changes
            foreach (Result result in results)
            {
                //Updates inventory if needed
                if (result.IsInventoryUpdate)
                {
                    UpdateInventory(result);
                    ShowMessage(result);
                }

                if (IsBackgroundChange(result.Code))
                {
                    ViewModel.UpdateBackgound(result.Id);
                }

                if (IsNextStep(result.Code))
                {
                    ViewModel.SaveNextStep(result);
                }
            }
        }

        private bool IsNextStep(string code)
        {
            return (code == "D" || code == "Q");
        }

        private bool IsBackgroundChange(string code)
        {
            return code == "B";
        }

        private void UpdateInventory(Result result)
        {
            switch (result.Code)
            {
                case ("O"):
                    {
                        if (result.Action == "R" && !Global.Inventory.Objects.Contains(result.Id))
                        {
                            Global.Inventory.Objects.Add(result.Id);
                        }
                        else if (Global.Inventory.Objects.Contains(result.Id))
                        {
                            Global.Inventory.Objects.Remove(result.Id);
                        }
                        break;
                    }
                case ("F"):
                    {
                        if (result.Action == "R" && !Global.Inventory.Friends.Contains(result.Id))
                        {
                            Global.Inventory.Friends.Add(result.Id);
                        }
                        else if (Global.Inventory.Friends.Contains(result.Id))
                        {
                            Global.Inventory.Friends.Remove(result.Id);
                        }
                        break;
                    }
                case ("S"):
                    {
                        if (result.Action == "R" && !Global.Inventory.Statuses.Contains(result.Id))
                        {
                            Global.Inventory.Statuses.Add(result.Id);
                        }
                        else if (Global.Inventory.Statuses.Contains(result.Id))
                        {
                            Global.Inventory.Statuses.Remove(result.Id);
                        }
                        break;
                    }
                default:
                    return;
            }
        }

        private void ShowMessage(Result result)
        {
            InventoryChangeWindow infoWindow = new InventoryChangeWindow(result);
            infoWindow.ShowDialog();
        }
        #endregion
    }
}
