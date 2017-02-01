using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class Unit
    {
        public string UnitName { get; set; }
        public string ChineseUnitName { get; set; }
        public double ConvertingValue { get; set; }
        //ConvertingValue is a double that multiply one unit equal to one meters.
        //For example:
        //1 centimeter * 100 = 1 meter
        //"100" is the ConvertingValue.
        //1 kilometer * 0.001 = 1 meter
        //"0.001"is the ConvertingValue.               
    }

   
    public class ConvertMethod
    {
        public String Convert(string ToConvertTextBox, object ToConvertListBoxSelected, object ConvertedListBoxSelected )
        {
            double ToConvertValue;
            string ConvertedValue = "0";
            bool CanOrNotConvertToDouble = double.TryParse(ToConvertTextBox, out ToConvertValue);
            bool IsTextBoxNotEmpty = ToConvertTextBox != null;
            bool IsToConvertListBoxNotEmpty = ToConvertListBoxSelected != null;
            bool IsConvertedListBoxNotEmpty = ConvertedListBoxSelected != null;
            if (CanOrNotConvertToDouble && IsTextBoxNotEmpty && IsToConvertListBoxNotEmpty && IsConvertedListBoxNotEmpty)
                //This Method Reference github.com/gncvt/UnitConverter
                ConvertedValue = (ToConvertValue / ((Unit)ToConvertListBoxSelected).ConvertingValue * ((Unit)ConvertedListBoxSelected).ConvertingValue).ToString();
            return ConvertedValue;


        }
    }
}
