using System;

namespace AnonymousSalaryComparison
{
    class Program
    {
        private static double GetDoubleNumericValue(int attempts = 3, double valueIfParseFails = 0.0)
        {
            Console.Write("Enter any numeric value:  ");
            string temp = "";
            double dblNum = valueIfParseFails;
            int n = 0; //the number of times the user has entered unrecognized values
            bool validEntry = false; //used to repeat opportunities to enter valid data
            while (!validEntry & n < attempts)
            {
                temp = Console.ReadLine();
                validEntry = double.TryParse(temp, out dblNum);
                if (!validEntry)
                {
                    n++;
                    if (n < attempts)
                    {
                        Console.Write("Sorry, we had trouble recognizing that as a numeric value. Please try again:  ");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, for demonstration purposes, we'll record that as the number {0}.", valueIfParseFails);
                        dblNum = valueIfParseFails; //set again because TryParse() converts "" to 0 even though it returns a false value
                    }
                }
            }
            return dblNum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Anonymous Income Comparison Program");
            Console.WriteLine();
            Console.WriteLine("Person 1");
            Console.Write("Hourly Rate?:  ");
            double rate1 = GetDoubleNumericValue(3, 12.50);
            Console.Write("Hours worked per week?:  ");
            double hours1 = GetDoubleNumericValue(3, 35.5);
            Console.WriteLine();
            Console.WriteLine("Person 2");
            Console.Write("Hourly Rate?:  ");
            double rate2 = GetDoubleNumericValue(3, 15.50);
            Console.Write("Hours worked per week?:  ");
            double hours2 = GetDoubleNumericValue(3, 40);
            Console.WriteLine();
            double salary1 = rate1 * hours1;
            double salary2 = rate2 * hours2;
            Console.WriteLine("Weekly salary of person 1:  " + salary1.ToString("C2"));
            Console.WriteLine("Weekly salary of person 2:  " + salary2.ToString("C2"));
            Console.WriteLine();
            if (salary1 > salary2)
            {
                Console.WriteLine("Person 1 earns the larger salary.");
            }
            else if (salary2 > salary1)
            {
                Console.WriteLine("Person 2 earns the larger salary.");
            }
            else
            {
                Console.WriteLine("Both people earn the same salary.");
            }
            Console.ReadLine();
        }
    }
}
