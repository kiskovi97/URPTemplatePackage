
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace URPTemplate.UI
{
    public class UIScreenManager : MonoBehaviour
    {
        private static UIScreenManager Instance;

        public SceneManagerSettings settings;
        public static SceneManagerSettings Settings { get => Instance != null ? Instance.settings : SceneManagerSettings.Default; }

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public static void GoToGamePlayScreen()
        {
            LevelLoader.LoadScene(Settings.Gameplay);
        }

        public static void GoToMenuScreen()
        {
            LevelLoader.LoadScene(Settings.Menu);
        }

        public static void GoToSettingsScreen()
        {
            LevelLoader.LoadScene(Settings.Settings);
        }

        internal static void Exit()
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            if (index == Settings.Gameplay)
                GoToDashboardScreen();
            else if (index == Settings.Marketplace || index == Settings.Settings)
                GoToMenuScreen();
            else
                Application.Quit();
        }

        public static void GoToMarketPlaceScreen()
        {
            LevelLoader.LoadScene(Settings.Marketplace);
        }

        public static void GoToDashboardScreen()
        {
            LevelLoader.LoadScene(Settings.Dashboard);
        }
    }
}
