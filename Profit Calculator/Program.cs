using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
        MainMenu:
            Console.Clear();

            Console.WriteLine("**************");
            Console.WriteLine("Main Menu!");
            Console.WriteLine("1-Calculate Percantage by giving Start and End Values");
            Console.WriteLine("2-Calculate Profit with Starting and Percantage Values");
            Console.WriteLine("3-Amount to invest to get the Profit amount with your Percantage Value");
            Console.Write("What do you want to do?(Write the number):");
            int answer = int.Parse(Console.ReadLine());


            switch (answer)
            {
                case 1://Calculates percantage between start-end values
                    Calculator.CalculatePercantage();
                    break;
                case 2://Calculates end value and profit with start value and percantage
                    Calculator.PercantageToEndValue();
                    break;
                case 3://Calculates investing amount with your profit goal and return percantage
                    Calculator.ProfitAmountToInvest();
                    break;

                default:
                    Console.WriteLine("Wrong input returning back to main menu!");
                    Console.ReadLine();
                    goto MainMenu;//returns back to main menu

            }

            //2 Lines of gap
            Console.WriteLine();
            Console.WriteLine();

            //Returning to main menu prompt
        MenuPrompt:
            Console.Write("Do you want to return to the main menu?(Y/N):");
            if(Console.ReadLine().ToUpper() == "Y")//if yes
            {
                Console.WriteLine("Returning back to main menu!");
                goto MainMenu;
            }
            else if(Console.ReadLine().ToUpper() == "N")//if no
            {
                Console.WriteLine("Have a great day!");
                Console.ReadLine();
            }
            else//wrong input
            {
                Console.WriteLine("Wrong input try again!");
                goto MenuPrompt;
            }


        }

    }

    public static class Calculator//The class that have the methods
    {
        // NUMBER 1
        public static void CalculatePercantage()//Percantage calculation by the diffrence between starting and end value
        {
            Console.Write("Starting Value:");
            float start = float.Parse(Console.ReadLine());

            Console.Write("End Value:");
            float end = float.Parse(Console.ReadLine());

            Console.Write("Leverage Value(If none write 1):");
            int leverage = int.Parse(Console.ReadLine());

            float percantage = ((end / start) - 1) * 100 * leverage;

            Console.WriteLine("Your profit percantage is {0}", percantage);
        }


        //NUMBER 2
        public static void PercantageToEndValue()//End value and profit calculation by
        {
            Console.Write("Starting Value:");
            float start = float.Parse(Console.ReadLine());

            Console.Write("Percantage Value:");
            float percantage = float.Parse(Console.ReadLine());

            Console.Write("Leverage Value(If none write 1):");
            float leverage = float.Parse(Console.ReadLine());

            Console.Write("Asset Value:");
            float assetValue = float.Parse(Console.ReadLine());

            float realValue = start * assetValue / leverage;
            float profit = realValue * percantage / 100;
            float end = profit + realValue;

            Console.WriteLine("Profit is: {0}", profit);
            Console.WriteLine("End value is: {0}", end);
        }


        //NUMBER 3
        public static void ProfitAmountToInvest()//Calculating starting value to get the profit amount you want with your percantage
        {
            float profit = float.Parse(Console.ReadLine());
            float percantage = float.Parse(Console.ReadLine());

            float invest = profit / percantage * 100;

            Console.WriteLine("You need to invest {0} to get {1} with {2} percantage return.",invest,profit,percantage);
        }

        
    }

}

