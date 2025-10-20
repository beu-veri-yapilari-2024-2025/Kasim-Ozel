using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListOdevi_2
{
    class Node
    {
        public string Ad;
        public string Soyad;
        public int Numara;
        public Node Next;

        public Node(string ad, string soyad, int numara)
        {
            Ad = ad;
            Soyad = soyad;
            Numara = numara;
            Next = null;
        }
    }

    class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            head = null;
        }

        // Listenin başına ekleme
        public void BasaEkle(string ad, string soyad, int numara)
        {
            Node yeni = new Node(ad, soyad, numara);
            yeni.Next = head;
            head = yeni;
        }

        // Listenin sonuna ekleme
        public void SonaEkle(string ad, string soyad, int numara)
        {
            Node yeni = new Node(ad, soyad, numara);
            if (head == null)
            {
                head = yeni;
                return;
            }

            Node temp = head;
            while (temp.Next != null)
                temp = temp.Next;
            temp.Next = yeni;
        }

        // Belirtilen numaradan SONRASINA ekleme
        public void SonrasinaEkle(int hedefNumara, string ad, string soyad, int numara)
        {
            Node temp = head;
            while (temp != null && temp.Numara != hedefNumara)
                temp = temp.Next;

            if (temp == null)
            {
                Console.WriteLine("Belirtilen numara bulunamadı!");
                return;
            }

            Node yeni = new Node(ad, soyad, numara);
            yeni.Next = temp.Next;
            temp.Next = yeni;
        }

        // Belirtilen numaradan ÖNCESİNE ekleme
        public void OncesineEkle(int hedefNumara, string ad, string soyad, int numara)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş!");
                return;
            }

            if (head.Numara == hedefNumara)
            {
                BasaEkle(ad, soyad, numara);
                return;
            }

            Node temp = head;
            while (temp.Next != null && temp.Next.Numara != hedefNumara)
                temp = temp.Next;

            if (temp.Next == null)
            {
                Console.WriteLine("Belirtilen numara bulunamadı!");
                return;
            }

            Node yeni = new Node(ad, soyad, numara);
            yeni.Next = temp.Next;
            temp.Next = yeni;
        }

        // Baştan silme
        public void BastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş!");
                return;
            }
            head = head.Next;
        }

        // Sondan silme
        public void SondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş!");
                return;
            }

            if (head.Next == null)
            {
                head = null;
                return;
            }

            Node temp = head;
            while (temp.Next.Next != null)
                temp = temp.Next;

            temp.Next = null;
        }

        // Belirtilen numarayı silme
        public void NumaraIleSil(int numara)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş!");
                return;
            }

            if (head.Numara == numara)
            {
                head = head.Next;
                return;
            }

            Node temp = head;
            while (temp.Next != null && temp.Next.Numara != numara)
                temp = temp.Next;

            if (temp.Next == null)
            {
                Console.WriteLine("Belirtilen numara bulunamadı!");
                return;
            }

            temp.Next = temp.Next.Next;
        }

        // Arama
        public void Ara(int numara)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Numara == numara)
                {
                    Console.WriteLine($"Bulundu: {temp.Ad} {temp.Soyad} - {temp.Numara}");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Öğrenci bulunamadı!");
        }

        // Listeleme
        public void Listele()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş!");
                return;
            }

            Node temp = head;
            Console.WriteLine("---- Öğrenci Listesi ----");
            while (temp != null)
            {
                Console.WriteLine($"{temp.Ad} {temp.Soyad} - {temp.Numara}");
                temp = temp.Next;
            }
        }

        // Kullanıcıdan değer alarak ekleme
        public void KullaniciEkle()
        {
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            Console.Write("Numara: ");
            int numara = int.Parse(Console.ReadLine());

            SonaEkle(ad, soyad, numara);
            Console.WriteLine("Öğrenci listeye eklendi!");
        }
    }

    class Program
    {
        static void Main()
        {
            LinkedList liste = new LinkedList();
            int secim;

            do
            {
                Console.WriteLine("\n--- LINKED LIST MENÜ ---");
                Console.WriteLine("1 - Baştan Ekle");
                Console.WriteLine("2 - Sondan Ekle");
                Console.WriteLine("3 - Sonrasına Ekle");
                Console.WriteLine("4 - Öncesine Ekle");
                Console.WriteLine("5 - Baştan Sil");
                Console.WriteLine("6 - Sondan Sil");
                Console.WriteLine("7 - Belirli Numarayı Sil");
                Console.WriteLine("8 - Ara");
                Console.WriteLine("9 - Listele");
                Console.WriteLine("10 - Kullanıcıdan Öğrenci Ekle");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz: ");
                secim = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (secim)
                {
                    case 1:
                        Console.Write("Ad: "); string ad1 = Console.ReadLine();
                        Console.Write("Soyad: "); string soyad1 = Console.ReadLine();
                        Console.Write("Numara: "); int no1 = int.Parse(Console.ReadLine());
                        liste.BasaEkle(ad1, soyad1, no1);
                        break;

                    case 2:
                        Console.Write("Ad: "); string ad2 = Console.ReadLine();
                        Console.Write("Soyad: "); string soyad2 = Console.ReadLine();
                        Console.Write("Numara: "); int no2 = int.Parse(Console.ReadLine());
                        liste.SonaEkle(ad2, soyad2, no2);
                        break;

                    case 3:
                        Console.Write("Ekleme yapılacak numara: "); int hedef1 = int.Parse(Console.ReadLine());
                        Console.Write("Yeni Ad: "); string ad3 = Console.ReadLine();
                        Console.Write("Yeni Soyad: "); string soyad3 = Console.ReadLine();
                        Console.Write("Yeni Numara: "); int no3 = int.Parse(Console.ReadLine());
                        liste.SonrasinaEkle(hedef1, ad3, soyad3, no3);
                        break;

                    case 4:
                        Console.Write("Ekleme yapılacak numara: "); int hedef2 = int.Parse(Console.ReadLine());
                        Console.Write("Yeni Ad: "); string ad4 = Console.ReadLine();
                        Console.Write("Yeni Soyad: "); string soyad4 = Console.ReadLine();
                        Console.Write("Yeni Numara: "); int no4 = int.Parse(Console.ReadLine());
                        liste.OncesineEkle(hedef2, ad4, soyad4, no4);
                        break;

                    case 5:
                        liste.BastanSil();
                        break;

                    case 6:
                        liste.SondanSil();
                        break;

                    case 7:
                        Console.Write("Silinecek numara: "); int silNo = int.Parse(Console.ReadLine());
                        liste.NumaraIleSil(silNo);
                        break;

                    case 8:
                        Console.Write("Aranacak numara: "); int araNo = int.Parse(Console.ReadLine());
                        liste.Ara(araNo);
                        break;

                    case 9:
                        liste.Listele();
                        break;

                    case 10:
                        liste.KullaniciEkle();
                        break;

                    case 0:
                        Console.WriteLine("Programdan çıkılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }

            } while (secim != 0);
        }
    }
}
