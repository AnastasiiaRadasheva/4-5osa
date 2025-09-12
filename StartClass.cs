using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Os4
{
    internal class StartClass
    {
        public static void Main(string[] args)
        {
            //osa4.Kirjuta_failisse();
            //Console.WriteLine("faili nimi: ");
            //string failinimi1 = Console.ReadLine();
            //osa4.Lugemine_fail(failinimi1);
            //osa4.RidadeLugemine();


            var tooted = osa5.LooToodeteNimekiri();

            var inimene = osa5.LoeKasutajaAndmed();

            double kcal = inimene.ArvutaEnergiavajadus();

            osa5.KuvadaTulemused(inimene, kcal, tooted);

        }
    }
}
