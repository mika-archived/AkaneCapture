using System.Collections.Generic;
using System.Configuration;

namespace QuickCapture.Models
{
    public class ApplicationSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        public List<string> TargetProcesses
        {
            get => (List<string>) this[nameof(TargetProcesses)];
            set => this[nameof(TargetProcesses)] = value;
        }

    }
}