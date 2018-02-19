using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AdditionTutor.value_converters
{
    class ValidationCodeToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AdditionTutorVM.VerificationCodeList code = (AdditionTutorVM.VerificationCodeList)value;
            Visibility ret = Visibility.Visible;

            if (code == AdditionTutorVM.VerificationCodeList.RESULT_IDLE)
            {
                ret = Visibility.Hidden;
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
