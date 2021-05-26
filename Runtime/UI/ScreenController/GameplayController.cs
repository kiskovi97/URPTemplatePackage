using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using URPTemplate.Database;

namespace URPTemplate.UI
{
    public class GameplayController : ScreenController
    {
        public static float score = 0;
        public static string userName = "UserName";
        public static float timeScale = 1f;

        public GameObject savePanel;
        public GameObject firstButtonPause;

        public void SaveScore()
        {
            DatabaseTables.scoreTable.AddItem(new Model.MaxScore(score, userName));
            Time.timeScale = timeScale;
            base.ExitClicked();
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

        public override void ExitClicked()
        {
            savePanel.SetActive(true);
            timeScale = Time.timeScale;
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButtonPause);
        }

        public void ResumeClicked()
        {
            savePanel.SetActive(false);
            Time.timeScale = timeScale;

            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
