using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Greenbook.Sessions
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

    public class ViewTypeToBoolConverter : MarkupExtension, IValueConverter
    {
        public ViewType ViewType { get; set; } = ViewType.All;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DoesViewTypeMatch(value);
        }

        public bool DoesViewTypeMatch(object value)
        {
            if (value == null)
            {
                return false;
            }

            var enumValue = value.ToString();

            if (string.IsNullOrEmpty(enumValue))
            {
                return false;
            }

            var parsed = Enum.TryParse(value.ToString(), true, out ViewType result);

            if (!parsed)
            {
                return false;
            }

            return result == ViewType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}