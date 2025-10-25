using System;
using System.Collections.Generic;

namespace CokluBagliListe
{
    // ÖğrenciDersNode: Öğrenci ve ders bilgisini tutan düğüm
    public class OgrenciDersNode
    {
        public int ogrenciNumara;      // Öğrenci numarası
        public string dersKodu;        // Dersin kodu
        public string harfNotu;        // Dersin harf notu
        public OgrenciDersNode sonrakiOgrenci; // Aynı dersteki bir sonraki öğrenci
        public OgrenciDersNode sonrakiDers;    // Aynı öğrencinin diğer dersi

        public OgrenciDersNode(int ogrenciNumara, string dersKodu, string harfNotu)
        {
            this.ogrenciNumara = ogrenciNumara;
            this.dersKodu = dersKodu;
            this.harfNotu = harfNotu;
            sonrakiOgrenci = null;
            sonrakiDers = null;
        }
    }

    // DersNode: Her dersin başını tutar
    public class DersNode
    {
        public string dersKodu;
        public OgrenciDersNode ogrenciBas;
        public DersNode sonrakiDers;

        public DersNode(string dersKodu)
        {
            this.dersKodu = dersKodu;
            ogrenciBas = null;
            sonrakiDers = null;
        }
    }

    // OgrenciNode: Her öğrencinin başını tutar
    public class OgrenciNode
    {
        public int ogrenciNumara;
        public OgrenciDersNode dersBas;
        public OgrenciNode sonrakiOgrenci;

        public OgrenciNode(int ogrenciNumara)
        {
            this.ogrenciNumara = ogrenciNumara;
            dersBas = null;
            sonrakiOgrenci = null;
        }
    }

    // Ana bağlı liste yapısı
    public class CokluBagliListe
    {
        public OgrenciNode ogrenciBas;
        public DersNode dersBas;

        public CokluBagliListe()
        {
            ogrenciBas = null;
            dersBas = null;
        }

        // 1 - Bir öğrenciye yeni bir ders ekleme
        public void OgrenciyeDersEkle(int ogrenciNumara, string dersKodu, string harfNotu)
        {
            OgrenciNode ogrenci = OgrenciBulVeyaEkle(ogrenciNumara);
            DersNode ders = DersBulVeyaEkle(dersKodu);

            OgrenciDersNode yeni = new OgrenciDersNode(ogrenciNumara, dersKodu, harfNotu);

            // Öğrencinin ders listesine ekle
            yeni.sonrakiDers = ogrenci.dersBas;
            ogrenci.dersBas = yeni;

            // Dersin öğrenci listesine ekle
            yeni.sonrakiOgrenci = ders.ogrenciBas;
            ders.ogrenciBas = yeni;
        }

        // 2 - Bir derse yeni bir öğrenci ekleme
        public void DerseOgrenciEkle(string dersKodu, int ogrenciNumara, string harfNotu)
        {
            OgrenciyeDersEkle(ogrenciNumara, dersKodu, harfNotu);
        }

        // 3 - Bir öğrencinin bir dersini silme
        public void OgrencininDersiniSil(int ogrenciNumara, string dersKodu)
        {
            OgrenciNode ogrenci = ogrenciBas;
            while (ogrenci != null && ogrenci.ogrenciNumara != ogrenciNumara)
                ogrenci = ogrenci.sonrakiOgrenci;

            if (ogrenci == null) return;

            OgrenciDersNode onceki = null, simdiki = ogrenci.dersBas;
            while (simdiki != null && simdiki.dersKodu != dersKodu)
            {
                onceki = simdiki;
                simdiki = simdiki.sonrakiDers;
            }

            if (simdiki == null) return;

            if (onceki == null) ogrenci.dersBas = simdiki.sonrakiDers;
            else onceki.sonrakiDers = simdiki.sonrakiDers;
        }

        // 4 - Bir dersteki bir öğrenciyi silme
        public void DerstekiOgrenciyiSil(string dersKodu, int ogrenciNumara)
        {
            DersNode ders = dersBas;
            while (ders != null && ders.dersKodu != dersKodu)
                ders = ders.sonrakiDers;

            if (ders == null) return;

            OgrenciDersNode onceki = null, simdiki = ders.ogrenciBas;
            while (simdiki != null && simdiki.ogrenciNumara != ogrenciNumara)
            {
                onceki = simdiki;
                simdiki = simdiki.sonrakiOgrenci;
            }

            if (simdiki == null) return;

            if (onceki == null) ders.ogrenciBas = simdiki.sonrakiOgrenci;
            else onceki.sonrakiOgrenci = simdiki.sonrakiOgrenci;
        }

