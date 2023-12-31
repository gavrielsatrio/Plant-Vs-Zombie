using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PlantVsZombie.GlobalVariables
{
    public static class AssetInfo
    {
        public static Size SunSize = new Size(50, 50);
        public static Size PlantTileSize = new Size(90, 100);
        public static Size LawnMowerSize = new Size(60, 70);
        public static Size PlantCardSize = new Size(78, 84);
        public static Size PlantedPlantSize = new Size(90, 100);
        public static Size ZombieSize = new Size(70, 100);
        public static Size ShotPeaSize = new Size(24, 24);

        public static int DefaultZombieSpeedInMillisecond = 60;
    }
}
