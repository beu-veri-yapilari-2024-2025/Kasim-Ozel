using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkiYonluLinkedListYapisi
{
        public class Dugum
        {
            public int veri;
            public Dugum onceki;
            public Dugum sonraki;

            public Dugum(int veri)
            {
                this.veri = veri;
                onceki = null;
                sonraki = null;
            }
        }

        public class IkiYonluBagliListe
        {
            private Dugum bas;
            private Dugum son;

            public IkiYonluBagliListe()
            {
                bas = null;
                son = null;
            }

            public void BasaEkle(int veri)
            {
                Dugum yeni = new Dugum(veri);
                if (bas == null)
                {
                    bas = son = yeni;
                }
                else
                {
                    yeni.sonraki = bas;
                    bas.onceki = yeni;
                    bas = yeni;
                }
            }

            public void SonaEkle(int veri)
            {
                Dugum yeni = new Dugum(veri);
                if (son == null)
                {
                    bas = son = yeni;
                }
                else
                {
                    son.sonraki = yeni;
                    yeni.onceki = son;
                    son = yeni;
                }
            }

            public void ArayaSonraEkle(int hedef, int veri)
            {
                Dugum temp = bas;
                while (temp != null && temp.veri != hedef)
                    temp = temp.sonraki;

                if (temp == null)
                {
                    Console.WriteLine("Hedef veri bulunamadı.");
                    return;
                }

                Dugum yeni = new Dugum(veri);
                yeni.sonraki = temp.sonraki;
                yeni.onceki = temp;
                if (temp.sonraki != null)
                    temp.sonraki.onceki = yeni;
                else
                    son = yeni;
                temp.sonraki = yeni;
            }

            public void ArayaOnceEkle(int hedef, int veri)
            {
                Dugum temp = bas;
                while (temp != null && temp.veri != hedef)
                    temp = temp.sonraki;

                if (temp == null)
                {
                    Console.WriteLine("Hedef veri bulunamadı.");
                    return;
                }

                Dugum yeni = new Dugum(veri);
                yeni.sonraki = temp;
                yeni.onceki = temp.onceki;
                if (temp.onceki != null)
                    temp.onceki.sonraki = yeni;
                else
                    bas = yeni;
                temp.onceki = yeni;
            }

            public void BastanSil()
            {
                if (bas == null) return;

                bas = bas.sonraki;
                if (bas != null) bas.onceki = null;
                else son = null;
            }

            public void SondanSil()
            {
                if (son == null) return;

                son = son.onceki;
                if (son != null) son.sonraki = null;
                else bas = null;
            }

            public void AradanSil(int veri)
            {
                Dugum temp = bas;
                while (temp != null && temp.veri != veri)
                    temp = temp.sonraki;

                if (temp == null) return;

                if (temp.onceki != null)
                    temp.onceki.sonraki = temp.sonraki;
                else
                    bas = temp.sonraki;

                if (temp.sonraki != null)
                    temp.sonraki.onceki = temp.onceki;
                else
                    son = temp.onceki;
            }

            public bool Ara(int veri)
            {
                Dugum temp = bas;
                while (temp != null)
                {
                    if (temp.veri == veri) return true;
                    temp = temp.sonraki;
                }
                return false;
            }

            public void Listele()
            {
                Dugum temp = bas;
                Console.Write("Liste: ");
                while (temp != null)
                {
                    Console.Write(temp.veri + " <-> ");
                    temp = temp.sonraki;
                }
                Console.WriteLine("null");
            }

            public void TumunuSil()
            {
                bas = null;
                son = null;
            }

            public int[] DiziyeDonustur()
            {
                List<int> liste = new List<int>();
                Dugum temp = bas;
                while (temp != null)
                {
                    liste.Add(temp.veri);
                    temp = temp.sonraki;
                }
                return liste.ToArray();
            }
        }

        class Program
        {
            static void Main()
            {
                IkiYonluBagliListe liste = new IkiYonluBagliListe();
                int secim;

                do
                {
                    Console.WriteLine("\n--- İKİ YÖNLÜ BAĞLI LİSTE MENÜ ---");
                    Console.WriteLine("1- Başa ekleme");
                    Console.WriteLine("2- Sona ekleme");
                    Console.WriteLine("3- Araya (sonra) ekleme");
                    Console.WriteLine("4- Araya (önce) ekleme");
                    Console.WriteLine("5- Baştan silme");
                    Console.WriteLine("6- Sondan silme");
                    Console.WriteLine("7- Aradan silme");
                    Console.WriteLine("8- Arama");
                    Console.WriteLine("9- Listeleme");
                    Console.WriteLine("10- Tümünü silme");
                    Console.WriteLine("11- Listeyi diziye dönüştürme");
                    Console.WriteLine("0- Çıkış");
                    Console.Write("Seçiminiz: ");
                    secim = int.Parse(Console.ReadLine());

                    switch (secim)
                    {
                        case 1:
                            Console.Write("Veri: ");
                            liste.BasaEkle(int.Parse(Console.ReadLine()));
                            break;
                        case 2:
                            Console.Write("Veri: ");
                            liste.SonaEkle(int.Parse(Console.ReadLine()));
                            break;
                        case 3:
                            Console.Write("Hedef veri: ");
                            int hedef1 = int.Parse(Console.ReadLine());
                            Console.Write("Yeni veri: ");
                            int veri1 = int.Parse(Console.ReadLine());
                            liste.ArayaSonraEkle(hedef1, veri1);
                            break;
                        case 4:
                            Console.Write("Hedef veri: ");
                            int hedef2 = int.Parse(Console.ReadLine());
                            Console.Write("Yeni veri: ");
                            int veri2 = int.Parse(Console.ReadLine());
                            liste.ArayaOnceEkle(hedef2, veri2);
                            break;
                        case 5:
                            liste.BastanSil();
                            break;
                        case 6:
                            liste.SondanSil();
                            break;
                        case 7:
                            Console.Write("Silinecek veri: ");
                            liste.AradanSil(int.Parse(Console.ReadLine()));
                            break;
                        case 8:
                            Console.Write("Aranacak veri: ");
                            Console.WriteLine(liste.Ara(int.Parse(Console.ReadLine())) ? "Veri bulundu." : "Veri yok.");
                            break;
                        case 9:
                            liste.Listele();
                            break;
                        case 10:
                            liste.TumunuSil();
                            Console.WriteLine("Liste temizlendi.");
                            break;
                        case 11:
                            int[] dizi = liste.DiziyeDonustur();
                            Console.WriteLine("Dizi: [" + string.Join(", ", dizi) + "]");
                            break;
                    }

                } while (secim != 0);
            }
        }
    
}

