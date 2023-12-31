using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantVsZombie
{
    public static class PictureBoxExtension
    {
        public static void DrawImageUsingCanvas(this PictureBox picBox, int width, int height, string imagePath)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (var canvas = Graphics.FromImage(bitmap))
            {
                canvas.DrawImage(Image.FromFile(imagePath), 0, 0, width, height);
            }

            picBox.Image = bitmap;
        }

        public static bool IsIntersectingWith(this PictureBox picBox1, PictureBox picBox2)
        {
            var isIntersecting = false;

            if (((picBox1.Location.X + picBox1.Width >= picBox2.Location.X && picBox1.Location.X + picBox1.Width <= picBox2.Location.X + picBox2.Width) || 
                (picBox1.Location.X >= picBox2.Location.X && picBox1.Location.X <= picBox2.Location.X + picBox2.Width)) &&
                picBox1.Location.Y >= picBox2.Location.Y &&
                picBox1.Location.Y <= picBox2.Location.Y + picBox2.Height)
            {
                isIntersecting = true;
            }

            return isIntersecting;
        }

        public static bool IsRaycasted(this PictureBox picBox1, PictureBox picBox2)
        {
            var isRaycasted = false;

            if (picBox2.Location.X >= picBox1.Location.X &&
                picBox2.Location.X <= picBox1.Location.X + picBox1.Width &&
                picBox1.Location.Y >= picBox2.Location.Y &&
                picBox1.Location.Y <= picBox2.Location.Y + picBox2.Height)
            {
                isRaycasted = true;
            }

            return isRaycasted;
        }
    }
}
