using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayilarinToplamiOdevi
{
    internal class Program
    {

        static void Main()
        {
            int[] sayi = { 44,21,35,17,88,99,12,13,27 };
            int top = 0;

            for (int i = 0; i < sayi.Length; i++)
            {
                top += sayi[i];
            }

            Console.WriteLine("Dizideki sayıların toplamı: " + top);
        }
    }
}

