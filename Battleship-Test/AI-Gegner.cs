using System;
using System.Collections.Generic;

namespace Battleship_Test
{
    class AI_Gegner
    {
        static Map map;
        static List<int[]> coordinatesThatAreHit = new();
        static bool lastShotHit = false;
        public AI_Gegner(Map Map)
        {
            map = Map;
        }
        Ship GenerateShip()
        {
            Random randy = new();
            Ship c = new();
            c.size = 4;
            c.x = randy.Next(0, 9);
            c.y = randy.Next(0, 9);
            return c;
        }
        public void DeployShips(int amount) //sollte überarbeitet werden...is billig und funktioniert nicht immer...
        {
            again:
            List<int[]> usedCords = new();
            List<Ship> usedShipCoordinates = new();
            int ships = 0;
            //erstellt Coordinaten für den Anfang der Schiffe
            while (ships < amount)
            {
                bool inUse = false;
                Ship c = GenerateShip();
                if (usedShipCoordinates.Count != 0)
                {
                    foreach (var ship in usedShipCoordinates)
                    {
                        if (ship == c) inUse = true;
                    }
                    if (!inUse && usedShipCoordinates.Count != 0)
                    {
                        usedShipCoordinates.Add(c);
                        usedCords.Add(new int[] {c.x, c.y});
                    }

                }
                else
                {
                    usedShipCoordinates.Add(c);
                    usedCords.Add(new int[] { c.x, c.y });
                }
                ships++;
            }
            foreach (var ship in usedShipCoordinates)
            {
                //entscheidet die Ausrichtung des Schiffs anhand der offenen Wege(wo halt genug platz is)
                DecideDirection(ship);
                if(ship.direction == Ship.Direction.up)
                {
                    for(int i=ship.y;i<ship.y+ship.size;i++)
                    {
                        foreach(var s in usedCords)
                        {
                            var arr = new int[] { ship.x, i };
                            if (s == arr) goto again;
                        }
                        map.map[ship.x, i] = ship.display;
                        usedCords.Add(new int[] { ship.x, i });
                    }
                }
                else if (ship.direction == Ship.Direction.down)
                {
                    for (int i = ship.y; i > ship.y-ship.size; i--)
                    {
                        foreach (var s in usedCords)
                        {
                            var arr = new int[] { ship.x, i };
                            if (s == arr) goto again;
                        }
                        map.map[ship.x, i] = ship.display;
                        usedCords.Add(new int[] { ship.x, i });
                    }
                }
                else if(ship.direction == Ship.Direction.right)
                {
                    for (int i = ship.x; i < ship.x + ship.size; i++)
                    {
                        foreach (var s in usedCords)
                        {
                            var arr = new int[] { ship.x, i };
                            if (s == arr) goto again;
                        }
                        map.map[i, ship.y] = ship.display;
                        usedCords.Add(new int[] { ship.x, i });
                    }
                }
                else if (ship.direction == Ship.Direction.left)
                {
                    for (int i = ship.x; i > ship.x-ship.size; i--)
                    {
                        foreach (var s in usedCords)
                        {
                            var arr = new int[] { ship.x, i };
                            if (s == arr) goto again;
                        }
                        map.map[i, ship.y] = ship.display;
                        usedCords.Add(new int[] { ship.x, i });
                    }
                }

            }
        }
        public void shootAt(Map display)
        {
            if (lastShotHit) aim(display);
            Random r = new();
            repeat:
            int x = r.Next(0, 9);
            int y = r.Next(0, 9);
            int[] xY = new int[2] { x, y };
            if(coordinatesThatAreHit.Count > 0)
            {
                foreach(var array in coordinatesThatAreHit)
                {
                    if (array == xY) goto repeat;
                }
            }
            if(display.map[x,y] == "#")
            {
                display.map[x, y] = "O";
                coordinatesThatAreHit.Add(new int[] { x, y });
                lastShotHit = false;
            }
            else
            {
                if(display.map[x, y] != "O")
                {
                    display.map[x, y] = "X";
                    coordinatesThatAreHit.Add(new int[] { x, y });
                    lastShotHit = true;
                }
            }
            string[] chars = new string[]
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J"
            };
            string camoY = chars[y];
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"\tComputer schießt auf [{camoY}|{x}]...");
        }

        private void aim(Map m)
        {
            int[] cords = coordinatesThatAreHit[coordinatesThatAreHit.Count-1];
            int x = cords[0];
            int y = cords[1];
            Random r = new();
            int decider = r.Next(0, 3);
            switch(decider)
            {
                case 0:
                    if (m.map[x + 1, y] == "#")
                    {
                        m.map[x + 1, y] = "O";
                        lastShotHit = false;
                    }
                    else if (m.map[x + 1, y] == "S")
                    {
                        if (m.map[x + 1, y] != "O")
                        {
                            m.map[x + 1, y] = "X";
                            lastShotHit = true;
                        }
                    }
                    break;
                case 1:
                    if (m.map[x - 1, y] == "#")
                    {
                        m.map[x - 1, y] = "O";
                        lastShotHit = false;
                    }
                    else if (m.map[x - 1, y] == "S")
                    {
                        if (m.map[x - 1, y] != "O")
                        {
                            m.map[x - 1, y] = "X";
                            lastShotHit = true;
                        }
                    }
                    break;
                case 2:
                    if (m.map[x, y+1] == "#")
                    {
                        m.map[x, y+1] = "O";
                        lastShotHit = false;
                    }
                    else if (m.map[x, y+1] == "S")
                    {
                        if (m.map[x, y+1] != "O")
                        {
                            m.map[x, y + 1] = "X";
                            lastShotHit = true;
                        }
                    }
                    break;
                case 3:
                    if (m.map[x, y - 1] == "#")
                    {
                        m.map[x, y - 1] = "O";
                        lastShotHit = false;
                    }
                    else if (m.map[x, y - 1] == "S")
                    {
                        if (m.map[x, y - 1] != "O")
                        {
                            m.map[x, y - 1] = "X";
                            lastShotHit = true;
                        }
                    }
                    break;

            }
            

        }

        static void DecideDirection(Ship ship)
        {
            Random r = new();
            bool canGoUp = false;
            bool canGoDown = false;
            bool canGoRight = false;
            bool canGoLeft = false;
            if(ship.x >= ship.size)
            {
                canGoLeft = true;
            }
            else
            {
                canGoRight = true;
            }
            if (ship.y >= ship.size)
            {
                canGoUp = true;
            }
            else
            {
                canGoDown = true;
            }

            if (canGoUp && canGoRight)
            {
                int decider = r.Next(0, 2);
                if (decider == 0) ship.direction = Ship.Direction.down;
                else ship.direction = Ship.Direction.right;
            }
            else if (canGoUp && canGoLeft)
            {
                int decider = r.Next(0, 2);
                if (decider == 0) ship.direction = Ship.Direction.down;
                else ship.direction = Ship.Direction.left;
            }
            else if (canGoDown && canGoRight)
            {
                int decider = r.Next(0, 2);
                if (decider == 0) ship.direction = Ship.Direction.up;
                else ship.direction = Ship.Direction.right;
            }
            else if (canGoDown && canGoLeft)
            {
                int decider = r.Next(0, 2);
                if (decider == 0) ship.direction = Ship.Direction.up;
                else ship.direction = Ship.Direction.left;
            }
        }
    }
}
