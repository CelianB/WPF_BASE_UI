using WPF_TEMPLATE_UI.Views;

using System;
using System.Diagnostics;
using System.Globalization;

namespace WPF_TEMPLATE_UI
{
    /// <summary>
    /// Converti <see cref="ApplicationPage"/> vers une page / vue
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Sélection des pages 
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Page1:
                    return new Page1View();
                case ApplicationPage.Page2:
                    return new Page2View();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
