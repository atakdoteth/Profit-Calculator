using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Profit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();//creates calculator

        MainMenu:
            Console.Clear();

            Console.WriteLine("**************");
            Console.WriteLine("Main Menu!");
            Console.WriteLine();
            Console.WriteLine("1-Calculate Percantage by giving Start and End Values");
            Console.WriteLine("2-Calculate Profit with Starting and Percantage Values");
            Console.WriteLine("3-Amount to invest to get the Profit amount with your Percantage Value");
            Console.WriteLine("4-Calculates the Profit with Starting and End Values");
            Console.WriteLine("5-Calculates average buy point with Amount and Price Points");
            Console.WriteLine();
            Console.Write("What do you want to do?(Write the number):");
            int answer = int.Parse(Console.ReadLine());


            switch (answer)
            {
                case 1://Calculates percantage between start-end values
                    calculator.CalculatePercantage();
                    break;
                case 2://Calculates end value and profit with start value and percantage
                    calculator.PercantageToEndValue();
                    break;
                case 3://Calculates investing amount with your profit goal and return percantage
                    calculator.ProfitAmountToInvest();
                    break;
                case 4://Calculates profit from start-end value and asset value
                    calculator.CalculateProfit();
                    break;
                case 5://Calculates asset average asset value for asset amount
                    calculator.AssetAverage();
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
            string menuPromptAnswer = Console.ReadLine().ToUpper();
            if (menuPromptAnswer == "Y")//if yes
            {
                Console.WriteLine("Returning back to main menu!");
                goto MainMenu;
            }
            else if (menuPromptAnswer == "N")//if no
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

    public class Calculator//The class that have the methods
    {
        // NUMBER 1
        public void CalculatePercantage()//Percantage calculation by the diffrence between starting and end value
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
        public void PercantageToEndValue()//End value and profit calculation by starting value and percantage
        {
            Console.Write("Starting Value:");
            float start = float.Parse(Console.ReadLine());

            Console.Write("Percantage Value:");
            float percantage = float.Parse(Console.ReadLine());

            Console.Write("Leverage Value(If none write 1):");
            float leverage = float.Parse(Console.ReadLine());

            Console.Write("Asset Value(Use  , instead of . ):");
            float assetValue = float.Parse(Console.ReadLine());


            float realValue = (start * assetValue) / leverage;
            float profit = realValue * (percantage / 100);
            float end = profit + realValue;


            Console.WriteLine("Profit is: {0}", profit.ToString("F"));
            Console.WriteLine("End value is: {0}", end.ToString("F"));
        }


        //NUMBER 3
        public void ProfitAmountToInvest()//Calculating starting value to get the profit amount you want with your return percantage
        {
            float profit = float.Parse(Console.ReadLine());
            float percantage = float.Parse(Console.ReadLine());

            float invest = profit / percantage * 100;

            Console.WriteLine("You need to invest {0} to get {1} with {2} percantage return.", invest, profit, percantage);
        }

        //NUMBER 4
        public void CalculateProfit()//Calculating Profit-End value by start-end values and asset value
        {
            Console.Write("Starting Value:");
            float start = float.Parse(Console.ReadLine());

            Console.Write("End Value:");
            float end = float.Parse(Console.ReadLine());

            Console.Write("Asset Value(Use  , instead of . ):");
            float assetValue = float.Parse(Console.ReadLine());

            float percantage = ((end / start) - 1);
            float profit = start * assetValue * percantage;

            Console.WriteLine("Your profit is -> {0}", profit);

        }

        //NUMBER 5
        public void AssetAverage()//Calculates average of the asset value with asset amounts and buy prices
        {
            //Creating vars
            List<double> amount = new List<double>(), price = new List<double>();//lists to store amounts and price points 
            double sum = 0, avg=0;//sum of amount and avg price

            Console.Write("How many buy prices there are?:");
            int buyPriceAmount = int.Parse(Console.ReadLine());


            for (int i = 0; i < buyPriceAmount; i++)//Getting and saving prices and amounts
            {
                Console.Write("Asset Amount({0}):", i+1);
                amount.Add(double.Parse(Console.ReadLine()));

                Console.Write("Asset Buy Price({0}):", i+1);
                price.Add(double.Parse(Console.ReadLine()));

                Console.WriteLine();//Blank space between lines for ease of seeing
            }

            
            for(int i = 0; i<amount.Count; i++)//Finding total asset size
            {
                sum += amount[i];
            }

            for (int i = 0; i <price.Count; i++)//calculating avg
            {
                avg += (amount[i] / sum) * price[i];
            }

            Console.WriteLine("Total assets={0}", sum.ToString());
            Console.WriteLine("Average cost={0}", avg);
            Console.WriteLine("Total value={0}", sum * avg);


        }
    }
}

