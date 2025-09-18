using System;
using System.Collections.Generic;
using static Os4.IsseseivTooFunk;

namespace Os4
{
    internal class IsseseivTooMain5osa
    {
       
        public static void Main(string[] args)
        {
            //// 4 ülesanne
            //Kirjeldus:

            //Loo klass Film, millel on:
            //Pealkiri(string)
            //Aasta(int)
            //Žanr(string)

            //Loo List<Film> vähemalt 5 filmiga(kas käsitsi või kasutajalt).
            //Kirjuta funktsioonid, mis:
            //Leiavad kõik filmid, mis kuuluvad kindlasse žanrisse.
            //Leiavad uusima filmi.
            //Grupeerivad filmid žanrite kaupa(Dictionary<string, List<Film>>).




            List<Film> filmid = new List<Film>()
            {
                new Film("Titanic", 1997, "Draama"),
                new Film("Inception", 2010, "Ulme"),
                new Film("Pulp Fiction", 1994, "Krimi"),
                new Film("The Matrix", 1999, "Ulme"),
                new Film("Forrest Gump", 1994, "Draama")
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vali tegevus:");
                Console.WriteLine("1 leia filmid žanri järgi");
                Console.WriteLine("2 leia uusim film");
                Console.WriteLine("3 näita filme grupeerituna žanri järgi");
                Console.WriteLine("0 välju");
                Console.Write("Sisesta valik: ");

                string valik = Console.ReadLine();

                if (valik == "0")
                {
                    break;
                }
                else if (valik == "1")
                {
                    Console.Write("Sisesta otsitav žanr: ");
                    string zanr = Console.ReadLine();
                    var valitudFilmid = IsseseivTooFunk.LeiaFilmidZanriJargi(filmid, zanr);

                    if (valitudFilmid.Count > 0)
                    {
                        Console.WriteLine($"\nFilmid žanris '{zanr}':");
                        foreach (var film in valitudFilmid)
                        {
                            Console.WriteLine($"- {film.Pealkiri} ({film.Aasta})");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Žanri '{zanr}' filme ei leitud.");
                    }
                }
                else if (valik == "2")
                {
                    var uusim = IsseseivTooFunk.LeiaUusimFilm(filmid);
                    if (uusim != null)
                    {
                        Console.WriteLine($"\nUusim film on: {uusim.Pealkiri} ({uusim.Aasta}) žanriga {uusim.Zanr}");
                    }
                    else
                    {
                        Console.WriteLine("Filmi pole.");
                    }
                }
                else if (valik == "3")
                {
                    var grupid = IsseseivTooFunk.GrupeeriFilmidZanriJargi(filmid);
                    Console.WriteLine("\nFilmid grupeerituna žanrite kaupa:");

                    foreach (var grupp in grupid)
                    {
                        Console.WriteLine($"\nŽanr: {grupp.Key}");
                        foreach (var film in grupp.Value)
                        {
                            Console.WriteLine($"- {film.Pealkiri} ({film.Aasta})");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Vale valik.");
                }

                Console.WriteLine("\nVajuta suvalist klahvi tagasi menüüsse...");
                Console.ReadKey();
            }

            Console.WriteLine("Programm lõpetas töö.");

        ////6 ülesanne
        //Kirjeldus:
        //    Loo klass Lemmikloom omadustega:
        //    Nimi(string)
        //    Liik(nt kass, koer)(string)
        //    Vanus(int)

        //    Kogu kasutajalt vähemalt 5 lemmiklooma andmed List<Lemmikloom> abil.
        //    Kirjuta funktsioonid, mis:
        //    kuvavad kõik kassid
        //    arvutavad keskmise vanuse
        //    leiavad vanima looma
        //    Boonus: võimalda kasutajal otsida looma nime järgi

            List<Lemmikloom> loomad = new List<Lemmikloom>();

            Console.WriteLine("Sisesta vähemalt 5 lemmiklooma andmed.");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nLemmikloom #{i + 1}:");

                Console.Write("Nimi: ");
                string nimi = Console.ReadLine();

                Console.Write("Liik (nt kass, koer): ");
                string liik = Console.ReadLine();

                int vanus;
                while (true)
                {
                    Console.Write("Vanus: ");
                    if (int.TryParse(Console.ReadLine(), out vanus) && vanus >= 0)
                        break;
                    else Console.WriteLine("Palun sisesta korrektne vanus.");
                }

                loomad.Add(new Lemmikloom(nimi, liik, vanus));
            }

            Console.WriteLine("\nKõik kassid:");
            LemmikloomToo.KuvanKassid(loomad); 
            double keskmine = LemmikloomToo.KeskmineVanus(loomad);
            Console.WriteLine($"\nKeskmine vanus: {keskmine:F2} aastat.");
            var vanim = LemmikloomToo.LeiaVanim(loomad);
            if (vanim != null)
                Console.WriteLine($"\nVanim lemmikloom: {vanim.Nimi}, liik: {vanim.Liik}, vanus: {vanim.Vanus}");
            else
                Console.WriteLine("Lemmikloomi ei leitud.");

            Console.Write("\nOtsi lemmiklooma nime järgi: ");
            string otsitavNimi = Console.ReadLine();
            var leitudLoom = LemmikloomToo.OtsiNimeJargi(loomad, otsitavNimi);
            if (leitudLoom != null)
                Console.WriteLine($"Leitud: {leitudLoom.Nimi}, liik: {leitudLoom.Liik}, vanus: {leitudLoom.Vanus}");
            else
                Console.WriteLine("Lemmiklooma ei leitud.");

            Console.WriteLine("\nProgramm lõppes. Vajuta suvalist klahvi lõpetamiseks.");
            Console.ReadKey();
        }
    }


    /// 4 ülesanne
    internal class Film
    {
        public string Pealkiri { get; set; }
        public int Aasta { get; set; }
        public string Zanr { get; set; }

        public Film(string pealkiri, int aasta, string zanr)
        {
            Pealkiri = pealkiri;
            Aasta = aasta;
            Zanr = zanr;
        }
    }

    /// 6 ülesanne
    internal class Lemmikloom
    {
        public string Nimi { get; set; }
        public string Liik { get; set; }
        public int Vanus { get; set; }

        public Lemmikloom(string nimi, string liik, int vanus)
        {
            Nimi = nimi;
            Liik = liik;
            Vanus = vanus;
        }
    }
}
