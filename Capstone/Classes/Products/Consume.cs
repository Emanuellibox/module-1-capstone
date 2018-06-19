using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public static class Consume
    {
        public static void ConsumeSnacks(int numberOfChips, int numberOfCandy, int numberOfDrinks, int numberOfGumSticks)
        {
            for (var i = 1; i <= numberOfChips; i++)
            {
                Console.WriteLine("Crunch Crunch, Yum!");
                Console.WriteLine();
            }

            Console.WriteLine();

            for (var i = 1; i <= numberOfCandy; i++)
            {
                Console.WriteLine("Munch Munch, Yum!");
                Console.WriteLine();
            }

            Console.WriteLine();

            for (var i = 1; i <= numberOfDrinks; i++)
            {
                Console.WriteLine("Glug Glug, Yum!");
                Console.WriteLine();
            }

            for (var i = 1; i <= numberOfGumSticks; i++)
            {
                Console.WriteLine("Chew Chew, Yum!");
                Console.WriteLine();
            }
        }

    }
}
