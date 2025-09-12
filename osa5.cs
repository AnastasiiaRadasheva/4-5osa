using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//✅ Задание 1 – Калорийный калькулятор с классами

//Задание:
//Создайте два класса:

//    Продукт – свойства: Название, Калории100г

//    Человек – свойства: Имя, Возраст, Пол, Рост, Вес, Уровень активности

//Создайте программу, которая:

//    Считывает объекты «Продукт» из файла или добавляет их в список вручную.

//    Запрашивает у пользователя его данные и рассчитывает суточную потребность в энергии по формуле Харриса-Бенедикта.

//    Предлагает пользователю список продуктов, в котором для каждого продукта рассчитывается, сколько его можно съесть в день (г), чтобы покрыть потребность в калориях.

//💡 Подсказка: распределение калорий на 100 г = количество в граммах.

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
    }
}
