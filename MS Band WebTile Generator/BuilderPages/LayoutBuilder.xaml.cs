using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts.DataProvider;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MS_Band_WebTile_Generator.BuilderPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LayoutBuilder : Page
    {
        public LayoutBuilder()
        {
            this.InitializeComponent();
            LayoutNext.IsEnabled = false;
            lrb_Selected = false;
            prb_Selected = false;
        }

        public static bool prb_Selected;
        public static bool lrb_Selected;

        private void LayoutBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.Builder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }

        private void LayoutNext_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.DataBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void HandlePageCheck(object sender, RoutedEventArgs e)
        {
            prb_Selected = true;
            RadioButton prb = sender as RadioButton;
            StyleBuilder.PageType = prb.Name;
            switch (prb.Name)
            {
                case "MSBand_ScrollingText":
                default:
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/ScrollingTextImage.png"));
                    StyleBuilder.E1 = "1";
                    StyleBuilder.E2 = "2";
                    StyleBuilder.E3 = null;
                    StyleBuilder.I1 = null;
                    StyleBuilder.I2 = null;
                    StyleBuilder.I3 = null;
                    StyleBuilder.IN1 = null;
                    StyleBuilder.IN2 = null;
                    StyleBuilder.IN3 = null;
                    DataBuilder.TB1Enable = true;
                    DataBuilder.TB2Enable = true;
                    DataBuilder.TB3Enable = false;
                    PostBuildPages.PostBuildHome.isRequired = false;
                    break;
                case "MSBand_NoScrollingText":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/NoScrollingTextImage.png"));
                    StyleBuilder.E1 = "1";
                    StyleBuilder.E2 = "2";
                    StyleBuilder.E3 = "3";
                    StyleBuilder.I1 = null;
                    StyleBuilder.I2 = null;
                    StyleBuilder.I3 = null;
                    StyleBuilder.IN1 = null;
                    StyleBuilder.IN2 = null;
                    StyleBuilder.IN3 = null;
                    DataBuilder.TB1Enable = true;
                    DataBuilder.TB2Enable = true;
                    DataBuilder.TB3Enable = true;
                    PostBuildPages.PostBuildHome.isRequired = false;
                    break;
                case "MSBand_SingleMetric":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricImage.png"));
                    StyleBuilder.E1 = "1";
                    StyleBuilder.E2 = "2";
                    StyleBuilder.E3 = null;
                    StyleBuilder.I1 = null;
                    StyleBuilder.I2 = null;
                    StyleBuilder.I3 = null;
                    StyleBuilder.IN1 = null;
                    StyleBuilder.IN2 = null;
                    StyleBuilder.IN3 = null;
                    DataBuilder.TB1Enable = true;
                    DataBuilder.TB2Enable = true;
                    DataBuilder.TB3Enable = false;
                    PostBuildPages.PostBuildHome.isRequired = false;
                    break;
                case "MSBand_SingleMetricWithIcon":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricWithIconImage.png"));
                    StyleBuilder.E1 = "12";
                    StyleBuilder.E2 = "21";
                    StyleBuilder.E3 = null;
                    StyleBuilder.I1 = "11";
                    StyleBuilder.I2 = null;
                    StyleBuilder.I3 = null;
                    StyleBuilder.IN1 = "true";
                    StyleBuilder.IN2 = null;
                    StyleBuilder.IN3 = null;
                    DataBuilder.TB1Enable = true;
                    DataBuilder.TB2Enable = true;
                    DataBuilder.TB3Enable = false;
                    PostBuildPages.PostBuildHome.isRequired = true;
                    break;
                case "MSBand_MetricsWithIcons":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/MetricsWithIconsImage.png"));
                    StyleBuilder.E1 = "12";
                    StyleBuilder.E2 = "22";
                    StyleBuilder.E3 = "32";
                    StyleBuilder.I1 = "11";
                    StyleBuilder.I2 = "21";
                    StyleBuilder.I3 = "31";
                    StyleBuilder.IN1 = "true";
                    StyleBuilder.IN2 = "true";
                    StyleBuilder.IN3 = "true";
                    DataBuilder.TB1Enable = true;
                    DataBuilder.TB2Enable = true;
                    DataBuilder.TB3Enable = true;
                    PostBuildPages.PostBuildHome.isRequired = true;
                    break;
                case "MSBand_SingleMetricWithSecondary":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricWithSecondaryImage.png"));
                    StyleBuilder.E1 = "12";
                    StyleBuilder.E2 = "22";
                    StyleBuilder.E3 = "32";
                    StyleBuilder.I1 = "21";
                    StyleBuilder.I2 = null;
                    StyleBuilder.I3 = null;
                    StyleBuilder.IN1 = "true";
                    StyleBuilder.IN2 = null;
                    StyleBuilder.IN3 = null;
                    DataBuilder.TB1Enable = true;
                    DataBuilder.TB2Enable = true;
                    DataBuilder.TB3Enable = true;
                    PostBuildPages.PostBuildHome.isRequired = true;
                    break;
            }
            LayoutNext.IsEnabled = (prb_Selected == true) && (lrb_Selected == true);
        }

        private void HandleResourceTypeCheck(object sender, RoutedEventArgs e)
        {
            lrb_Selected = true;
            RadioButton lrb = sender as RadioButton;
            if (lrb.Name == "Simple")
            {
                StyleBuilder.ResourceType = "Simple";
            }
            else if (lrb.Name == "Simple2")
            {
                StyleBuilder.ResourceType = "Simple";
            }
            else
            {
                StyleBuilder.ResourceType = "Feed";
            }
            LayoutNext.IsEnabled = (prb_Selected == true) && (lrb_Selected == true);
        }
    }
}
