using Madu;
using System;
using System.Threading;



public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine("             ussi mäng                 ");
        Console.WriteLine("=======================================");
        Console.ResetColor();
        Console.Write("\nVali raskusaste (1 - Lihtne, 2 - Keskmine, 3 - Raske): ");

        int tase = 1;
        string sisend = Console.ReadLine();
        int.TryParse(sisend, out tase);

        
        ManguSeaded seaded = new ManguSeaded(tase);

        try
        {
          
            Console.SetWindowSize(seaded.Laius + 5, seaded.Kõrgus + 5);
            Console.SetBufferSize(seaded.Laius + 5, seaded.Kõrgus + 5);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.CursorVisible = false;
        Console.Clear(); 

     
        Kaart kaart = new Kaart(seaded.Laius, seaded.Kõrgus);
        int algX = seaded.Laius / 2;
        int algY = seaded.Kõrgus / 2;
        Uss uss = new Uss(algX, algY, 3);
        Toit toit = new Toit(seaded.Laius, seaded.Kõrgus);
        int skoor = 0;

       
        kaart.Joonista();

     
        while (true)
        {
          
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo klahv = Console.ReadKey(true);
                if (klahv.Key == ConsoleKey.W && uss.PraeguneSuund != Suund.Alla)
                    uss.PraeguneSuund = Suund.Üles;
                else if (klahv.Key == ConsoleKey.S && uss.PraeguneSuund != Suund.Üles)
                    uss.PraeguneSuund = Suund.Alla;
                else if (klahv.Key == ConsoleKey.A && uss.PraeguneSuund != Suund.Paremale)
                    uss.PraeguneSuund = Suund.Vasakule;
                else if (klahv.Key == ConsoleKey.D && uss.PraeguneSuund != Suund.Vasakule)
                    uss.PraeguneSuund = Suund.Paremale;
            }

        
            uss.Liigu();
            Punkt pea = uss.HangiPea();

           
            if (kaart.Takistused.Any(t => t.X == pea.X && t.Y == pea.Y))
            {
                Heliefektid.MängiKaotust();
                break;
            }

        
            if (uss.KasHammustasEnnast())
            {
                Heliefektid.MängiKaotust();
                break;
            }

           
            if (pea.X == toit.Asukoht.X && pea.Y == toit.Asukoht.Y)
            {
                skoor += 10;
                uss.Kasva();
                toit.LooUusToit();
                Heliefektid.MängiSöömist();
            }

        
            Console.SetCursorPosition(0, seaded.Kõrgus + 1);
            Console.Write($"Skoor: {skoor} punkti");

            Thread.Sleep(seaded.KiirusMS);
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("=============================");
        Console.WriteLine("          MÄNG LÄBI!         ");
        Console.WriteLine("=============================\n");
        Console.ResetColor();
        Console.WriteLine($"Sinu lõplik skoor: {skoor} punkti\n");

        Console.Write("Sisesta oma nimi edetabeli jaoks: ");
        string nimi = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nimi)) nimi = "Tundmatu";

        Edetabel.Salvesta(nimi, skoor);
        Edetabel.KuvaEdetabel();

        Console.WriteLine("\nVajuta Enter klahvi väljumiseks...");
        Console.ReadLine();
    }
}