using System;

namespace AB4_Rabattstaffel
{
    class Program
    {
        static void Main()
        {
            Display display = new Display();
            display.input();
        }
    }

    class Display
    {
        Calculation myCalculation = null;

        int myAmount;
        double mySinglePrice;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public int GetAmount(){
            return myAmount;
        }
        public double GetSinglePrice(){
            return mySinglePrice;
        }

        public bool input()
        {
            Console.Clear();

            Console.WriteLine("Rabattberechnung \n");
            Console.WriteLine("Eingabe \n");

            Console.Write("Artikelanzahl: \t");
            myAmount = Convert.ToInt32(Console.ReadLine());
            if (myAmount == 0){
                Console.WriteLine("Die Anzahl darf nicht 0 sein.");
                return false;
            }

            Console.Write("Einzelpreis: \t");
            mySinglePrice = Convert.ToDouble(Console.ReadLine());
            if (mySinglePrice == 0){
                Console.WriteLine("Der Preis darf nicht 0 sein.");
                return false;
            }

            output();

            return true;
        }

        public void output()
        {
            Console.WriteLine("");
            Console.WriteLine("Ausgabe \n");

            double[] arr = myCalculation.price();

            Console.WriteLine("Verkaufspreis \t {0:F2} Euro", arr[0]);
            Console.WriteLine("- {0} % Rabatt \t {1:F2} Euro", arr[1], arr[2]);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Zahlungsbetrag \t {0:F2} Euro", arr[3]);
        }

    }

    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public double[] price()
        {
            int amount = myDisplay.GetAmount();
            double singlePrice = myDisplay.GetSinglePrice();

            double total = amount * singlePrice;

            int discount = discounting(total);

            Console.WriteLine("Esto es el discount: {0}", discount);

            double discounted = total * discount / 100;
            double final = total - discounted;

            double[] arr = {total, discount, discounted, final};

            return arr;
        }

        public int discounting(double x)
        {
            int discount;
            if (x < 500) {
                discount = 0;
            } else if (x < 1000) {
                discount = 5;
            } else if (x < 2500) {
                discount = 9;
            } else if (x < 5000) {
                discount = 13;
            } else if (x < 10000) {
                discount = 16;
            } else {
                discount = 18;
            }

            return discount;
        }
    }
}
