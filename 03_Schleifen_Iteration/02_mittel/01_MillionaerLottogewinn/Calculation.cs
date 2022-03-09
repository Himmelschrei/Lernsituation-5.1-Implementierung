using System;

namespace _01_MillionaerLottogewinn
{
    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public void CalcLottogewinn(double lottoPrice, double interest, double rent)
        {
            double startCapital = lottoPrice;
            double endCapital = 1;
            double appliedInterest;
            int month = 1;

            while (endCapital > 0)
            {
                appliedInterest = startCapital * interest / 100 / 12;
                endCapital = startCapital + appliedInterest - rent;

                Console.WriteLine("{0}\t\t{1:F2}\t\t\t{2:F2}\t\t{3:F2}\t\t\t{4:F2}", month++, startCapital, appliedInterest, rent, endCapital);

                startCapital = endCapital;
            }

            int year = month/12;
            Console.WriteLine("Der Lottogewinn reicht {0} Jahre, um davon zu leben.", year);
        }

        public void CalcMillionaer(double startCapital, double interest, int startYear)
        {
            double appliedInterest, endCapital = 0;

            while (endCapital < 1000000)
            {
                appliedInterest = startCapital * interest / 100;
                endCapital = startCapital + appliedInterest;

                Console.WriteLine("{0}\t\t\t{1:F2}\t\t\t{2:F2} \t\t{3:F2}", startYear++, startCapital, appliedInterest, endCapital);
                
                startCapital = endCapital;
            }
        }
    }
}