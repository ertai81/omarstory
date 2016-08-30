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
using OmarStory.Data;

namespace OmarStory.Models
{
    public class MainModel : ViewModelBase
    {
        private Inventory currentInventory;
        public Inventory CurrentInventory
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
        private void InventoryCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("CurrentInventory");
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
                NotifyPropertyChanged();
            }
        }

        #region Properties for the Footer
        private CharacterData currentChar;
        public CharacterData CurrentChar
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

        private ObservableCollection<DecisionData> decisions;
        public ObservableCollection<DecisionData> Decisions
        {
            get
            {
                return decisions;
            }
            set
            {
                decisions = value;
                decisions.CollectionChanged += ContentCollectionChanged;
                NotifyPropertyChanged();
            }
        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Decisions");
        }
        #endregion
    }
}
