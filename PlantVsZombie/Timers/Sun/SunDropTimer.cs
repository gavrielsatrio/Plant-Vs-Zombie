using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PlantVsZombie.Components;

namespace PlantVsZombie.Timers.Sun
{
    public class SunDropTimer : Timer
    {
        public int MaxY { get; set; }
        public SunPictureBox SunPictureBox { get; set; }
    }
}
