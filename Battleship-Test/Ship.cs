using System;
using System.Collections.Generic;

namespace Battleship_Test
{
    public record Ship
    {
        public enum Direction
        {
            up,
            down,
            left,
            right
        }
        public enum klasse
        {
            SchlachtSchiff,
            Kreuzer,
            Zerstörer,
            UBoot
        }
        public string display { get; set; } = "S";
        public int x { get; set; }
        public int y { get; set; }
        public Direction direction { get; set; }
        public int size { get; set; } = 4;
        public void place(Ship ship, Map map)
        {
        tryAgain:
            map.map[ship.x, ship.y] = ship.display;

            Console.WriteLine("\nIn welche Himmelsrichtung soll das Schiff fahren?\n\n\t    [N]\n\t     | \n\t[W]--+--[O]\n\t     |\n\t    [S]");
            string input = Console.ReadLine();
            if (input.ToUpper() == "N") ship.direction = Direction.up;
            if (input.ToUpper() == "S") ship.direction = Direction.down;
            if (input.ToUpper() == "W") ship.direction = Direction.left;
            if (input.ToUpper() == "O") ship.direction = Direction.right;

            if (ship.direction == Ship.Direction.right)
            {
                try
                {
                    for (int i = ship.y; i < ship.y + ship.size; i++)
                    {
                        map.map[ship.x, i] = ship.display;
                    }
                }
                catch
                {
                    try
                    {
                        for (int i = ship.y; i < ship.y + ship.size; i++)
                        {
                            map.map[ship.x, i] = "#";
                        }
                    }
                    catch (Exception e) { };
                    Console.Clear();
                    map.map[ship.x, ship.y] = "S";
                    Console.WriteLine("In die gewählte Richtung ist nicht genug Platz!");
                    System.Threading.Thread.Sleep(2000);
                    map.displayMap();
                    goto tryAgain;
                }
            }
            else if (ship.direction == Ship.Direction.left)
            {
                try
                {
                    for (int i = ship.y; i > ship.y - ship.size; i--)
                    {
                        map.map[ship.x, i] = ship.display;
                    }
                }
                catch
                {
                    try
                    {
                        for (int i = ship.y; i > ship.y - ship.size; i--)
                        {
                            map.map[ship.x, i] = "#";
                        }
                    }
                    catch (Exception e) { };
                    Console.Clear();
                    map.map[ship.x, ship.y] = "S";
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("\n\n\tIn die gewählte Richtung ist nicht genug Platz!");
                    System.Threading.Thread.Sleep(2000);
                    map.displayMap();
                    goto tryAgain;
                }
            }
            else if (ship.direction == Ship.Direction.down)
            {
                try
                {
                    for (int i = ship.x; i < ship.x + ship.size; i++)
                    {
                        map.map[i, ship.y] = ship.display;
                    }
                }
                catch
                {
                    try
                    {
                        for (int i = ship.x; i < ship.x + ship.size; i++)
                        {
                            map.map[i, ship.y] = "#";
                        }
                    }
                    catch (Exception e) { };
                    Console.Clear();
                    map.map[ship.x, ship.y] = "S";
                    Console.WriteLine("In die gewählte Richtung ist nicht genug Platz!");
                    System.Threading.Thread.Sleep(2000);
                    map.displayMap();
                    goto tryAgain;
                }
            }
            else if (ship.direction == Ship.Direction.up)
            {
                try
                {
                    for (int i = ship.x; i > ship.x - ship.size; i--)
                    {
                        map.map[i, ship.y] = ship.display;
                    }
                }
                catch
                {
                    try
                    {
                        for (int i = ship.x; i > ship.x - ship.size; i--)
                        {
                            map.map[i, ship.y] = "#";
                        }
                    }
                    catch (Exception e) { };
                    Console.Clear();
                    map.map[ship.x, ship.y] = "S";
                    Console.WriteLine("In die gewählte Richtung ist nicht genug Platz!");
                    System.Threading.Thread.Sleep(2000);
                    map.displayMap();
                    goto tryAgain;
                }
            }
        }
    }
}
