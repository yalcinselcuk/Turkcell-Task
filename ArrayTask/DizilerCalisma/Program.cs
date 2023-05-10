using System.Reflection.Metadata.Ecma335;

namespace DizilerCalisma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dizi = new int[] {50, 20, 10, 40, 30 };
            dondur(dizi);
            Console.WriteLine();
            sirala(dizi);
            Console.WriteLine();
            dondur(dizi);
            Console.WriteLine();
            enBuyukSayiyiBul(dizi);
            enKucukSayiyiBul(dizi);
            diziElemanlariToplami(dizi);
            diziElemanlariOrtalamasi(dizi);

            void sirala(int[] dizi)
            {
                Array.Sort(dizi);
                Console.WriteLine("dizi siralandi");
            }
            void dondur(int[] dizi)
            {
                Console.WriteLine("Dizi Elemanları");
                for(int i = 0; i < dizi.Length; i++)
                {
                    Console.WriteLine(dizi[i]);
                }
            }
            void enBuyukSayiyiBul(int[] dizi)
            {
                int enBuyukSayi = dizi[0];

                for(int i = 1; i < dizi.Length; i++)
                {
                    if(enBuyukSayi < dizi[i])
                    {
                        enBuyukSayi = dizi[i];
                    }
                }
                Console.WriteLine($"Dizideki en buyuk sayi : {enBuyukSayi}");
            }
            void enKucukSayiyiBul(int[] dizi)
            {
                int enKucukSayi = dizi[0];

                for (int i = 1; i < dizi.Length; i++)
                {
                    if (enKucukSayi > dizi[i])
                    {
                        enKucukSayi = dizi[i];
                    }
                }
                Console.WriteLine($"Dizideki en buyuk sayi : {enKucukSayi}");
            }
            void diziElemanlariToplami(int[] dizi)
            {
                int toplam = 0;
                for (int i = 0; i < dizi.Length; i++)
                {
                    toplam += dizi[i];
                }
                Console.WriteLine($"Dizi elemanlarininn toplami : {toplam}");
            }
            void diziElemanlariOrtalamasi(int[] dizi)
            {
                int toplam = 0;
                for (int i = 0; i < dizi.Length; i++)
                {
                    toplam += dizi[i];
                }
                Console.WriteLine($"Dizi elemanlarinin ortalamasi : {toplam/dizi.Length}");
            }
        }
    }
}