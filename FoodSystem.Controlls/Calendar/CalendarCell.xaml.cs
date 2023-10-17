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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodSystem.Controlls.Calendar
{
    /// <summary>
    /// Логика взаимодействия для CalendarCell.xaml
    /// </summary>
    public partial class CalendarCell : UserControl
    {


        public string Year
        {
            get { return (string)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Year.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(string), typeof(CalendarCell), new PropertyMetadata(""));


        public CalendarCell()
        {
            InitializeComponent();
        }
    }
}
