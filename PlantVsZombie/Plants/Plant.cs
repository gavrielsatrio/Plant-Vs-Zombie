using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.Components;
using PlantVsZombie.Droppables;
using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Shootables;
using PlantVsZombie.Timers.Plant;

namespace PlantVsZombie.Plants
{
    public class Plant
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
        public int CooldownTime { get; set; }
        public bool CanProduceSun { get; set; } = false;
        public bool CanShoot { get; set; } = false;
        public int StartFrameNo { get; set; }
        public int EndFrameNo { get; set; }

        public PlantPictureBox PlantPictureBox { get; set; }

        public PictureBox PicBoxGameArea { get; set; }
        public MainForm MainForm { get; set; }

        public void PlantToGround(int x, int y)
        {
            this.PlantPictureBox = new PlantPictureBox()
            {
                Size = AssetInfo.PlantedPlantSize,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(x, y),
                BackColor = Color.Transparent
            };

            this.PlantPictureBox.PlantIdleTimer = new PlantIdleTimer()
            {
                CurrentFrameNo = this.StartFrameNo,
                Interval = 90,
                PlantPictureBox = this.PlantPictureBox
            };

            this.PlantPictureBox.ImageLocation = Application.StartupPath + $"/Assets/{this.Name}/frame_{this.PlantPictureBox.PlantIdleTimer.CurrentFrameNo.ToString().PadLeft(2, '0')}.png";

            if (this.CanShoot == true)
            {
                var plantRaycastPictureBox = new PlantRaycastPictureBox()
                {
                    Size = new Size((GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width + (GameInfo.ColumnCount * AssetInfo.PlantTileSize.Width)) - (this.PlantPictureBox.Location.X + this.PlantPictureBox.Width), 0),
                    BackColor = Color.Transparent,
                    Location = new Point(this.PlantPictureBox.Location.X + this.PlantPictureBox.Width, y + (AssetInfo.PlantTileSize.Height / 2))
                };

                this.PlantPictureBox.PlantShootTimer = new PlantShootTimer()
                {
                    Interval = 1425,
                    PlantPictureBox = this.PlantPictureBox,
                    PlantRaycastPictureBox = plantRaycastPictureBox
                };

                this.PicBoxGameArea.Controls.Add(plantRaycastPictureBox);
                this.StartShootAnimationTimer();
            }

            if(this.CanProduceSun == true)
            {
                this.PlantPictureBox.PlantProduceSunTimer = new PlantProduceSunTimer()
                {
                    Interval = 7000,
                    PlantPictureBox = this.PlantPictureBox
                };

                this.StartProduceSunAnimationTimer();
            }

            this.PicBoxGameArea.Controls.Add(this.PlantPictureBox);
            this.StartIdleAnimationTimer();
        }

        private void StartShootAnimationTimer()
        {
            this.PlantPictureBox.PlantShootTimer.Tick += PlantShootTimer_Tick; ;
            this.PlantPictureBox.PlantShootTimer.Start();
        }

        private void PlantShootTimer_Tick(object sender, EventArgs e)
        {
            var plantShootTimer = (PlantShootTimer)sender;
            var plantRaycastPicBox = plantShootTimer.PlantRaycastPictureBox;

            var sameRowZombie = GameInfo.ZombieList.Where(x => x.Name == "DiscoZombie")
                   .OrderBy(x => x.ZombiePictureBox.Location.X)
                   .FirstOrDefault(zombie => plantRaycastPicBox.IsRaycasted(zombie.ZombiePictureBox));

            if (sameRowZombie != null)
            {
                var plantPictureBox = plantShootTimer.PlantPictureBox;

                Shootable shotBullet = null;
                if(this.Name == "IceShooter")
                {
                    shotBullet = new IcePea(this.PicBoxGameArea);
                }
                else if(this.Name == "PeaShooter")
                {
                    shotBullet = new Pea(this.PicBoxGameArea);
                }

                shotBullet.GetShootable(plantPictureBox.Location.X + plantPictureBox.Width, plantPictureBox.Location.Y + 16);
                shotBullet.MoveShoot();
            }
        }

        private void StartIdleAnimationTimer()
        {
            this.PlantPictureBox.PlantIdleTimer.Tick += PlantIdleTimer_Tick;
            this.PlantPictureBox.PlantIdleTimer.Start();
        }

        private void PlantIdleTimer_Tick(object sender, EventArgs e)
        {
            var plantIdleTimer = (PlantIdleTimer)sender;

            if (plantIdleTimer.CurrentFrameNo == this.StartFrameNo)
            {
                plantIdleTimer.FrameChanger = 1;
            }
            else if (plantIdleTimer.CurrentFrameNo == this.EndFrameNo)
            {
                plantIdleTimer.FrameChanger = -1;
            }

            plantIdleTimer.CurrentFrameNo += plantIdleTimer.FrameChanger;
            plantIdleTimer.PlantPictureBox.ImageLocation = Application.StartupPath + $"/Assets/{this.Name}/frame_{plantIdleTimer.CurrentFrameNo.ToString().PadLeft(2, '0')}.png";
        }

