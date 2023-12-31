using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Timers.Plant;

namespace PlantVsZombie.Components
{
    public class PlantPictureBox : PictureBox
    {
        public PlantIdleTimer PlantIdleTimer { get; set; }

        // If plant.CanProduceSun == true
        public PlantProduceSunTimer PlantProduceSunTimer { get; set; }
        public PlantThrowProducedSunTimer PlantThrowProducedSunTimer { get; set; }

        // If plant.CanShoot == true
        public PlantShootTimer PlantShootTimer { get; set; }
    }
}
