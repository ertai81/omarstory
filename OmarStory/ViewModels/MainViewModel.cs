using OmarStory.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OmarStory.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IEnumerable<Inventory> currentInventory;
        public IEnumerable<Inventory> CurrentInventory
        {
            get
            {
                return currentInventory;
            }
            set
            {
                currentInventory = value;
                NotifyPropertyChanged();
            }
        }

        #region Properties for the Footer
        private Char currentChar;
        public Char CurrentChar
        {
            get
            {
                return currentChar;
            }
            set
            {
                currentChar = value;

                UpdateCurrentCharImage(currentChar.Name);

                NotifyPropertyChanged();
            }
        }

        private BitmapSource currentCharImage;
        public BitmapSource CurrentCharImage
        {
            get
            {
                return currentCharImage;
            }
            set
            {
                currentCharImage = value;
                NotifyPropertyChanged();
            }
        }

        private string currentText;
        public string CurrentText
        {
            get
            {
                return currentText;
            }
            set
            {
                currentText = value;
                NotifyPropertyChanged();
            }
        }
        #endregion


        public MainViewModel()
        {
            GetAllItems();
            NewGame();
        }

        public void NewGame()
        {
            Inventory CurrentInventory = new Inventory();
            ChangeCharacter(1);
        }

        #region Characters
        private void GetAllItems()
        {
            using (var db = new OmarStoryEntities())
            {
                Global.AllItemsDB.AllChars = db.Chars.ToList();
                Global.AllItemsDB.AllObjects = db.Objects.ToList();
                Global.AllItemsDB.AllStatuses = db.Statuses.ToList();
                Global.AllItemsDB.AllBackgrounds = db.Backgrounds.ToList();
            }
        }

        public void ChangeCharacter(string name)
        {
            try
            {
                CurrentChar = Global.AllItemsDB.AllChars.Single(x => x.Name == name);
            }
            catch
            {
                ShowError("Personaje no encontrado");
            }
        }

        public void ChangeCharacter(int id)
        {
            using (var db = new OmarStoryEntities())
            {
                try
                {
                    CurrentChar = db.Chars.Single(x => x.Id == id);
                }
                catch
                {
                    ShowError("Personaje no encontrado");
                }
            }
        }
        #endregion

        public void ShowDialog(int id)
        {
            CharDialog dialog;
            try
            {
                using (var db = new OmarStoryEntities())
                {
                    dialog = db.CharDialogs.Single(x => x.Id == id);
                }

                if (dialog.CharId != CurrentChar.Id)
                {
                    ChangeCharacter(dialog.CharId);
                }

                CurrentText = dialog.Text;
            }
            catch
            {
                ShowError("Dialog not found");
            }
        }

        private void UpdateCurrentCharImage(string name)
        {
            try
            {
                CurrentCharImage = Converters.BitmapConversion.ToWpfBitmap(Resources.CharImagesList.GetBitmap[name]);
            }
            catch
            {
                ShowError("Imagen no encontrada");
            }
        }
    }
}
