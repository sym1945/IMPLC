using System;
using System.Windows;

namespace IMPLC
{
    public abstract class AttachedPropertyBase<TParent, TProperty>
        where TParent : new()
    {
        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { }; 

        #endregion


        public static TParent Instance { get; private set; } = new TParent();


        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value"
                , typeof(TProperty)
                , typeof(AttachedPropertyBase<TParent, TProperty>)
                , new UIPropertyMetadata(
                    default(TProperty)
                    , new PropertyChangedCallback(OnValuePropertyChanged)
                    , new CoerceValueCallback(OnValuePropertyUpdated)
                    ));

        public static TProperty GetValue(DependencyObject d) => (TProperty)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, TProperty value) => d.SetValue(ValueProperty, value);


        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (Instance as AttachedPropertyBase<TParent, TProperty>)?.OnValueChanged(d, e);

            (Instance as AttachedPropertyBase<TParent, TProperty>)?.ValueChanged(d, e);
        }

        private static object OnValuePropertyUpdated(DependencyObject d, object baseValue)
        {
            (Instance as AttachedPropertyBase<TParent, TProperty>)?.OnValueUpdated(d, baseValue);

            (Instance as AttachedPropertyBase<TParent, TProperty>)?.ValueUpdated(d, baseValue);

            return baseValue;
        }


        #region Event Methods

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }
}