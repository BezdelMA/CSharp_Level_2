using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Records
    {
        int rank;
        string name;
        int score = 0;
        static List<Records> lRec;

        public string Rank
        {
            get { return rank.ToString(); }
        }

        public string Name
        {
            get { return name; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }


        public string Print
        {
            get
            {
                return null;
            }
        }

        public List<Records> LRec
        {
            get => lRec;
        }

        public Records()
        {

        }
        public Records(int rank, string name, int score)
        {
            this.rank = rank;
            this.name = name;
            this.score = score;
        }

        public static List<Records> LoadList()
        {
            lRec = new List<Records>();
            for (int i = 0; i < 10; i++)
            {
                lRec.Add(new Records(i + 1, "xxxxxxxxxx", 0));
            }
            return lRec;
        }

        public static void InputList(Records records)
        {
            lRec = new List<Records>();
            lRec.Add(records);
        }
    }
}
