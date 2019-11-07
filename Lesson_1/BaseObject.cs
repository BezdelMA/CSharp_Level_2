using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Lesson_1
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size size;

        public BaseObject (Point Pos, Point Dir, Size size)
        {
            this.Pos = Pos;
            this.Dir = Dir;
            this.size = size;
        }

        virtual public void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, size.Width, size.Height);
        }

        abstract public void Update();

        abstract public void Update(int position);

        public Rectangle Rect => new Rectangle(Pos, size);
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
    }
}
