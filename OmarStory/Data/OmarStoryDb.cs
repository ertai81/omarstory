﻿using OmarStory.DBQueries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Data
{
    class OmarStoryDb
    {
        #region Character
        public static ICollection<CharacterData> SelectCharacterData(IDbConnection cnn)
        {
            try
            {
                var chars = DbTable<CharacterData>.Select(cnn).ToList();

                if (chars == null)
                {
                    return new List<CharacterData>();
                }

                return chars;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando personajes{0}{1}", Environment.NewLine, e.Message));
                return null;
            }
        }

        public static CharacterData SelectCharacterData(IDbConnection cnn, int id)
        {
            try
            {
                var charCondition = new DbCondition("Id=?", id);

                var chars = DbTable<CharacterData>.Select(cnn, condition: charCondition).ToList();

                if (chars == null)
                {
                    return new CharacterData();
                }

                return chars[0];
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando personaje {0}{1}{2}", 
                    id.ToString(), Environment.NewLine, e.Message));
                return null;
            }
        }
        #endregion

        #region Dialog
        public static DialogData SelectDialogData(IDbConnection cnn, int id)
        {
            try
            {
                var dialogCondition = new DbCondition("Id=?", id);

                var dialogs = DbTable<DialogData>.Select(cnn, condition: dialogCondition).ToList();

                if (dialogs == null)
                {
                    return new DialogData();
                }

                return dialogs[0];
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando diálogo {0}{1}{2}",
                                        id.ToString(), Environment.NewLine, e.Message));
                return null;
            }
        }
        #endregion

        #region Decision
        public static ICollection<DecisionData> SelectDecisionData(IDbConnection cnn, int id)
        {
            try
            {
                var decisionCondition = new DbCondition("Id=?", id);

                var decisions = DbTable<DecisionData>.Select(cnn, condition: decisionCondition).ToList();

                if (decisions == null)
                {
                    return new List<DecisionData>();
                }

                return decisions;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando decisiones {0}{1}{2}",
                                        id.ToString(), Environment.NewLine, e.Message));
                return null;
            }
        }
        #endregion

        #region Object
        public static ICollection<ObjectData> SelectObjectData(IDbConnection cnn)
        {
            try
            {
                var objects = DbTable<ObjectData>.Select(cnn).ToList();

                if (objects == null)
                {
                    return new List<ObjectData>();
                }

                return objects;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando objectos{0}{1}", Environment.NewLine, e.Message));
                return null;
            }
        }

        public static ObjectData SelectObjectData(IDbConnection cnn, int id)
        {
            try
            {
                var objectCondition = new DbCondition("Id=?", id);

                var objects = DbTable<ObjectData>.Select(cnn, condition: objectCondition).ToList();

                if (objects == null)
                {
                    return new ObjectData();
                }

                return objects[0];
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando objecto {0}{1}{2}",
                                        id.ToString(), Environment.NewLine, e.Message));
                return null;
            }
        }
        #endregion

        #region Background
        public static ICollection<BackgroundData> SelectBackgroundData(IDbConnection cnn)
        {
            try
            {
                var backgrounds = DbTable<BackgroundData>.Select(cnn).ToList();

                if (backgrounds == null)
                {
                    return new List<BackgroundData>();
                }

                return backgrounds;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando fondos{0}{1}", Environment.NewLine, e.Message));
                return null;
            }
        }

        public static BackgroundData SelectBackgroundData(IDbConnection cnn, int id)
        {
            try
            {
                var backgroundCondition = new DbCondition("Id=?", id);

                var backgrounds = DbTable<BackgroundData>.Select(cnn, condition: backgroundCondition).ToList();

                if (backgrounds == null)
                {
                    return new BackgroundData();
                }

                return backgrounds[0];
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando fondo {0}{1}{2}",
                        id.ToString(), Environment.NewLine, e.Message));
                return null;
            }
        }
        #endregion

        #region Status
        public static ICollection<StatusData> SelectStatusData(IDbConnection cnn)
        {
            try
            {
                var statuses = DbTable<StatusData>.Select(cnn).ToList();

                if (statuses == null)
                {
                    return new List<StatusData>();
                }

                return statuses;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando estados{0}{1}", Environment.NewLine, e.Message));
                return null;
            }
        }

        public static StatusData SelectStatusData(IDbConnection cnn, int id)
        {
            try
            {
                var statusCondition = new DbCondition("Id=?", id);

                var statuses = DbTable<StatusData>.Select(cnn, condition: statusCondition).ToList();

                if (statuses == null)
                {
                    return new StatusData();
                }

                return statuses[0];
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Error recuperando estado {0}{1}{2}",
                        id.ToString(), Environment.NewLine, e.Message));
                return null;
            }
        }
        #endregion
    }
}
