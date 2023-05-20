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
            bool isPlaying = true;
            char[] map = CreateMap();

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
                    case GameCondition.Lose:
                        Console.WriteLine("Kakhovka AI in won!");
                        isPlaying = false;
                        break;

                }

                if (isPlaying == false)
                    break;

                Console.WriteLine("Turn 1:");
                int t1 = int.Parse(Console.ReadLine());

                map[t1] = turnChar;
                DrawMap(map);

                if (isPlaying == true)
                    Enemy(ref map, ref turnChar, ref isPlaying);
            }

        }

        static void Enemy(ref char[] map, ref char turnChar, ref bool gameState)
        {
            bool repeatState = true;
            turnChar = 'X';
            Random rnd = new Random();

            while (repeatState)
            {
                int t1 = rnd.Next(0, 9);
                if (map[t1] == '.')
                {
                    repeatState = false;
                    map[t1] = turnChar;
                    DrawMap(map);
                }
            }

        }

        static GameCondition CheckWin(char[] map, char turnChar)
        {
            char winChar = ' ';
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
            int[][] winCoords = new int[][]
            {
                new int[] {0, 1, 2},
                new int[] {3, 4, 5},
                new int[] {6, 7, 8},
                new int[] {0, 3, 6},
                new int[] {1, 4, 7},
                new int[] {2, 5, 8},
                new int[] {0, 4, 8},
                new int[] {2, 4, 6}
            };

            foreach(var coord in winCoords)
            {
                if (map[coord[0]] == map[coord[1]] && map[coord[1]] == map[coord[2]])
                    winChar = map[coord[0]];
            }

            if (winChar != '.' && winChar == 'O')
                return GameCondition.Win;
            else if (winChar != '.' && winChar == 'X')
                return GameCondition.Lose;
            else
                return GameCondition.Running;

        }

        static char[] CreateMap()
        {
            char[] map = new char[9];
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = '.';
            }

            return map;
        }

        static void DrawMap(char[] map)
        {
            Console.Clear();
            for (int i = 0; i < map.Length; i++)
            {
                Console.Write(map[i] + " ");

                if((i + 1) % 3 == 0)
                    Console.WriteLine();
            }
        }
    }
}
 