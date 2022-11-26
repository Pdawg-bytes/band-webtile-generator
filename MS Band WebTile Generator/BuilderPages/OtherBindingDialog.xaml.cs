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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MS_Band_WebTile_Generator.BuilderPages
{
    public enum TextResult
    {
        Set,
        Cancel
    }
    public sealed partial class OtherBindingDialog : ContentDialog
    {
        public TextResult Result { get; set; }
        public OtherBindingDialog()
        {
            this.InitializeComponent();
            SetButton.IsEnabled = false;
            BindingValue.Text = "";
        }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            BindingDialog.Hide();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            BindingDialog.Hide();
        }

        private void BindingValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataBuilder.OtherString = BindingValue.Text;
            if (BindingValue.Text != "")
            {
                SetButton.IsEnabled = true;
            }
            else
            {
                SetButton.IsEnabled = false;
            }
        }
    }
}
