using System.Text;

namespace berek2020;

class Program
{
    static void Main()
    {
        List<Dolgozo> dolgozok = new();

        using StreamReader sr = new(@"..\..\..\src\berek2020.txt", Encoding.UTF8);
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            dolgozok.Add(new Dolgozo(sr.ReadLine()));
        }
        // 3) Határozza meg és írja ki a képernyőre, hogy hány dolgozó adatai találhatók a forrásállományban!
        Console.WriteLine($"3) A dolgozók száma: {dolgozok.Count} dolgozó\n");

        // 4) Határozza meg és írja ki a képernyőre a 2020-as átlagbéreket! Az eredményt ezer forintban, egy tizedesjegyre kerekítve jelenítse meg!
        var atlagBer = dolgozok.Average(d => d.Ber) / 1000.0;
        Console.WriteLine($"4) 2020-as átlagbér: {atlagBer:F1} ezer Ft\n");

        //5) Kérje be egy részleg nevét a felhasználótól a minta szerint!
        Console.Write("5) Kérem a részleg nevét: ");
        var keresettReszleg = Console.ReadLine();
        var reszlegDolgozok = dolgozok.Where(d => d.Reszleg == keresettReszleg).ToList();

        /* 6) . Az előző feladatban megadott részlegen keresse meg és írja ki a legnagyobb bérrel (fizetéssel) rendelkező dolgozó adatait! 
                Ha a megadott részleg nem létezik a cégnél, akkor a „A megadott részleg nem létezik a cégnél!” 
                feliratot jelenítse meg! Feltételezheti, hogy nem alakult ki „holtverseny” egy-egy részlegen dolgozók fizetése között! */
        if (reszlegDolgozok.Count == 0)
        {
            Console.WriteLine("6) A megadott részleg nem létezik a cégnél!");
        }
        else
        {
            var legnagyobbBeru = reszlegDolgozok.OrderByDescending(d => d.Ber).First();
            Console.WriteLine($"6) feladat: Legnagyobb bér a {keresettReszleg} részlegen: {legnagyobbBeru.Nev}, {legnagyobbBeru.Ber} Ft");
        }
        // 7) Készítsen statisztikát az egyes részlegeken dolgozók számáról! A részlegek kiírásának sorrendje tetszőleges!
        var reszlegStatisztika = dolgozok
                .GroupBy(d => d.Reszleg)
                .ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("\n7) Részleg statisztika:");
        foreach (var stat in reszlegStatisztika)
        {
            Console.WriteLine($"{stat.Key}: {stat.Value} fő");
        }
        //A feladat megoldására kellendő idő 33 perc volt.
    }
}

