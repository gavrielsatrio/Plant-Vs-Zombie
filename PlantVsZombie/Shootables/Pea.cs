using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Zombies;

namespace PlantVsZombie.Shootables
{
    public class Pea : Shootable
    {
        public Pea(PictureBox picBoxGameArea)
        {
            this.PicBoxGameArea = picBoxGameArea;

            this.Damage = 10;
            this.Speed = 4;
            this.ShotEffectOnZombie = "normal";
            this.ShotBulletType = "Pea";
            this.SlowEffect = 0f;
        }
    }
}
