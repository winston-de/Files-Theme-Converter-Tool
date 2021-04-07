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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Files_Theme_Importer_Tool
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = "Export failed";
            try
            {
                var paletteModel = new ControlPaletteModel();
                await paletteModel.InitializeData("ms-appx:///demodata.json");
                var item = new ControlPaletteViewModel(paletteModel);
                await item.LoadData();
                text = await item.ExportAsync();
            }
            catch (Exception ex)
            {
                text += $"\n{ex}";
            }

            ResultTextBlock.Text = text;
        }
    }
}
