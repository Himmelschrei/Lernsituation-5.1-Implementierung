using System;

namespace AB1_Prozentsatz
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

        double myInterest, myCapital;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public double GetInterest(){
            return myInterest;
        }
        public double GetCapital(){
            return myCapital;
        }

        public bool input(){
            Console.Clear();

            Console.WriteLine("Kapital eingeben:");
            myCapital = Convert.ToDouble(Console.ReadLine());
            if (myCapital == 0){
                Console.WriteLine("Fehler bei der Eingabe");
                return false;
            }

            Console.WriteLine("Zinsen eingeben:");
            myInterest = Convert.ToDouble(Console.ReadLine());

            output();

            return true;
        }

        public void output()
        {
            double interestRate = myCalculation.interestRate();

            Console.WriteLine("Prozentsatz: {0} %", interestRate);
        }
    }

    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public double interestRate()
        {
            double interest = myDisplay.GetInterest();
            double capital = myDisplay.GetCapital();
            
            double interestRate = interest * 100 / capital;

            return interestRate;
        }
    }
}