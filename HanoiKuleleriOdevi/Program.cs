using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiKuleleriOdevi
{
    internal class Program
    {
        static long hareketSayisi = 0;

        static void Main(string[] args)
        {
            int diskSayisi = 3; // varsayilan
            if (args.Length > 0 && int.TryParse(args[0], out int parsed))
                diskSayisi = Math.Max(1, parsed);

            Console.WriteLine($"Disk sayisi: {diskSayisi}\n");

            BaslangicDurumuYaz(diskSayisi);

            Console.WriteLine("Hareketler:");
            Hanoi(diskSayisi, 'A', 'C', 'B');

            Console.WriteLine($"\nToplam hareket: {hareketSayisi}");
        }

        static void Hanoi(int n, char kaynak, char hedef, char yardimci)
        {
            if (n == 1)
            {
                hareketSayisi++;
                Console.WriteLine($"{hareketSayisi}. {kaynak} -> {hedef}");
                return;
            }

            Hanoi(n - 1, kaynak, yardimci, hedef);
            hareketSayisi++;
            Console.WriteLine($"{hareketSayisi}. {kaynak} -> {hedef}");
            Hanoi(n - 1, yardimci, hedef, kaynak);
        }

        static void BaslangicDurumuYaz(int n)
        {
            Console.WriteLine("Baslangic durumu (ustten alta kucukten buyuge):");
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"  Disk {i} - Cubuk A");
            }
            Console.WriteLine();
        }

    }
}
