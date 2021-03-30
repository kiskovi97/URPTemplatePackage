using UnityEngine;

namespace URPTemplate.Database
{
    public class DatabaseTableManager : MonoBehaviour
    {
        public static GameObject instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = gameObject;
                DontDestroyOnLoad(gameObject);
            }
            if (instance != gameObject)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DatabaseTables.Initialize();
        }

        private void OnApplicationPause()
        {
            DatabaseTables.SaveToDisk();
        }

        private void OnApplicationQuit()
        {
            DatabaseTables.SaveToDisk();
        }
    }

}
