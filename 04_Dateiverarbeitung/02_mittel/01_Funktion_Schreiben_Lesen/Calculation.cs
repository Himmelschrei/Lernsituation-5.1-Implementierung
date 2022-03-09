using System;
using System.IO;

namespace _01_Funktion_Schreiben_Lesen
{
    class Calculation
    {
        Display myDisplay;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public int anzeigen(string filename, string datum)
        {
            StreamReader sr = new StreamReader(filename);
            int i = 0;
            while (!sr.EndOfStream)
            {
                string fileline = sr.ReadLine();
                if (datum == fileline.Substring(0,10)) {
                    Console.WriteLine(fileline);
                    i++;
                } 
            }
            
            sr.Close();
            return i;
        }

        public bool checkEntry(string x)
        {
            bool b = String.IsNullOrEmpty(x);
            return b;
        }

        public void newFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename, true);
            sw.WriteLine(string.Format("{0,-5}{1,13}{2,8}", "Datum", "Uhrzeit", "- Text"));
            sw.Close();
        }

        public void schreiben(string entry, string filename)
        {
            StreamWriter sw = new StreamWriter(filename, true);

            sw.WriteLine(DateTime.Now.ToString() + " - " + entry);

            sw.Close();
        }

        public void sichern(string filename, string backUpFile)
        {
            string line;
            backUpFile = "@\""+backUpFile+"\t";

            StreamReader sr = new StreamReader(filename);
            StreamWriter sw = new StreamWriter(backUpFile);
            while ((line = sr.ReadLine()) != null)
            {
                sw.WriteLine(line);
            }

            sw.Close();
            sr.Close();
        }
    }
}