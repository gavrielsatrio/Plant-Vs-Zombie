using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantVsZombie.Timers.Zombie
{
    public class ZombieWalkingTimer : Timer
    {
        public int FrameChanger { get; set; } = 1;
        public int CurrentFrameNo { get; set; }
        public PictureBox ZombiePictureBox { get; set; }
    }
}
