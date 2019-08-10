using System;
using System.Collections.Generic;
using Okra.Models;
using Prism.Navigation;
using Xamarin.Forms;

namespace Okra.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
