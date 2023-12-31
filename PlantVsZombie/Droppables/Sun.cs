using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Components;
using PlantVsZombie.Timers.Sun;

namespace PlantVsZombie.Droppables
{
    public class Sun
    {
        private PictureBox parentPicBox;
        private MainForm mainForm;
        private SunPictureBox pictureBoxSun;

        private string sunImagePath = Application.StartupPath + "/Assets/General/Sun.png";

        public Sun(PictureBox parentPicBoxParam, MainForm mainFormParam)
        {
            this.parentPicBox = parentPicBoxParam;
            this.mainForm = mainFormParam;
        }

        public SunPictureBox GetSunPictureBox(int x, int y, int maxYDrop)
        {
            pictureBoxSun = new SunPictureBox()
            {
                Size = AssetInfo.SunSize,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(x, y),
                SunDropTimer = new SunDropTimer()
                {
                    Interval = 60,
                    MaxY = maxYDrop
                },
                SunBeforeExpiredTimer = new SunBeforeExpiredTimer()
                {
                    Interval = 2000
                },
                SunExpiredTimer = new SunExpiredTimer()
                {
                    Interval = 3000
                },
                SunBlibBlibTimer = new SunBlibBlibTimer()
                {
                    Interval = 40
                },
                RotateAngle = 0
            };

            pictureBoxSun.DrawImageUsingCanvas(AssetInfo.SunSize.Width, AssetInfo.SunSize.Height, sunImagePath);
            pictureBoxSun.BackColor = Color.Transparent;
            pictureBoxSun.SunDropTimer.SunPictureBox = pictureBoxSun;
            pictureBoxSun.SunBeforeExpiredTimer.SunPictureBox = pictureBoxSun;
            pictureBoxSun.SunExpiredTimer.SunPictureBox = pictureBoxSun;
            pictureBoxSun.SunBlibBlibTimer.SunPictureBox = pictureBoxSun;

            pictureBoxSun.Click += PictureBoxSun_Click;
            pictureBoxSun.SunDropTimer.Tick += SunDropTimer_Tick;

            return pictureBoxSun;
        }

        private void PictureBoxSun_Click(object sender, EventArgs e)
        {
            var newRandomSun = (SunPictureBox)sender;
            newRandomSun.SunDropTimer.Stop();
            parentPicBox.Controls.Remove(newRandomSun);

            GameInfo.SunCount += 25;
            mainForm.LoadSunCount();
        }

        private void SunDropTimer_Tick(object sender, EventArgs e)
        {
            var timerSunDrop = (SunDropTimer)sender;
            if (timerSunDrop.SunPictureBox.Location.Y >= timerSunDrop.MaxY)
            {
                timerSunDrop.Stop();

                timerSunDrop.SunPictureBox.SunBeforeExpiredTimer.Tick += SunBeforeExpiredTimer_Tick;
                timerSunDrop.SunPictureBox.SunBeforeExpiredTimer.Start();
            }
            else
            {
                var bitmap = new Bitmap(AssetInfo.SunSize.Width, AssetInfo.SunSize.Height);

                using (var canvas = Graphics.FromImage(bitmap))
                {
                    timerSunDrop.SunPictureBox.RotateAngle += 5;

                    canvas.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
                    canvas.RotateTransform(timerSunDrop.SunPictureBox.RotateAngle % 360);
                    canvas.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);
                    canvas.DrawImage(Image.FromFile(sunImagePath), 0, 0, AssetInfo.SunSize.Width, AssetInfo.SunSize.Height);

                    timerSunDrop.SunPictureBox.Image.Dispose();
                    timerSunDrop.SunPictureBox.Image = null;
                    timerSunDrop.SunPictureBox.Image = bitmap;
                }

                timerSunDrop.SunPictureBox.Location = new Point(timerSunDrop.SunPictureBox.Location.X, timerSunDrop.SunPictureBox.Location.Y + 4);
            }
        }

        private void SunBeforeExpiredTimer_Tick(object sender, EventArgs e)
        {
            var timerSunBeforeExpired = (SunBeforeExpiredTimer)sender;

            timerSunBeforeExpired.Stop();

            timerSunBeforeExpired.SunPictureBox.SunBlibBlibTimer.LastDroppedSunImage = timerSunBeforeExpired.SunPictureBox.Image;

            timerSunBeforeExpired.SunPictureBox.SunBlibBlibTimer.Tick += SunBlibBlibTimer_Tick;
            timerSunBeforeExpired.SunPictureBox.SunExpiredTimer.Tick += SunExpiredTimer_Tick;

            timerSunBeforeExpired.SunPictureBox.SunBlibBlibTimer.Start();
            timerSunBeforeExpired.SunPictureBox.SunExpiredTimer.Start();
        }

        private void SunBlibBlibTimer_Tick(object sender, EventArgs e)
        {
            var timerSunBlibBlib = (SunBlibBlibTimer)sender;

            timerSunBlibBlib.SunPictureBox.Image = null;

            var lastDroppedSunImage = timerSunBlibBlib.LastDroppedSunImage;
            var bitmap = new Bitmap(AssetInfo.SunSize.Width, AssetInfo.SunSize.Height);
            using (var canvas = Graphics.FromImage(bitmap))
            {
                //canvas.DrawImage(lastDroppedSunImage, 0, 0, AssetInfo.SunSize.Width, AssetInfo.SunSize.Height);
                //canvas.FillRectangle(new SolidBrush(Color.FromArgb(timerSunBlibBlib.IsSunBlibbing ? 80 : 0, 255, 255, 255)), 0, 0, AssetInfo.SunSize.Width, AssetInfo.SunSize.Height);

                if(timerSunBlibBlib.CurrentOpacity <= 0.0f)
                {
                    timerSunBlibBlib.OpacityChanger = 0.1f;
                }
                else if(timerSunBlibBlib.CurrentOpacity >= 1.0f)
                {
                    timerSunBlibBlib.OpacityChanger = -0.1f;
                }

                timerSunBlibBlib.CurrentOpacity += timerSunBlibBlib.OpacityChanger;

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(new ColorMatrix() { Matrix33 = timerSunBlibBlib.CurrentOpacity }, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                canvas.DrawImage(lastDroppedSunImage, new Rectangle(0, 0, AssetInfo.SunSize.Width, AssetInfo.SunSize.Height), 0, 0, AssetInfo.SunSize.Width, AssetInfo.SunSize.Height, GraphicsUnit.Pixel, attributes);

                timerSunBlibBlib.SunPictureBox.Image = bitmap;
            }
        }

        private void SunExpiredTimer_Tick(object sender, EventArgs e)
        {
            var timerSunExpired = (SunExpiredTimer)sender;

            parentPicBox.Controls.Remove(timerSunExpired.SunPictureBox);

            timerSunExpired.SunPictureBox.SunBlibBlibTimer.Stop();
            timerSunExpired.Stop();
        }
    }
}
