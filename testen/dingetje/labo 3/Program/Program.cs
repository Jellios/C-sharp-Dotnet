using System;

namespace space
{
    public class Player : IComparable
    {
        public int Highscore { get; set; }
        public string PlayerName { get; set; }

        public Player(int _Highscore, string _playerName)
        {
            Highscore = _Highscore;
            PlayerName = _playerName;
        }
        public Player()
        {
            Highscore = 0;
            PlayerName = "";
        }
        public int CompareTo(object obj)
        {
            Player p = (Player)obj;
            if (this.Highscore > p.Highscore)
            {
                return 1;
            }
            else if (this.Highscore == p.Highscore)
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
    }
    public static class Ding
    {
        public static void PrintList(List<Player> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                System.Console.WriteLine($"{lst[i].PlayerName}:\t {lst[i].Highscore}");
            }
        }
        public static void Main(string[] args)
        {
            List<Player> Plist = new List<Player>();

            Plist.Add(new Player(100, "test 2"));
            Plist.Add(new Player(300, "test 3"));
            Plist.Add(new Player(50, "test 4"));
            Plist.Add(new Player(400, "test 5"));
            Plist.Add(new Player(250, "test 6"));
              Plist.Add(new Player(100, "test 2"));
            Plist.Add(new Player(300, "test 3"));
            Plist.Add(new Player(50, "test 4"));
            Plist.Add(new Player(400, "test 5"));
            Plist.Add(new Player(250, "test 6"));


            System.Console.WriteLine("List before sorting: ");
            PrintList(Plist);
            System.Console.WriteLine("\n\n");
            Plist.Sort();
            System.Console.WriteLine("List after sorting: ");
            PrintList(Plist);
        }
    }
}