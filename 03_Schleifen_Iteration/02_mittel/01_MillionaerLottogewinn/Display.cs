using System;

namespace _01_MillionaerLottogewinn
{
    class Display
    {
        Calculation myCalculation = null;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public void Input()
        {
            Console.Clear();

            Console.Write("Bitte zwischen Aufgabe (M)illionär und (L)ottogewinn auswählen: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "M":
                case "m":
                case "Millionär":
                case "millionär":
                case "Millionaer":
                case "millionaer":
                    AufgabeMillionaer();
                    break;
                case "L":
                case "l":
                case "Lottogewinn":
                case "lottogewinn":
                    AufgabeLottogewinn();
                    break;
                default:
                    Console.WriteLine("Bitte wählen Sie eine gültige Aufgabe. ");
                    break;
            }
        }

        public void AufgabeMillionaer()
        {
            Console.Clear();
            Console.WriteLine("Wie lange dauert es, um Millionär zu werden?");
            Console.WriteLine("");

            Console.Write("Einlage in Euro \t: ");
            double startCapital = Convert.ToDouble(Console.ReadLine());

            Console.Write("Zinssatz (p. a.) \t: ");
            double interest = Convert.ToDouble(Console.ReadLine());

            Console.Write("Anfangsjahr \t\t: ");
            int startYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Jahr\t\tWert am Jahresanfang\t\tZinsen pro Jahr\t\tWert am Jahresende");

            myCalculation.CalcMillionaer(startCapital, interest, startYear);
        }

        public void AufgabeLottogewinn()
        {
            Console.Clear();
            Console.WriteLine("Wie lange reicht ein Lottogewinn, um davon zu leben? ");
            Console.WriteLine("");

            Console.Write("Lottogewinn in Euro \t: ");
            double lottoPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Verzinsung (p. a.) \t: ");
            double interest = Convert.ToDouble(Console.ReadLine());

            Console.Write("Monatliche Rente \t: ");
            double rent = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Monat\t\tKapital am Anfang\t\tZinsen\t\tmonatliche Rente\t\tKapital am Ende");

            Console.WriteLine();

            myCalculation.CalcLottogewinn(lottoPrice, interest, rent);
        }
    }
}