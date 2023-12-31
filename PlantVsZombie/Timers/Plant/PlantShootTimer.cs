using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;

namespace PlantVsZombie.Timers.Plant
{
    public class PlantShootTimer : Timer
    {
        public PlantRaycastPictureBox PlantRaycastPictureBox { get; set; }
        public PlantPictureBox PlantPictureBox { get; set; }
    }
}
