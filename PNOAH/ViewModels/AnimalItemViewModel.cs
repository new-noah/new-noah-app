// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/ViewModels
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PNOAH.Models;
using Xamarin.Forms;
using System.Diagnostics;
using PNOAH.Services;
using Refit;
using System.ComponentModel;

namespace PNOAH.ViewModels
{
    public class AnimalItemViewModel: INotifyPropertyChanged
    {
        readonly AnimalModel AnimalModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Url 
        {
            get 
            {
                return AnimalModel.Url;
            } 

        }

        public string AboutAnimal {
            get 
            {
                return AnimalModel.AboutAnimal;
            }
        }

        public string Name {
            get => AnimalModel.Name;
        }

        public string Donated { get; set; } = "Donated: ";

        public string ContractBalance { get; set; }

        public bool CanExePayCmd { get; set; } = true;

        public ICommand ContractCommand
        {
            get
            {
                return new Command(async () =>
                {

                    await GetContractAsync();

                });
            }
        }

        async private Task GetContractAsync()
        {
            try
            {
                var API = RestService.For<INoahApi>(NOAHConst.BASE_SERVER);
                var response = await API.GetContractBalance();

                ContractBalance = response.Balance;

            } catch (Exception e)
            {

            }
        }

        public ICommand PayCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (!CanExePayCmd) return;
                    Donated = "Transaction ... ";
                    CanExePayCmd = false;
                    await PayAsync();
                    await GetContractAsync();
                    Donated = "Donated: ";
                    CanExePayCmd = true;
                });
            }
        }

        private async Task PayAsync()
        {
            try
            {
                var API = RestService.For<INoahApi>(NOAHConst.BASE_SERVER);
                var response = await API.Pay();

            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public AnimalItemViewModel(AnimalModel model)
        {
            AnimalModel = model;
        }
    }
}
