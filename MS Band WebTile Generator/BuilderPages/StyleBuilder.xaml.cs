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
using System.Runtime.CompilerServices;
using System.Text;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Shapes;

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
            RefreshInt = 15;
            RefreshSlider.Value = 15;
            StyleNext.IsEnabled = false;
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
        public static string E1;
        public static string E2;
        public static string E3;
        public static string I1;
        public static string I2;
        public static string I3;
        public static int[] removeLines;

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
            StyleNext.IsEnabled = (TitleTextBox.Text != "") && (DescriptionBox.Text != "") && (AuthorBox.Text != "") && (OrgBox.Text != "") && (eBox.Text != "");
        }

        private void DescriptionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DescriptionTile = DescriptionBox.Text;
            StyleNext.IsEnabled = (TitleTextBox.Text != "") && (DescriptionBox.Text != "") && (AuthorBox.Text != "") && (OrgBox.Text != "") && (eBox.Text != "");
        }

        private void AuthorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AuthorTile = AuthorBox.Text;
            StyleNext.IsEnabled = (TitleTextBox.Text != "") && (DescriptionBox.Text != "") && (AuthorBox.Text != "") && (OrgBox.Text != "") && (eBox.Text != "");
        }

        private void OrgBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrgTile = OrgBox.Text;
            StyleNext.IsEnabled = (TitleTextBox.Text != "") && (DescriptionBox.Text != "") && (AuthorBox.Text != "") && (OrgBox.Text != "") && (eBox.Text != "");
        }

        private void eBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TileEmail = eBox.Text;
            StyleNext.IsEnabled = (TitleTextBox.Text != "") && (DescriptionBox.Text != "") && (AuthorBox.Text != "") && (OrgBox.Text != "") && (eBox.Text != "");
        }

        int stradd = 0;
        public static string filename;
        private async void Browse46_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder subFolder = await DownloadsFolder.CreateFolderAsync("icons", CreationCollisionOption.GenerateUniqueName);
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".png");
            IReadOnlyList<StorageFile> files = await openPicker.PickMultipleFilesAsync();
            if (files.Count > 0)
            {
                foreach (StorageFile file in files.Take(2))
                {
                    stradd++;
                    string final = "str" + stradd;
                    switch (stradd)
                    {
                        case 1:
                            filename = "tileIcon.png";
                            break;
                        case 2:
                            filename = "badgeIcon.png";
                            break;
                    }
                    try
                    {
                        StorageFile copiedFile = await file.CopyAsync(subFolder);
                        await copiedFile.RenameAsync(filename);
                    }
                    catch
                    {
                        ExceptionFileAccess.IsOpen = true;
                    }
                }
            }
            else
            {
                ExceptionFileCreate.IsOpen = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
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
                            rsstitle = "title", // These are here by default, they aren't needed. Can be removed if wanted.
                            rssdesc = "description", // These are here by default, they aren't needed. Can be removed if wanted.
                            rsspubdate = "pubDate", // These are here by default, they aren't needed. Can be removed if wanted.
                        },
                    },
                },
                pages = new dynamic[]
                {
                new {
                    layout = PageType,
                    condition = "true",
                    iconBindings = new dynamic[]
                    {
                        new
                        {
                            elementId = I1,
                            conditions = new []
                            {
                                new
                                {
                                    condition = "true",
                                    icon = "Type the icons name here"
                                }
                            },
                        },
                        new
                        {
                            elementId = I2,
                            conditions = new []
                            {
                                new
                                {
                                    condition = "true",
                                    icon = "Type the icons name here"
                                }
                            },
                        },
                        new
                        {
                            elementId = I3,
                            conditions = new []
                            {
                                new
                                {
                                    condition = "true",
                                    icon = "Type the icons name here"
                                }
                            },
                        },
                    },
                    textBindings = new []
                    {
                        new
                        {
                            elementId = E1,
                            value = "You may also set whatever text you want to be here.",
                        },
                        new
                        {
                            elementId = E2,
                            value = "Variables defined in your resources are called like this: {{SomeDefinedVariable}}",
                        },
                        new
                        {
                            elementId = E3,
                            value = "Variables defined in your resources are called like this: {{SomeDefinedVariable}}",
                        }
                    }
                },       
               },
            };

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            try
            {
                StorageFile manifestFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("manifest.json", CreationCollisionOption.GenerateUniqueName);
                await FileIO.WriteTextAsync(manifestFile, json);
                string line = null;
                int arrInc = 0;
                int arrPull = removeLines[arrInc];
                using (StreamReader reader = new StreamReader("C:\\input"))
                {
                    using (StreamWriter writer = new StreamWriter("C:\\output"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            line_number++;

                            if (line_number == arrPull)
                                continue;

                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch
            {
                ExceptionFileAccess.IsOpen = true;
            }
        }
    }
}
