using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using URPTemplate.Database;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 2f;

    public static LevelLoader Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
        }
        else
            Destroy(this);
    }

    private void Init()
    {
        DatabaseTables.settingsDatabase.Updated += SettingsDatabase_Updated;
        SetValues();
    }

    private void SetValues()
    {
        AudioListener.volume = DatabaseTables.settingsDatabase.UiSoundVolume;
    }

    private void SettingsDatabase_Updated()
    {
        SetValues();
    }

    public static void LoadScene(int levelIndex)
    {
        if (Instance != null)
            Instance.StartCoroutine(Instance.LoadSceneAsync(levelIndex));
        else
            SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator LoadSceneAsync(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