        // 5 - Bir dersteki tüm öğrencileri numara sırasına göre listeleme
        public void DerstekiOgrencileriListele(string dersKodu)
        {
            DersNode ders = dersBas;
            while (ders != null && ders.dersKodu != dersKodu)
                ders = ders.sonrakiDers;

            if (ders == null)
            {
                Console.WriteLine("Ders bulunamadı.");
                return;
            }

            List<OgrenciDersNode> liste = new List<OgrenciDersNode>();
            OgrenciDersNode temp = ders.ogrenciBas;
            while (temp != null)
            {
                liste.Add(temp);
                temp = temp.sonrakiOgrenci;
            }

            liste.Sort((a, b) => a.ogrenciNumara.CompareTo(b.ogrenciNumara));

            Console.WriteLine($"Ders: {dersKodu} öğrencileri:");
            foreach (var x in liste)
                Console.WriteLine($"Numara: {x.ogrenciNumara}, Harf: {x.harfNotu}");
        }

        // 6 - Bir öğrencinin aldığı tüm dersleri ders koduna göre listeleme
        public void OgrencininDersleriniListele(int ogrenciNumara)
        {
            OgrenciNode ogrenci = ogrenciBas;
            while (ogrenci != null && ogrenci.ogrenciNumara != ogrenciNumara)
                ogrenci = ogrenci.sonrakiOgrenci;

            if (ogrenci == null)
            {
                Console.WriteLine("Öğrenci bulunamadı.");
                return;
            }

            List<OgrenciDersNode> liste = new List<OgrenciDersNode>();
            OgrenciDersNode temp = ogrenci.dersBas;
            while (temp != null)
            {
                liste.Add(temp);
                temp = temp.sonrakiDers;
            }

            liste.Sort((a, b) => a.dersKodu.CompareTo(b.dersKodu));

            Console.WriteLine($"Öğrenci {ogrenciNumara} dersleri:");
            foreach (var x in liste)
                Console.WriteLine($"Ders: {x.dersKodu}, Harf: {x.harfNotu}");
        }

        // Yardımcı metotlar
        private OgrenciNode OgrenciBulVeyaEkle(int numara)
        {
            OgrenciNode temp = ogrenciBas, onceki = null;
            while (temp != null && temp.ogrenciNumara != numara)
            {
                onceki = temp;
                temp = temp.sonrakiOgrenci;
            }

            if (temp == null)
            {
                OgrenciNode yeni = new OgrenciNode(numara);
                if (ogrenciBas == null) ogrenciBas = yeni;
                else onceki.sonrakiOgrenci = yeni;
                return yeni;
            }
            return temp;
        }

        private DersNode DersBulVeyaEkle(string kod)
        {
            DersNode temp = dersBas, onceki = null;
            while (temp != null && temp.dersKodu != kod)
            {
                onceki = temp;
                temp = temp.sonrakiDers;
            }

            if (temp == null)
            {
                DersNode yeni = new DersNode(kod);
                if (dersBas == null) dersBas = yeni;
                else onceki.sonrakiDers = yeni;
                return yeni;
            }
            return temp;
        }
    }

    class Program
    {
        static void Main()
        {
            CokluBagliListe liste = new CokluBagliListe();
            while (true)
            {
                Console.WriteLine("\n1- Öğrenciye ders ekle" +
                                  "\n2- Derse öğrenci ekle" +
                                  "\n3- Öğrencinin dersini sil" +
                                  "\n4- Dersteki öğrenciyi sil" +
                                  "\n5- Dersteki öğrencileri listele" +
                                  "\n6- Öğrencinin derslerini listele" +
                                  "\n0- Çıkış");
                Console.Write("Seçim: ");
                int secim = int.Parse(Console.ReadLine());
                if (secim == 0) break;

                switch (secim)
                {
                    case 1:
                        Console.Write("Öğrenci numarası: ");
                        int no1 = int.Parse(Console.ReadLine());
                        Console.Write("Ders kodu: ");
                        string kod1 = Console.ReadLine();
                        Console.Write("Harf notu: ");
                        string not1 = Console.ReadLine();
                        liste.OgrenciyeDersEkle(no1, kod1, not1);
                        break;
                    case 2:
                        Console.Write("Ders kodu: ");
                        string kod2 = Console.ReadLine();
                        Console.Write("Öğrenci numarası: ");
                        int no2 = int.Parse(Console.ReadLine());
                        Console.Write("Harf notu: ");
                        string not2 = Console.ReadLine();
                        liste.DerseOgrenciEkle(kod2, no2, not2);
                        break;
                    case 3:
                        Console.Write("Öğrenci numarası: ");
                        int no3 = int.Parse(Console.ReadLine());
                        Console.Write("Ders kodu: ");
                        string kod3 = Console.ReadLine();
                        liste.OgrencininDersiniSil(no3, kod3);
                        break;
                    case 4:
                        Console.Write("Ders kodu: ");
                        string kod4 = Console.ReadLine();
                        Console.Write("Öğrenci numarası: ");
                        int no4 = int.Parse(Console.ReadLine());
                        liste.DerstekiOgrenciyiSil(kod4, no4);
                        break;
                    case 5:
                        Console.Write("Ders kodu: ");
                        string kod5 = Console.ReadLine();
                        liste.DerstekiOgrencileriListele(kod5);
                        break;
                    case 6:
                        Console.Write("Öğrenci numarası: ");
                        int no6 = int.Parse(Console.ReadLine());
                        liste.OgrencininDersleriniListele(no6);
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim.");
                        break;
                }
            }
        }
    }
}