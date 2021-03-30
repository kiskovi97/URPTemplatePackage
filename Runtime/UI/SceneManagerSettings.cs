using UnityEngine;

[CreateAssetMenu(fileName = "SceneManagerSettings", menuName = "Settings/SceneManagerSettings", order = 1)]
public class SceneManagerSettings : ScriptableObject
{
    public int Menu = 0;
    public int Dashboard = 4;
    public int Gameplay = 1;
    public int Settings = 2;
    public int Marketplace = 3;

    public static SceneManagerSettings Default => CreateInstance<SceneManagerSettings>();
}
