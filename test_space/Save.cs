using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAndShootz
{
    internal class FileSet
    {
        public double KilledStats { get; set; }
        public double ShootedStats { get; set; }
        public double MainStat { get; set; }
    }

    internal class Save
    {
        FileSet fileSet = new FileSet
        {
            KilledStats = Display.KilledEnemies,
            ShootedStats = Display.FiredProjectiles,
            MainStat = Display.KilledEnemies / Display.FiredProjectiles * 100
        };
    }
}
