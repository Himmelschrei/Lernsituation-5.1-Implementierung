using System;

namespace _01_Funktion_Schreiben_Lesen
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
            string filename = @"C:\Users\Pin\Documents\protokolldatei.txt";

            Console.Clear();

            Console.WriteLine("Bite wählen Sie");
            Console.WriteLine("1 - Datensatz erfassen");
            Console.WriteLine("2 - Datensatz auslesen");
            Console.WriteLine("3 - Neue Protokolldatei erstellen");
            Console.WriteLine("4 - Bestehende Protokolldatei löschen");
            Console.WriteLine("5 - Sicherungsdatei erstellen");
            Console.WriteLine("6 - Programm beenden");

            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    write(filename);
                    break;
                case ConsoleKey.D2:
                    read(filename);
                    break;
                case ConsoleKey.D3:
                    create(filename);
                    break;
                case ConsoleKey.D4:
                    delete(filename);
                    break;
                case ConsoleKey.D5:
                    back(filename);
                    break;
                case ConsoleKey.D6:
                    finish();
                    break;
                
                default:
                    Console.WriteLine("Wählen Sie bitte eine gültige Option.");
                    choice();
                    break;
            }
        }

        public void back(string filename)
        {
            Console.Clear();
            Console.WriteLine("5 - Sicherungsdatei erstellen");
            Console.WriteLine("");

            Console.WriteLine("Schreiben Sie bitte den Namen und Pfad der gewünschten Sicherungsdatei:");
            string backUpFile = Console.ReadLine();

            myCalculation.sichern(filename, backUpFile);
        }

        public void create(string filename)
        {
            Console.Clear();
            Console.WriteLine("3 - Neue Protokolldatei erstellen");
            Console.WriteLine("");

            if (File.Exists(filename)) {
                Console.WriteLine("Die Datei existiert bereits.");
                Console.Write("Wollen Sie die alte löschen? j/n");
                Console.WriteLine("");
                
                ConsoleKeyInfo input = Console.ReadKey();
                
                switch (input.Key)
                {
                    case ConsoleKey.J:
                        File.Delete(filename);
                        myCalculation.newFile(filename);
                        Console.WriteLine("Die alte Protokolldatei wurde gelöscht und eine neue wurde erstellt.");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Die alte Protokolldatei wurde nichg gelöscht.");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Wählen Sie bitte eine gültige Option.");
                        create(filename);
                        break;
                }
            } else {
                myCalculation.newFile(filename);
                Console.WriteLine("Die Protokolldatei wurder erstellt.");
                Console.ReadKey();
            }

            choice();
        }

        public void delete(string filename)
        {
            Console.Clear();
            Console.WriteLine("4 - Bestehende Protokolldatei löschen");
            Console.WriteLine("");

            if (File.Exists(filename)) {
                File.Delete(filename);
                Console.WriteLine("Die Datei protokolldatei.txt wurde gelöscht.");
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
            Console.WriteLine("6 - Programm beenden");
            Console.WriteLine("");
            Console.WriteLine("Programm wird beendet.");
            Console.ReadKey();
        }

        public void read(string filename)
        {
            Console.Clear();
            Console.WriteLine("2 - Datensatz auslesen");
            Console.WriteLine("");

            Console.WriteLine("Wollen Sie die ganze Datei oder nur ein bestimmtes Datum auslesen?");
            Console.WriteLine("Wählen Sie: ");
            Console.WriteLine("\t\"0\" um die ganze Datei auszulesen");
            Console.WriteLine("\t Oder schreiben Sie bitte das gewünschte Datum");

            string input = Console.ReadLine();
            Console.Clear();

            if (input == "0") {
                Console.WriteLine("Ausgabe von der gesamten Datei: ");
                Console.WriteLine("");
                
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string fileline = sr.ReadLine();
                    Console.WriteLine(fileline);
                }
                sr.Close();
            } else { 
                Console.WriteLine("Ausgabe von den Datensätzen vom " + input + ": ");
                Console.WriteLine("");
                int i = myCalculation.anzeigen(filename, input);

                if (i == 0) {
                    Console.WriteLine("Keine Protokolleinträge für den {0} vorhanden.", input);
                } else {
                    Console.WriteLine("Das gewünschte Datum wurde {0} Mal gefunden.", i);
                }
            }

            Console.ReadKey();
            choice();
        }

        public void write(string filename)
        {
            Console.Clear();
            Console.WriteLine("1 - Datensatz erfassen");
            Console.WriteLine("");

            if (!File.Exists(filename)) {
                Console.WriteLine("Es existiert noch keine Datei.");
                Console.Write("Wollen Sie eine neue erstellen? j/n ");
                ConsoleKeyInfo input = Console.ReadKey();

                Console.WriteLine("");

                switch (input.Key)
                {
                    case ConsoleKey.J:
                        myCalculation.newFile(filename);
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
                        write(filename);
                        break;
                }
            }

            Console.WriteLine("Schreiben Sie bitte den gewünschten Protokolleintrag:");
            string entry = Console.ReadLine();
            if(myCalculation.checkEntry(entry) == true) {
                Console.WriteLine("Bitte schreiben Sie einen Eintrag.");
                Console.ReadKey();
                choice();
            }

            myCalculation.schreiben(entry, filename);

            choice();
        }
    }
}