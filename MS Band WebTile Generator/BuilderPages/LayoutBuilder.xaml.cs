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
                    StyleBuilder.E3 = "DELETE THIS ELEMENT";
                    StyleBuilder.E4 = "DELETE THIS ELEMENT";
                    StyleBuilder.E5 = "DELETE THIS ELEMENT";
                    StyleBuilder.E6 = "DELETE THIS ELEMENT";
                    break;
                case "MSBand_NoScrollingText":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/NoScrollingTextImage.png"));
                    StyleBuilder.E1 = "1";
                    StyleBuilder.E2 = "2";
                    StyleBuilder.E3 = "3";
                    StyleBuilder.E4 = "DELETE THIS ELEMENT";
                    StyleBuilder.E5 = "DELETE THIS ELEMENT";
                    StyleBuilder.E6 = "DELETE THIS ELEMENT";
                    break;
                case "MSBand_SingleMetric":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricImage.png"));
                    StyleBuilder.E1 = "1";
                    StyleBuilder.E2 = "2";
                    StyleBuilder.E3 = "DELETE THIS ELEMENT";
                    StyleBuilder.E4 = "DELETE THIS ELEMENT";
                    StyleBuilder.E5 = "DELETE THIS ELEMENT";
                    StyleBuilder.E6 = "DELETE THIS ELEMENT";
                    break;
                case "MSBand_SingleMetricWithIcon":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricWithIconImage.png"));
                    StyleBuilder.E1 = "11";
                    StyleBuilder.E2 = "12";
                    StyleBuilder.E3 = "21";
                    StyleBuilder.E4 = "DELETE THIS ELEMENT";
                    StyleBuilder.E5 = "DELETE THIS ELEMENT";
                    StyleBuilder.E6 = "DELETE THIS ELEMENT";
                    break;
                case "MSBand_MetricsWithIcons":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/MetricsWithIconsImage.png"));
                    StyleBuilder.E1 = "11";
                    StyleBuilder.E2 = "12";
                    StyleBuilder.E3 = "21";
                    StyleBuilder.E4 = "22";
                    StyleBuilder.E5 = "31";
                    StyleBuilder.E6 = "32";
                    break;
                case "MSBand_SingleMetricWithSecondary":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricWithSecondaryImage.png"));
                    StyleBuilder.E1 = "11";
                    StyleBuilder.E2 = "12";
                    StyleBuilder.E3 = "21";
                    StyleBuilder.E4 = "22";
                    StyleBuilder.E5 = "DELETE THIS ELEMENT";
                    StyleBuilder.E6 = "DELETE THIS ELEMENT";
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
                MSBand_SingleMetric.IsEnabled = true;
                MSBand_MetricsWithIcons.IsEnabled = true;
                MSBand_SingleMetricWithIcon.IsEnabled = true;
                MSBand_SingleMetricWithSecondary.IsEnabled = true;
            }
            else if (lrb.Name == "Simple2")
            {
                StyleBuilder.ResourceType = "Simple";
                MSBand_SingleMetric.IsEnabled = true;
                MSBand_MetricsWithIcons.IsEnabled = true;
                MSBand_SingleMetricWithIcon.IsEnabled = true;
                MSBand_SingleMetricWithSecondary.IsEnabled = true;
            }
            else
            {
                MSBand_SingleMetric.IsEnabled = false;
                MSBand_MetricsWithIcons.IsEnabled = false;
                MSBand_SingleMetricWithIcon.IsEnabled = false;
                MSBand_SingleMetricWithSecondary.IsEnabled = false;
                StyleBuilder.ResourceType = "Feed";
            }
            LayoutNext.IsEnabled = (prb_Selected == true) && (lrb_Selected == true);
        }
    }
}
