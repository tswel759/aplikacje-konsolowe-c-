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
namespace SimpleSportsTeam
{
    public class Team
    {
        // Metody AddPlayer i RemovePlayer z poprzednich commitów...

        public void ShowAllPlayers()
        {
            Console.WriteLine("\nLista wszystkich zawodników:");
            Console.WriteLine("-----------------------------");

            if (players.Count == 0)
            {
                Console.WriteLine("Drużyna nie ma jeszcze żadnych zawodników.");
                return;
            }

            foreach (var player in players)
            {
                Console.WriteLine($"Imię: {player.Name}");
                Console.WriteLine($"Pozycja: {player.Position}");
                Console.WriteLine($"Punkty: {player.Score}");
                Console.WriteLine("-----------------------------");
            }
        }

        public void ShowPlayersByPosition(string position)
        {
            Console.WriteLine($"\nZawodnicy na pozycji {position}:");
            Console.WriteLine("-----------------------------");

            bool found = false;
            foreach (var player in players)
            {
                if (player.Position == position)
                {
                    Console.WriteLine($"Imię: {player.Name}, Punkty: {player.Score}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Nie znaleziono zawodników na pozycji {position}");
            }
        }
    }
}
namespace SimpleSportsTeam
{
    public class Team
    {
        // Metody AddPlayer, RemovePlayer, ShowAllPlayers, ShowPlayersByPosition...

        public void ShowTeamAverageScore()
        {
            if (players.Count == 0)
            {
                Console.WriteLine("Nie można obliczyć średniej - brak zawodników");
                return;
            }

            int totalScore = 0;
            foreach (var player in players)
            {
                totalScore += player.Score;
            }

            double average = (double)totalScore / players.Count;
            Console.WriteLine($"Średnia punktów drużyny: {average:F2}");
        }
    }
}
