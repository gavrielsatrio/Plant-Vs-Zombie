using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Shootables;
using PlantVsZombie.Zombies;

namespace PlantVsZombie.Plants
{
    public class PeaShooter : Plant
    {
        public PeaShooter(PictureBox picBoxGameArea, MainForm mainForm)
        {
            this.PicBoxGameArea = picBoxGameArea;
            this.MainForm = mainForm;

            this.Name = "PeaShooter";
            this.Cost = 100;
            this.Health = 30;
            this.StartFrameNo = 0;
            this.EndFrameNo = 30;

            this.CanShoot = true;

            this.CooldownTime = 7500;
        }
    }
}
