using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;
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
using Newtonsoft.Json;
using System.Xml.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MS_Band_WebTile_Generator.BuilderPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StyleBuilder : Page
    {
        public StyleBuilder()
        {
            this.InitializeComponent();
        }

        public static string TileTitle;
        public static string DescriptionTile;
        public static string AuthorTile;
        public static string OrgTile;
        public static int RefreshInt;

        private void StyleBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.DataBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }

        private void StyleNext_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.CompleteBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            var obj = new
            {
                manifestVersion = 1,
                name = "SEA & JFK weather",
                description = "This tile shows the current weather at SEA and JFK",
                version = 1,
                versionString = "1",
                author = "Microsoft Band Team",
                organization = "MS Health",
                contactEmail = "healthms@microsoft.com",
                tileIcon = new Dictionary<int, string>
                {
                    [46] = "icons/tileIcon.png"
                },
                badgeIcon = new Dictionary<int, string>
                {
                    [24] = "icons/badgeIcon.png",
                },
                icons = new
                {
                    SEAIcon = "icons/SEA.png",
                    JFKIcon = "icons/JFK.png",
                },
                refreshIntervalMinutes = 30,
                resources = new dynamic[] {
                new {
                    url = "http://services.faa.gov/airport/status/SEA?format=json",
                    style = "Simple",
                    content = new
                    {
                        SEAWeather = "weather.weather",
                        SEAvisibility = "weather.visibility"
                    },
                },
               new {
                    url = "http://services.faa.gov/airport/status/JFK?format=json",
                    style = "Simple",
                    content = new
                    {
                        JFKWeather = "weather.weather",
                        JFKvisibility = "weather.visibility"
                    },
                },
            },
                pages = new dynamic[]
    {
                new {
                    layout = "MSBand_NoScrollingText",
                    condition = "true",
                    textBindings = new []
                    {
                        new
                        {
                            elementId = "1",
                            value = "Airport Weather",
                        },
                        new
                        {
                            elementId = "2",
                            value = "SEA: {{SEAweather}}",
                        },
                        new
                        {
                            elementId = "3",
                            value = "JFK: {{JFKweather}}",
                        },
                    }
                },
                new {
                    layout = "MSBand_SingleMetricWithSecondary",
                    condition = "true",
                    iconBindings = new []
                    {
                        new
                        {
                            elementId = "21",
                            conditions = new[]
                            {
                                new
                                {
                                    condition = "true",
                                    icon = "SEAIcon",
                                },
                            },
                        },
                    },
                    textBindings = new []
                    {
                        new
                        {
                            elementId = "11",
                            value = "SEA",
                        },
                        new
                        {
                            elementId = "12",
                            value = "Visibility",
                        },
                        new
                        {
                            elementId = "22",
                            value = "{{SEAvisibility}}",
                        },
                    },
                },
                  new {
                    layout = "MSBand_SingleMetricWithSecondary",
                    condition = "true",
                    iconBindings = new []
                    {
                        new
                        {
                            elementId = "21",
                            conditions = new[]
                            {
                                new
                                {
                                    condition = "true",
                                    icon = "JFKIcon",
                                },
                            },
                        },
                    },
                    textBindings = new []
                    {
                        new
                        {
                            elementId = "11",
                            value = "JFK",
                        },
                        new
                        {
                            elementId = "12",
                            value = "Visibility",
                        },
                        new
                        {
                            elementId = "22",
                            value = "{{JFKvisibility}}",
                        },
                    },
                  },
                },
            };

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TileTitle = TitleTextBox.Text;
        }

        private void DescriptionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DescriptionTile = DescriptionBox.Text;
        }

        private void AuthorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AuthorTile = AuthorBox.Text;
        }

        private void OrgBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrgTile = OrgBox.Text;
        }

        private async void Browse46_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Fix later
            }
            else
            {
                // Do nothing
            }
        }

        private async void Browse24_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
            }
            else
            {
                // Do nothing
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageFolder newFolder = await DownloadsFolder.CreateFolderAsync("WebTile", CreationCollisionOption.FailIfExists);
                StorageFolder subFolder = await DownloadsFolder.CreateFolderAsync("WebTile\\icons", CreationCollisionOption.FailIfExists);
            }
            catch
            {
                ExceptionFileAccess.IsOpen = true;
            }
        }

        private void RefreshSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            RefreshInt = Convert.ToInt32(e.NewValue);
        }
    }
}
