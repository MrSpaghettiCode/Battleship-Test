using System;

namespace Battleship_Test
{
    public class Map
    {
        public string Name { get; set; }
        static int ROWS = 10;
        static int COLS = 10;
        static string spacer = "#"; //wird zum initialisieren der Maps verwendet
        public string[,] map = new string[ROWS, COLS];
        public Map(string name)
        {
            Name = name;
        }
        public void displayMap(int HP)
        {
            Console.WriteLine("    A B C D E F G H I J\n");
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (c == 0) Console.Write(r + "   ");
                    if (r == 4 && c == 9) Console.Write($"{map[r, c]}\t  [{Name}] [{HP}]");
                    else
                    Console.Write(map[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
        public void displayMap()
        {
            Console.WriteLine($"\t[{Name}]");
            Console.WriteLine("    A B C D E F G H I J\n");
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (c == 0) Console.Write(r + "   ");
                    Console.Write(map[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
        public void initializeMap()
        {
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    map[r, c] = spacer;
                }
            }
        }
    }
}
