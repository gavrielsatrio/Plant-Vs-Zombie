using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.GlobalVariables;

namespace PlantVsZombie.Layouts
{
    public partial class PlantCardLayout : UserControl
    {
        public int plantIndex = -1;
        public int plantCost = -1;
        public string plantName = "";
        public MainForm mainForm;

        public PlantCardLayout()
        {
            InitializeComponent();
        }

        private void PlantListItem_Load(object sender, EventArgs e)
        {
            lblPlantCost.Text = plantCost.ToString();
            picBoxPlant.ImageLocation = Application.StartupPath + $"/Assets/{plantName}.png";
        }

        private void picBoxPlant_Click(object sender, EventArgs e)
        {
            SelectedPlant.Index = plantIndex;
        }
    }
}
