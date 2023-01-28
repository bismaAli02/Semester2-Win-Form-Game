using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    internal class PlayerDL
    {
        private static List<Player> players = new List<Player>();

        public static List<Player> Players { get => players; set => players = value; }
        public static void AddPlayerInList(string name, int score)
        {
            Player p = new Player(name, score);
            Players.Add(p);
        }
        public static void StoreScore()
        {
            string path = "SavedScore.txt";
            StreamWriter store_score = new StreamWriter(path, false);
            for (int i = 0; i < Players.Count; i++)
            {
                if (i != 0)
                {
                    store_score.Write("\n");
                }
                store_score.Write(Players[i].Name + "," + Players[i].Score);
            }
            store_score.Flush();
            store_score.Close();
        }
        public static void ReadScore()
        {
            string path = "SavedScore.txt";
            if (File.Exists(path))
            {
                StreamReader Load_score = new StreamReader(path);
                string line;
                while ((line = Load_score.ReadLine()) != null)
                {
                    string[] SplitRecord = line.Split(',');
                    string name = SplitRecord[0];
                    int score = int.Parse(SplitRecord[1]);
                    Player p = new Player(name, score);
                    Players.Add(p);
                }
                Load_score.Close();
            }
        }

    }
}
