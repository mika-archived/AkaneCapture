using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using QuickCapture.Models;
using QuickCapture.Services.Interfaces;

namespace QuickCapture.Services
{
    internal class ConfigurationService : IConfigurationService
    {
        private readonly ApplicationSettings _settings;

        public ConfigurationService()
        {
            _settings = new ApplicationSettings();
        }

        public void Save()
        {
            _settings.Save();
        }

        public void Load()
        {
            _settings.Reload();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}