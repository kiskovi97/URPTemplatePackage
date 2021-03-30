using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace URPTemplate.UI
{
    public class MarketPlaceController : ScreenController
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
    }
}
