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

        private void StyleBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.DataBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }

        private void StyleNext_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MS_Band_WebTile_Generator.BuilderPages.CompleteBuilder), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
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
                // Application now has read/write access to the picked file
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
            StorageFolder newFolder = await DownloadsFolder.CreateFolderAsync("WebTile");
        }
    }
}
