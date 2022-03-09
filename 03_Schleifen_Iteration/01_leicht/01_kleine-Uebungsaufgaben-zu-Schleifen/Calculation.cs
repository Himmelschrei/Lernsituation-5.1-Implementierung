using System;
using System.Text.RegularExpressions;

namespace _01_kleine_Uebungsaufgaben_zu_Schleifen
{
    class Calculation
    {
        Display myDisplay = null;

        public Calculation(Display display)
        {
            myDisplay = display;
        }

        public bool checker(string s){
            bool isLetter = !String.IsNullOrEmpty(s) && Char.IsLetter(s[0]);
            
            return isLetter;
        }

        public string[] separator(string input)
        {
            Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
            Match result = re.Match(input);

            string alphaPart = result.Groups[1].Value;
            string numberPart = result.Groups[2].Value;

            if (alphaPart == null) {
                return new[]{"", numberPart};
            } else return new[] {alphaPart, numberPart};
        }

        public void doSeries1()
        {
            Console.WriteLine("1st series:");
            string s = myDisplay.GetSeries1();

            string[] arr;
            string abc, num;
            int x;

            bool check = checker(s);
            if (check == true) {
                arr = separator(s);
                abc = arr[0];
                num = arr[1];
                x = Convert.ToInt32(num);

                for (int i = 1; i <= 5; i++) 
                {
                    Console.Write("{0}{1} \t", abc, x);
                    x += 4;
                }
            } else {
                x = Convert.ToInt32(s);

                for (int i = 1; i <= 5; i++)
                {
                    Console.Write("{0} \t", x);
                    x += 4;
                }
            }            
        }

        public void doSeries2()
        {
            Console.WriteLine("2nd series:");
            string s = myDisplay.GetSeries2();

            string[] arr;
            string abc, num;
            int x;

            bool check = checker(s);
            if (check == true) {
                arr = separator(s);
                abc = arr[0];
                num = arr[1];
                x = Convert.ToInt32(num);

                for (int i = 1; i <= 7; i++) 
                {
                    Console.Write("{0}{1} \t", abc, x);
                    x -= 1;
                }
            } else {
                x = Convert.ToInt32(s);

                for (int i = 1; i <= 7; i++)
                {
                    Console.Write("{0} \t", x);
                    x -= 1;
                }
            }  
        }

        public void doSeries3()
        {
            Console.WriteLine("3rd series:");
            string s = myDisplay.GetSeries3();

            string[] arr;
            string abc, num;
            int x;

            bool check = checker(s);
            if (check == true) {
                arr = separator(s);
                abc = arr[0];
                num = arr[1];
                x = Convert.ToInt32(num);

                for (int i = 1; i <= 5; i++) 
                {
                    Console.Write("{0}{1} \t", abc, x);
                    x += 1000;
                }
            } else {
                x = Convert.ToInt32(s);

                for (int i = 1; i <= 5; i++)
                {
                    Console.Write("{0} \t", x);
                    x += 1000;
                }
            }  
        }

        public void doSeries4()
        {
            Console.WriteLine("4th series:");
            string s = myDisplay.GetSeries4();

            string[] arr;
            string abc, num;
            int x;

            bool check = checker(s);
            if (check == true) {
                arr = separator(s);
                abc = arr[0];
                num = arr[1];
                x = Convert.ToInt32(num);

                for (int i = 1; i <= 5; i++) 
                {
                    Console.Write("{0}{1} \t", abc, x);
                    x += 2;
                }
            } else {
                x = Convert.ToInt32(s);

                for (int i = 1; i <= 5; i++)
                {
                    Console.Write("{0} \t", x);
                    x += 2;
                }
            }  
        }

        public void doSeries5()
        {
            Console.WriteLine("5th series:");
            string s = myDisplay.GetSeries5();

            string[] arr;
            string abc, num;
            int x;

            bool check = checker(s);
            if (check == true) {
                arr = separator(s);
                abc = arr[0];
                num = arr[1];
                x = Convert.ToInt32(num);

                for (int i = 1; i <= 3; i++) 
                {
                    Console.Write("{0}{1} \t", abc, x);
                    x += 1;
                }
            } else {
                x = Convert.ToInt32(s);

                for (int i = 1; i <= 3; i++)
                {
                    Console.Write("{0} \t", x);
                    x += 1;
                }
            }  
        }

        public void doSeries6()
        {
            Console.WriteLine("6th series:");
            string s = myDisplay.GetSeries6();

            string[] arr;
            string abc, num;
            int x;

            bool check = checker(s);
            if (check == true) {
                arr = separator(s);
                abc = arr[0];
                num = arr[1];
                x = Convert.ToInt32(num);

                for (int i = 1; i <= 3; i++) 
                {
                    Console.Write("{0}{1} \t", abc, x);
                    x += 1;
                    Console.Write("{0}{1} \t", abc, x);
                    x += 9;
                }
            } else {
                x = Convert.ToInt32(s);

                for (int i = 1; i <= 3; i++)
                {
                    Console.Write("{0} \t", x);
                    x += 1;
                    Console.Write("{0} \t", x);
                    x += 9;
                }
            }  
        }

        public void doSeries7()
        {
            Console.WriteLine("7th series:");
            string s = myDisplay.GetSeries7();

            string[] arr;
            string abc, num;
            int x;

            bool check = checker(s);
            if (check == true) {
                arr = separator(s);
                abc = arr[0];
                num = arr[1];
                x = Convert.ToInt32(num);

                for (int i = 1; i <= 7; i++) 
                {
                    Console.Write("{0}{1} \t", abc, x);
                    if (x >= 20 && x <= 30) {
                        x += 12;
                    } else {
                        x += 4;
                    }
                }
            } else {
                x = Convert.ToInt32(s);

                for (int i = 1; i <= 7; i++)
                {
                    Console.Write("{0} \t", x);
                    if (x >= 20 && x <= 30) {
                        x += 12;
                    } else {
                        x += 4;
                    }
                }
            }  
        }
    }
}