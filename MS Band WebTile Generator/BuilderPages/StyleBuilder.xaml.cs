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
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;

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

        public static string ResourceType;
        public static string TileTitle;
        public static string DescriptionTile;
        public static string AuthorTile;
        public static string OrgTile;
        public static string ResourceURL;
        public static BitmapImage SampleImage;
        public static string PageType;
        public static string TileEmail;
        public static int RefreshInt;

        private void StyleBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.DataBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }

        private void StyleNext_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.CompleteBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            SerializeJSON();
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

        private void eBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TileEmail = eBox.Text;
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
                // I need to copy the file that is selected
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
                StorageFolder subFolder = await DownloadsFolder.CreateFolderAsync("icons", CreationCollisionOption.FailIfExists);
            }
            catch
            {
                ExceptionFileAccess.IsOpen = true;
            }
            TilePage1Image.Source = SampleImage;
        }

        private void RefreshSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            RefreshInt = Convert.ToInt32(e.NewValue);
        }

        private async void SerializeJSON()
        {
            var obj = new
            {
                manifestVersion = 1,
                name = TileTitle,
                description = DescriptionTile,
                version = 1,
                versionString = "1",
                author = AuthorTile,
                organization = OrgTile,
                contactEmail = TileEmail,
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
                    addIconsHere = "If you want extra icons in your webtile, add them here. If not, delete this attribute.",
                },
                refreshIntervalMinutes = RefreshInt,
                resources = new dynamic[] {
                new {
                    url = ResourceURL,
                    style = ResourceType,
                    content = new
                    {
                        contentitem1 = "Add any variables that you need here",
                        contentitem2 = "Add any variables that you need here",
                        contentitem3 = "You can pull any of the data attributes from a selected data source!"
                    },
                  },
                },
                pages = new dynamic[]
                {
                new {
                    layout = PageType,
                    condition = "true",
                    textBindings = new []
                    {
                        new
                        {
                            elementId = "Example Element",
                            value = "Each element serves a different purpose, you'll see why soon (in the post build docs)",
                        },
                        new
                        {
                            elementId = "Example Element",
                            value = "Variables defined in your resources are called like this: {{SomeDefinedVariable}}",
                        },
                        new
                        {
                            elementId = "Example Element",
                            value = "Variables defined in your resources are called like this: {{SomeDefinedVariable}}",
                        },
                    }
                },       
               },
            };

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            StorageFile manifestFile = await DownloadsFolder.CreateFileAsync("manifest.json");
            await FileIO.WriteTextAsync(manifestFile, json);
        }
    }
}
