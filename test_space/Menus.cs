using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Configuration;

namespace FlyAndShootz
{
    internal class Menus
    {
        private static int SelectedMenu = 0;
        private static int SelectedSMenu = 0;

        public static bool mainMenu = true;
        private static bool settings = false;

        private static ConsoleKey Pressed;

        public static void MainMenu()
        {
            while (mainMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                if (SelectedMenu == 0) { Console.ForegroundColor = ConsoleColor.Green; }
                Console.WriteLine("Játék indítása");
                Console.ForegroundColor = ConsoleColor.White;
                if (SelectedMenu == 1) { Console.ForegroundColor = ConsoleColor.Green; }
                Console.WriteLine("Beállítások");
                Console.ForegroundColor = ConsoleColor.White;
                if (SelectedMenu == 2) { Console.ForegroundColor = ConsoleColor.Green; }
                Console.WriteLine("Kilépés");
                Pressed = Console.ReadKey(true).Key;
                switch (Pressed)
                {
                    case ConsoleKey.UpArrow:
                        if (SelectedMenu > 0)
                        {
                            SelectedMenu--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedMenu < 2)
                        {
                            SelectedMenu++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (SelectedMenu)
                        {
                            case 0:
                                mainMenu = false;
                                Program.isProgram = true;
                                Display.KilledEnemies = 0;
                                Display.FiredProjectiles = 0;
                                Delete.Enemy();
                                Delete.EnemyProjectile();
                                Delete.Projectile();
                                break;
                            case 1:
                                settings = true;
                                Settings();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }
            }
        }

        public static void Settings()
        {
            while (settings)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                if (SelectedSMenu == 0) { Console.ForegroundColor = ConsoleColor.Green; }
                Console.WriteLine("Statok törlése");
                Console.ForegroundColor = ConsoleColor.White;
                if (SelectedSMenu == 1) { Console.ForegroundColor = ConsoleColor.Green; }
                Console.WriteLine("Vissza");
                Pressed = Console.ReadKey(true).Key;
                switch (Pressed)
                {
                    case ConsoleKey.UpArrow:
                        if (SelectedSMenu > 0) { SelectedSMenu--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedSMenu < 1) { SelectedSMenu++; }
                        break;
                    case ConsoleKey.Enter:
                        switch (SelectedSMenu)
                        {
                            case 0:
                                break;
                            case 1:
                                settings = false;
                                break;
                        }
                        break;
                }
            }
        }

        public static void EpilepsziaFelhivas()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("░██╗░░░░░░░██╗░█████╗░██████╗░███╗░░██╗██╗███╗░░██╗░██████╗░");
            Console.WriteLine("░██║░░██╗░░██║██╔══██╗██╔══██╗████╗░██║██║████╗░██║██╔════╝░");
            Console.WriteLine("░╚██╗████╗██╔╝███████║██████╔╝██╔██╗██║██║██╔██╗██║██║░░██╗░");
            Console.WriteLine("░░████╔═████║░██╔══██║██╔══██╗██║╚████║██║██║╚████║██║░░╚██╗");
            Console.WriteLine("░░╚██╔╝░╚██╔╝░██║░░██║██║░░██║██║░╚███║██║██║░╚███║╚██████╔╝");
            Console.WriteLine("░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚══╝░╚═════╝░");
            Console.WriteLine("");
            Console.WriteLine("EZ A JÁTÉK POTENCIONÁLIS EPILEPSZIA ROHAMOT OKOZHAT!");
            Console.WriteLine("AMENYIBBEN ROSSZÚLLÉTET ÉRZEL A JÁTÉK JÁTSZÁSA KÖZBEN AZONNAL HAGYD ABBA!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Nyomj egy gombot a továbblépéshez.");
            Console.ReadKey(true);
        }
    }
}
