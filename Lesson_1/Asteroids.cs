using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Lesson_1
{
    class Asteroids : BaseObject
    {
        Image img;
        public Asteroids (Point Pos, Point Dir, Size size) :base (Pos, Dir, size)
        {
            LoadImage();
        }

        public void LoadImage()
        {
            FileStream fs = new FileStream(@"Image\\asteroids.png", FileMode.Open);
            img = Image.FromStream(fs);
            fs.Close();
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0)
                Pos.X = Game.Width + size.Width;
        }

        public override void Update(int position)
        {
            Pos.X = Game.Width + size.Width;
            Pos.Y = position;
        }
    }
}
