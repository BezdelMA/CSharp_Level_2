using System;
using System.Drawing;

namespace Lesson_1
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
