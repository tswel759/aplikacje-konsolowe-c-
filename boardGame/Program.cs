using System;

public class Player
{
    public string Name;
    public int Position { get; set; }
    public int Score { get; set; }

    public Player(string name)
    {
        Name = name;
        Position = 0;
        Score = 0;
    }
    
    public int Ruch(int x)
    {
        Position += x;
        return Position;
    }
    
    public int Aktualizacja(int score)
    {
        Score += score;
        return Score;
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

internal class Program
{
    public static void Main(string[] args)
    {
        
        Player player = new Player("RL9");
        
        Board board = new Board(20);
        
        Console.WriteLine($"Gracz: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        
        
        int ruch = 5;
        player.Ruch(ruch);
        Console.WriteLine($"Po wykonaniu ruchu o {ruch}, Pozycja: {player.Position}");
        
        int nagroda = board.PobierzNagrode(player.Position);
        Console.WriteLine($"Nagroda na polu {player.Position}: {nagroda}");
        
        player.Aktualizacja(nagroda);
        Console.WriteLine($"Po aktualizacji, Wynik gracza: {player.Score}");
    }
}
