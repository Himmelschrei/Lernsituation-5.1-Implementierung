using System;

namespace _00_Ausgangssituation
{
    /// <summary>
    /// Main class. Has nothing but the main function.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main function. Sends to Display.Choice() where the programm starts.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Display display = new Display();
            display.Choice();
        }
    }
}