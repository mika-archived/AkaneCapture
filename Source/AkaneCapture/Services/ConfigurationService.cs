using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using AkaneCapture.Models;
using AkaneCapture.Services.Interfaces;

namespace AkaneCapture.Services
{
    internal class ConfigurationService : IConfigurationService
    {
        private readonly ApplicationSettings _settings;

        public ConfigurationService()
        {
            _settings = new ApplicationSettings();
            TargetProcesses = new ObservableCollection<string>();
            TargetProcesses.CollectionChanged += (sender, e) => _settings.TargetProcesses = TargetProcesses.ToList();
        }

        public ObservableCollection<string> TargetProcesses { get; }

        public long CaptureFrames
        {
            get => _settings.CaptureFrames;
            set
            {
                if (_settings.CaptureFrames == value)
                    return;
                _settings.CaptureFrames = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CaptureFrames)));
            }
        }

        public long CaptureRate
        {
            get => _settings.CaptureRate;
            set
            {
                if (_settings.CaptureRate == value)
                    return;
                _settings.CaptureRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CaptureRate)));
            }
        }

        public void Save()
        {
            _settings.Save();
        }

        public void Load()
        {
            _settings.Reload();

            if (_settings.TargetProcesses == null)
                _settings.TargetProcesses = new List<string> { "VRChat" };

            // initialize
            foreach (var process in _settings.TargetProcesses)
                TargetProcesses.Add(process);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}