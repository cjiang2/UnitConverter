using Converter.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AreaPage : Page
    {
        public AreaPage()
        {
            this.InitializeComponent();
            //---------------Display Listbox item by BinDing And set convertingvalue---------------//
            List<Unit> AreaUnit = new List<Unit>()       //Unit Class is at /Models/Unit.cs
            {
                new Unit() { UnitName = "mm", ConvertingValue = 1000000 },
                new Unit() { UnitName = "cm", ConvertingValue = 10000 },
                new Unit() { UnitName = "dm", ConvertingValue = 100 },
                new Unit() { UnitName = "m", ConvertingValue = 1 },
                new Unit() { UnitName = "hm", ConvertingValue = 0.0001 },
                new Unit() { UnitName = "km", ConvertingValue = 0.000001 },
                new Unit() { UnitName = "ft", ConvertingValue = 10.7639104 },
                new Unit() { UnitName = "in", ConvertingValue = 1550.0031 }
            };//↑↑↑All Unit Have Square Symbol. I use a textblock at line 37,56 of AreaPage.xaml to display Square Symbol.

            ToConvertListBox.ItemsSource = AreaUnit;
            ConvertedListBox.ItemsSource = AreaUnit;
        }


        //----------------Limit Textbox input:only can input number---------------//
        // reference: http://stackoverflow.com/questions/19761487/how-to-make-a-textbox-accept-only-numbers-and-just-one-decimal-point-in-windows
        private void ToConvertTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // only allow 0-9 and "."
            e.Handled = !((e.Key.GetHashCode() >= 48 && e.Key.GetHashCode() <= 57));

            // check if "." is already there in box.
            if (e.Key.GetHashCode() == 190)
                e.Handled = (sender as TextBox).Text.Contains(".");
        }


        //------------Start Convert And Display Result When TextChanged, SelectionChanged--------------//
        private void ToConvertTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConvertMethod convert = new ConvertMethod();
            ConvertedValue.Text = convert.Convert(ToConvertTextBox.Text, ToConvertListBox.SelectedItem, ConvertedListBox.SelectedItem);
        }


        private void ToConvertListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertMethod convert = new ConvertMethod();
            ConvertedValue.Text = convert.Convert(ToConvertTextBox.Text, ToConvertListBox.SelectedItem, ConvertedListBox.SelectedItem);
        }


        private void ConvertedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertMethod convert = new ConvertMethod();
            ConvertedValue.Text = convert.Convert(ToConvertTextBox.Text, ToConvertListBox.SelectedItem, ConvertedListBox.SelectedItem);
        }
    }
}