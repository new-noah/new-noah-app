// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/ViewModels
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using PNOAH.Models;
using PNOAH.Services;
using Refit;
using Xamarin.Forms;

namespace PNOAH.ViewModels
{
    public class AnimalListViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsInitialized { get; set; } = false;

        public List<AnimalModel> Animals { get; set; }

        public bool IsRefreshing { get; set; } = false;

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await RefreshData();

                    IsRefreshing = false;
                });
            }
        }

        private async  Task RefreshData()
        {
            Animals.Clear();
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
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

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
