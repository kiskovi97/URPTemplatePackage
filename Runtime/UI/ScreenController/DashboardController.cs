using UnityEngine;

namespace URPTemplate.UI
{
    public class DashboardController : ScreenController
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
    }
}
