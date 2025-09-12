using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Os4
{
    internal class Inimene
    {
        public string Sugu;
        public int Vanus;
        public double Pikkus, Kaal;
        public int Aktiivsus;

        public Inimene(string sugu, int vanus, double pikkus, double kaal, int aktiivsus)
        {
            Sugu = sugu.ToLower();
            Vanus = vanus;
            Pikkus = pikkus;
            Kaal = kaal;
            Aktiivsus = aktiivsus;
        }
        public double ArvutaEnergiavajadus()
        {
            double bmr = 0;
            if (Sugu == "mees")
                bmr = 88.362 + 13.397 * Kaal + 4.799 * Pikkus - 5.677 * Vanus;
            else if (Sugu == "naine")
                bmr = 447.593 + 9.247 * Kaal + 3.098 * Pikkus - 4.330 * Vanus;

            double[] kordajad = { 1.2, 1.375, 1.55, 1.725, 1.9 };
            return bmr * kordajad[Aktiivsus - 1];
        }
    }
}
