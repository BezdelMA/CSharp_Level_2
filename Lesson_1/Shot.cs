using System;
using System.Drawing;
using System.IO;

namespace Lesson_1
{
    class Shot : BaseObject
    {
        int power;
        Image img;

        public Shot(Point Pos, Point Dir, Size size) : base(Pos, Dir, size)
        {
            power = Dir.X;
            LoadImage();
        }
        
        void LoadImage()
        {
            FileStream fs = new FileStream(@"Image\\Shot.png", FileMode.Open);
            img = Image.FromStream(fs);
            fs.Close();
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            Pos.X += power;
            if (Pos.X > Game.Width)
                Update(Game.Rnd.Next(0, 600));
        }

        public override void Update(int position)
        {
            Pos.X = -size.Width;
            Pos.Y = position;
        }
    }
}
