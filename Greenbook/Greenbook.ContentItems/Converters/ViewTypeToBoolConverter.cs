using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Greenbook.ContentItems.Converters
{
    public class BoolToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public Visibility TrueVisibility { get; set; } = Visibility.Visible;
        public Visibility FalseVisibility { get; set; } = Visibility.Collapsed;

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return FalseVisibility;
            }

            var stringValue = value.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return FalseVisibility;
            }

            bool result = bool.TryParse(stringValue, out var boolResult);

            if (!result)
            {
                return FalseVisibility;
            }

            return boolResult ? TrueVisibility : FalseVisibility;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }


    }
}