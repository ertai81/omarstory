using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
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
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
        }

        public void ChangeCharacter(string name)
        {
            using (var db = new OmarStoryEntities())
            {
                try
                {
                    CurrentChar = db.Chars.Single(x => x.Name == name);
                }
                catch (Exception e)
                {
                    ShowError("Personaje no encontrado");
                }
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
    }
}
