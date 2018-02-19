using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdditionTutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string BUTTON_STRING_CHECK = "Check";
        public const string BUTTON_STRING_RESET = "Reset";

        AdditionTutorVM additionVm = new AdditionTutorVM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = additionVm;
        }

        private void Button_Check_Click(object sender, RoutedEventArgs e)
        {
            additionVm.VerifyResult();

            if (additionVm.VerificationCode != AdditionTutorVM.VerificationCodeList.RESULT_ERROR_INVALID_ENTRY)
            {
                btnCheckReset.Click -= Button_Check_Click;
                btnCheckReset.Click += Button_Reset_Click;
            }
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            additionVm.Reset();

            btnCheckReset.Click += Button_Check_Click;
            btnCheckReset.Click -= Button_Reset_Click;
        }

        private void UserResult_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numbers to be typed
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Button_Score_Click(object sender, RoutedEventArgs e)
        {
            additionVm.GetScore();

            WindowScore windowScore = new WindowScore
            {
                DataContext = additionVm
            };

            windowScore.Show();
        }
    }
}
