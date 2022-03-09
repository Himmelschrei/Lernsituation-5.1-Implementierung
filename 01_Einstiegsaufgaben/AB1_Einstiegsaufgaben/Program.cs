using System;

namespace AB1_Einstiegsaufgaben
{
    class Program
    {
        public static void Main(string[] args)
        {
            int zahl1, zahl2;

            Console.Write("Bitte die erste Zahl eingeben: ");
            zahl1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Bitte die zweite Zahl eingeben: ");
            zahl2 = Convert.ToInt32(Console.ReadLine());

            //Pointers to the different calculations
            SimpleMath point = new SimpleMath();
            int summe = point.Summe(zahl1, zahl2);
            int differenz = point.Differenz(zahl1, zahl2);
            int[] quotient = point.Quotient(zahl1, zahl2);
            int produkt = point.Produkt(zahl1, zahl2);
            
            Console.WriteLine("Die Summe der zwei Zahlen lautet: {0} ", summe);
            Console.WriteLine("Die Differenz der zwei Zahlen lautet: {0} ", differenz);
            Console.WriteLine("Der Quotient der zwei Zahlen lautet: {0}. Der Rest lautet: {1} ", quotient[0], quotient[1]);
            Console.WriteLine("Das Produkt der zwei Zahlen lautet: {0} ", produkt);
        }
        
    }

    //Class where all calculations are made
    class SimpleMath
    {
        public int Summe(int x, int y)
        {
            return x + y;
        }

        public int Differenz(int x, int y)
        {
            return x - y;
        }

        //An array is used in order to return two values
       public int[] Quotient(int x, int y)
        {
            int q = x / y;
            int r = x % y;
            int[] arr = new int[] {q, r};
            return arr;
        }

        public int Produkt(int x, int y)
        {
            return x * y;
        }
    }
}
