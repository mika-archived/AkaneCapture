using System.Collections.Generic;
using System.Configuration;

namespace AkaneCapture.Models
{
    public class ApplicationSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        public List<string> TargetProcesses
        {
            get => (List<string>) this[nameof(TargetProcesses)];
            set => this[nameof(TargetProcesses)] = value;
        }

        [UserScopedSetting]
        public long CaptureFrames
        {
            get => this[nameof(CaptureFrames)] == null ? 5 : (long) this[nameof(CaptureFrames)];
            set => this[nameof(CaptureFrames)] = value;
        }

        [UserScopedSetting]
        public long CaptureRate
        {
            get => this[nameof(CaptureRate)] == null ? 1000 : (long) this[nameof(CaptureRate)];
            set => this[nameof(CaptureRate)] = value;
        }
    }
}