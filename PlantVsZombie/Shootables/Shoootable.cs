using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Timers.Shootable;

namespace PlantVsZombie.Shootables
{
    public class Shootable
    {
        public int Damage { get; set; }
        public int Speed { get; set; }
        public string ShotBulletType { get; set; }
        public string ShotEffectOnZombie { get; set; }
        public float SlowEffect { get; set; }

        public ShootablePictureBox ShootablePictureBox { get; set; }

        public PictureBox PicBoxGameArea { get; set; }

        public ShootablePictureBox GetShootable(int x, int y)
        {
            this.ShootablePictureBox = new ShootablePictureBox()
            {
                ImageLocation = Application.StartupPath + $"/Assets/Shootables/{this.ShotBulletType}.png",
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = AssetInfo.ShotPeaSize,
                BackColor = Color.Transparent,
                Location = new Point(x, y),
                ShootableMoveShootTimer = new ShootableMoveShootTimer()
                {
                    Interval = 10
                }
            };

            this.ShootablePictureBox.ShootableMoveShootTimer.ShootablePictureBox = this.ShootablePictureBox;

            this.PicBoxGameArea.Controls.Add(this.ShootablePictureBox);

            return this.ShootablePictureBox;
        }

        public void MoveShoot()
        {
            this.ShootablePictureBox.ShootableMoveShootTimer.Tick += ShootableMoveShootTimer_Tick;
            this.ShootablePictureBox.ShootableMoveShootTimer.Start();
        }

        private void ShootableMoveShootTimer_Tick(object sender, EventArgs e)
        {
            var timerShootableMoveShoot = (ShootableMoveShootTimer)sender;
            var currentShootablePicBox = timerShootableMoveShoot.ShootablePictureBox;

            if (currentShootablePicBox.Location.X >= this.PicBoxGameArea.Width)
            {
                currentShootablePicBox.ShootableMoveShootTimer.Stop();
                this.PicBoxGameArea.Controls.Remove(currentShootablePicBox);

                return;
            }

            var shootedZombie = GameInfo.ZombieList
                   .OrderBy(x => x.ZombiePictureBox.Location.X)
                   .FirstOrDefault(zombie => currentShootablePicBox.IsIntersectingWith(zombie.ZombiePictureBox));

            if (shootedZombie != null)
            {
                currentShootablePicBox.ShootableMoveShootTimer.Stop();
                this.PicBoxGameArea.Controls.Remove(currentShootablePicBox);

                shootedZombie.Health -= this.Damage;
                shootedZombie.WalkMode = this.ShotEffectOnZombie;

                var zombiePictureBox = shootedZombie.ZombiePictureBox;
                zombiePictureBox.ImageLocation = Application.StartupPath + $"/Assets/{shootedZombie.Name}/frame_damaged_{zombiePictureBox.ZombieWalkingTimer.CurrentFrameNo.ToString().PadLeft(2, '0')}.png";
                zombiePictureBox.ZombieWalkingTimer.Interval = AssetInfo.DefaultZombieSpeedInMillisecond + Convert.ToInt32(AssetInfo.DefaultZombieSpeedInMillisecond * this.SlowEffect);

                if (shootedZombie.Health <= 0)
                {
                    shootedZombie.Death();
                }

                return;
            }

            currentShootablePicBox.Location = new Point(currentShootablePicBox.Location.X + this.Speed, currentShootablePicBox.Location.Y);
        }
    }
}
