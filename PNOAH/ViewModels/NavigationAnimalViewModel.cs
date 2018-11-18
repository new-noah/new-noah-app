// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/ViewModels
using System;
using System.ComponentModel;

namespace PNOAH.ViewModels
{
    public class NavigationAnimalViewModel: INotifyPropertyChanged
    {
        public string Balance { get; set; } = "00000000000";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
