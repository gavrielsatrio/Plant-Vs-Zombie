using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.GlobalVariables;

namespace PlantVsZombie.Components
{
    public class PlantCardPictureBox : PictureBox
    {
        public int PlantIndex { get; set; }
        public int PlantCost { get; set; }
        public int CooldownTime { get; set; }

        private bool isCooldown = false;
        private float cooldownImageFilterYReduction;
        private float cooldownImageFilterYLocation = 0;

        private bool isInsufficientRedFilterOn = false;
        private bool isInsufficientAnimationDone = true;

        private Timer insufficientSunTimer = new Timer()
        {
            Interval = 1000
        };

        private Timer insufficientSunBlibBlibTimer = new Timer()
        {
            Interval = 50
        };

        private Timer cooldownTimer = new Timer()
        { 
            Interval = 20
        };

        public void InitializeComponents()
        {
            cooldownTimer.Tick += CooldownTimer_Tick;
            insufficientSunTimer.Tick += InsufficientSunTimer_Tick;
            insufficientSunBlibBlibTimer.Tick += InsufficientSunBlibBlibTimer_Tick;

            cooldownImageFilterYReduction = (float)this.Height / (CooldownTime / cooldownTimer.Interval);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if(isCooldown == false)
            {
                ToggleSelectedState(true);

                SelectedPlant.Index = PlantIndex;
                SelectedPlant.PlantCardPictureBox = this;
            }
        }

        public void ToggleSelectedState(bool isSelected)
        {
            Bitmap bitmap = new Bitmap(Image.FromFile(this.ImageLocation));
            Graphics canvas = Graphics.FromImage(bitmap);

            if (SelectedPlant.PlantCardPictureBox != null && SelectedPlant.PlantCardPictureBox != this)
            {
                SelectedPlant.PlantCardPictureBox.ToggleSelectedState(false);
            }

            if (isSelected)
            {
                canvas.FillRectangle(new SolidBrush(Color.FromArgb(80, 0, 0, 0)), 0, 0, bitmap.Width, bitmap.Height);
            }

            this.Image = bitmap;
        }

        public void StartCooldown()
        {
            isCooldown = true;
            cooldownTimer.Start();
        }

        public void TriggerInsufficientSunAnimation()
        {
            if(isInsufficientAnimationDone == true)
            {
                isInsufficientAnimationDone = false;

                insufficientSunTimer.Start();
                insufficientSunBlibBlibTimer.Start();
            }
        }

        private void CooldownTimer_Tick(object sender, EventArgs e)
        {
            if(cooldownImageFilterYLocation >= this.Height)
            {
                isCooldown = false;
                cooldownImageFilterYLocation = 0;
                ToggleSelectedState(false);

                cooldownTimer.Stop();
                return;
            }

            Bitmap bitmap = new Bitmap(Image.FromFile(this.ImageLocation));
            Graphics canvas = Graphics.FromImage(bitmap);

            cooldownImageFilterYLocation += cooldownImageFilterYReduction;

            canvas.FillRectangle(new SolidBrush(Color.FromArgb(80, 0, 0, 0)), 0, cooldownImageFilterYLocation, bitmap.Width, bitmap.Height);

            this.Image = bitmap;
        }

        private void InsufficientSunTimer_Tick(object sender, EventArgs e)
        {
            isInsufficientAnimationDone = true;

            if(SelectedPlant.Index == PlantIndex)
            {
                ToggleSelectedState(true);
            }
            else
            {
                ToggleSelectedState(false);
            }

            insufficientSunBlibBlibTimer.Stop();
            insufficientSunTimer.Stop();
        }

        private void InsufficientSunBlibBlibTimer_Tick(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(Image.FromFile(this.ImageLocation));
            Graphics canvas = Graphics.FromImage(bitmap);

            canvas.FillRectangle(new SolidBrush(Color.FromArgb(isInsufficientRedFilterOn ? 80 : 0, 255, 0, 0)), 0, 0, bitmap.Width, bitmap.Height);

            isInsufficientRedFilterOn = !isInsufficientRedFilterOn;

            this.Image = bitmap;
        }
    }
}
