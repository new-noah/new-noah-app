// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Views/Pages
using System;
using System.Collections.Generic;
using PNOAH.Models;
using Xamarin.Forms;

using PNOAH.ViewModels;

namespace PNOAH.Views.Pages
{
    public partial class AnimalItemPage : ContentPage
    {

        AnimalItemViewModel ViewModel;
        public AnimalItemPage(AnimalModel animal)
        {
            InitializeComponent();
            BindingContext = ViewModel = new  AnimalItemViewModel(animal);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.ContractCommand.Execute(null);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
        }
    }
}
