using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Lesson_1
{
    static class Game
    {
        static int width, height;
        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        public static BaseObject[] _asteroids;
        static Shot shot;
        static bool flag = false;
        static int asteroidsCounter;
        static int countCollision = 0;
        static int gameScore = 5;

        static BackGround back;
        public static int Width 
        { 
            get
            {
                return width;
            }
            set
            {
                while(true)
                {
                    try
                    {
                        
                        
                        if (value > 400 && value <= Screen.PrimaryScreen.WorkingArea.Width)
                        {
                            width = value;
                            break;
                        }
                        else throw new ArgumentOutOfRangeException();
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Введите размер экрана по ширине: ");
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
        }
        public static int Height 
        {
            get
            {
                return height;
            }
            set
            {
                while (true)
                {
                    try
                    {
                        
                        if (value > 500 && value <= Screen.PrimaryScreen.WorkingArea.Height)
                        {
                            height = value;
                            break;
                        }
                        else throw new ArgumentOutOfRangeException();
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Введите размер окна по высоте: ");
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
        }

        static Random rnd = new Random();

        public static bool Flag
        {
            set 
            {
                flag = value;
                if (flag == true)
                    shot.Update(rnd.Next(0, Height));
            }
        }
        public static Random Rnd
        {
            get { return rnd; }
        }

        public static int AsteroidsCounter
        {
            get { return asteroidsCounter; }
            set
            {
                while(true)
                {
                    try
                    {
                        if (value > 0 && value < 20)
                        {
                            asteroidsCounter = value;
                            break;
                        }
                        else throw new AsteroidsException();
                    }
                    catch (AsteroidsException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Введите количество астероидов: ");
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
        }

        public static int CountCollision
        {
            get => countCollision;
            set => countCollision = value;
        }
        static Game()
        {

        }

        public static void Init(Form f1)
        {

            Graphics g;

            _context = BufferedGraphicsManager.Current;
            g = f1.CreateGraphics();

            Buffer = _context.Allocate(g, new Rectangle(0, 0, width, height));
            Load();
            back = new BackGround();
            back.LoadImage();
            Timer timer = new Timer {Interval = 1};
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            back.Draw();
            //Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject i in _objs)
                i.Draw();
            if (countCollision <= gameScore & flag == true)
            {
                foreach (BaseObject j in _asteroids)
                    j.Draw();
                shot.Draw();
            }
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject i in _objs)
                i.Update();
            if (countCollision < gameScore & flag == true)
            {
                foreach (BaseObject j in _asteroids)
                {
                    j.Update();
                    if (j.Collision(shot))
                    {
                        countCollision++;
                        System.Media.SystemSounds.Hand.Play();
                        {
                            shot.Update(rnd.Next(0, Height));
                            j.Update(rnd.Next(0, Height));
                            FormGame.RefreshLScore();
                        }
                        if (countCollision == gameScore)
                        {
                            GameOver();
                            break;
                        }
                    }
                }
            }
            shot.Update();
        }

        public static void GameOver()
        {
            Console.Write("Введите свое имя: ");
            string name = Console.ReadLine();
            Records records = new Records(1, name, countCollision);
            Records.InputList(records);
            back.Draw();
            foreach (var i in _objs)
                i.Draw();
        }
        public static void Load()
        {
            _objs = new BaseObject[100];
            _asteroids = new BaseObject[asteroidsCounter];
            for (int i = 0; i < _asteroids.Length; i++)
                _asteroids[i] = new Asteroids(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(rnd.Next(2, 10), 3), new Size(rnd.Next(30, 60), rnd.Next(30, 60)));
            for (int i = 0; i < _objs.Length; i++)
            {
                int sizeStar = rnd.Next(2, 15);
                _objs[i] = new Stars(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(rnd.Next(0, 3), 3), new Size(sizeStar, sizeStar));
            }
            shot = new Shot(new Point(0, rnd.Next(0, Height)), new Point(10, 0), new Size(100, 50));
        }
    }
}
