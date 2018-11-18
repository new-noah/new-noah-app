// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Views/Navigation
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using System.IO;
using PNOAH.Helpers;
using Plugin.Media;
using PNOAH.Views.Pages;

namespace PNOAH.Views.Navigation
{
    public partial class NavigationViewAnimal : ContentView
    {
        public NavigationViewAnimal()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new SubmitAnimalPage());
        }
    }
}
