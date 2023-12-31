using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantVsZombie.Plants;
using PlantVsZombie.Zombies;

namespace PlantVsZombie.GlobalVariables
{
    public static class GameInfo
    {
        public static int GameAreaTopPadding { get; set; } = 30;
        public static int GameAreaLeftPadding { get; set; } = 20;
        public static int RowCount = 5;
        public static int ColumnCount = 9;
        public static int SunCount { get; set; } = 75;

        public static List<Plant> PlantList = new List<Plant>();
        public static List<Zombie> ZombieList = new List<Zombie>();

        public static Point CurrentMouseLocation { get; set; }
    }
}
