using System;
using System.Collections.Generic;

namespace Battleship_Test
{
    class MainLoop
    {
        static int playerHP = 1;
        static int computerHP = 1;
        static int MaxShips = 4;
        static void Main(string[] args)
        {
            Console.Title = "BattleShip";
            Map pMap = new("_Player_");
            Map cMap = new("Computer");
            Map cHittMap = new("cHittMap");
            AI_Gegner bob = new(cHittMap);
            pMap.initializeMap();
            cMap.initializeMap();
            cHittMap.initializeMap();
            bob.DeployShips(MaxShips);
            letPlayerPlaceShips(pMap);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Alle Schiffe Gesetzt. Los geht's!");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            bool gameloop = true;
            while (gameloop)
            {
                playerHP = calcHP(pMap);
                computerHP = calcHP(cHittMap);
                if (playerHP == 0)
                { Console.WriteLine("Der Computer gewinnt! Mehr Glück beim nächsten Mal."); break; }
                else if (computerHP == 0)
                {Console.WriteLine("Du gewinnst! Gz..."); break; }
                cMap.displayMap(computerHP); ////////////////////
                DrawALine();                 //Zeigt Die Map an//
                pMap.displayMap(playerHP);   ////////////////////

                int[] coordinaten = WhereToShoot();
                traceShot(coordinaten, cMap, cHittMap);
                Console.Clear();
                bob.shootAt(pMap);
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
            }
        }
        static int calcHP(Map thismap)
        {
            int output = 0;
            foreach (var s in thismap.map)
            {
                if (s == "S" || s == "s") output++;
            }
            return output;
        }
        static void letPlayerPlaceShips(Map map)
        {
            bool showInts = true;
            bool placing = false;
            while (MaxShips != 0)
            {
                map.displayMap();
                if (showInts) { Console.WriteLine("\n  Platziere dein Schiff!"); System.Threading.Thread.Sleep(2000); showInts = false; }
                string input = Console.ReadLine();
                int[] coordinates = ProcessInput(input);
                map.map[coordinates[0], coordinates[1]] = "S";
                if (!placing)
                {
                    Console.Clear();
                    map.displayMap();
                    Ship ship = new();
                    int x = coordinates[0];
                    int y = coordinates[1];
                    ship.x = x;
                    ship.y = y;
                    ship.place(ship, map);
                    placing = false;
                    showInts = true;
                }
                else placing = true;
                Console.Clear();
                MaxShips--;
            }
        }
        static void traceShot(int[] cords, Map display, Map hit)
        {
            int x = cords[0];
            int y = cords[1];
            if (hit.map[x, y] != "#")
            {
                display.map[x, y] = "X";
                hit.map[x, y] = "X";
                Console.Clear();
                Console.WriteLine("\n\n\t\t    HIT!!\n");
                //Ascii explosion!!!!
                Console.Write("\t     _.-^^---....,,--_\n\t  _--                  --_\n\t(<   ..,__,,...        >)\n         <|              .,,..    |\n          (._    ..,__,,...    _./\n          ```--. . , ; .--'''\n                  | |   |\n               .-=||  | |=-.\n              `-=#$%&%$#=-'ßn\n                  | ;  :|\n         _____.,-#%&$@%#&#~,._____");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                display.map[x, y] = "O";
                Console.Clear();
                Console.WriteLine("\n\n\tMISS!!");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
        static int[] WhereToShoot()
        {
            Console.WriteLine("\nWohin möchten Sie schießen? [x|y]"); /////////////////////////////
            string whereToShoot = Console.ReadLine();                 //Verarbeitet BenutzerInput//
            int[] coordinaten = ProcessInput(whereToShoot);           /////////////////////////////
            return coordinaten;
        }
        static int[] ProcessInput(string input)
        {
            int[] posis = new int[2];
            List<char> cords = new();
            foreach (var s in input)
            {
                if (Char.IsLetter(s))
                    cords.Add(Char.ToUpper(s));
                else
                    cords.Add(s);
            }
            string[] charTranslation = new string[]
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
            for (int o = 0; o < cords.Count; o++)
                for (int i = 0; i < charTranslation.Length; i++)
                {
                    if (Char.IsLetter(cords[o]))
                    {
                        string input2 = cords[o].ToString();
                        if (input2.ToUpper() == charTranslation[i])
                        {
                            posis[1] = i; //Y
                            break;
                        }
                    }
                    else
                    {
                        if (cords[o] == '0') posis[0] = 0;
                        if (cords[o] == '1') posis[0] = 1;
                        if (cords[o] == '2') posis[0] = 2;
                        if (cords[o] == '3') posis[0] = 3;
                        if (cords[o] == '4') posis[0] = 4;
                        if (cords[o] == '5') posis[0] = 5;
                        if (cords[o] == '6') posis[0] = 6;
                        if (cords[o] == '7') posis[0] = 7;
                        if (cords[o] == '8') posis[0] = 8;
                        if (cords[o] == '9') posis[0] = 9;
                    }

                }
            return posis;
        }
        static void DrawALine()
        {

            Console.WriteLine("\n>------------------------<\n");
        }
    }
}
