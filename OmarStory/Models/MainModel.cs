using OmarStory.Classes;
using OmarStory.Global;
using OmarStory.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.Specialized;

namespace OmarStory.Models
{
    public class MainModel : ViewModelBase
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
            }
        }

        private Step nextStep;
        public Step NextStep
        {
            get
            {
                return nextStep;
            }
            set
            {
                nextStep = value;
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
            }
        }

        private BitmapSource currentBackground;
        public BitmapSource CurrentBackground
        {
            get
            {
                return currentBackground;
            }
            set
            {
                currentBackground = value;
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
            }
        }
        #endregion

        #region  Properties for the General View
        public bool IsWaitingForDecision { get; set; }
        
        private Visibility decisionsVisibility;
        public Visibility DecisionsVisibility
        {
            get
            {
                return decisionsVisibility;
            }
            set
            {
                decisionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Decision> decisions;
        public ObservableCollection<Decision> Decisions
        {
            get
            {
                return decisions;
            }
            set
            {
                decisions = value;
                decisions.CollectionChanged += ContentCollectionChanged;
            }
        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }

        public Decision Decision0
        {
            get
            {
                if (Decisions.Count > 0)
                    return Decisions[0];
                else
                    return new Decision();
            }
        }

        public Decision Decision1
        {
            get
            {
                if (Decisions.Count > 1)
                    return Decisions[1];
                else
                    return new Decision();
            }
        }

        public Decision Decision2
        {
            get
            {
                if (Decisions.Count > 2)
                    return Decisions[2];
                else
                    return new Decision();
            }
        }
        #endregion
    }
}
