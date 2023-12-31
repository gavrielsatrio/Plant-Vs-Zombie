using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;

namespace PlantVsZombie.GlobalVariables
{
    public static class SelectedPlant
    {
        public static int Index { get; set; } = -1;
        public static PlantCardPictureBox PlantCardPictureBox { get; set; }
    }
}
