using System;

using QuickCapture.Mvvm;

namespace QuickCapture.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IDisposableExtensions
    {
        public static T AddTo<T>(this T disposable, ViewModel viewModel) where T : IDisposable
        {
            viewModel.CompositeDisposable.Add(disposable);
            return disposable;
        }
    }
}