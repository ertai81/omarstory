﻿using OmarStory.Classes;
using OmarStory.ViewModels;
using OmarStory.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Actions
{
    public class CommonActions
    {
        #region Condition
        public Result CheckCondition(Condition condition)
        {
            switch (condition.Code)
            {
                case ("O"):
                    {
                        return CheckObject(condition);
                    }
                case ("F"):
                    {
                        return CheckFriend(condition);
                    }
                case ("S"):
                    {
                        return CheckStatus(condition);
                    }
                default:
                    return null;
            }
        }

        private Result CheckObject(Condition condition)
        {
            if (condition.IsHave && Global.Inventory.Objects.Any(x => x.Id == condition.Id)
                || (!condition.IsHave && !Global.Inventory.Objects.Any(x => x.Id == condition.Id)
                ))
            {
                return null;
            }
            else
            {
                return condition.AlternateResult;
            }
        }

        private Result CheckFriend(Condition condition)
        {
            if (condition.IsHave && Global.Inventory.Friends.Any(x => x.Id == condition.Id)
                || (!condition.IsHave && !Global.Inventory.Friends.Any(x => x.Id == condition.Id)
                ))
            {
                return null;
            }
            else
            {
                return condition.AlternateResult;
            }
        }

        private Result CheckStatus(Condition condition)
        {
            if (condition.IsHave && Global.Inventory.Statuses.Any(x => x.Id == condition.Id)
                || (!condition.IsHave && !Global.Inventory.Statuses.Any(x => x.Id == condition.Id)
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
        public void AnalizeResults(MainViewModel ViewModel, string resultString, bool showPopUpMessages)
        {
            List<Result> results = Converters.Deserialize.ToListResults(resultString).ToList();

            //Gets the changes
            foreach (Result result in results)
            {
                //Updates inventory if needed
                if (result.IsInventoryUpdate)
                {
                    bool successfulUpdate = UpdateInventory(result);

                    if (successfulUpdate && showPopUpMessages && !result.IsStatusUpdate)
                    {
                        ShowMessage(result);
                    }
                }

                //Changes background
                if (IsBackgroundChange(result.Code))
                {
                    ViewModel.UpdateBackgound(Converters.Support.GetNameItem(result));
                }

                //Saves next step
                if (IsNextStep(result.Code))
                {
                    ViewModel.SaveNextStep(result);
                }
            }
        }

        public bool IsNextStep(string code)
        {
            return (code == "D" || code == "Q");
        }

        public bool IsBackgroundChange(string code)
        {
            return code == "B";
        }

        public bool UpdateInventory(Result result)
        {
            bool successfulUpdate = false;

            switch (result.Code)
            {
                case ("O"):
                    {
                        if (result.Action == "R" && !Global.Inventory.Objects.Any(x => x.Id == result.Id))
                        {
                            Global.Inventory.Objects.Add(Global.AllItemsDB.AllObjects.Single(x => x.Id == result.Id));
                            successfulUpdate = true;
                        }
                        else if (result.Action == "L" && Global.Inventory.Objects.Any(x => x.Id == result.Id))
                        {
                            Global.Inventory.Objects.Remove(Global.AllItemsDB.AllObjects.Single(x => x.Id == result.Id));
                            successfulUpdate = true;
                        }
                        break;
                    }
                case ("F"):
                    {
                        if (result.Action == "R" && !Global.Inventory.Friends.Any(x => x.Id == result.Id))
                        {
                            Global.Inventory.Friends.Add(Global.AllItemsDB.AllChars.Single(x => x.Id == result.Id));
                            successfulUpdate = true;
                        }
                        else if (result.Action == "L" && Global.Inventory.Friends.Any(x => x.Id == result.Id))
                        {
                            Global.Inventory.Friends.Remove(Global.AllItemsDB.AllChars.Single(x => x.Id == result.Id));
                            successfulUpdate = true;
                        }
                        break;
                    }
                case ("S"):
                    {
                        if (result.Action == "R" && !Global.Inventory.Statuses.Any(x => x.Id == result.Id))
                        {
                            Global.Inventory.Statuses.Add(Global.AllItemsDB.AllStatuses.Single(x => x.Id == result.Id));
                            successfulUpdate = true;
                        }
                        else if (result.Action == "L" && Global.Inventory.Statuses.Any(x => x.Id == result.Id))
                        {
                            Global.Inventory.Statuses.Remove(Global.AllItemsDB.AllStatuses.Single(x => x.Id == result.Id));
                            successfulUpdate = true;
                        }
                        break;
                    }
                default:
                    return false;
            }

            return successfulUpdate;
        }

        public void ShowMessage(Result result)
        {
            InventoryChangeWindow infoWindow = new InventoryChangeWindow(result);
            infoWindow.ShowDialog();
        }
        #endregion
    }
}
