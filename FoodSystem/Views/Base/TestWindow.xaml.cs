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

namespace FoodSystem.Views.Base
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public List<DateTime> SelectedDates = new List<DateTime>()
        {
            new DateTime(2023,1,1)
        };

        public string CurrentMode => "Year";
        public void SelectedDate(DateTime time)
        {
            var b = time;
        }
        private DateTime _currentTime;
        public DateTime CurrentTime {
            get => _currentTime;
            set
            {
                _currentTime = value;
            }
        }
        public TestWindow()
        {
            InitializeComponent();
        }
    }
}
