using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Zahlensysteme
{
    class Calculation
    {
        Form1 myForm1 = null;

        public Calculation(Form1 form1)
        {
            myForm1 = form1;
        }

        public string calcToBinary(string s)
        {
            int decimalNumber = Convert.ToInt32(s);
            int rest;
            string result = string.Empty;

            while (decimalNumber > 0)
            {
                rest = decimalNumber % 2;
                decimalNumber /= 2;
                result = rest.ToString() + result;
            }

            return result;
        }

        public string calcToDecimal(string s)
        {
            int binaryNumber = Convert.ToInt32(s);
            int decimalValue = 0;
            int base1 = 1;

            while (binaryNumber > 0)
            {
                int rest = binaryNumber % 10;
                binaryNumber = binaryNumber / 10;
                decimalValue += rest * base1;
                base1 = base1 * 2;
            }

            string decimalString = Convert.ToString(decimalValue);
            return decimalString;
        }

        public bool checkInt(string s)
        {
            return Regex.IsMatch(s, @"^\d+$");
        }
    }
}
