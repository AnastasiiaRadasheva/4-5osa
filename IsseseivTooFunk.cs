using System;
using System.Collections.Generic;

namespace Os4
{
    //// 4 ülesanne
    internal class IsseseivTooFunk
    {
        public static List<Film> LeiaFilmidZanriJargi(List<Film> filmid, string zanr)
        {
            List<Film> tulem = new List<Film>();
            foreach (var film in filmid)
            {
                if (film.Zanr.ToLower() == zanr.ToLower())
                {
                    tulem.Add(film);
                }
            }
            return tulem;
        }

        public static Film LeiaUusimFilm(List<Film> filmid)
        {
            if (filmid.Count == 0)
                return null;

            Film uusim = filmid[0];
            foreach (var film in filmid)
            {
                if (film.Aasta > uusim.Aasta)
                {
                    uusim = film;
                }
            }
            return uusim;
        }

        public static Dictionary<string, List<Film>> GrupeeriFilmidZanriJargi(List<Film> filmid)
        {
            Dictionary<string, List<Film>> grupid = new Dictionary<string, List<Film>>();

            foreach (var film in filmid)
            {
                string zanr = film.Zanr;

                if (!grupid.ContainsKey(zanr))
                {
                    grupid[zanr] = new List<Film>();
                }

                grupid[zanr].Add(film);
            }

            return grupid;
        }

        
    }
    //6 ülesanne
    internal class LemmikloomToo
    {
        public static void KuvanKassid(List<Lemmikloom> loomad)
        {
            bool leitud = false;
            foreach (var loom in loomad)
            {
                if (loom.Liik.ToLower() == "kass")
                {
                    Console.WriteLine($"{loom.Nimi}, Vanus: {loom.Vanus}");
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine("Kasse ei leitud.");
        }

        public static double KeskmineVanus(List<Lemmikloom> loomad)
        {
            if (loomad.Count == 0) return 0;
            int summa = 0;
            foreach (var loom in loomad) summa += loom.Vanus;
            return (double)summa / loomad.Count;
        }

        public static Lemmikloom LeiaVanim(List<Lemmikloom> loomad)
        {
            if (loomad.Count == 0) return null;
            Lemmikloom vanim = loomad[0];
            foreach (var loom in loomad)
                if (loom.Vanus > vanim.Vanus)
                    vanim = loom;
            return vanim;
        }

        public static Lemmikloom OtsiNimeJargi(List<Lemmikloom> loomad, string nimi)
        {
            foreach (var loom in loomad)
                if (loom.Nimi.ToLower() == nimi.ToLower())
                    return loom;
            return null;
        }
    }
}
