using OmarStory.Data;
using OmarStory.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.Global
{
    public class Inventory : ViewModelBase
    {
        public static ObservableCollection<CharacterData> Friends { get; set; }

        public static ObservableCollection<ObjectData> Objects { get; set;}

        public static ObservableCollection<StatusData> Statuses { get; set; }

        public Inventory()
        {
            Friends = new ObservableCollection<CharacterData>();
            Objects = new ObservableCollection<ObjectData>();
            Statuses = new ObservableCollection<StatusData>();
        }
    }
}
