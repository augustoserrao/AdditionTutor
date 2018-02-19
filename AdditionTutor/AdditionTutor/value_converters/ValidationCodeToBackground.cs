using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AdditionTutor.value_converters
{
    class ValidationCodeToBackground : IValueConverter
    {
        const string BACKGROUND_RESULT_OK = "Green";
        const string BACKGROUND_RESULT_WRONG = "Red";
        const string BACKGROUND_RESULT_ERROR_INVALID = "#A0FFFFFF";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AdditionTutorVM.VerificationCodeList code = (AdditionTutorVM.VerificationCodeList)value;
            string ret;

            switch (code)
            {
                case AdditionTutorVM.VerificationCodeList.RESULT_OK:
                    ret = BACKGROUND_RESULT_OK;
                    break;
                case AdditionTutorVM.VerificationCodeList.RESULT_WRONG:
                    ret = BACKGROUND_RESULT_WRONG;
                    break;
                case AdditionTutorVM.VerificationCodeList.RESULT_ERROR_INVALID_ENTRY:
                    ret = BACKGROUND_RESULT_ERROR_INVALID;
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
