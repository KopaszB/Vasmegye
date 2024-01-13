using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vasmegye
{
    class SzuletesiAdatok
    {
        string M;
        string Eehhnn;
        string Sssk;

        struct Adat
        {
            public string M { get; set; }
            public string Eehhnn { get; set; }
            public string Sssk { get; set; }
        }

        public static void Main()
        {
            //2.feladat
            Console.WriteLine("2. feladat: Adatok beolvasása, tárolása");
            string sor;
            string[] elemek;
            List<Adat> szuladatok = new List<Adat>();

            using (StreamReader olvaso = new StreamReader("vas.txt"))
            {
                while ((sor = olvaso.ReadLine()) != null)
                {
                    elemek = sor.Split('-');
                    Adat ujadat = new Adat();
                    ujadat.M = elemek[0];
                    ujadat.Eehhnn = elemek[1];
                    ujadat.Sssk = elemek[2];
                    szuladatok.Add(ujadat);
                }
            }

            //4.feladat
            Console.WriteLine("4. feladat: Ellenőrzés");
            int hiba = 0;
            
            for (int i = 0; i < szuladatok.Count(); i++)
            {
                if (CvdEll(szuladatok[i].M, szuladatok[i].Eehhnn, szuladatok[i].Sssk) == false)
                {
                    Console.WriteLine($"        Hibás a {szuladatok[i].M}-{szuladatok[i].Eehhnn}-{szuladatok[i].Sssk} személyi azonosító!");
                    hiba++;
                }          
            }

            //5.feladat
            Console.WriteLine($"5. feladat: Vas megyében a vizsgált évek alatt {szuladatok.Count-hiba} gyerek született.");

            //6.feladat
            int fiuk = 0;
            for (int i = 0; i < szuladatok.Count(); i++)
            {
                if (CvdEll(szuladatok[i].M, szuladatok[i].Eehhnn, szuladatok[i].Sssk) == true)
                {
                    switch (szuladatok[i].M)
                    {
                        case "1" :
                        case "3" :  
                            fiuk++;
                            break;
                    }
                }
            }
            Console.WriteLine($"6. feladat: Fiúk száma: {fiuk}");

            //7.feladat
            int evszam;

            List<int> evszamok = new List<int>();
            
            for (int i = 0; i < szuladatok.Count(); i++)
            {
                if (CvdEll(szuladatok[i].M, szuladatok[i].Eehhnn, szuladatok[i].Sssk) == true)
                {
                    evszam = int.Parse(szuladatok[i].Eehhnn.Substring(0, 2));
                    if (evszam >= 0 && evszam < 97)
                    {
                        evszam = 2000 + evszam;
                         // pl: 2002
                    }
                    else 
                    {
                        evszam = 1900 + evszam; // pl: 1998
                    }
                    evszamok.Add(evszam);
                }
            }
            int min = evszamok.Min();
            int max = evszamok.Max();
            Console.WriteLine($"7. feladat: Vizsgált időszak: {min} - {max}");

            //8.feladat
            for (int i = 0; i < szuladatok.Count(); i++)
            {
                if (CvdEll(szuladatok[i].M, szuladatok[i].Eehhnn, szuladatok[i].Sssk) == true)
                {
                    int szokonap;
                    szokonap = int.Parse(szuladatok[i].Eehhnn.Substring(4));
                    evszam = int.Parse(szuladatok[i].Eehhnn.Substring(0, 2));
                    if (evszam == 0 && szokonap == 24)
                    {
                        Console.WriteLine($"8. feladat: Szökőnapon született baba!");
                        break;
                    }
                }
            }

            //9.feladat
            evszamok.Sort();
            int csere = evszamok[0];
            int szamlalo = 0;
            Console.WriteLine($"9. feladat: Statisztika:");
            for (int i = 0; i < evszamok.Count(); i++)
            {
                if (evszamok[i] == csere)
                {
                    szamlalo++;
                }
                else
                {
                    Console.WriteLine($"    {csere} - {szamlalo}");
                    csere = evszamok[i];
                    szamlalo = 1;
                }
            }
            Console.WriteLine($"    {csere} - {szamlalo}");













            Console.ReadKey();
        }
        
        // 3.feladat
        static bool CvdEll(string adat1, string adat2, string adat3)
        {
            string fuzer;
            int osszeg = 0;
            int k = 10;

            fuzer = string.Concat(adat1, adat2, adat3);
            char utolso = fuzer[fuzer.Length-1];
            int uszamjegy = utolso - '0';
          
            for (int i = 0; i < fuzer.Length - 1; i++)
            {
                osszeg = osszeg + k * (fuzer[i] - '0');              
                k--;
            }
            
            if (osszeg % 11 == uszamjegy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
 }

