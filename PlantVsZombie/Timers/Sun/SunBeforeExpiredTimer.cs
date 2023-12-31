using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlantVsZombie.Components;

namespace PlantVsZombie.Timers.Sun
{
    public class SunBeforeExpiredTimer : Timer
    {
        public SunPictureBox SunPictureBox { get; set; }
    }
}
