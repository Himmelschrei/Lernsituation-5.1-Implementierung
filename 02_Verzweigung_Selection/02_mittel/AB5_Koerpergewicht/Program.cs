using System;
using System.Collections.Generic;

namespace AB5_Koerpergewicht
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

        double myHeight;
        double myWeight;
        string mySex;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public double GetHeight()
        {
            return myHeight;
        }
        public double GetWeight()
        {
            return myWeight;
        }
        public string GetSex()
        {
            return mySex;
        }

        public bool input()
        {
            Console.Clear();

            Console.WriteLine("GEWICHTSBERECHNUNG \n");
            
            Console.Write("Geben Sie bitte Ihre Köpergröße ein: ");
            myHeight = Convert.ToDouble(Console.ReadLine());
            if (myHeight == 0) {
                Console.WriteLine("Die Körpergröße darf nicht 0 sein");
                return false;
            }

            Console.Write("Sind Sie ein Mann oder eine Frau (m/w): ");
            mySex = Console.ReadLine();
            if (mySex != "m" && mySex != "w") {
                Console.WriteLine("Ungültige Angabe");
                return false;
            }

            Console.Write("Wie viel wiegen Sie aktuell? ");
            myWeight = Convert.ToDouble(Console.ReadLine());
            if (myWeight == 0) {
                Console.WriteLine("Das Gewicht darf nicht 0 sein");
                return false;
            }

            output();

            return true;
        }

        public void output()
        {
            Console.WriteLine("");

            List<double> listBmi = myCalculation.bmi();

            Console.WriteLine("Ihr Normalgeweicht beträgt {0} kg.", listBmi[0]);
            Console.WriteLine("Ihr Idealgewicht beträgt {0} kg.", listBmi[1]);

            if (listBmi[2] > 0) { 
                Console.WriteLine("Sie haben {0} kg Übergewicht.", listBmi[2]);
            } else if (listBmi[2] == 2) {
                Console.WriteLine("Sie liegen auf ihrem Idealgewicht!");
            } else {
                Console.WriteLine("Sie haben {0} kg Untergewicht.", Math.Abs(listBmi[2]));
            }

        }
    }

    class Calculation
    {
        Display myDisplay = null;

        public Calculation (Display display)
        {
            myDisplay = display;
        }

        public List<double> bmi()
        {
            double height = myDisplay.GetHeight();
            double weight = myDisplay.GetWeight();
            string sex = myDisplay.GetSex();
            
            List<double> listBmi = new List<double> ();
            if (sex == "m") {
                listBmi = bmiMan(height, weight);
            } else {
                listBmi = bmiWoman(height, weight);
            }

            double difference = weight - listBmi[1];

            listBmi.Add(difference);            

            return listBmi;
        }

        public List<double> bmiMan(double height, double weight)
        {
            double normalWeight = height - 100;

            double idealWeight = normalWeight * 0.9;

            List<double> listBmiMan = new List<double> ();
            listBmiMan.Add(normalWeight);
            listBmiMan.Add(idealWeight);

            return listBmiMan;
        }
        
        public List<double> bmiWoman(double height, double weight)
        {
            double normalWeight = height - 100;

            double idealWeight = normalWeight * 0.85;

            List<double> listBmiWoman = new List<double> ();
            listBmiWoman.Add(normalWeight);
            listBmiWoman.Add(idealWeight);

            return listBmiWoman;
        }
    }
}
