using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;

namespace PlantVsZombie.Plants
{
    public class WallNut : Plant
    {
        public WallNut(PictureBox picBoxGameArea, MainForm mainForm)
        {
            this.PicBoxGameArea = picBoxGameArea;
            this.MainForm = mainForm;

            this.Name = "WallNut";
            this.Cost = 50;
            this.Health = 200;
            this.StartFrameNo = 0;
            this.EndFrameNo = 32;

            this.CooldownTime = 30000;
        }
    }
}
