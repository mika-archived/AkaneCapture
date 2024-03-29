﻿using AkaneCapture.Models.ReadingResults;
using AkaneCapture.Mvvm;
using AkaneCapture.Services.Interfaces;

namespace AkaneCapture.ViewModels.Items
{
    internal class CaptureHistoryViewModel : ViewModel
    {
        private readonly ResultBase _result;

        public string RecordAt => $"{_result.RecordAt:G}";
        public string Situation => _result.Situation;
        public string Text => _result.Text;

        protected CaptureHistoryViewModel(ResultBase result)
        {
            _result = result;
        }

        public static CaptureHistoryViewModel Create(ResultBase result, IExternalUrlService urlService)
        {
            var type = result.GetType();
            if (type == typeof(Website))
                return new WebsiteCaptureHistoryViewModel((Website) result, urlService);
            return new OtherCaptureHistoryViewModel(result);
        }
    }
}