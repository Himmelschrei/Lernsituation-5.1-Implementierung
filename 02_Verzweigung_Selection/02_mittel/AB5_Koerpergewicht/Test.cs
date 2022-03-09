using System;

class Test
{
    public static void Main()
    {
        //Instanzierung der Klasse
        Random r = new Random();   

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("{0} -> {1}", i, rand.Next(0, 20));
        }
    }
}