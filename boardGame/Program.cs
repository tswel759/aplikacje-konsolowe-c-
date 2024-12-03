// See https://aka.ms/new-console-template for more information

public class Player
{
    public string Name { get; set; }
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








internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
