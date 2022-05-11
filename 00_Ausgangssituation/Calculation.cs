using System;
using System.IO;
using System.Globalization;

namespace _00_Ausgangssituation
{
    /// <summary>
    /// Here are all functions without user's input.
    /// Makes use of CultureInfo in case the user has '.' as decimal separator.
    /// </summary>
    /// <remarks>
    /// Class variables:
    /// <para>string myFilename</para>
    /// </remarks>
    class Calculation
    {
        Display myDisplay;

        CultureInfo culture = new CultureInfo("es-ES");
        NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

        /// <summary>
        /// Pointer to the Display class.
        /// </summary>
        /// <param name="display"></param>
        public Calculation(Display display)
        {
            myDisplay = display;
        }

        string myFilename = @"C:\Users\Pin\OneDrive\Ausbildung\Aufgaben\LF5\Lernsituation-5.1-Implementierung\00_Ausgangssituation\temperaturen.txt";

        /// <summary>
        /// Gets the date given by the user and checks whether it's found on the document. 
        /// </summary>
        /// <param name="date">Date given by user to search.</param>
        /// <returns>True if the date given was found on the document. False if otherwise.</returns>
        public bool CheckDate(string date)
        {

            StreamReader sr = new StreamReader(myFilename);

            string fileline;
            string data;

            while (!sr.EndOfStream)
            {
                fileline = sr.ReadLine();
                data = GetElement(fileline, 0);
                if (data == date)
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// This method returns a single specified element of the provided row.
        /// </summary>
        /// <param name="fileline">The row in which to search.</param>
        /// <param name="index">The index of the searched element, beginning with index 0.</param>
        /// <returns>The element on the specified position.</returns>
        public static string GetElement(string fileline, int index)
        {
            int currentIndex = 0;
            int elementPosition = 0;
            int semicolonPosition = fileline.IndexOf(';');

            string result;

            while (currentIndex < index)
            {
                currentIndex++;
                elementPosition = semicolonPosition + 1;
                semicolonPosition = fileline.IndexOf(';', elementPosition);
            }

            if (semicolonPosition == -1)
            {
                result = fileline.Substring(elementPosition);
            } else {
                result = fileline.Substring(elementPosition, semicolonPosition - elementPosition);
            }

            return result;
        }
        
        /// <summary>
        /// Gets the date to search on the document and checks its maximal temperature.
        /// </summary>
        /// <param name="date">Date given by the user.</param>
        /// <returns>Decimal value of maximal temperature for given day.</returns>
        public decimal GetMaxDay(string date)
        {
            StreamReader sr = new StreamReader(myFilename);

            decimal maxTemp = 0;
            decimal temp = 0;

            string fileline;
            string data;
            string tempString;

            while (!sr.EndOfStream)
            {
                fileline = sr.ReadLine();
                data = GetElement(fileline, 0);
                tempString = GetElement(fileline, 3);
                temp = Decimal.Parse(GetElement(fileline, 3), style, culture);
                if (date == data && maxTemp < temp) {
                    maxTemp = temp;
                }    
            }

            sr.Close();

            return maxTemp;
        }

        /// <summary>
        /// Gets the date to search on the document and checks its mean temperature. 
        /// </summary>
        /// <param name="date">Date given by the user.</param>
        /// <returns>Decimal value of mean temperature for the given day.</returns>
        public decimal GetMeanDay(string date)
        {
            StreamReader sr = new StreamReader(myFilename);
            decimal temp = 0;
            decimal meanDayTemp;

            int counter = 0;

            string fileline;
            string data;
            string tempString;

            while (!sr.EndOfStream)
            {
                fileline = sr.ReadLine();
                data = GetElement(fileline, 0);
                if(data == date)
                {    
                    tempString = GetElement(fileline, 3);
                    temp += Decimal.Parse(GetElement(fileline, 3), style, culture);
                    counter++;
                }
            }

            meanDayTemp = temp / counter;

            sr.Close();

            return meanDayTemp;
        }

        /// <summary>
        /// Goes through the whole document and calculates the mean temperature from all listed on it.
        /// </summary>
        /// <returns>Decimal value of mean temperature of the whole document.</returns>
        public decimal GetMeanWhole()
        {
            StreamReader sr = new StreamReader(myFilename);
            decimal temp = 0;
            decimal meanWholeTemp;

            int counter = 0;

            string fileline;
            string tempString;

            while (!sr.EndOfStream)
            {
                fileline = sr.ReadLine();
                tempString = GetElement(fileline, 3);
                temp += Decimal.Parse(GetElement(fileline, 3), style, culture);
                counter++;
            }

            meanWholeTemp = temp / counter;

            sr.Close();

            return meanWholeTemp;
        }
    }
}