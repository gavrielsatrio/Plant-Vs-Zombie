using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Timers.Zombie;

namespace PlantVsZombie.Zombies
{
    public class DiscoZombie : Zombie
    {
        public DiscoZombie(PictureBox picBoxGameArea, MainForm mainForm)
        {
            this.PicBoxGameArea = picBoxGameArea;
            this.MainForm = mainForm;

            this.Health = 50;
            this.SpeedModifier = 2;
            this.StartFrameNo = 0;
            this.EndFrameNo = 33;
        }
    }
}
