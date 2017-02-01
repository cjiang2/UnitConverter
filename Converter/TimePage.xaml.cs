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
    public sealed partial class TimePage : Page
    {
        public TimePage()
        {
            this.InitializeComponent();

            //---------------Display Listbox item by BinDing And set convertingvalue---------------//

            List<Unit> DistanceUnit = new List<Unit>()       //Unit Class is at /Models/Unit.cs
            {
                new Unit() { UnitName = "Year", ChineseUnitName = "年", ConvertingValue = 0.0027378508 },
                new Unit() { UnitName = "Month", ChineseUnitName = "月", ConvertingValue = 0.0328542094 },
                new Unit() { UnitName = "Week", ChineseUnitName = "星期", ConvertingValue = 0.1428571389 },
                new Unit() { UnitName = "Day", ChineseUnitName = "日", ConvertingValue = 1 },
                new Unit() { UnitName = "Hour", ChineseUnitName = "时", ConvertingValue = 24 },
                new Unit() { UnitName = "Minute", ChineseUnitName = "分", ConvertingValue = 1440 },
                new Unit() { UnitName = "Second", ChineseUnitName = "秒", ConvertingValue = 86400 },
                new Unit() { UnitName = "MilliSecond", ChineseUnitName = "毫秒", ConvertingValue = 86400000 },
                new Unit() { UnitName = "MicroSecond", ChineseUnitName = "微秒", ConvertingValue = 86400000000 },
                new Unit() { UnitName = "MilliSecond", ChineseUnitName = "纳秒", ConvertingValue = 86400000000000 }
            };

            var languages = System.Globalization.CultureInfo.CurrentUICulture.Name;
            if (languages == "zh-CN")
            {
                ToConvertListBox.ItemsSource = DistanceUnit;
                ToConvertListBox.DisplayMemberPath = "ChineseUnitName";
                ConvertedListBox.ItemsSource = DistanceUnit;
                ConvertedListBox.DisplayMemberPath = "ChineseUnitName";
            }
            else
            {
                ToConvertListBox.ItemsSource = DistanceUnit;
                ToConvertListBox.DisplayMemberPath = "UnitName";
                ConvertedListBox.ItemsSource = DistanceUnit;
                ConvertedListBox.DisplayMemberPath = "UnitName";
            }
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
