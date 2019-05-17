using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPF_TEMPLATE_UI
{
    /// <summary>
    /// Base value converter qui permet d'utiliser le XAML directement
    /// </summary>
    /// <typeparam name="T">Type du value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter 
        where T : class, new()
    {
        /// <summary>
        /// Singleton : On veut une seul instance du value converter
        /// </summary>
        private static T converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new T());
        }
        #region value converter method
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion
    }
}
