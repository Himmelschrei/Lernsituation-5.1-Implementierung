using System;

namespace _02_Bevoelkerung
{
    class Display
    {
        Calculation myCalculation;

        int myCountryA, myCountryB, myYear;
        double myCountryAChange, myCountryBChange;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public int GetCountryA()
        {
            return myCountryA;
        }
        public int GetCountryB()
        {
            return myCountryB;
        }
        public int GetYear()
        {
            return myYear;
        }
        public double GetCountryAChange()
        {
            return myCountryAChange;
        }
        public double GetCountryBChange()
        {
            return myCountryBChange;
        }

        public void Input()
        {
            Console.Clear();

            Console.WriteLine("===== Bevölkerungsentwicklung =====");

            Console.WriteLine();

            Console.WriteLine("Wann ist Land B größer als Land A?");

            Console.WriteLine();

            Console.Write("Bevölkerung in Land A\t: ");
            myCountryA = int.Parse(Console.ReadLine());
            Console.Write("Veränderung in % \t: ");
            myCountryAChange = double.Parse(Console.ReadLine())/100;

            Console.WriteLine();

            Console.Write("Bevölkerung in Land B\t: ");
            myCountryB = int.Parse(Console.ReadLine());
            Console.Write("Veränderung in % \t: ");
            myCountryBChange = double.Parse(Console.ReadLine())/100;

            Console.WriteLine();

            Console.Write("Aktualles Jahr \t\t: ");
            myYear = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            myCalculation.Check();
        }
    }
}