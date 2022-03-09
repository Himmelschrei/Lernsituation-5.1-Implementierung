using System;
using System.Collections.Generic;

namespace _02_Rechnung_Fakultaet
{
    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public void fakultaet(int x)
        {
            Console.WriteLine("");
            Console.Write("Berechnung: {0} ", x);
            ulong fak = Convert.ToUInt64(x);
            ulong s = Convert.ToUInt64(x);

            while (s > 1)
            {
                Console.Write("* {0} ", --s);
                fak *= s;
            }

            Console.WriteLine("\n");
            Console.WriteLine("Die Fakultät von {0} lautet {1}.", x, fak);
        }

        public double mwstCalc(double x)
        {
            double mwst = x * 0.19;
            return mwst;
        }

        public void rechnung()
        {
            double nettoSum = save();
            Console.WriteLine("Grsamtpreis netto \t\t {0:F2} Euro", nettoSum);
            
            double mwst = mwstCalc(nettoSum);
            Console.WriteLine("+ 19 % Mehrwertsteuer \t\t {0:F2} Euro", mwst);

            Console.WriteLine("-----------------------------------------");
            
            double bruttoSum = nettoSum + mwst;
            Console.WriteLine("Gesamtpreis brutto \t\t {0:F2} Euro", bruttoSum);
        }

        public double save()
        {
            List<int> listAmount = new List<int>();
            List<double> listPrice = new List<double>();

            double amount;
            double singlePrice;
            double nettoPrice;
            double nettoSum = 0;

            do
            {
                Console.Write("Bitte Artikelmenge eingeben (0 = Ende): ");
                amount = Convert.ToDouble(Console.ReadLine());
                if (amount == 0) break;

                Console.Write("Bitte Einzelpreis eingeben: ");
                singlePrice = Convert.ToDouble(Console.ReadLine());

                nettoPrice = amount * singlePrice;

                nettoSum += nettoPrice;
            }
            while (amount != 0);

            return nettoSum;
        }
    }
}