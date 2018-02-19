using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AdditionTutor.value_converters
{
    class ValidationCodeToButtonString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AdditionTutorVM.VerificationCodeList code = (AdditionTutorVM.VerificationCodeList)value;
            string ret;

            switch (code)
            {
                case AdditionTutorVM.VerificationCodeList.RESULT_OK:
                case AdditionTutorVM.VerificationCodeList.RESULT_WRONG:
                    ret = MainWindow.BUTTON_STRING_RESET;
                    break;
                case AdditionTutorVM.VerificationCodeList.RESULT_ERROR_INVALID_ENTRY:
                case AdditionTutorVM.VerificationCodeList.RESULT_IDLE:
                    ret = MainWindow.BUTTON_STRING_CHECK;
                    break;
                default:
                    ret = "";
                    break;
            }
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
