using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using System.ServiceModel;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using System.ServiceModel.Syndication;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MS_Band_WebTile_Generator.BuilderPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataBuilder : Page
    {
        public DataBuilder()
        {
            this.InitializeComponent();
        }

        private void DataBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.LayoutBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }

        private void DataNext_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.StyleBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        public static string rsslink;
        private void DataFeedBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            rsslink = DataFeedBox.Text;
            ParseRSS();
        }

        public void ParseRSS()
        {
            // Set defualt
            SyndicationFeed feed = null;

            // Try and read RSS/ATOM Feed
            try
            {
                using (var reader = XmlReader.Create(rsslink))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            // Handle bad resource
            catch { 
                feed = null;
                DataStatus.Text = "Data feed unavailable, please try again later.";
                DataStatus.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (feed != null)
            {
                // Push parsed data
                foreach (var element in feed.Items.Take(1))
                {
                    DataStatus.Text = "Data feed found.";
                    DataStatus.Foreground = new SolidColorBrush(Colors.LightGreen);
                    RSSTitle.Text = ($"Title: {element.Title.Text}");
                    RSSDesc.Text = ($"Description: {element.Summary.Text}");
                    RSSDate.Text = ($"Date and Time Published: {element.PublishDate}");
                }
            }
        }
    }
}
