using System;

namespace AB9_Urlaubsanspruch
{
    class Display
    {
        int myAge;
        int myEmploymentBegin;
        int myEmploymentEnd;
        int myDisability;

        bool breaker = true;

        public Display()
        {

        }

        public bool input()
        {
            Console.Clear();

            Console.WriteLine("ERMITTLUNG DES URLAUBSANSPRUCHES \n");

            Console.Write("Alter: \t\t\t\t\t");
            myAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");
            Console.Write("Beschäftigt von (Monat): \t\t");
            myEmploymentBegin = Convert.ToInt32(Console.ReadLine());

            breaker = Calculation.checkMonth(myEmploymentBegin);
            if (breaker == false) {
                return false;
            }

            Console.Write("Beschäftigt bis (Monat): \t\t");
            myEmploymentEnd = Convert.ToInt32(Console.ReadLine());
            if (myEmploymentEnd < myEmploymentBegin) {
                Console.WriteLine("Der Wert für \"Beschäftigt bis\" muss kleiner als der Wert für \"Beschäftigt von\" sein.");
                return false;
            }

            breaker = Calculation.checkMonth(myEmploymentBegin);
            if (breaker == false) {
                return false;
            }

            Console.Write("Grad der Behinderung in Prozent: \t");
            myDisability = Convert.ToInt32(Console.ReadLine());
            if (myDisability < 0 | myDisability > 100) {
                Console.WriteLine("Die Grad der Behinderung muss eine Zahl zwischen 0 und 100 sein.");
                return false;
            }

            output();
            return true;
        }

        public void output()
        {
            int vacationDays = Calculation.vacation(myAge, myDisability);

            Console.WriteLine("");
            Console.WriteLine("Der Urlaubsanspruch beträgt {0} Tage.", vacationDays);
        }
    }
}