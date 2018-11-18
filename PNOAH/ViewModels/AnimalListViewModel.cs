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

        public NavigationAnimalViewModel ViewModelNavigation { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await RefreshData();
                    await RefreshBalance();

                    IsRefreshing = false;
                });
            }
        }

        public ICommand RefreshBalanceCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await RefreshBalance();
                });
            }
        }

        private async  Task RefreshData()
        {
            Animals.Clear();
            try
            {
                var API = RestService.For<INoahApi>(NOAHConst.BASE_SERVER);
                var response = await API.GetAnimals();
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


        private async Task RefreshBalance()
        {
            try
            {
                var API = RestService.For<INoahApi>(NOAHConst.BASE_SERVER);
                var response = await API.GetUserBalance();
                if (ViewModelNavigation != null)
                {
                    ViewModelNavigation.Balance = response.Balance;
                }
            } catch (Exception e)
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
