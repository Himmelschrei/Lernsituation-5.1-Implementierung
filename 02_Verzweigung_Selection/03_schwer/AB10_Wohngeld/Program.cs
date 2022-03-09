using System;

namespace AB10_Wohngeld
{
    class Program
    {
        static void Main(string[] args)
        {
            double verdienst;
            double grenze;
            int kinder;
            int verheiratet;

            Console.Clear();

            Console.Write("Geben Sie Ihren Verdienst ein. ");
            verdienst = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Sind Sie verheiratet? (ja = 1/nein = 0) ");
            verheiratet = Convert.ToInt16(Console.ReadLine());
            if (verheiratet != 1 & verheiratet != 0) {
                Console.WriteLine("Bitte geben Sie eine gültige Eingabe.");
                return;
            }
            Console.WriteLine("Wie viele Kinder haben Sie? ");
            kinder = Convert.ToInt16(Console.ReadLine());
            if (kinder <= 0) {
                Console.WriteLine("Bitte schreiben Sie eine gültige Zahlt.");
                return;
            }

            if (verheiratet == 1)
                {grenze =+ 800;}
            else 
                {grenze =+ 500;}

            if (kinder == 1)
                {grenze =+ 200;}
            else if (kinder == 2)
                {grenze =+ 400;}
            else if (kinder == 3)
                {grenze =+ 600;}
            else
                {grenze =+ 800;}

            if (verdienst < grenze) {
                Console.WriteLine("Sie bekommen Wohngeld bewilligt in Höhe von ");
                Console.WriteLine(grenze - verdienst);
            } else {
                Console.WriteLine("Sie sind nicht wohngeldberechtigt!");
            }
            Console.ReadKey();
        }
    }
}
