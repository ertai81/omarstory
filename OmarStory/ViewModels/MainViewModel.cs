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
        private IEnumerable<Char> chars;
        public IEnumerable<Char> Chars
        {
            get
            {
                return chars;
            }
            set
            {
                chars = value;
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
            InitializeGame();
        }

        public void InitializeGame()
        {
            GetAllChars();
            ChangeCharacter(1);
        }

        private void GetAllChars()
        {
            using (var db = new OmarStoryEntities())
            {
                Chars = db.Chars.ToList();
            }
        }

        public void ChangeCharacter(string name)
        {
            try
            {
                CurrentChar = Chars.Single(x => x.Name == name);
            }
            catch (Exception e)
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
