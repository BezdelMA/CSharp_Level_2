using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace Lesson_1
{
    class BackGround
    {
        static Image img;
        public void LoadImage()
        {
            FileStream fs = new FileStream(@"Image\\BackGraund.jpg", FileMode.Open);
            img = Image.FromStream(fs);
            fs.Close();
        }

        public void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, new Rectangle(0, 0, img.Width/(img.Width/Game.Width), img.Height/(img.Height/Game.Height)));
        }
    }
}
