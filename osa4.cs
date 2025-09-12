using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Os4
{
    internal class osa4
    {
        public static void Kirjuta_failisse()
        {
            try
            {
                string path = Path.Combine(@"..\..\..\Kuud.txt"); //@"..\..\..\Kuud.txt"
                StreamWriter text = new StreamWriter(path, true); // true = lisa lõppu
                Console.WriteLine("Sisesta mingi tekst: ");
                string lause = Console.ReadLine();
                text.WriteLine(lause);
                text.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }
        }
        //public static void Lugemine_fail(string failinimi)
        //{
        //    try
        //    {

        //        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, failinimi);
        //        StreamReader text = new StreamReader(path);
        //        string laused = text.ReadToEnd();
        //        text.Close();
        //        Console.WriteLine(laused);
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
        //    }

        //}
        public static void Lugemine_fail(string failinimi)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, failinimi);
                StreamReader text = new StreamReader(path);
                string laused = text.ReadToEnd();
                text.Close();
                Console.WriteLine(laused);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
            }
        }
        public static List<string> RidadeLugemine(string failinimi2)
        {
            List<string> kuude_list = new List<string>();
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, failinimi2);
                foreach (string rida in File.ReadAllLines(path))
                {
                    kuude_list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga: ");
            }
            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }

            kuude_list.Remove("Juuni");

            if (kuude_list.Count > 0)
                kuude_list[0] = "Veeel kuuu";

            Console.WriteLine("--------------Kustutasime juuni-----------");

            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }
            return kuude_list;

        }
       

    }
}
