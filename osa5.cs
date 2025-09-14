using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Задание 2 – Округа и столицы (словарь и тест)
 
//Задание:
//Создайте Dictionary<string, string>, где:
//ключом является название округа,
//значением является центр округа (столица).
 
//Добавьте возможности:
//Запросить название столицы и найти по нему округ.
//Запросить название области и найти по нему столицу.
//Если данных нет, разрешить пользователю добавить их в словарь.
//Добавьте игровой режим, в котором программа выбирает случайную область или город и запрашивает у пользователя ответ.
//В конце покажите процентный результат.
 
//Подсказка: Вы можете использовать два словаря Dictionary или преобразовать KeyValuePair.

//Переведено с помощью DeepL.com (бесплатная версия)
namespace Os4
{
    internal class osa5
    {
        public static List<Toode> LooToodeteNimekiri()
        {
            return new List<Toode>
        {
            new Toode("Shokolad", 420),
            new Toode("adrifilee", 1000),
            new Toode("Kanafilee", 165),
            new Toode("banana", 60)
        };
        }

        public static Inimene LoeKasutajaAndmed()
        {
            Console.Write("Sugu (mees/naine): ");
            string sugu = Console.ReadLine();

            Console.Write("Vanus: ");
            int vanus = int.Parse(Console.ReadLine());

            Console.Write("Pikkus (cm): ");
            double pikkus = double.Parse(Console.ReadLine());

            Console.Write("Kaal (kg): ");
            double kaal = double.Parse(Console.ReadLine());

            Console.Write("Aktiivsus (1-5): ");
            int aktiivsus = int.Parse(Console.ReadLine());

            return new Inimene(sugu, vanus, pikkus, kaal, aktiivsus);
        }

        public static void KuvadaTulemused(Inimene inimene, double energiavajadus, List<Toode> tooted)
        {
            Console.WriteLine($"{inimene.Sugu} energiavajadus: {energiavajadus:F0} kcal");
            Console.WriteLine("Soovitatav kogus grammi iga toote kohta:");

            foreach (var t in tooted)
            {
                double grammid = energiavajadus / t.Kalorid100g * 100;
                Console.WriteLine($"{t.Nimi}: {grammid:F1} g");
            }

        }
        //2 (5-osa)
        public static void OkrugJaStolitsa()
        {
            Dictionary<string, string> okrugid = new Dictionary<string, string>()
            {
                {"Harjumaa", "Tallinn"},
                {"Tartumaa", "Tartu"},
                {"Pärnumaa", "Pärnu"},
                {"Ida-Virumaa", "Jõhvi"},
                {"Läänemaa", "Haapsalu"}
            };
            while (true)
            {
                Console.WriteLine("Vali tegevus:");
                Console.WriteLine("1. Otsi okrugi järgi");
                Console.WriteLine("2. Otsi stolitsa järgi");
                Console.WriteLine("3. Mängi mängu");
                Console.WriteLine("4. Välju");
                string valik = Console.ReadLine();
                if (valik == "1")
                {
                    Console.Write("Sisesta okrugi nimi: ");
                    string okrug = Console.ReadLine();
                    if (okrugid.ContainsKey(okrug))
                    {
                        Console.WriteLine($"{okrug} stolits on {okrugid[okrug]}.");
                    }
                    else
                    {
                        Console.WriteLine("Okrugi ei leitud. Sisesta stolitsa nimi, et lisada see sõnastikku:");
                        string stolitsa = Console.ReadLine();
                        okrugid[okrug] = stolitsa;
                        Console.WriteLine("Okrug ja stolitsa lisatud.");
                    }
                }
                else if (valik == "2")
                {
                    Console.Write("Sisesta stolitsa nimi: ");
                    string stolitsa = Console.ReadLine();
                    var okrug = okrugid.FirstOrDefault(x => x.Value.Equals(stolitsa, StringComparison.OrdinalIgnoreCase)).Key;
                    if (okrug != null)
                    {
                        Console.WriteLine($"{stolitsa} on {okrug} stolits.");
                    }
                    else
                    {
                        Console.WriteLine("Stolitsat ei leitud. Sisesta okrugi nimi, et lisada see sõnastikku:");
                        string okrug1 = Console.ReadLine();
                        okrugid[okrug1] = stolitsa;
                        Console.WriteLine("Okrug ja stolitsa lisatud.");
                    }
                }
                else if (valik == "3")
                {
                    int õigeid = 0;
                    int kokku = 0;
                    Random rnd = new Random();

                    while (true)
                    {
                        var paar = okrugid.ElementAt(rnd.Next(okrugid.Count));
                        Console.WriteLine($"Mis on {paar.Key} stolits? (või kirjuta 'välju' lõpetamiseks)");
                        string vastus = Console.ReadLine();

                        if (vastus.Equals("valju", StringComparison.OrdinalIgnoreCase))
                            break;

                        kokku++;

                        if (vastus.Equals(paar.Value, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Õige!");
                            õigeid++;
                        }
                        else
                        {
                            Console.WriteLine($"Vale! Õige vastus on {paar.Value}.");
                        }
                    }

                    if (kokku > 0)
                    {
                        double protsent = (double)õigeid / kokku * 100;
                        Console.WriteLine($"Sa vastasid õigesti {õigeid} korda {kokku}-st. Protsent: {protsent:F2}%");
                    }
                }

            }
        }
    }
}
