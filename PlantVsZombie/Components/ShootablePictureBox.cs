using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Timers.Shootable;

namespace PlantVsZombie.Components
{
    public class ShootablePictureBox : PictureBox
    {
        public ShootableMoveShootTimer ShootableMoveShootTimer { get; set; }
    }
}
