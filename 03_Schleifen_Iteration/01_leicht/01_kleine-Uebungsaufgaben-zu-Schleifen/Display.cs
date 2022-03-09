using System;

namespace _01_kleine_Uebungsaufgaben_zu_Schleifen
{
    class Display
    {
        Calculation myCalculation = null;

        string mySeries1;
        string mySeries2;
        string mySeries3;
        string mySeries4;
        string mySeries5;
        string mySeries6;
        string mySeries7;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public string GetSeries1()
        {
            return mySeries1;
        }
        public string GetSeries2()
        {
            return mySeries2;
        }
        public string GetSeries3()
        {
            return mySeries3;
        }
        public string GetSeries4()
        {
            return mySeries4;
        }
        public string GetSeries5()
        {
            return mySeries5;
        }
        public string GetSeries6()
        {
            return mySeries6;
        }
        public string GetSeries7()
        {
            return mySeries7;
        }

        public void input()
        {
            Console.Clear();

            Console.Write("Enter input for the first series [a(n) = a(n-1) + 4]: ");
            mySeries1 = Console.ReadLine();

            Console.Write("Enter input for the second series [a(n) = a(n-1) - 1]: ");
            mySeries2 = Console.ReadLine();

            Console.Write("Enter input for the third series [a(n) = a(n-1) + 1000]: ");
            mySeries3 = Console.ReadLine();

            Console.Write("Enter input for the fourth series [a(n) = a(n-1) + 2]: ");
            mySeries4 = Console.ReadLine();

            Console.Write("Enter input for the fifth series [a(n) = a(n-1) + 1]: ");
            mySeries5 = Console.ReadLine();

            Console.Write("Enter input for the sixth series [a(n) = a(n-1) + 1 ] / [a(n+1) = a(n) + 9]: ");
            mySeries6 = Console.ReadLine();

            Console.Write("Enter input for the seventh series [a(n) = a(n-1) + 4 || except when it doesn't make any sense]: ");
            mySeries7 = Console.ReadLine();

            output();
        }

        public void output()
        {
            Console.WriteLine("===== Number series =====");
            myCalculation.doSeries1();
            Console.WriteLine("");
            myCalculation.doSeries2();
            Console.WriteLine("");
            myCalculation.doSeries3();
            Console.WriteLine("");
            myCalculation.doSeries4();
            Console.WriteLine("");
            myCalculation.doSeries5();
            Console.WriteLine("");
            myCalculation.doSeries6();
            Console.WriteLine("");
            myCalculation.doSeries7();
        }
    }
}