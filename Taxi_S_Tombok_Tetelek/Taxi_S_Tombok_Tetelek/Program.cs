using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_S_Tombok_Tetelek
{
    class Program
    {
        static string[] FuvarozoTMB = new string[17];
        static int[] BevetelTMB = new int[17];
        static int[] KoltsegTMB = new int[17];
        static int[] BorravaloTMB = new int[17];
        static int[] NyeresegTMB= new int[17];
        static void Main(string[] args)
        {
            Feladat1(); Console.WriteLine("\n------------------------------------------\n");
            Feladat2(); Console.WriteLine("\n------------------------------------------\n");
            Feladat3(); Console.WriteLine("\n------------------------------------------\n");
            Feladat4(); Console.WriteLine("\n------------------------------------------\n");
            Feladat5(); Console.WriteLine("\n------------------------------------------\n");
            Feladat6();
            Console.ReadKey();
        }

        private static void Feladat6()
        {
            Console.WriteLine("Feladat 6: Írjon kereső programot mely rákeres egy adott személy nevére. A keresés során ha nem találja meg az adott"+
                "személyt írja ki a program nincs ilyen személy a nevek között.Ha megtalálja a keresett személyt akkor a program"+
                "írja ki a rá vonatkozó összes információt(név, bevétel, kiadás, borravaló)");

            Console.Write("\n\tKérem adja meg a keresett személy nevét: ");
            string KeresettFuvarozo = Console.ReadLine().ToLower().Replace(" ", "");
            int Szamlalo = 0;
            while(Szamlalo<17 && KeresettFuvarozo!=FuvarozoTMB[Szamlalo].ToLower().Replace(" ", ""))
            {
                Szamlalo++;
            }
            if(Szamlalo==17)
            {
                Console.WriteLine("\n\tSajnos nincs ilyen fuvaros a listában");
            }
            else 
            {
                Console.WriteLine("\n\tVan ilyen személy az adataink között\n\t{0,-25} -> bevétele: {1} -> kiadása: {2} -> borravaloja: {3}", FuvarozoTMB[Szamlalo],
                    BevetelTMB[Szamlalo],KoltsegTMB[Szamlalo], BorravaloTMB[Szamlalo]);
            }
        }

        private static void Feladat5()
        {
            Console.WriteLine("Feladat 5: Számítsa ki mekkora bevételek átlaga és hány személy van akinek átlag feletti a bevétele."+"" +
                " (Külön számolja ki az átlagot és számlálja le az átlag feletti személyek számát)");
            double Osszbevetel = 0;
            double AtlagBevetel = 0;
            for (int i = 0; i < 17; i++)
            {
                Osszbevetel += BevetelTMB[i];
            }
            AtlagBevetel = (double)Osszbevetel / BevetelTMB.Length;
            Console.WriteLine("\tA fuvarosok átlag bevétele: {0:0.00}",AtlagBevetel);
            int dbFeletti = 0;
            for (int i = 0; i < 17; i++)
            {
                if(BevetelTMB[i]>AtlagBevetel)
                {
                    dbFeletti++;
                }

            }
            Console.WriteLine("\n\tEnnyi személynek volt átlag feletti a betétele: {0}", dbFeletti);
        }

        private static void Feladat4()
        {
            Console.WriteLine("Feladat 4: Írjon programot, mely meghatározza hány olyan személy volt akinek a borravalója 125 peták fölötti volt");
            int db = 0;
            for (int i = 0; i < 17; i++)
            {
                if(BorravaloTMB[i]>125)
                { 
                    db++;
                }
            }
            Console.WriteLine("\tEnnyi személy borravalója volt 125 peták felett: {0}", db);

        }

        private static void Feladat3()
        {
            Console.WriteLine("Feladat 3: Határozza meg ki volt az a taxis, aki a legtöbb bevételre tett szert, " +
                "illetve azt a személyt is akinek a legkevesebb"+
                "volt kiadása.Számítsa ki a két érték különbségét.Minden adatot külön írasson ki a konzolra.");
            int MinimumKTG = int.MaxValue;
            string MinimumKTGFuvarozo = "cica";//ez az én rossz szokásom te nyugodtan használs szóközt vagy valami mást
            int MaxBevetel = int.MinValue;
            string MaxBevFuvarozo = "kutya";//ez az én rossz szokásom te nyugodtan használs szóközt vagy valami mást
            for (int i = 0; i < 17; i++)
            {
                if(KoltsegTMB[i]<MinimumKTG)
                {
                    MinimumKTG = KoltsegTMB[i];
                    MinimumKTGFuvarozo = FuvarozoTMB[i];
                }
                if(MaxBevetel<BevetelTMB[i])
                {
                    MaxBevetel = BevetelTMB[i];
                    MaxBevFuvarozo = FuvarozoTMB[i];
                }
            }
            Console.WriteLine("\tA legkisebb költséggel ez a személy fuvarozott: {0}\n\tKöltsége: {1}",MinimumKTGFuvarozo,MinimumKTG);
            Console.WriteLine("\n");
            Console.WriteLine("\tA legnagyobbbb bevétellel ez a személy fuvarozott: {0}\n\tBevétele: {1}", MaxBevFuvarozo, MaxBevetel);
            int Kulonbseg = MaxBevetel-MinimumKTG;
            Console.WriteLine("\nA két éték különbsége: {0}", Kulonbseg);
        }

        private static void Feladat2()
        {
            Console.WriteLine("Feladat 2: Nyereség kiszámítása tárolása");
            int Nyereseg = 0;
            for (int i = 0; i < 17; i++)
            {
                Nyereseg = BevetelTMB[i] - KoltsegTMB[i] + BorravaloTMB[i];
                Console.WriteLine("\t{0,-25} : {1} ", FuvarozoTMB[i], Nyereseg);
                NyeresegTMB[i] = Nyereseg;
            }
            Console.WriteLine("\nEllenőrzés");
            for (int i = 0; i < 17; i++)
            {
                Console.WriteLine("\t{0,-25} : {1} ",FuvarozoTMB[i],NyeresegTMB[i]);
            }
        }

        private static void Feladat1()
        {
            Console.WriteLine("Feladat 1: adatok feltöltése");
            FuvarozoTMB = new string[17] { "Apród Adrián", "László Péter", "Pataki Olivér", "Juhász Dániel",
                "Varga Gábor", "Bodnár Benedek", "Bács Bence", "Barta Csaba", "Fekete Ábel", "Vászoly András", 
                "Veres Noel", "Csatár Dezső", "Fodor Zalán", "Farkas Roland", "Balla Géza", "Tamás András", "Apród Valentin" };
            BevetelTMB = new int[17] { 602 , 1440 , 1641 , 616 , 658 , 619 , 1799 , 1230 , 1230 , 1270 , 1353 , 
                1468 , 1247 , 997 , 1117, 898 , 765 };
            KoltsegTMB = new int[17] { 467, 506, 383, 492, 498, 300, 457, 375, 400, 333, 299, 354, 465, 472, 390, 587, 554 };
            BorravaloTMB = new int[17] { 139, 94, 101, 139, 130, 133, 98, 98, 149, 124, 150, 108, 122, 105, 129,128 ,127};
        }
    }
}
