using OmarStory.Classes;
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
        public Result AnalizeCondition(Condition condition)
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

        #region Result
        public bool IsNextStep(string code)
        {
            return (code == "D" || code == "Q");
        }

        public bool IsBackgroundChange(string code)
        {
            return code == "B";
        }

        public void UpdateInventory(Result result)
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

        public void ShowMessage(Result result)
        {
            InventoryChangeWindow infoWindow = new InventoryChangeWindow(result);
            infoWindow.ShowDialog();
        }
        #endregion
    }
}
