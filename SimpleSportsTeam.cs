namespace SimpleSportsTeam
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Score { get; set; }

        public Player(string name, string position, int score)
        {
            Name = name;
            Position = position;
            Score = score;
        }

        public void UpdateScore(int newScore)
        {
            Score = newScore;
            Console.WriteLine($"Zaktualizowano punkty dla {Name}: {Score}");
        }
    }
}
namespace SimpleSportsTeam
{
    public class Team
    {
        private List<Player> players;

        public Team()
        {
            players = new List<Player>();
            Console.WriteLine("Utworzono nową drużynę!");
        }

        public void AddPlayer(string name, string position, int score)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Błąd: Imię zawodnika nie może być puste!");
                return;
            }

            var player = new Player(name, position, score);
            players.Add(player);
            Console.WriteLine($"Dodano zawodnika: {name} na pozycji {position}");
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = null;
            foreach (var player in players)
            {
                if (player.Name == name)
                {
                    playerToRemove = player;
                    break;
                }
            }

            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                Console.WriteLine($"Usunięto zawodnika: {name}");
            }
            else
            {
                Console.WriteLine($"Nie znaleziono zawodnika o imieniu: {name}");
            }
        }
    }
}
