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
        }

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
            RadioButton prb = sender as RadioButton;
            StyleBuilder.PageType = prb.Name;
            switch (prb.Name)
            {
                case "MSBand_ScrollingText":
                default:
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/ScrollingTextImage.png"));
                    break;
                case "MSBand_NoScrollingText":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/NoScrollingTextImage.png"));
                    break;
                case "MSBand_SingleMetric":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricImage.png"));
                    break;
                case "MSBand_SingleMetricWithIcon":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricWithIconImage.png"));
                    break;
                case "MSBand_MetricsWithIcons":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/MetricsWithIconsImage.png"));
                    break;
                case "MSBand_SingleMetricWithSecondary":
                    StyleBuilder.SampleImage = new BitmapImage(new Uri("ms-appx:///Assets/ContentLayoutAssets/SingleMetricWithSecondaryImage.png"));
                    break;
            }
        }

        private void HandleResourceTypeCheck(object sender, RoutedEventArgs e)
        {
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
        }
    }
}
