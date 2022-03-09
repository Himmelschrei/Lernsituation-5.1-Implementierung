using System;

namespace AB3_Notenberechnung
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

        int myTotal;
        int myAchieved;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public int GetTotal(){
            return myTotal;
        }
        public int GetAchieved(){
            return myAchieved;
        }

        public bool input()
        {
            Console.Clear();

            Console.WriteLine("Gesamtpunktzahl der Klassenarbeit:");
            myTotal = Convert.ToInt32(Console.ReadLine());
            if (myTotal == 0){
                Console.WriteLine("Ungültiger Wert");
                return false;
            }

            Console.WriteLine("Erreichte Punkte:");
            myAchieved = Convert.ToInt32(Console.ReadLine());
            if (myAchieved > myTotal){
                Console.WriteLine("Die erreichten Punkte können nicht größer als die Gesamtpunktzahl sein!");
                return false;
            }

            output();

            return true;
        }

        public void output()
        {
            string[] arr = myCalculation.note();

            Console.WriteLine("{0} Punkte bedeuten {1} %.", myAchieved, arr[0]);
            Console.WriteLine("Die Note {0} wurde erreicht", arr[1]);
        }
    }

    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public string[] note()
        {
            int total = myDisplay.GetTotal();
            int achieved = myDisplay.GetAchieved();

            int percentage = achieved * 100 / total;

            string noteWord;
            if (percentage >= 92){
                noteWord = "sehr gut";
            } else if (percentage >= 81) {
                noteWord = "gut";
            } else if (percentage >= 67) {
                noteWord = "befriedigend";
            } else if (percentage >= 50) {
                noteWord = "ausreichend";
            } else if (percentage >= 30) {
                noteWord = "mangelhaft";
            } else {
                noteWord = "ungenügend";
            }

            string[] arr = {percentage.ToString(), noteWord}; 
            
            return arr;
        }
    }
}
