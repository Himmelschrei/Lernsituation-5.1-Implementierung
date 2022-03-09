using System;
using System.IO;

namespace _02_Bevoelkerung
{
    class Calculation
    {
        Display myDisplay;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public void Check()
        {
            if (myDisplay.GetCountryA() < myDisplay.GetCountryB())
            {
                Console.WriteLine("Fehler: Land A muss größer als Land B sein.");
            } else if (myDisplay.GetCountryA() == myDisplay.GetCountryB())
            {
                Console.WriteLine("Die Bevölkerung ist schon gleich.");
            } else {
                Print();
            }
        }

        public void Print()
        {
            Console.WriteLine("Jahr \t\t Land A \t\t Land B");
            Console.WriteLine();

            int year = myDisplay.GetYear();
            double countryA = myDisplay.GetCountryA();
            double countryB = myDisplay.GetCountryB();

            double tempA, tempB;
            int count = 0;

            Console.WriteLine("{0} \t\t {1:F0} \t\t {2:F0}", year, countryA, countryB);

            while (countryA > countryB)
            {                
                tempA = countryA * myDisplay.GetCountryAChange();
                countryA -= tempA;
                tempB = countryB * myDisplay.GetCountryBChange();
                countryB += tempB;
                Console.WriteLine("{0} \t\t {1:F0} \t\t {2:F0}", ++year, countryA, countryB);
                ++count;
            }

            Console.WriteLine();
            Console.WriteLine("Nach {0} Jahren ist Land B größer als Land A", count);
        }
    }
}