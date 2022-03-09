using System;

namespace _02_Rechnung_Fakultaet
{
    class Display
    {
        Calculation myCalculation = null;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public void input()
        {
            Console.Clear();

            Console.Write("Bitte zwischen Aufgaben (R)echnung und (F)akultät auswählen: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "R":
                case "r":
                case "Rechnung":
                case "rechnung":
                    aufgabeRechnung();
                    break;
                case "F":
                case "f":
                case "Fakultät":
                case "fakultät":
                case "Fakultaet":
                case "fakultaet":
                    aufgabeFakultaet();
                    break;
                
                default:
                    Console.WriteLine("Choose a possible excercise");
                    break;
            }
        }

        public void aufgabeRechnung()
        {
            Console.Clear();
            Console.WriteLine("========== RECHNUNG ==========");
            myCalculation.rechnung();
        }

        public void aufgabeFakultaet()
        {
            Console.Clear();
            Console.WriteLine("========== FAKULTÄT ==========");

            Console.Write("Bitte geben Sie eine Zahl ein: ");
            int number = Convert.ToInt32(Console.ReadLine());

            myCalculation.fakultaet(number);
        }
    }
}





