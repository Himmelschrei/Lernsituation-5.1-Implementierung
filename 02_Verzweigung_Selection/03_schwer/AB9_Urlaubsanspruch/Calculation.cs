using System;

namespace AB9_Urlaubsanspruch
{
    public static class Calculation
    {
        public static bool checkDisability(int disabled)
        {
            if (disabled >= 50) {
                return true;
            } else return false;
        }

        public static bool checkMinor(int age)
        {
            if (age < 18) {
                return true;
            } else {
                return false;
            }
        }

        public static bool checkMonth(int x)
        {
            if (x < 1 | x > 12) {
                Console.WriteLine("Bitte einen Monat zwischen 1 und 12 schreiben.");
                return false;
            } else return true;
        }

        public static bool checkOld(int age) {
            if (age >= 55) {
                return true;
            } else {
                return false;
            }
        }

        public static int vacation(int x, int y)
        {
            int vacationDays;

            bool minor = checkMinor(x);
            bool old = checkOld(x);
            bool disabled = checkDisability(y);
           
            if (minor == true) {
                vacationDays = 30;
            } else if (old == true) {
                vacationDays = 26;
            } else vacationDays = 24;

            if (disabled == true) {
                vacationDays += 5;
            }

            return vacationDays;
        }
    }
}
