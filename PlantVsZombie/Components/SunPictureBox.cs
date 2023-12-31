using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Timers.Sun;

namespace PlantVsZombie.Components
{
    public class SunPictureBox : PictureBox
    {
        public int RotateAngle { get; set; }
        public float Opacity { get; set; }
        public SunDropTimer SunDropTimer { get; set; }
        public SunBeforeExpiredTimer SunBeforeExpiredTimer { get; set; }
        public SunExpiredTimer SunExpiredTimer { get; set; }
        public SunBlibBlibTimer SunBlibBlibTimer { get; set; }

        public void StartDropping()
        {
            this.SunDropTimer.Start();
        }
    }
}
