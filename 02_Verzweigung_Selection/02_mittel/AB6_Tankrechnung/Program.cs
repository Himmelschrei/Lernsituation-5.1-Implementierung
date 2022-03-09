using System;

namespace AB6_Tankrechnung
{
    class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();
            display.input();
        }
    }

    class Display
    {
        Calculation myCalculation = null;

        double myLiter;
        string myGas;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public double GetLiter()
        {
            return myLiter;
        }

        public string GetGas()
        {
            return myGas;
        }

        public bool input()
        {
            Console.Clear();

            Console.Write("Bitte geben Sie die benutzte Benzinsorte zwischen Normalbenzin, Superbenzin und Diesel: ");
            myGas = Console.ReadLine();
            if (myGas != "Normalbenzin" && myGas != "Superbenzin" && myGas != "Diesel") {
                Console.WriteLine("Ungültige Angabe. Wählen Sie bitte eine der gelisteten Benziznsorten.");
                return false;
            }

            Console.Write("Bitte geben Sie die getankten Liter ein: ");
            myLiter = Convert.ToDouble(Console.ReadLine());
            if (myLiter <= 0) {
                Console.WriteLine("Ungültige Angabe.");
                return false;
            }

            output();

            return true;
        }

        public void output()
        {
            Console.Clear();

            double[] arr = myCalculation.cost();

            Console.WriteLine("\t\t\t\t\t Tankrechnung");
            Console.WriteLine("\t\t\t\t\t ============ \n");

            Console.WriteLine("Sie haben {0:F1} Liter {1} zu einem Literpreis in Höhe von {2:F3} EUR pro Liter getankt. \n", myLiter, myGas, arr[0]);
            Console.WriteLine("Sie müssen {0:F2} Euro zahlen. \n", arr[1]);

            Console.WriteLine("Nettobetrag: \t\t {0:F2} Euro", arr[3]);
            Console.WriteLine("Mehrwertsteuer: \t {0:F2} Euro", arr[2]);
            Console.WriteLine("Bruttobetrag: \t\t {0:F2} Euro", arr[1]);
        }
    }

    class Calculation
    {
        Display myDisplay = null;
        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public double[] cost()
        {
            string gas = myDisplay.GetGas();
            double liter = myDisplay.GetLiter();

            double price;
            if (gas == "Normalbenzin") {
                price = 1.612;
            } else if (gas == "Superbenzin") {
                price = 1.674;
            } else {
                price = 1.465;
            }

            double brutto = liter * price;
            double netto = brutto / 1.19;
            double mwst = brutto - netto;

            double[] arr = {price, brutto, mwst, netto};
            return arr;
        }
    }
}
