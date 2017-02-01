using Converter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class DistPage : Page
    {
        public DistPage()
        {
            this.InitializeComponent();
        
            
       //---------------Display Listbox item by BinDing And set convertingvalue---------------//
            List<Unit> DistanceUnit = new List<Unit>()       //Unit Class is at /Models/Unit.cs
            {
                new Unit() { UnitName = "mm", ConvertingValue = 1000 },
                new Unit() { UnitName = "cm", ConvertingValue = 100 },
                new Unit() { UnitName = "dm", ConvertingValue = 10 },
                new Unit() { UnitName = "m", ConvertingValue = 1 },
                new Unit() { UnitName = "km", ConvertingValue = 0.001 },
                new Unit() { UnitName = "Inch", ConvertingValue = 39.3700787 },
                new Unit() { UnitName = "Foot", ConvertingValue = 3.2808399 },
                new Unit() { UnitName = "Mile", ConvertingValue = 0.00062 }
            };
            ToConvertListBox.ItemsSource = DistanceUnit;
            ToConvertListBox.DisplayMemberPath = "UnitName";
            ConvertedListBox.ItemsSource = DistanceUnit;
            ConvertedListBox.DisplayMemberPath = "UnitName";
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
