using System;

namespace AB4_Mehrwertsteuer_Einstieg
{
    class Program
    {
        static void Main(string[] args)
        {
            //UTF8 encoding in order to show € symbol
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Pointer to the Display class
            Display display = new Display();
            //Call to input function via Display pointer
            display.input();
        }
    }

    class Display
    {
        //Declarate of the pointer to the Berechnung class
        Berechnung myBerechnung = null;
        //Declarate of the members for the Display (and its subordinate, Berechnung)
        bool myFlag = true;
        string myWare;
        double myMenge = 0;
        double myNettoEinheit = 0;
        double myNettoGesamt = 0;

        //Display class constructor
        public Display()
        {
            //Initialize of the pointer to the Berechnung class
            myBerechnung = new Berechnung(this);
        }

        //Create Get-Functions to acces the members from the other classes
        public string GetWare(){
            return myWare;
        }
        public double GetMenge(){
            return myMenge;
        }
        public double GetNettoEinheit(){
            return myNettoEinheit;
        }
        public double GetNettoGesamt(){
            return myNettoGesamt;
        }
        
        public bool input()
        {
            Console.Clear();
            
            Console.WriteLine("Bitte Ware eingeben: ");
            myWare = Console.ReadLine();

            Console.WriteLine("Bitte Menge eingeben: ");
            myMenge = Convert.ToDouble(Console.ReadLine());
            if (myMenge == 0){
                Console.WriteLine("Keine 0 erlaubt.");
                return false;
            }

            Console.WriteLine("Nettopreis pro (E)inheit oder (G)esamt eingeben?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "E" or "Einheit" or "e" or "einheit":
                    netto_einheit_display();
                    myFlag = true;
                    break;
                case "G" or "Gesamt" or "g" or "gesamt":
                    netto_gesamt_display();
                    myFlag = false;
                    break;
                default:
                    Console.WriteLine("Ungültiger Auswahl");
                    return false;
            }
            output();
            return true;
        }
        
        void netto_einheit_display()
        {
            Console.WriteLine("Nettopreis pro Einheit eingeben: ");
            myNettoEinheit = Convert.ToDouble(Console.ReadLine());
        }

        void netto_gesamt_display()
        {
            Console.WriteLine("Nettopreis insgesamt eingeben: ");
            myNettoGesamt = Convert.ToDouble(Console.ReadLine());
        }

        public void output()
        {
            if (myFlag) {
                double[] arr = myBerechnung.netto_einheit();
                Console.Clear();
                Console.WriteLine("Der Nettopreis pro Einheit von {0} beträgt {1:F2} € und insgesamt (für {2} Stück) {3:F2} €.", myWare, arr[0], myMenge, arr[1]);
                Console.WriteLine("Der Bruttopreis pro Einheit beträgt {0:F2} € und insgesamt {1:F2} €", arr[2], arr[3]);
                Console.WriteLine("Die Höhe der bezahlten Mehrwertsteuer beträgt {0:F2} €", arr[4]);
            } else {
                double[] arr = myBerechnung.netto_gesamt();
                Console.Clear();
                Console.WriteLine("Der Nettopreis pro Einheit von {0} beträgt {1:F2} € und insgesamt (für {2} Stück) {3:F2} €.", myWare, arr[0], myMenge, arr[1]);
                Console.WriteLine("Der Bruttopreis pro Einheit beträgt {0:F2} € und insgesamt {1:F2} €", arr[2], arr[3]);
                Console.WriteLine("Die Höhe der bezahlten Mehrwertsteuer beträgt {0:F2} €", arr[4]);
            }
        }
    }

    class Berechnung
    {
        Display myDisplay = null;

        public Berechnung(Display display)
        {
            myDisplay = display;
        }
        
        public double[] netto_einheit()
        {
            double menge = myDisplay.GetMenge();
            double nettoEinheit = myDisplay.GetNettoEinheit();
            double nettoGesamt = menge * nettoEinheit;

            double bruttoEinheit = nettoEinheit * 1.19;
            double bruttoGesamt = nettoGesamt * 1.19;
            double steuerBetrag = bruttoGesamt - nettoGesamt;

            double[] arr = new double[5]; 
            arr[0] = nettoEinheit;
            arr[1] = nettoGesamt;
            arr[2] = bruttoEinheit;
            arr[3] = bruttoGesamt;
            arr[4] = steuerBetrag;
            
            return arr;
        }

        public double[] netto_gesamt()
        {
            double menge = myDisplay.GetMenge();
            double nettoGesamt = myDisplay.GetNettoGesamt();
            double nettoEinheit = nettoGesamt / menge;

            double bruttoEinheit = nettoEinheit * 1.19;
            double bruttoGesamt = nettoGesamt * 1.19;
            double steuerBetrag = bruttoGesamt - nettoGesamt;

            double[] arr = new double[5]; 
            arr[0] = nettoEinheit;
            arr[1] = nettoGesamt;
            arr[2] = bruttoEinheit;
            arr[3] = bruttoGesamt;
            arr[4] = steuerBetrag;
            
            return arr;
        }
    }
}
