using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using System.Xml.Linq;

namespace FlyAndShootz
{
    internal class Program
    {
        private static bool epi = false;
        public static bool isProgram = true;
        private static int[] MoveDatas;
        private static ConsoleKey pressed;
        private static Thread DisplayThread;
        static void Main(string[] args)
        {
            Console.Title = "Fly and Shootz";
            string[] savearg = Data.GetSave();
            Display.StatKilledEnemies = Convert.ToDouble(savearg[0]);
            Display.StatFiredProjectiles = Convert.ToDouble(savearg[1]);
            while (true)
            {
                if (!epi)
                {
                    Data.GetSave();
                    Menus.EpilepsziaFelhivas();
                    epi = !epi;
                }
                Menus.mainMenu = true;
                Menus.MainMenu();
                MoveDatas = new int[2];
                MoveDatas[0] = Display.Height - 1;
                MoveDatas[1] = Display.Lenght / 2;
                DisplayThread = new Thread(Display.Write);
                DisplayThread.Start();
                while (isProgram)
                {
                    pressed = Console.ReadKey(true).Key;
                    Display.Move(pressed);
                }
            }
        }
    }
}
