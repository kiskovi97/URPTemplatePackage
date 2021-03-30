
using System;

namespace URPTemplate.Database
{
    public interface IAppSettingsDatabase
    {
        float UiSoundVolume { get; set; }

        event Action Updated;
    }
}
