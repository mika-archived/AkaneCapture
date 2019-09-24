using System.IO;

using QuickCapture.Models;
using QuickCapture.Mvvm;

namespace QuickCapture.ViewModels.Items
{
    internal class CaptureHistoryViewModel : ViewModel
    {
        private readonly ReadingResult _result;

        public string RecordAt => $"Read at : {_result.RecordAt:G}";
        public string Situation => Path.Combine(Constants.SituationsDirPath, _result.Situation.Replace("~/", ""));
        public string Text => _result.Text;

        public CaptureHistoryViewModel(ReadingResult result)
        {
            _result = result;
        }
    }
}