using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

using Microsoft.Extensions.DependencyInjection;
using BandWebtileGenerator.Library.ViewModels;
using BandWebtileGenerator.Views;
using Microsoft.UI.Xaml.Controls;

namespace BandWebtileGenerator
{
    public sealed partial class MainPage : Page
    {
        private Microsoft.UI.Xaml.Controls.NavigationViewItem _lastSelectedItem;

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = App.ServiceProvider.GetRequiredService<MainPageViewModel>();

            ContentFrame.Navigate(typeof(HomeView), null, new EntranceNavigationTransitionInfo());
            _lastSelectedItem = HomeNavItem;
            RootNavView.SelectedItem = HomeNavItem;

            Window.Current.SetTitleBar(AppTitleBar);
        }

        public MainPageViewModel ViewModel => (MainPageViewModel)this.DataContext;

        private void RootNavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as Microsoft.UI.Xaml.Controls.NavigationViewItem;

            if (item == null || item == _lastSelectedItem)
                return;

            NavigateToView(item.Tag.ToString());
            _lastSelectedItem = item;
        }

        private void NavigateToView(string itemTag)
        {
            switch (itemTag)
            {
                case "Settings":
                    ContentFrame.Navigate(typeof(SettingsView), null, new SlideNavigationTransitionInfo());
                    break;
                case "HomeView":
                    ContentFrame.Navigate(typeof(HomeView), null, new SlideNavigationTransitionInfo());
                    break;
            }
        }
    }
}
