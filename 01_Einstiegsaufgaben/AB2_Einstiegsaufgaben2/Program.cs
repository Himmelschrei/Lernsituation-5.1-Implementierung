using System;

namespace AB1_Einstiegsaufgaben
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.Write("Bitte zwischen Aufgabe (5) und Aufgabe (6) wählen: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "5":
                    aufgabe5(0,0);
                    break;
                case "6":
                    aufgabe6(0,0);
                    break;
                default:
                    Console.WriteLine("Ungültiger Auswahl");
                    break;
            }
        }

        private static void aufgabe5(double zahl1, double zahl2)
        {
            Console.Write("Bitte die erste Zahl eingeben: ");
            zahl1 = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Bitte die zweite Zahl eingeben: ");
            zahl2 = Convert.ToDouble(Console.ReadLine());

            SimpleMath point = new SimpleMath();
            double quotient = point.Quotient(zahl1, zahl2);
            double produkt = point.Produkt(zahl1, zahl2);

            Console.WriteLine("{0} * {1} = {2:F2} ", zahl1, zahl2, produkt);
            Console.WriteLine("{0} / {1} = {2:F2} ", zahl1, zahl2, quotient);
        }
        
        private static void aufgabe6(int zahl1, int zahl2)
        {
            Console.Write("Geben Sie den Dividenden ein: ");
            zahl1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Geben Sie den Divisor ein (keine 0): ");
            zahl2 = Convert.ToInt32(Console.ReadLine());
            if (zahl2 == 0){
                Console.WriteLine("Keine 0 erlaubt!");
            } else {
                SimpleMath point = new SimpleMath();
                int[] division = point.Division(zahl1, zahl2);

                Console.WriteLine("Ergebnis: {0} ", division[0]);
                Console.WriteLine("Der Rest der Division ist {0}.", division[1]);
            }           
        }
        
    }

    //Class where all calculations are made
    class SimpleMath
    {
       public double Quotient(double x, double y)
        {
            return x / y;
        }

        public double Produkt(double x, double y)
        {
            return x * y;
        }
        public int[] Division(int x, int y)
        {
            int ergebnis = x / y;
            int rest = x % y;
            int[] arr = {ergebnis, rest};
            return arr;
        }
    }
}
