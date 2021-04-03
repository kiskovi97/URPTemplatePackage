using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using URPTemplate.Database;

namespace URPTemplate.UI
{
    public class DashboardController : ScreenController
    {
        public List<Text> maxScores;
        private void Awake()
        {
            var scores = DatabaseTables.scoreTable.GetAll().OrderBy(item => item.time).OrderByDescending(item => item.score).ToArray();
            for (int i = 0; i < scores.Length && i < maxScores.Count; i++)
                maxScores[i].text = scores[i].name + " : " + scores[i].score + " at: " + scores[i].time;
        }

        public void StartClicked()
        {
            Debug.Log("Start Clicked"); 
            UIScreenManager.GoToGamePlayScreen();
        }

        public void SettingsClicked()
        {
            Debug.Log("Settings Clicked"); 
            UIScreenManager.GoToSettingsScreen();
        }

        public void MarketPlaceClicked()
        {
            Debug.Log("MarketPlace Clicked");
            UIScreenManager.GoToMarketPlaceScreen();
        }
    }
}
