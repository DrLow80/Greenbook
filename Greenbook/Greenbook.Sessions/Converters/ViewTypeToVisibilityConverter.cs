using System;
using System.Globalization;
using System.Windows;

namespace Greenbook.Sessions.Converters
{
    public class ViewTypeToVisibilityConverter : ViewTypeToBoolConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DoesViewTypeMatch(value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}