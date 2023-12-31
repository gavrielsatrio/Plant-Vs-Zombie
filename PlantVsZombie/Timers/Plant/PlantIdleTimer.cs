using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;

namespace PlantVsZombie.Timers.Plant
{
    public class PlantIdleTimer : Timer
    {
        public int CurrentFrameNo { get; set; }
        public int FrameChanger { get; set; } = 1;
        public PlantPictureBox PlantPictureBox { get; set; }
    }
}
