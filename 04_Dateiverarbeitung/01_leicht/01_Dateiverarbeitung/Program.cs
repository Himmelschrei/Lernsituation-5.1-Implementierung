using System;

namespace _01_Dateiverarbeitung
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateiname = @"C:\Users\Pin\Documents\test.txt";

            //Schreiben in eine Datei. Falls die Datei existiert, dann am Ende hinzufügen

            //Öffnen der Datei zum Anhängen (Append = true)
            StreamWriter sw = new StreamWriter(dateiname, true);

            //Schreiben einer Zeile
            sw.WriteLine("Hello World!");

            //Datei wieder schließen, damit sie nicht gesperrt bleibt
            sw.Close();

            //Lesen aus einer Datei
            string dateizeile;

            //Öffnen der Datei zum Lesen
            StreamReader sr = new StreamReader(dateiname);

            //Solange nicht das Ende der Datei erreicht ist...
            while (!sr.EndOfStream)
            {
                //Eine Zeile einlesen und in der Variablen text speichern
                dateizeile = sr.ReadLine();

                //Hier mal auf dem Bildschirm ausgeben
                Console.WriteLine(dateizeile);
            }

            //Datei wieder schließen, damit sie nicht gesperrt bleibt
            sr.Close();

            Console.ReadKey();
        }
    }
}