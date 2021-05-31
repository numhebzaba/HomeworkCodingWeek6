using System;

namespace Homework_week6_No2
{
    class Program
    {
       struct shopdata
        {
            public double cost;
            public string note;
        }
        static void Main(string[] args)
        {
            Console.Write("Input number of shops : ");
            int numberOfshop = int.Parse(Console.ReadLine());
            shopdata[] arrayNumberOfShop = new shopdata[numberOfshop];

            double minCost = double.PositiveInfinity;
            int shopNo = 0;
            string minNote = "None";
            
            for(int i = 0; i < numberOfshop; i++)
            {
                Console.Write("Shop No."+(i+1)+" cost : ");
                arrayNumberOfShop[i].cost = double.Parse(Console.ReadLine());
                Console.Write("Note : ");
                arrayNumberOfShop[i].note = Console.ReadLine();

                if (arrayNumberOfShop[i].cost < minCost)
                {
                    minCost = arrayNumberOfShop[i].cost;
                    minNote = arrayNumberOfShop[i].note;
                    shopNo = i;
                }

                
            }
            Console.WriteLine("The cheapest shop is {0}" ,shopNo+1);
            Console.WriteLine("Cost : {0}", minCost);
            Console.WriteLine("Note : {0}", minNote);
        }
        

    }
}
