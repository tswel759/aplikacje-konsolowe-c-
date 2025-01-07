using System;
using System.Collections.Generic;

public interface IPlayer
{
    string Name { get; }
    int Position { get; set; }
    int Score { get; set; }

    void Ruch(int x);
    void Aktualizacja(int score);
}

public interface IWojownik
{
    void Walka();
}

public interface IMag
{
    void RzucZaklecie();
}

public interface IHealer
{
    void Leczenie(IPlayer player);
}

public class Player : IPlayer
{
    public string Name { get; }
    public int Position { get; set; }
    public int Score { get; set; }

    public Player(string name)
    {
        Name = name;
        Position = 0;
        Score = 0;
    }

    public virtual void Ruch(int x)
    {
        Position += x;
        Console.WriteLine($"{Name} przesuwa się na pole {Position}.");
    }

    public virtual void Aktualizacja(int score)
    {
        Score += score;
        Console.WriteLine($"{Name} otrzymuje {score} punktów. Obecny wynik: {Score}.");
    }
}

public class Wojownik : Player, IWojownik
{
    public Wojownik(string name) : base(name) { }

    public void Walka()
    {
        Console.WriteLine($"{Name} walczy i zdobywa 10 punktów!");
        Aktualizacja(10);
    }
}

public class Mag : Player, IMag
{
    public Mag(string name) : base(name) { }

    public void RzucZaklecie()
    {
        Console.WriteLine($"{Name} rzuca zaklęcie! Zwiększa wynik o 5 punktów.");
        Aktualizacja(5);
    }
}

public class Healer : Player, IHealer
{
    public Healer(string name) : base(name) { }

    public void Leczenie(IPlayer player)
    {
        Console.WriteLine($"{Name} leczy {player.Name} i przywraca 5 punktów.");
        player.Aktualizacja(5);
    }
}

public class Board
{
    public int RozmiarPl { get; set; }
    public int[] Nagrody { get; set; }

    public Board(int rozmiar)
    {
        RozmiarPl = rozmiar;
        Nagrody = new int[rozmiar];
        LosujNagrody();
    }

    public void LosujNagrody()
    {
        Random rand = new Random();
        for (int i = 0; i < RozmiarPl; i++)
        {
            Nagrody[i] = rand.Next(0, 5); 
        }
    }

    public int PobierzNagrode(int pozycja)
    {
        if (pozycja >= 0 && pozycja < RozmiarPl)
        {
            return Nagrody[pozycja];
        }
        else
        {
            return 0; 
        }
    }
}

public class Game
{
    private List<IPlayer> Gracze;
    private Board Plansza;
    private Random Kostka;

    public Game(int rozmiarPlanszy, List<IPlayer> gracze)
    {
        Plansza = new Board(rozmiarPlanszy);
        Gracze = gracze;
        Kostka = new Random();
    }

    public void RozpocznijGre()
    {
        Console.WriteLine("Gra rozpoczyna się!");
        bool graTrwa = true;
        int tura = 0;

        while (graTrwa)
        {
            IPlayer obecnyGracz = Gracze[tura % Gracze.Count];
            Console.WriteLine($"\nTura gracza: {obecnyGracz.Name}");

            int rzut = Kostka.Next(1, 7);
            Console.WriteLine($"{obecnyGracz.Name} rzuca kostką i otrzymuje: {rzut}.");
            obecnyGracz.Ruch(rzut);

            int nagroda = Plansza.PobierzNagrode(obecnyGracz.Position);
            if (nagroda > 0)
            {
                Console.WriteLine($"{obecnyGracz.Name} trafia na pole z nagrodą: {nagroda} punktów!");
                obecnyGracz.Aktualizacja(nagroda);
            }
            else
            {
                Console.WriteLine($"{obecnyGracz.Name} trafia na pole bez nagrody.");
            }

            if (obecnyGracz is IWojownik wojownik)
            {
                wojownik.Walka();
            }
            else if (obecnyGracz is IMag mag)
            {
                mag.RzucZaklecie();
            }
            else if (obecnyGracz is IHealer healer)
            {
                healer.Leczenie(Gracze[(tura + 1) % Gracze.Count]);
            }

            tura++;

            if (tura >= 10) 
            {
                graTrwa = false;
            }
        }

        WyswietlWyniki();
    }

    private void WyswietlWyniki()
    {
        Console.WriteLine("\nGra zakończona! Wyniki końcowe:");
        foreach (var gracz in Gracze)
        {
            Console.WriteLine($"{gracz.Name}: {gracz.Score} punktów.");
        }
    }
}
 
internal class Program
{
    public static void Main(string[] args)
    {
        var gracze = new List<IPlayer>
        {
            new Wojownik("Wojownik1"),
            new Mag("Mag1"),
            new Healer("Healer1"),
            new Wojownik("Wojownik2"),
            new Mag("Mag2")
        };
        
        Game game = new Game(20, gracze);
        game.RozpocznijGre();
    }
}
