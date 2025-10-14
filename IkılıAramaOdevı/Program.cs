using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkılıAramaOdevı
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public static int IkılıArama(int[] dizi, int aranilanSayi)
        {
            int sol = 0;
            int sag = dizi.Length - 1;

            for (; sag >= sol;) 
            {
                int orta = sol + (sag - sol) / 2;

                if (dizi[orta] == aranilanSayi)
                    return orta; 

                else if (dizi[orta] > aranilanSayi)
                    sag = orta - 1;

                else
                    sol = orta + 1; 
            }

            return -1; 
        }

    }
}
    

