using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;

namespace PlantVsZombie.Timers.Sun
{
    public class SunBlibBlibTimer : Timer
    {
        public SunPictureBox SunPictureBox { get; set; }
        public Image LastDroppedSunImage { get; set; }
        public float CurrentOpacity { get; set; } = 1.0f;
        public float OpacityChanger { get; set; } = 0.1f;
    }
}
