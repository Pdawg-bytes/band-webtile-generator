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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MS_Band_WebTile_Generator.PostBuildPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostBuildHome : Page
    {
        public PostBuildHome()
        {
            this.InitializeComponent();
        }

        public static bool isRequired;

        private void ResourceNext_Click(object sender, RoutedEventArgs e)
        {
            if (isRequired == true)
            {
                this.Frame.Navigate(typeof(PostBuildIconTrue), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            }
            else
            {
                this.Frame.Navigate(typeof(PostBuildIconFalse), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            }
        }

        private void ResourceBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PostBuild), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }
    }
}
