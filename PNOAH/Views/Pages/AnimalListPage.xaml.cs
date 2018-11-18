// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Views/Pages
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Refit;
using PNOAH.Services;
using System.Net;
using System.Diagnostics;
using PNOAH.Models;
using PNOAH.ViewModels;

namespace PNOAH.Views.Pages
{
    public partial class AnimalListPage : ContentPage
    {
        AnimalListViewModel ViewModel;

        public AnimalListPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new AnimalListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }


        async void Load()
        {
            try
            {
                if (!ViewModel.IsInitialized)
                {
                    ViewModel.Load();
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as AnimalModel;
            Navigation.PushModalAsync(new AnimalItemPage(item));
        }
    }
}
