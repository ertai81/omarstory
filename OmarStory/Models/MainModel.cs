using OmarStory.Classes;
using OmarStory.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OmarStory.Models
{
    public class MainModel
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

    }
}
