using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Timers.LawnMower;

namespace PlantVsZombie.Components
{
    public class LawnMowerPictureBox : PictureBox
    {
        public LawnMowerIdleTimer LawnMowerIdleTimer { get; set; }
        public LawnMowerMowingTimer LawnMowerMowingTimer { get; set; }
    }
}
