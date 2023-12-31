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
    public class IceShooter : Plant
    {
        public IceShooter(PictureBox picBoxGameArea, MainForm mainForm)
        {
            this.PicBoxGameArea = picBoxGameArea;
            this.MainForm = mainForm;

            this.Name = "IceShooter";
            this.Cost = 175;
            this.Health = 30;
            this.StartFrameNo = 2;
            this.EndFrameNo = 31;

            this.CanShoot = true;

            this.CooldownTime = 7500;
        }
    }
}
