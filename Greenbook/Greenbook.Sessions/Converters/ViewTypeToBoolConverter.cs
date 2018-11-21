using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Greenbook.Sessions.Converters
{
    public class ViewTypeToBoolConverter : MarkupExtension, IValueConverter
    {
        public ViewType ViewType { get; set; } = ViewType.All;

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DoesViewTypeMatch(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public bool DoesViewTypeMatch(object value)
        {
            if (value == null) return false;

            var enumValue = value.ToString();

            if (string.IsNullOrEmpty(enumValue)) return false;

            var parsed = Enum.TryParse(value.ToString(), true, out ViewType result);

            if (!parsed) return false;

            return result == ViewType;
        }
    }
}