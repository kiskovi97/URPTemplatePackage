using UnityEngine;
using UnityEngine.UI;
using URPTemplate.UI;

namespace URPTemplate.GamePlayExample
{
    public class ScoreGenerator : MonoBehaviour
    {
        public Text text;

        // Start is called before the first frame update
        void Start()
        {
            GameplayController.score = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            GameplayController.score += Time.deltaTime;
            if (text != null)
                text.text = GameplayController.score.ToString();
        }
    }
}


