using System;

namespace AB2_kleinste_Zahl
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

        int mySize;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public int GetSize(){
            return mySize;
        }

        public bool input()
        {
            Console.Clear();

            Console.WriteLine("Bitte schreiben Sie die Anzahl von Werten die Sie für die Suche eingeben wollen:");
            mySize = Convert.ToInt32(Console.ReadLine());
            if (mySize == 0){
                Console.WriteLine("Die Anzahl darf nicht 0 sein.");
                return false;
            }

            output();

            return true;
        }

       public void output()
        {
            int[] arr = myCalculation.sort();

            Console.WriteLine("");
            Console.WriteLine("Die kleinste Zahl ist {0}", arr[mySize-1]);
            //The highest number could easily be also displayed with the following line:
            //Console.WriteLine("Die größte Zahl ist {0}", arr[0]);
        }
    }

    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public int[] save()
        {
            int size = myDisplay.GetSize();
            int[] myArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write("Geben Sie bitte die {0}. Zahl: ", i+1);
                myArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            return myArray;
        }

       public int[] sort()
        {
            int[] arr = save();
            int size = myDisplay.GetSize();

            int temp;

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (arr[i] < arr[j]){
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    Console.Write("For interior: ");
                    foreach (int item in arr) {
                        Console.Write("{0} ", item);
                    }
                    Console.WriteLine("");
                }
                Console.Write("For exterior: ");
                foreach (int item in arr) {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine("");
            }

            return arr;
        }
    }
}
