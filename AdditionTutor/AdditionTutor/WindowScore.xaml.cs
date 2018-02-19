using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdditionTutor
{
    /// <summary>
    /// Interaction logic for WindowHistory.xaml
    /// </summary>
    public partial class WindowScore : Window
    {
        public const float BAR_MAX_HEIGHT = 150;

        public WindowScore()
        {
            InitializeComponent();

            AdditionTutorVM additionVm = (AdditionTutorVM)DataContext;
        }
    }
}
