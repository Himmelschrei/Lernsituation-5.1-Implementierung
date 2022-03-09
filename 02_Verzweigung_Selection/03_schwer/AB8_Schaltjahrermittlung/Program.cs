using System;

namespace AB8_Schaltjahrermittlung
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

        int myYear;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public int GetYear()
        {
            return myYear;
        }

        public void input()
        {
            Console.Clear();

            Console.Write("Geben Sie das gewünschte Jahr ein: ");
            myYear = Convert.ToInt32(Console.ReadLine());

            output();
        }

        public void output()
        {
            Console.WriteLine("");
            string message = myCalculation.leap();
            Console.Write(message);
        }
    }

    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public string leap()
        {
            int year = myDisplay.GetYear();
            string message;

            if (year % 400 == 0) {
                message = "Das Jahr " + year + " ist ein Schaltjahr!";
                return message;
            } else if (year % 4 == 0 && year % 100 != 0) {
                message = "Das Jahr " + year + " ist ein Schaltjahr!";
                return message;
            } else { 
                message = "Das Jahr " + year + " ist kein Schaltjahr!";
                return message;
            } 
        }
    }
}
