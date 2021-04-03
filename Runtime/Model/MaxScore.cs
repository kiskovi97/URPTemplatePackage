

using System;

namespace URPTemplate.Model
{
    public class MaxScore : SavableItem
    {
        public float score;
        public string name;
        public DateTime time;
        public MaxScore(float score, string name)
        {
            id = name;
            this.name = name;
            this.score = score;
            time = DateTime.Now;
        }

        public override int CompareTo(object obj)
        {
            if (obj is MaxScore item)
                return score.CompareTo(item.score);
            return -1;
        }
    }
}
