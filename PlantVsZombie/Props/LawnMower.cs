using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Timers.LawnMower;
using PlantVsZombie.Zombies;

namespace PlantVsZombie.Props
{
    public class LawnMower
    {
        private PictureBox picBoxGameArea;
        private MainForm mainForm;

        private LawnMowerPictureBox lawnMowerPictureBox;

        public LawnMower(PictureBox picBoxGameArea, MainForm mainForm)
        {
            this.picBoxGameArea = picBoxGameArea;
            this.mainForm = mainForm;
        }

        public void PlaceToMap(int x, int y)
        {
            lawnMowerPictureBox = new LawnMowerPictureBox()
            {
                Size = AssetInfo.LawnMowerSize,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(x, y),
                ImageLocation = Application.StartupPath + "/Assets/General/lawnmowerIdle.gif",
                BackColor = Color.Transparent,
                LawnMowerIdleTimer = new LawnMowerIdleTimer()
                {
                    Interval = 100
                },
                LawnMowerMowingTimer = new LawnMowerMowingTimer()
                {
                    Interval = 40
                }
            };
            lawnMowerPictureBox.LawnMowerIdleTimer.LawnMowerPictureBox = lawnMowerPictureBox;
            lawnMowerPictureBox.LawnMowerIdleTimer.Tick += LawnMowerIdleTimer_Tick;
            lawnMowerPictureBox.LawnMowerIdleTimer.Start();

            lawnMowerPictureBox.LawnMowerMowingTimer.LawnMowerPictureBox = lawnMowerPictureBox;
            lawnMowerPictureBox.LawnMowerMowingTimer.Tick += LawnMowerMowingTimer_Tick;

            picBoxGameArea.Controls.Add(lawnMowerPictureBox);
        }

        private void LawnMowerIdleTimer_Tick(object sender, EventArgs e)
        {
            var timerLawnMowerIdle = (LawnMowerIdleTimer)sender;
            var currentPicBoxLawnMower = timerLawnMowerIdle.LawnMowerPictureBox;

            var zombieThatTriggeredLawnMower = GameInfo.ZombieList.Where(x => x.Name == "DiscoZombie")
                   .OrderBy(x => x.ZombiePictureBox.Location.X)
                   .FirstOrDefault(zombie => currentPicBoxLawnMower.IsIntersectingWith(zombie.ZombiePictureBox));

            if(zombieThatTriggeredLawnMower != null)
            {
                timerLawnMowerIdle.Stop();

                lawnMowerPictureBox.BringToFront();
                lawnMowerPictureBox.ImageLocation = Application.StartupPath + $"/Assets/General/lawnmowerActivated.gif";
                lawnMowerPictureBox.LawnMowerMowingTimer.Start();
            }
        }

        private void LawnMowerMowingTimer_Tick(object sender, EventArgs e)
        {
            var timerLawnMowerMowing = (LawnMowerMowingTimer)sender;
            var currentPicBoxLawnMower = timerLawnMowerMowing.LawnMowerPictureBox;

            if(currentPicBoxLawnMower.Location.X >= picBoxGameArea.Width)
            {
                timerLawnMowerMowing.Stop();
                picBoxGameArea.Controls.Remove(currentPicBoxLawnMower);

                return;
            }

            var lawnMowedZombie = GameInfo.ZombieList.Where(x => x.Name == "DiscoZombie")
                   .OrderBy(x => x.ZombiePictureBox.Location.X)
                   .FirstOrDefault(zombie => currentPicBoxLawnMower.IsIntersectingWith(zombie.ZombiePictureBox));

            if(lawnMowedZombie != null)
            {
                lawnMowedZombie.Death();
            }

            currentPicBoxLawnMower.Location = new Point(currentPicBoxLawnMower.Location.X + 6, currentPicBoxLawnMower.Location.Y);
        }        
    }
}
