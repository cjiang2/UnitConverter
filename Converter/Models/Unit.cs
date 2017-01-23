using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class Unit
    {
        public string unitname { get; set; }
        public double convertingvalue { get; set; }
        //ConvertingValue is a double that multiply one unit equal to one meters.
        //For example:
        //1 centimeter * 100 = 1 meter
        //"100" is the ConvertingValue.
        //1 kilometer * 0.001 = 1 meter
        //"0.001"is the ConvertingValue.               
    }

    public class convertmethod
    {
        public double dimensionconvert(double toconvert, double toconvertUnitConvertingValue, double convertedUnitConvertingValue )
        {
            double result = (toconvert / toconvertUnitConvertingValue * convertedUnitConvertingValue);
            return result;
        }
    }
}