        private void StartProduceSunAnimationTimer()
        {
            this.PlantPictureBox.PlantProduceSunTimer.Tick += PlantProduceSunTimer_Tick;
            this.PlantPictureBox.PlantProduceSunTimer.Start();
        }

        private void PlantProduceSunTimer_Tick(object sender, EventArgs e)
        {
            var plantProduceSunTimer = (PlantProduceSunTimer)sender;

            var plantLocation = plantProduceSunTimer.PlantPictureBox.Location;
            var producedSun = new Sun(plantProduceSunTimer.PlantPictureBox, MainForm);
            var picBoxSun = producedSun.GetSunPictureBox((AssetInfo.PlantedPlantSize.Width / 2) - (AssetInfo.SunSize.Width / 2), (AssetInfo.PlantedPlantSize.Height / 2) - (AssetInfo.SunSize.Height / 2), AssetInfo.PlantTileSize.Height - AssetInfo.SunSize.Height);

            plantProduceSunTimer.PlantPictureBox.Controls.Add(picBoxSun);

            var random = new Random();
            var throwProducedSunTimer = new PlantThrowProducedSunTimer()
            {
                Interval = 10,
                ToX = random.Next(0, 2) == 0 ? 0 : AssetInfo.PlantedPlantSize.Width - AssetInfo.SunSize.Width,
                ToY = 0,
                ProducedSunPictureBox = picBoxSun
            };
            plantProduceSunTimer.PlantPictureBox.PlantThrowProducedSunTimer = throwProducedSunTimer;

            throwProducedSunTimer.Tick += ThrowProducedSunTimer_Tick; ;
            throwProducedSunTimer.Start();
        }

        private void ThrowProducedSunTimer_Tick(object sender, EventArgs e)
        {
            var throwProducedSunTimer = (PlantThrowProducedSunTimer)sender;
            var producedSunPictureBox = throwProducedSunTimer.ProducedSunPictureBox;

            if (producedSunPictureBox.Location.X == throwProducedSunTimer.ToX && producedSunPictureBox.Location.Y == throwProducedSunTimer.ToY)
            {
                throwProducedSunTimer.Stop();
                throwProducedSunTimer.ProducedSunPictureBox.StartDropping();
            }

            if (producedSunPictureBox.Location.X > throwProducedSunTimer.ToX)
            {
                producedSunPictureBox.Location = new Point(producedSunPictureBox.Location.X - 1, producedSunPictureBox.Location.Y);
            }

            if (producedSunPictureBox.Location.X < throwProducedSunTimer.ToX)
            {
                producedSunPictureBox.Location = new Point(producedSunPictureBox.Location.X + 1, producedSunPictureBox.Location.Y);
            }

            if (producedSunPictureBox.Location.Y > throwProducedSunTimer.ToY)
            {
                producedSunPictureBox.Location = new Point(producedSunPictureBox.Location.X, producedSunPictureBox.Location.Y - 1);
            }
        }

        public void SetTempPlant(int x, int y)
        {
            if(this.PicBoxGameArea.Controls.Find("picBoxTempPlant", false).Length > 0)
            {
                this.PicBoxGameArea.Controls.Remove(this.PicBoxGameArea.Controls.Find("picBoxTempPlant", false)[0]);
            }

            var tempPlantPictureBox = new PictureBox()
            {
                Name = "picBoxTempPlant",
                Size = AssetInfo.PlantedPlantSize,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(x, y),
                BackColor = Color.Transparent
            };

            Bitmap bitmap = new Bitmap(AssetInfo.PlantedPlantSize.Width, AssetInfo.PlantedPlantSize.Height);
            Graphics canvas = Graphics.FromImage(bitmap);

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(new ColorMatrix() { Matrix33 = 0.5f });

            canvas.DrawImage(Image.FromFile(Application.StartupPath + $"/Assets/General/{this.Name}.png"), new Rectangle(0, 0, AssetInfo.PlantedPlantSize.Width, AssetInfo.PlantedPlantSize.Height), 0, 0, AssetInfo.PlantedPlantSize.Width, AssetInfo.PlantedPlantSize.Height, GraphicsUnit.Pixel, attributes);

            tempPlantPictureBox.Image = bitmap;

            tempPlantPictureBox.MouseClick += TempPlantPictureBox_MouseClick;

            this.PicBoxGameArea.Controls.Add(tempPlantPictureBox);
        }

        private void TempPlantPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var tempPlantPicBox = (PictureBox)sender;

            this.PicBoxGameArea.Controls.Remove(tempPlantPicBox);
            this.MainForm.PicBoxGameAreaClick(GameInfo.CurrentMouseLocation.X, GameInfo.CurrentMouseLocation.Y);
        }
    }
}
