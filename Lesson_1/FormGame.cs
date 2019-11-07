using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lesson_1
{
    class FormGame : Form
    {
        public Button bNewGame = new Button();
        public Button bRecords = new Button();
        public Button bExit = new Button();
        public Button bBack = new Button();
        public TextBox tbRecords = new TextBox();
        public Label lAuthor = new Label();
        public static Label lScore = new Label();

        public FormGame()
        {
            Width = Game.Width;
            Height = Game.Height;
            bNewGame.Text = "Новая игра";
            bNewGame.Location = new System.Drawing.Point(25, 50);
            bNewGame.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(bNewGame);
            bNewGame.Click += BNewGame_Click;

            bRecords.Text = "Рекорды";
            bRecords.Location = new System.Drawing.Point(25, 90);
            bRecords.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(bRecords);
            bRecords.Click += BRecords_Click;

            bExit.Text = "Выход";
            bExit.Location = new System.Drawing.Point(25, 130);
            bExit.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(bExit);
            bExit.Click += BExit_Click;

            bBack.Text = "Назад";
            bBack.Location = new System.Drawing.Point(25, 25);
            bBack.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(bBack);
            bBack.Visible = false;
            bBack.Click += BBack_Click;

            tbRecords.Multiline = true;
            tbRecords.ReadOnly = true;
            tbRecords.Font = new System.Drawing.Font("Times New Roman", 18);
            tbRecords.Location = new System.Drawing.Point(25, 50);
            tbRecords.Size = new System.Drawing.Size(750, 500);
            this.Controls.Add(tbRecords);
            tbRecords.Visible = false;

            lAuthor.Location = new System.Drawing.Point(25, Height - 100);
            lAuthor.Font = new System.Drawing.Font("Times New Roman", 14);
            lAuthor.Size = new System.Drawing.Size(260, 24);
            lAuthor.BackColor = new System.Drawing.Color();
            lAuthor.Text = "@Бездель Михаил Алексеевич";
            this.Controls.Add(lAuthor);

            lScore.Location = new System.Drawing.Point(Width - 350, 25);
            lScore.Font = new System.Drawing.Font("Times New Roman", 14);
            lScore.Size = new System.Drawing.Size(300, 24);
            lScore.BackColor = new System.Drawing.Color();
            lScore.Text = "Количество набранных очков: " + Game.CountCollision.ToString();
            lScore.Visible = false;
            this.Controls.Add(lScore);       
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            bNewGame.Visible = true;
            bRecords.Visible = true;
            bExit.Visible = true;
            lAuthor.Visible = true;
            lScore.Visible = false;
            tbRecords.Visible = false;
            bBack.Visible = false;
            Game.Flag = false;
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BRecords_Click(object sender, EventArgs e)
        {
            Records temp = new Records();
            List<Records> lRecords;
            if (temp.LRec == null)
                lRecords = Records.LoadList();
            else lRecords = temp.LRec;
            tbRecords.Visible = true;
            tbRecords.Text = "";
            string text = "";
            foreach (Records r in lRecords)
            {
                text = r.Rank + "\t\t" + r.Name + "\t\t" + r.Score.ToString();
                tbRecords.Text += text + Environment.NewLine;
            }
            bNewGame.Visible = false;
            bRecords.Visible = false;
            bExit.Visible = false;
            bBack.Visible = true;
            Game.Flag = false;
        }

        private void BNewGame_Click(object sender, EventArgs e)
        {
            bNewGame.Visible = false;
            bRecords.Visible = false;
            bExit.Visible = false;
            lAuthor.Visible = false;
            lScore.Text = "Количество набранных очков: " + Game.CountCollision.ToString();
            lScore.Visible = true;
            bBack.Visible = true;
            Game.Flag = true;
            Game.CountCollision = 0;
            Game.Draw();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(Width, Height);
            this.Name = "Астероиды";
            this.ResumeLayout(false);
        }

        internal static void RefreshLScore()
        {
            lScore.Text = "Количество набранных очков: " + Game.CountCollision.ToString();
        }
    }
}
