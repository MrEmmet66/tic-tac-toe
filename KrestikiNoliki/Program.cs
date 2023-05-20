using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrestikiNoliki
{
    enum GameCondition
    {
        Running,
        Lose,
        Win,
        Draw
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GameCondition gc = new GameCondition();
            bool isPlaying = true;
            char[,] map = CreateMap();

            Console.Title = "MBF.EXE WATAFAK";
            DrawMap(map);

            while (isPlaying)
            {
                char turnChar = 'O';
                switch (CheckWin(map, turnChar))
                {
                    case GameCondition.Win:
                        Console.WriteLine("You won!");
                        isPlaying = false;
                        break;

                    case GameCondition.Draw:
                        Console.WriteLine("Draw! Kakhovka and Myropil equals");
                        isPlaying = false;
                        break;

                }

                if (isPlaying == false)
                    break;

                Console.WriteLine("Turn 1:");
                int t1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Turn 2: ");
                int t2 = int.Parse(Console.ReadLine());

                map[t1, t2] = turnChar;
                DrawMap(map);

                if (isPlaying == true)
                    Enemy(ref map, ref turnChar, ref isPlaying);
            }

        }

        static void Enemy(ref char[,] map, ref char turnChar, ref bool gameState)
        {
            bool repeatState = true;
            turnChar = 'X';
            Random rnd = new Random();

            while (repeatState)
            {
                int t1 = rnd.Next(0, 3);
                int t2 = rnd.Next(0, 3);
                if (map[t1, t2] == '.')
                {
                    repeatState = false;
                    map[t1, t2] = turnChar;
                    DrawMap(map);
                    switch (CheckWin(map, turnChar))
                    {
                        case GameCondition.Win:
                            Console.WriteLine("Kakhovka AI is won!");
                            gameState = false;
                            break;
                    }
                }
            }

        }

        static GameCondition CheckWin(char[,] map, char turnChar)
        {

            int kostilCount = 0;
            foreach (char c in map)
            {
                if (c == '.')
                    kostilCount++;

            }
            if (kostilCount == 0)
            {
                return GameCondition.Draw;
            }
            //Row 1
            if (map[0, 0] == turnChar && map[0, 1] == turnChar && map[0, 2] == turnChar)
                return GameCondition.Win;
            // Diagonal 1
            else if (map[0, 0] == turnChar && map[1, 1] == turnChar && map[2, 2] == turnChar)
                return GameCondition.Win;
            // Column 1
            else if (map[0, 0] == turnChar && map[1, 0] == turnChar && map[2, 0] == turnChar)
                return GameCondition.Win;
            // Diagonal 2
            else if (map[0, 2] == turnChar && map[1, 1] == turnChar && map[2, 0] == turnChar)
                return GameCondition.Win;
            //Row 3
            else if (map[2, 0] == turnChar && map[2, 1] == turnChar && map[2, 2] == turnChar)
                return GameCondition.Win;
            // Row 2
            else if (map[1, 0] == turnChar && map[1, 1] == turnChar && map[1, 2] == turnChar)
                return GameCondition.Win;
            // Column 3
            else if (map[0, 2] == turnChar && map[1, 2] == turnChar && map[2, 2] == turnChar)
                return GameCondition.Win;
            //Column 2
            else if (map[0, 1] == turnChar && map[1, 1] == turnChar && map[2, 1] == turnChar)
                return GameCondition.Win;
            else
                return GameCondition.Running;

        }

        static char[,] CreateMap()
        {
            char[,] map = new char[3, 3];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = '.';
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
        {
            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
 