using System;

namespace _02_Funktion_Schreiben_Lesen
{
    class Display
    {
        Calculation myCalculation;

        public Display()
        {
            myCalculation = new Calculation(this);
        }

        public void choice()
        {
            string dateiname = @"C:\Users\Pin\Documents\daten.txt";

            Console.Clear();

            Console.WriteLine("Bitte wählen Sie");
            Console.WriteLine("1 - Datensatz erfassen");
            Console.WriteLine("2 - Datensatz auslesen");
            Console.WriteLine("3 - Neue Datei erstellen");
            Console.WriteLine("4 - Bestehende Datei löschen");
            Console.WriteLine("5 - Programm beenden");
            
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    write(dateiname);
                    break;
                case ConsoleKey.D2:
                    read(dateiname);
                    break;
                case ConsoleKey.D3:
                    create(dateiname);
                    break;
                case ConsoleKey.D4:
                    delete(dateiname);
                    break;
                case ConsoleKey.D5:
                    finish();
                    break;

                default:
                    Console.WriteLine("Wählen Sie bitte eine gültige Option.");
                    choice();
                    break;
            }
        }

        public void create(string dateiname)
        {
            Console.Clear();
            Console.WriteLine("3 - Neue Datei erstellen");
            Console.WriteLine("");

            if (File.Exists(dateiname)) {
                Console.WriteLine("Die Datei existiert bereits.");
                Console.Write("Wollen Sie die alte löschen? j/n ");
                Console.WriteLine("");
                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.J:
                        File.Delete(dateiname);
                        myCalculation.newFile(dateiname);
                        Console.WriteLine("Die alte Datei wurde gelöscht und eine neue wurde erstellt.");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Die alte Datei wurde nicht gelöscht.");
                        Console.ReadKey();
                        break;
                    
                    default:
                        Console.WriteLine("Wählen Sie bitte eine gültige Option.");
                        choice();
                        break;
                }
            } else {
                myCalculation.newFile(dateiname);
                Console.WriteLine("Die Datei daten.txt wurde erstellt.");
                Console.ReadKey();
            }

            choice();
        }

        public void delete(string dateiname)
        {
            Console.Clear();
            Console.WriteLine("4 - Bestehende Datei löschen");
            Console.WriteLine("");

            if (File.Exists(dateiname)) {
                File.Delete(dateiname);
                Console.WriteLine("Die Datei daten.txt wurde gelöscht.");
                Console.ReadKey();
            } else {
                Console.WriteLine("Die Datei existiert nicht.");
                Console.ReadKey();
            }

            choice();
        }

        public void finish()
        {
            Console.Clear();
            Console.WriteLine("5 - Programm beenden");
            Console.WriteLine("");
            Console.WriteLine("Programm wird beendet.");
            Console.ReadKey();
        }

        public void read(string dateiname)
        {
            Console.Clear();
            Console.WriteLine("2 - Datensatz auslesen");
            Console.WriteLine("");

            Console.WriteLine("Wollen Sie die ganze Datei oder nur einen bestimmten Datensatz auslesen?");
            Console.WriteLine("Wählen Sie:");
            Console.WriteLine("\t\"0\" um die ganze Datei auszulesen");
            Console.WriteLine("\t Oder schreiben Sie bitte das Datum des gewünschten Datensatzes: ");

            string? input = Console.ReadLine();
            Console.Clear();
            if (input == "0") {
                Console.WriteLine("Ausgabe von allen Datensätzen: ");
                Console.WriteLine("");
            } else {
                Console.WriteLine("Ausgabe von den Datensätzen vom " + input + ": ");
                Console.WriteLine("");
            }

            StreamReader sr = new StreamReader(dateiname);
            while (!sr.EndOfStream)
            {
                string? dateizeile = sr.ReadLine();
                if (dateizeile is not null) {
                    if (input == dateizeile.Substring(0,10)) {
                        Console.WriteLine(dateizeile);
                    } else if (input == "0") {
                        Console.WriteLine(dateizeile);
                    }
                }
            }
            
            sr.Close();
            Console.ReadKey();
            choice();
        }

        public void write(string dateiname)
        {
            Console.Clear();
            Console.WriteLine("1 - Datensatz erfassen");
            Console.WriteLine("");

            if (!File.Exists(dateiname)) {
                Console.WriteLine("Es existiert noch keine Datei.");
                Console.Write("Wollen Sie eine neue erstellen? j/n ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine("");
                switch (input.Key)
                {
                    case ConsoleKey.J:
                        myCalculation.newFile(dateiname);
                        Console.WriteLine("Eine neue Datei wurde erstellt.");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Es wurde keine neue Datei erstellt.");
                        Console.ReadKey();
                        choice();
                        break;
                    
                    default:
                        Console.WriteLine("Geben Sie eine gültige Eingabe, bitte.");
                        Console.ReadKey();
                        write(dateiname);
                        break;
                }
            }

            StreamWriter sw = new StreamWriter(dateiname, true);

            sw.Write(DateTime.Now.ToString());

            Console.Write("Bitte geben Sie die Zimmernummer ein: ");
            string? roomNumber = Console.ReadLine();
            if (myCalculation.checkRoom(roomNumber) == false) {
                Console.WriteLine("Bitte geben Sie eine gültige Zimmernummer ein.");
                sw.Close();
                myCalculation.clear(dateiname);
                Console.ReadKey();
                choice();
            }
            sw.Write("\t  {0,-17}", roomNumber);

            Console.Write("Bitte geben Sie den Zimmerpreis ein: ");
            string? roomPrice = Console.ReadLine();
            if (myCalculation.checkPrice(roomPrice) == false) {
                Console.WriteLine("Bitte geben Sie einen gültigen Zimmerpreis ein.");
                sw.Close();
                myCalculation.clear(dateiname);
                Console.ReadKey();
                choice();
            }
            sw.Write("{0,-17}", roomPrice + " €");

            Console.Write("Bitte geben Sie den Namen des Gästes ein: ");
            string? name = Console.ReadLine();
            if (myCalculation.checkName(name) == true) {
                Console.WriteLine("Bitte geben Sie einen Namen ein.");
                sw.Close();
                myCalculation.clear(dateiname);
                Console.ReadKey();
                choice();
            }
            sw.Write("{0}", name);
            sw.WriteLine("");

            sw.Close();

            choice();
        }
    }
}