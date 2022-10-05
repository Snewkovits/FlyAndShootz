using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlyAndShootz
{
    /// <summary>
    /// Kijelzéshez tartozó methodok és adatok.
    /// </summary>
    internal class Display
    {
        public static int Lenght = 50;
        public static int Height = 10;

        public static int xPos = Height - 2;
        public static int yPos = Lenght / 2;

        public static double KilledEnemies = 0;
        public static double FiredProjectiles = 0;

        public static int xProjPos = 0;
        public static int yProjPos = 0;

        public static int xEnemyPos = 0;
        public static int yEnemyPos = 0;

        public static int xEnemyProjPos = 0;
        public static int yEnemyProjPos = 0;

        public static char FullBox = 'X';

        public static bool isProjectile = false;
        public static bool isEnemy = false;
        public static bool isEnemyProjectile = false;

        public static double StatKilledEnemies = 0;
        public static double StatFiredProjectiles = 0;

        /// <summary>
        /// Autómatikus kijelzés (csak külön szálon működik!).
        /// </summary>
        public static void Write()
        {
            while (Program.isProgram)
            {
                Thread.Sleep(100);
                Console.Clear();
                Console.WriteLine("Mozgás: nyilak, Lövés: Spacebar, Ellenfél létrehozása: E");
                for (int x = 0; x <= Height; x++)
                {
                    for (int y = 0; y <= Lenght; y++)
                    {
                        if (x == 0 && y == 0)
                        {
                            Console.Write("╔");
                        }
                        else if (x == Height && y == Lenght)
                        {
                            Console.Write("╝");
                        }
                        else if (x == Height && y == 0)
                        {
                            Console.Write("╚");
                        }
                        else if (x == 0 && y == Lenght)
                        {
                            Console.Write("╗");
                        }
                        else if (y == 0)
                        {
                            Console.Write("║");
                        }
                        else if (y == Lenght)
                        {
                            Console.Write("║");
                        }
                        else if (x == 0)
                        {
                            Console.Write("═");
                        }
                        else if (x == Height)
                        {
                            Console.Write("═");
                        }
                        else if (x == xPos && y == yPos)
                        {
                            Console.Write("▲");
                        }
                        else if (isProjectile && x == xProjPos && y == yProjPos)
                        {
                            Console.Write("I");
                        }
                        else if (isEnemyProjectile && x == xEnemyProjPos && y == yEnemyProjPos)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("I");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (isEnemy && x == xEnemyPos && y == yEnemyPos)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("▼");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Pontosság: {KilledEnemies / FiredProjectiles * 100}%");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Megölt ellenfelek: {KilledEnemies}, Kilőtt lövedékek: {FiredProjectiles}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("A játékot készítette: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Szabó Ádám");
            }
        }

        public static void Move(ConsoleKey PressedKey)
        {
            switch (PressedKey)
            {
                case ConsoleKey.RightArrow:
                    if (yPos < Lenght - 1) { yPos++; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (yPos > 1) { yPos--; }
                    break;
                case ConsoleKey.UpArrow:
                    if (xPos > 1) { xPos--; }
                    break;
                case ConsoleKey.DownArrow:
                    if (xPos < Height - 1) { xPos++; }
                    break;
                case ConsoleKey.Spacebar:
                    if (!isProjectile)
                    {
                        isProjectile = true;
                        Create.Threading("projectile");
                        FiredProjectiles++;
                    }
                    break;
                case ConsoleKey.E:
                    if (!isEnemy)
                    {
                        isEnemy = true;
                        Create.Threading("enemy");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
