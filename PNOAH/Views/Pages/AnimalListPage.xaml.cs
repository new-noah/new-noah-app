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
using PNOAH.Views.Navigation;

namespace PNOAH.Views.Pages
{
    public partial class AnimalListPage : ContentPage
    {
        AnimalListViewModel ViewModel;
        View TitleView;

        public AnimalListPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new AnimalListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();

            TitleView = NavigationPage.GetTitleView(this);
            ViewModel.ViewModelNavigation = TitleView.BindingContext as NavigationAnimalViewModel;

        }

        void Load()
        {
            try
            {
                if (!ViewModel.IsInitialized)
                {
                    ViewModel.Load();
                    ViewModel.RefreshBalanceCommand.Execute(true);
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
