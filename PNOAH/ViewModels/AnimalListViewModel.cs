// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/ViewModels
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using PNOAH.Models;
using PNOAH.Services;
using Refit;

namespace PNOAH.ViewModels
{
    public class AnimalListViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsInitialized { get; set; } = false;

        public List<AnimalModel> Animals { get; set; }

        public async void Load()
        {
            if(!IsInitialized) 
            {
                try
                {
                    var apiAnimal = RestService.For<INoahApi>(NOAHConst.BASE_SERVER);
                    var response = await apiAnimal.GetAnimals();
                    Animals = response;

                    IsInitialized = true;
                }
                catch (WebException e)
                {
                    Debug.WriteLine(e.Message);
                } catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
