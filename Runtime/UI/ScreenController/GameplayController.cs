using UnityEngine;
using URPTemplate.Database;

namespace URPTemplate.UI
{
    public class GameplayController : ScreenController
    {
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

        public override void ExitClicked()
        {
            DatabaseTables.scoreTable.AddItem(new Model.MaxScore(Random.value * 10f, "Name " + Random.Range(0, 3)));
            base.ExitClicked();
        }
    }
}
