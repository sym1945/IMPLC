using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace IMPLC
{
    public class ListBoxScrollIntoViewBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            ListBox listBox = AssociatedObject;
            ((INotifyCollectionChanged)listBox.Items).CollectionChanged += OnListBox_CollectionChanged;
        }

        protected override void OnDetaching()
        {
            ListBox listBox = AssociatedObject;
            ((INotifyCollectionChanged)listBox.Items).CollectionChanged -= OnListBox_CollectionChanged;
        }

        private void OnListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListBox listBox = AssociatedObject;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // scroll the new item into view   
                //listBox.ScrollIntoView(e.NewItems[0]);

                if (VisualTreeHelper.GetChildrenCount(listBox) > 0)
                {
                    Border border = (Border)VisualTreeHelper.GetChild(listBox, 0);
                    ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                    scrollViewer.ScrollToBottom();
                }
            }
        }

    }
}