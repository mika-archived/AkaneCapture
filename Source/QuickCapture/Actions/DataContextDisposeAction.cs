using System;
using System.Windows;
using System.Windows.Interactivity;

namespace QuickCapture.Actions
{
    internal class DataContextDisposeAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke(object parameter)
        {
            var disposable = AssociatedObject.DataContext as IDisposable;
            disposable?.Dispose();
        }
    }
}