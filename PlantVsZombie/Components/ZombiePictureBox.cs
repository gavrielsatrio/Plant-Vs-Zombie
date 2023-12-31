using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Timers.Zombie;

namespace PlantVsZombie.Components
{
    public class ZombiePictureBox : PictureBox
    {
        public ZombieWalkingTimer ZombieWalkingTimer { get; set; }
    }
}
