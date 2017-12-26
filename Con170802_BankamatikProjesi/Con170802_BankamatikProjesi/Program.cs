using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con170802_BankamatikProjesi
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hareketler = null;
            string[] yedek = null;
            int bakiye = 600;
            int tutar;

        AnaMenü:
            Console.Clear();
            Console.WriteLine("\t \t \t \t 202 BANK \t \t \t \t");
            Console.WriteLine("1. Para Yatır");
            Console.WriteLine("2. Para Çek");
            Console.WriteLine("3. Hareketler");
            Console.WriteLine("4. Kart İade");
            Console.WriteLine("Yapmak İstediğiniz İşlemi Seçiniz Lütfen..");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                #region ParaYatırmaEkranı
                ParaYatir:
                    Console.Clear();
                    Console.WriteLine("Yatırmak İstediğiniz Tutarı Giriniz : ");
                    tutar = int.Parse(Console.ReadLine());
                    bakiye = bakiye + tutar;
                    if (hareketler == null)
                    {
                        hareketler = new string[1];
                        hareketler[0] = "+" + Convert.ToString(tutar) + "\t" + DateTime.Now.ToShortTimeString() + "\t" + DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        yedek = hareketler;
                        hareketler = new string[hareketler.Length + 1];
                        for (int i = 0; i < hareketler.Length - 1; i++)
                        {
                            hareketler[i] = yedek[i];
                        }
                        hareketler[hareketler.Length - 1] = "+" + Convert.ToString(tutar) + "\t" + DateTime.Now.ToShortTimeString() + "\t" + DateTime.Now.ToLongDateString();
                    }
                    Console.WriteLine("İşleminiz Gerçekleştirildi. Yeni Bakiyeniz : {0}", bakiye);
                    Console.WriteLine("Devam Etmek İstiyor musunuz? E / H");
                secim1:
                    string secim = Console.ReadLine();
                    if (secim == "e")
                    {
                        goto ParaYatir;
                    }
                    else if (secim == "h")
                    {
                        goto AnaMenü;
                    }
                    else
                        goto secim1; 
                #endregion

                case 2:
                #region ParaCekmeEkranı
                ParaCek:
                    Console.Clear();
                    Console.WriteLine("\t \t \t PARA ÇEK \t \t \t");
                    Console.Write("Çekmek İstediğiniz Para Tutarını Giriniz : ");
                    tutar = int.Parse(Console.ReadLine());
                    if (tutar > bakiye)
                    {
                        Console.WriteLine("Hesabınızda yeterli bakiye bulunmamaktadır.");
                        Console.WriteLine("Hesap Bakiyeniz : {0}", bakiye);
                        Console.WriteLine("Devam Etmek İstiyor musunuz? E / H");
                        string secim1 = Console.ReadLine();
                        if (secim1 == "e")
                        {
                            goto ParaCek;
                        }
                        else if (secim1 == "h")
                        {
                            goto AnaMenü;
                        }
                    }
                    else
                    {
                        bakiye = bakiye - tutar;
                        Console.WriteLine("İşleminiz gerçekleştirildi.Yeni Bakiyeniz : {0}", bakiye);
                        if (hareketler == null)
                        {
                            hareketler = new string[1];
                            hareketler[0] = "-" + "\t" + Convert.ToString(tutar) + "\t" + DateTime.Now.ToShortTimeString() + "\t" + DateTime.Now.ToLongDateString();
                        }
                        else
                        {
                            yedek = hareketler;
                            hareketler = new string[hareketler.Length + 1];
                            for (int i = 0; i < hareketler.Length - 1; i++)
                            {
                                hareketler[i] = yedek[i];
                            }
                            hareketler[hareketler.Length - 1] = "-" + Convert.ToString(tutar) + "\t" + DateTime.Now.ToShortTimeString() + "\t" + DateTime.Now.ToLongDateString();
                        }
                    }

                    Console.WriteLine("Devam Etmek İstiyor musunuz? E / H");
                secim2:
                    string secim2 = Console.ReadLine();

                    if (secim2 == "e")
                    {
                        goto ParaCek;
                    }
                    else if (secim2 == "h")
                    {
                        goto AnaMenü;
                    }
                    else
                        goto secim2; 
                #endregion

                case 3:
                #region HareketlerEkranı
                Hareketler:
                    Console.Clear();
                    Console.WriteLine("\t \t \t HAREKETLER \t \t \t");
                    if (hareketler == null)
                    {
                        Console.WriteLine("Herhangi bir işlem gerçekleştirmediniz..");
                    }
                    else
                    {
                        foreach (var item in hareketler)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Şuanki Bakiyeniz : {0}", bakiye);
                        Console.WriteLine("------------------------------------------------------------------");
                    }
                    Console.WriteLine("Devam Etmek İstiyor musunuz? E / H");
                    string secim3 = Console.ReadLine().ToLower();
                secim3:
                    if (secim3 == "e")
                    {
                        goto AnaMenü;
                    }
                    else if (secim3 == "h")
                    {
                        goto Kartİade;
                    }
                    else
                        goto secim3;                  
                #endregion

                case 4:
                #region KartİadeEkranı
                Kartİade:
                    Console.Clear();
                    Console.WriteLine("Lütfen Kartınızı Alınız..");
                    Console.ReadLine();
                    goto AnaMenü; 
                #endregion

                default:
                    goto AnaMenü;

                    
            }
            
        }
    }
}
