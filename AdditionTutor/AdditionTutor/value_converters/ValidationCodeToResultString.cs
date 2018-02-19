using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AdditionTutor.value_converters
{
    class ValidationCodeToResultString : IValueConverter
    {
        const string STRING_RESULT_OK = "Correct";
        const string STRING_RESULT_WRONG = "Incorrect";
        const string STRING_RESULT_ERROR_INVALID = "Enter result";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AdditionTutorVM.VerificationCodeList code = (AdditionTutorVM.VerificationCodeList)value;
            string ret;

            switch (code)
            {
                case AdditionTutorVM.VerificationCodeList.RESULT_OK:
                    ret = STRING_RESULT_OK;
                    break;
                case AdditionTutorVM.VerificationCodeList.RESULT_WRONG:
                    ret = STRING_RESULT_WRONG;
                    break;
                case AdditionTutorVM.VerificationCodeList.RESULT_ERROR_INVALID_ENTRY:
                    ret = STRING_RESULT_ERROR_INVALID;
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
