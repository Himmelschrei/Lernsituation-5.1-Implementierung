using System;

namespace AB5_Rabattrechner
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

        string myProduct;
        double mySinglePrice;
        int myAmount;
        double myDiscount;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public string GetProduct(){
            return myProduct;
        }
        public double GetSinglePrice(){
            return mySinglePrice;
        }
        public int GetAmount(){
            return myAmount;
        }
        public double GetDiscount(){
            return myDiscount;
        }

        public bool input()
        {
            Console.Clear();

            Console.WriteLine("Welches Produkt wurde gekauft?");
            myProduct = Console.ReadLine();

            Console.WriteLine("Wie hoch ist der Einzelpreis?");
            mySinglePrice = Convert.ToDouble(Console.ReadLine());
            if (mySinglePrice == 0){
                Console.WriteLine("Der Preis darf nicht 0 sein.");
                return false;
            }

            Console.WriteLine("Wie viel Stück haben Sie davon gekauft?");
            myAmount = Convert.ToInt32(Console.ReadLine());
            if (myAmount == 0){
                Console.WriteLine("Die Menge darf nicht 0 sein.");
                return false;
            }

            Console.WriteLine("Wie viel Rabatt wollen Sie gewähren?");
            myDiscount = Convert.ToDouble(Console.ReadLine());

            output();

            return true;
        }

        public void output()
        {
            Console.Clear();

            double[] arr = myCalculation.discount();

            Console.WriteLine("Für das Produkt {0} ergibt sich folgende Berechnung mit einem Rabattsatz von {1:F1} %: \n", myProduct, myDiscount);
            Console.WriteLine("Der Kunde kauft: {0} Stück {1} zu einem Einzelpreis von {2} Euro \n", myAmount, myProduct, mySinglePrice);
            Console.WriteLine("Gesamtpreis ohne Rabatt: \t\t {0:F2} Euro", arr[0]);
            Console.WriteLine("Rabattbetrag: \t\t\t\t {0} Euro", arr[1]);
            Console.WriteLine("Gesamtpreis nach Rabattabzug: \t\t {0:F2} Euro", arr[2]);
        }
    }

    class Calculation
    {
        Display myDisplay = null;
        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public double[] discount()
        {
            int amount = myDisplay.GetAmount();
            double singlePrice = myDisplay.GetSinglePrice();
            double discount = myDisplay.GetDiscount();

            double totalPrice = amount * singlePrice;
            double discounted = totalPrice * discount / 100;
            double discountApplied = totalPrice - discounted;

            double[] arr = new double[3];
            arr[0] = totalPrice;
            arr[1] = discounted;
            arr[2] = discountApplied;
            return arr;
        }
    }
}
