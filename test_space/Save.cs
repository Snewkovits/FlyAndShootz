using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAndShootz
{
    internal class Data
    {
        private static string SaveDirection = @"Saves.csv";
        public static void Save()
        {
            string data = $"{Display.KilledEnemies};{Display.FiredProjectiles}";
            string[] dataTable = GetSave();
            if (Convert.ToDouble(dataTable[0]) < Display.KilledEnemies)
            {
                Display.StatKilledEnemies = Display.KilledEnemies;
                Display.StatFiredProjectiles = Display.FiredProjectiles;
                using (StreamWriter sw = new StreamWriter(SaveDirection))
                {
                    sw.Write(data);
                }
            }
        }

        // Killed, Fired
        public static string[] GetSave()
        {
            string[] data = new string[2];

            using (StreamReader sr = new StreamReader(SaveDirection))
            {
                string line = sr.ReadLine();
                data = line.Split(';');
            }
            return data;
        }
    }
}
