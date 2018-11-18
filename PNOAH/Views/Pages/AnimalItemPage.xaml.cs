// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Views/Pages
using System;
using System.Collections.Generic;
using PNOAH.Models;
using Xamarin.Forms;

namespace PNOAH.Views.Pages
{
    public partial class AnimalItemPage : ContentPage
    {
        public AnimalItemPage(AnimalModel animal)
        {
            InitializeComponent();
            BindingContext = animal;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            // TODO:
        }
    }
}
