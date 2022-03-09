using System;
using System.IO;

namespace _02_Funktion_Schreiben_Lesen
{
    class Calculation
    {
        Display myDisplay;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public bool checkName(string? x)
        {
            bool b = String.IsNullOrEmpty(x);
            
            return b;
        }

        public bool checkPrice(string? x)
        {
            double number;
            bool b = double.TryParse(x, out number);
            
            return b;
        }

        public bool checkRoom(string? x)
        {
            int number;
            bool b = int.TryParse(x, out number);

            return b;
        }

        public void clear(string dateiname)
        {
            List<string> lines = File.ReadAllLines(dateiname).ToList();
            File.WriteAllLines(dateiname, lines.GetRange(0, lines.Count - 1).ToArray());
        }

        public void newFile(string dateiname)
        {
            StreamWriter sw = new StreamWriter(dateiname, true);
            sw.WriteLine(string.Format("{0,-5}{1,13}\t- {2, -15}- {3, -15}- {4, -15}", "Datum", "Uhrzeit", "Zimmernr.", "Zimmerpreis", "Name"));
            sw.Close();
        }
    }
}