using System;

using AkaneCapture.Mvvm;

namespace AkaneCapture.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IDisposableExtensions
    {
        public static T AddTo<T>(this T disposable, ViewModel viewModel) where T : IDisposable
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            viewModel.CompositeDisposable.Add(disposable);
            return disposable;
        }
    }
}