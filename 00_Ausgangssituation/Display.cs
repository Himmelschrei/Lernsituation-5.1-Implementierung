using System;


namespace _00_Ausgangssituation
{
    /// <summary>
    /// Here are all functions listed where the program gets user input.
    /// </summary>
    /// <remarks>
    /// Class variables:
    /// <para>decimal myResult</para>
    /// <para>string myDate</para>
    /// </remarks>
    class Display
    {
        Calculation myCalculation;

        /// <summary>
        /// Constructor from class Display.
        /// </summary>
        public Display()
        {
            myCalculation = new Calculation(this);
        }

        decimal myResult;
        string myDate;

        /// <summary>
        /// First output for the user. Lists the different options that can be chosen.
        /// </summary>
        /// <remarks>
        /// <para>1: Calculation.MeanWhole()</para>
        /// <para>2: Calculation.MeanDay()</para>
        /// <para>3: Calculation.MaxDay()</para>
        /// </remarks>
        public void Choice()
        {
            Console.Clear();
            Console.WriteLine("1 - Durchschnittstemperatur insgesamt ausgeben");
            Console.WriteLine("2 - Durchschnittstemperatur eines Tages ausgeben");
            Console.WriteLine("3 - Maximaltemperatur eines Tages ausgeben");
            Console.WriteLine();
            Console.WriteLine("0 - Programm beenden");
            Console.Write("Ihre Wahl (0-3): ");
            ConsoleKeyInfo input = Console.ReadKey();

            Console.WriteLine();

            switch (input.Key)
            {
                case ConsoleKey.D0:
                    Finish();
                    break;
                case ConsoleKey.D1:
                    MeanWhole();
                    break;
                case ConsoleKey.D2:
                    MeanDay();
                    break;
                case ConsoleKey.D3:
                    MaxDay();
                    break;
                
                default:
                    Console.WriteLine("Wählen Sie bitte eine gültige Option.");
                    Choice();
                    break;
            }
        }

        /// <summary>
        /// Closing function.
        /// </summary>
        public void Finish()
        {
            Console.WriteLine("Programm wird beendet.");
            Console.WriteLine("Tschüss!");
            Console.ReadKey();
        }

        /// <summary>
        /// Gets a date from the user and calls Calculation.CheckDate() to check if it's present on the 
        /// document. If it is, it calls Calculation.GetMaxDay() to get the result.  Otherwise, it prints
        /// a warning. Then it goes back to Display.Choice().
        /// </summary>
        public void MaxDay()
        {
            Console.Write("Bitte geben Sie das Datum in der Form JJJJ-MM-TT an: ");
            string myDate = Console.ReadLine();
            if (myCalculation.CheckDate(myDate))
            {
                myResult = myCalculation.GetMaxDay(myDate);
                Console.WriteLine("Die Maximaltemperatur am {0} ist {1:F2} Grad", myDate, myResult);
                Console.WriteLine("Press any key to continue . . .");
            } else {
                Console.WriteLine("Bitte wählen Sie ein gültiges Datum aus.");
                Console.WriteLine("Press any key to continue . . .");
            }
            Console.ReadKey();
            Choice();
        }

        /// <summary>
        /// Gets a date from the user and calls Calculation.CheckDate() to check if it's present on the 
        /// document. If it is, it calls Calculation.GetMeanDay() to get the result. Otherwise, it prints
        /// a warning. Then it goes back to Display.Choice().
        /// </summary>
        public void MeanDay()
        {
            Console.Write("Bitte geben Sie das Datum in der Form JJJJ-MM-TT an: ");
            string myDate = Console.ReadLine();
            if (myCalculation.CheckDate(myDate))
            {
                myResult = myCalculation.GetMeanDay(myDate);
                Console.WriteLine("Die Durchschnittstemperatur am {0} ist {1:F2} Grad", myDate, myResult);
                Console.WriteLine("Press any key to continue . . .");
            } else {
                Console.WriteLine("Bitte wählen Sie ein gültiges Datum aus.");
                Console.WriteLine("Press any key to continue . . .");
            }
            Console.ReadKey();
            Choice();
        }

        /// <summary>
        /// Calls Calculation.GetMeanWhole() to get the result. Then it goes to Display.Choice().
        /// </summary>
        public void MeanWhole()
        {
            myResult = myCalculation.GetMeanWhole();
            Console.WriteLine("Die Durchschnittstemperatur insgesamt ist {0:F2} Grad.", myResult);
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
            Choice();
        }
    }
}