using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Zombies;

namespace PlantVsZombie.Shootables
{
    public class IcePea : Shootable
    {
        public IcePea(PictureBox picBoxGameArea)
        {
            this.PicBoxGameArea = picBoxGameArea;

            this.Damage = 7;
            this.Speed = 4;
            this.ShotEffectOnZombie = "frozen";
            this.ShotBulletType = "IcePea";
            this.SlowEffect = 0.5f;
        }
    }
}
