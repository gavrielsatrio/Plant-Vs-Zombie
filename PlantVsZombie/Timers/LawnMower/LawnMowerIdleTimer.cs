using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;

namespace PlantVsZombie.Timers.LawnMower
{
    public class LawnMowerIdleTimer : Timer
    {
        public LawnMowerPictureBox LawnMowerPictureBox { get; set; }
    }
}
