using BandWebtileGenerator.Library.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BandWebtileGenerator.Views
{
    public sealed partial class BuilderHomeView : Page
    {
        public BuilderHomeView()
        {
            this.InitializeComponent();

            DataContext = App.ServiceProvider.GetRequiredService<BuilderHomeViewModel>();
        }

        public BuilderHomeViewModel ViewModel => (BuilderHomeViewModel)this.DataContext;
    }
}
