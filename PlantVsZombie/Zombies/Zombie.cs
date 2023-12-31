using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Timers.Zombie;

namespace PlantVsZombie.Zombies
{
    public class Zombie
    {
        public int Health { get; set; }
        public int SpeedModifier { get; set; } = 1;
        public string WalkMode { get; set; } = "normal";
        public string Name { get; set; }
        public int StartFrameNo { get; set; }
        public int EndFrameNo { get; set; }

        public ZombiePictureBox ZombiePictureBox { get; set; }

        public PictureBox PicBoxGameArea { get; set; }
        public MainForm MainForm { get; set; }

        public void Spawn(int x, int y)
        {
            this.ZombiePictureBox = new ZombiePictureBox()
            {
                BackColor = Color.Transparent,
                Location = new Point(x, y),
                Size = AssetInfo.ZombieSize,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.ZombiePictureBox.ZombieWalkingTimer = new ZombieWalkingTimer()
            {
                Interval = AssetInfo.DefaultZombieSpeedInMillisecond + this.SpeedModifier,
                CurrentFrameNo = this.StartFrameNo,
                ZombiePictureBox = this.ZombiePictureBox
            };

            this.ZombiePictureBox.ImageLocation = Application.StartupPath + $"/Assets/{this.Name}/frame_{this.WalkMode}_{this.ZombiePictureBox.ZombieWalkingTimer.CurrentFrameNo.ToString().PadLeft(2, '0')}.png";

            this.PicBoxGameArea.Controls.Add(this.ZombiePictureBox);
            this.StartWalkingAnimationTimer();
        }

        public void Death()
        {
            this.ZombiePictureBox.ZombieWalkingTimer.Stop();

            GameInfo.ZombieList.Remove(this);
            this.PicBoxGameArea.Controls.Remove(this.ZombiePictureBox);
        }

        public void StartWalkingAnimationTimer()
        {
            this.ZombiePictureBox.ZombieWalkingTimer.Tick += ZombieWalkingTimer_Tick;
            this.ZombiePictureBox.ZombieWalkingTimer.Start();
        }

        private void ZombieWalkingTimer_Tick(object sender, EventArgs e)
        {
            var timerZombieWalking = (ZombieWalkingTimer)sender;

            if (timerZombieWalking.CurrentFrameNo == this.StartFrameNo)
            {
                timerZombieWalking.FrameChanger = 1;
            }
            else if (timerZombieWalking.CurrentFrameNo == this.EndFrameNo)
            {
                timerZombieWalking.FrameChanger = -1;
            }

            timerZombieWalking.CurrentFrameNo += timerZombieWalking.FrameChanger;

            timerZombieWalking.ZombiePictureBox.ImageLocation = Application.StartupPath + $"/Assets/{this.Name}/frame_{this.WalkMode}_{timerZombieWalking.CurrentFrameNo.ToString().PadLeft(2, '0')}.png"; ;
            timerZombieWalking.ZombiePictureBox.Location = new Point(timerZombieWalking.ZombiePictureBox.Location.X - this.SpeedModifier, timerZombieWalking.ZombiePictureBox.Location.Y);
        }
    }
}
