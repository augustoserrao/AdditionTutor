using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AdditionTutor.value_converters
{
    class ValidationCodeToForeground : IValueConverter
    {
        const string FOREGROUND_RESULT_OK_OR_WRONG = "White";
        const string FOREGROUND_RESULT_ERROR_INVALID = "Red";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AdditionTutorVM.VerificationCodeList code = (AdditionTutorVM.VerificationCodeList)value;
            string ret;

            switch (code)
            {
                case AdditionTutorVM.VerificationCodeList.RESULT_OK:
                case AdditionTutorVM.VerificationCodeList.RESULT_WRONG:
                    ret = FOREGROUND_RESULT_OK_OR_WRONG;
                    break;
                case AdditionTutorVM.VerificationCodeList.RESULT_ERROR_INVALID_ENTRY:
                    ret = FOREGROUND_RESULT_ERROR_INVALID;
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
