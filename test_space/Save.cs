using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAndShootz
{
    internal class Data
    {
        private static string SaveDirection = @"C:\Users\Public\Documents\FlyAndShootzSaves.txt";
        public static void Save()
        {
            try
            {
                string[] datas = System.IO.File.ReadAllLines(SaveDirection);

                if (Convert.ToDouble(datas[0]) < Display.KilledEnemies)
                {
                    string[] DataArray = { Display.KilledEnemies.ToString(), Display.FiredProjectiles.ToString() };
                    System.IO.File.WriteAllLines(SaveDirection, DataArray);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static void GetSave()
        {
            try
            {
                int a = 0;
                string[] datas = System.IO.File.ReadAllLines(SaveDirection);
                foreach (string data in datas)
                {
                    switch (a)
                    {
                        case 0:
                            Display.StatKilledEnemies = Convert.ToDouble(datas[a]);
                            a++;
                            break;
                        case 1:
                            Display.StatFiredProjectiles = Convert.ToDouble(datas[a]);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
