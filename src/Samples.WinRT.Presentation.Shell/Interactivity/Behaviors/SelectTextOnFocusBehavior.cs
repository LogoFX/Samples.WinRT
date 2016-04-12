using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Samples.WinRT.Client.Presentation.Shell.Interactivity.Behaviors
{
    public class SelectTextOnFocusBehavior
        : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += AssociatedObjectGotFocus;
        }

        void AssociatedObjectGotFocus(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject is TextBox)
                ((TextBox)AssociatedObject).SelectAll();
            else if (AssociatedObject is PasswordBox)
                ((PasswordBox)AssociatedObject).SelectAll();

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= AssociatedObjectGotFocus;
        }
    }
}