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
                new Unit() { unitname = "mm", convertingvalue = 1000000 },
                new Unit() { unitname = "cm", convertingvalue = 10000 },
                new Unit() { unitname = "dm", convertingvalue = 100 },
                new Unit() { unitname = "m", convertingvalue = 1 },
                new Unit() { unitname = "hm", convertingvalue = 0.0001 },
                new Unit() { unitname = "km", convertingvalue = 0.000001 },
                new Unit() { unitname = "ft", convertingvalue = 10.7639104 },
                new Unit() { unitname = "in", convertingvalue = 1550.0031 }
            };//↑↑↑All Unit Have Square Symbol. I use a textblock at line 37,56 of AreaPage.xaml to display Square Symbol.

            toconvertlistbox.ItemsSource = AreaUnit;
            convertedlistbox.ItemsSource = AreaUnit;
        }


        //----------------Limit Textbox input:only can input number---------------//
        private void textboxkeydown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9) && (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9))
            {
                e.Handled = true;
            }
        }


        //---------------Start Convert When TextChanged, SelectionChanged-----------------//
        private void toconverttextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            displayresult();
        }


        private void toconvertlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayresult();
        }


        private void convertedlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayresult();
        }


        //---------------This can display result on ConvertedTextBlock---------------//
        public void displayresult()
        {
            double toconvertvalue;
            bool canornotconverttodouble = double.TryParse(toconverttextbox.Text, out toconvertvalue);
            bool istextboxnotempty = toconverttextbox.Text != null;
            bool istoconvertlistboxnotempty = toconvertlistbox.SelectedItem != null;
            bool isconvertedlistboxnotempty = convertedlistbox.SelectedItem != null;
            convertmethod convert = new convertmethod();
            if (canornotconverttodouble && istextboxnotempty && istoconvertlistboxnotempty && isconvertedlistboxnotempty)
                convertedvalue.Text = (convert.dimensionconvert(toconvertvalue, ((Unit)toconvertlistbox.SelectedItem).convertingvalue, ((Unit)convertedlistbox.SelectedItem).convertingvalue)).ToString();
            //"convert.distenceconvert" Method is at /Models/Unit.cs
        }

    }
}