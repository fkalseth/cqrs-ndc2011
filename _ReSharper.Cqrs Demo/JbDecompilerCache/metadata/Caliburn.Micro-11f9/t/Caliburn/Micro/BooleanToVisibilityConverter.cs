// Type: Caliburn.Micro.BooleanToVisibilityConverter
// Assembly: Caliburn.Micro, Version=1.1.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f
// Assembly location: E:\Dropbox\Dropbox\Source\ndc2011\Cqrs Demo\packages\Caliburn.Micro.1.1.0\lib\SL40\Caliburn.Micro.dll

using System;
using System.Globalization;
using System.Windows.Data;

namespace Caliburn.Micro
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
