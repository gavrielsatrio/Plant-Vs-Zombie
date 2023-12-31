using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.Droppables;
using PlantVsZombie.GlobalVariables;

namespace PlantVsZombie.Plants
{
    public class Sunflower : Plant
    {
        public Sunflower(PictureBox picBoxGameArea, MainForm mainForm)
        {
            this.PicBoxGameArea = picBoxGameArea;
            this.MainForm = mainForm;

            this.Name = "SunFlower";
            this.Cost = 50;
            this.Health = 30;
            this.StartFrameNo = 1;
            this.EndFrameNo = 24;

            this.CanProduceSun = true;

            this.CooldownTime = 7500;
        }
    }
}
