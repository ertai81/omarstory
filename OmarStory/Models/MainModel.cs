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

        public DecisionData Decision0
        {
            get
            {
                if (Decisions.Count > 0)
                    return Decisions[0];
                else
                    return new DecisionData();
            }
        }

        public DecisionData Decision1
        {
            get
            {
                if (Decisions.Count > 1)
                    return Decisions[1];
                else
                    return new DecisionData();
            }
        }

        public DecisionData Decision2
        {
            get
            {
                if (Decisions.Count > 2)
                    return Decisions[2];
                else
                    return new DecisionData();
            }
        }

        public DecisionData Decision3
        {
            get
            {
                if (Decisions.Count > 3)
                    return Decisions[3];
                else
                    return new DecisionData();
            }
        }
        #endregion
    }
}
