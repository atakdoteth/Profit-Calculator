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
        
        }

    }

    public static class Calculator
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

