using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;

namespace PlantVsZombie.Timers.Plant
{
    public class PlantThrowProducedSunTimer : Timer
    {
        public int ToX { get; set; }
        public int ToY { get; set; }
        public SunPictureBox ProducedSunPictureBox { get; set; }
    }
}
