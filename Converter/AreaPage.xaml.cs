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
        private void ToConvertTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9) && (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9))
            {
                e.Handled = true;
            }
        }


        //---------------Start Convert When TextChanged, SelectionChanged-----------------//
        private void ToConvertTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayResult();
        }


        private void ToConvertListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayResult();
        }


        private void ConvertedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayResult();
        }


        //---------------This can display result on ConvertedTextBlock---------------//
        public void DisplayResult()
        {
            double ToConvertValue;
            bool CanOrNotConvertToDouble = double.TryParse(ToConvertTextBox.Text, out ToConvertValue);
            bool IsTextBoxNotEmpty = ToConvertTextBox.Text != null;
            bool IsToConvertListBoxNotEmpty = ToConvertListBox.SelectedItem != null;
            bool IsConvertedListBoxNotEmpty = ConvertedListBox.SelectedItem != null;
            ConvertMethod convert = new ConvertMethod();
            if (CanOrNotConvertToDouble && IsTextBoxNotEmpty && IsToConvertListBoxNotEmpty && IsConvertedListBoxNotEmpty)
                ConvertedValue.Text = (convert.BasicUnitConvert(ToConvertValue, ((Unit)ToConvertListBox.SelectedItem).ConvertingValue, ((Unit)ConvertedListBox.SelectedItem).ConvertingValue)).ToString();
            //"convert.distenceconvert" Method is at /Models/Unit.cs
        }
    }
}