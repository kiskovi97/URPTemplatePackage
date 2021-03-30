using System;
using UnityEngine;
using UnityEngine.UI;
using URPTemplate.Database;

namespace URPTemplate.UI
{
    public class SoundSettingUI : MonoBehaviour
    {
        public Slider slider;
        public Image image;

        public Sprite on;
        public Sprite off;
        public float Value { get; private set; } = 0f;
        public float DatabaseTest { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            Value = DatabaseTables.settingsDatabase.UiSoundVolume;
            slider.onValueChanged.AddListener(ValueChanged);
            slider.value = Value;
            SetVolume();
            DatabaseTables.settingsDatabase.Updated += SettingsDatabase_Updated;
        }

        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(ValueChanged);
            DatabaseTables.settingsDatabase.Updated -= SettingsDatabase_Updated;
        }

        private void SetVolume()
        {
            image.sprite = Value < 0.02f ? off : on;
        }

        private void SettingsDatabase_Updated()
        {
            Value = DatabaseTables.settingsDatabase.UiSoundVolume;
            slider.value = Value;
            SetVolume();
        }

        // Update is called once per frame
        void ValueChanged(float value)
        {
            Value = value;
            DatabaseTables.settingsDatabase.UiSoundVolume = value;
            SetVolume();
        }
    }
}
