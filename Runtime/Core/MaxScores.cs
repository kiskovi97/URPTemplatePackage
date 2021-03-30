

namespace URPTemplate.Core
{
    public class MaxScores : SavableItem
    {
        public float score;
        public string name;

        public MaxScores(float score, string name)
        {
            id = name;
            this.name = name;
            this.score = score;
        }
    }
}
