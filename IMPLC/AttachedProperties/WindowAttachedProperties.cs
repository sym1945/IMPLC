using System.Windows;

namespace IMPLC
{
    public class WindowHideProperty : AttachedPropertyBase<WindowHideProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Window window))
                return;

            if ((bool)e.NewValue)
                window.Hide();
            else
                window.Show();
        }
    }
}