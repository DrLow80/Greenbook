using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Greenbook.Sessions.Converters
{
    public class CollectionContainsToVisibilityConverter : MarkupExtension,IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var item = values.FirstOrDefault();

            if (item == null || !(values.ElementAtOrDefault(1) is IList items))
            {
                return Visibility.Visible;
            }

            return items.Contains(item) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}