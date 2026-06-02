using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    using System;
    using System.IO;
    using System.Linq;

    public static class Edetabel
    {
        private static string failiTee = "skoorid.txt";

        public static void Salvesta(string nimi, int skoor)
        {
            File.AppendAllLines(failiTee, new[] { $"{nimi};{skoor}" });
        }

        public static void KuvaEdetabel()
        {
            if (!File.Exists(failiTee)) return;

            var skoorid = File.ReadAllLines(failiTee)
                .Select(rida => rida.Split(';'))
                .Where(osad => osad.Length == 2 && int.TryParse(osad[1], out _))
                .Select(osad => new { Nimi = osad[0], Punktid = int.Parse(osad[1]) })
                .OrderByDescending(x => x.Punktid)
                .Take(5);

            Console.WriteLine("\n--- TOP 5 EDETABEL ---");
            foreach (var s in skoorid)
            {
                Console.WriteLine($"{s.Nimi}: {s.Punktid} punkti");
            }
        }
    }
}
