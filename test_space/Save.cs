using System;
using System.IO;

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
            try
            {
                using (StreamReader sr = new StreamReader(SaveDirection))
                {
                    string line = sr.ReadLine();
                    data = line.Split(';');
                }
            }
            catch
            {
                data[0] = "0";
                data[1] = "0";
                using (StreamWriter sw = new StreamWriter(SaveDirection))
                {
                    sw.Write($"{data[0]};{data[1]}");
                }
            }
            return data;
        }
    }
}
