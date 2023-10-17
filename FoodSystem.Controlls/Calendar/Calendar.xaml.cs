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
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public enum CalendarMode
        {
            Days = 0,
            Months,
            Years,
        }

        public class CalendarItem
        {
            public string Name { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }
        }



        public List<CalendarItem> Years
        {
            get { return (List<CalendarItem>)GetValue(YearsProperty); }
            set { SetValue(YearsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Years.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearsProperty =
            DependencyProperty.Register("Years", typeof(List<CalendarItem>), typeof(Calendar), new PropertyMetadata(new List<CalendarItem>()));



        public CalendarMode Mode
        {
            get { return (CalendarMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(CalendarMode), typeof(Calendar), new PropertyMetadata(CalendarMode.Years));



        public Calendar()
        {

            Years.AddRange(new List<CalendarItem>
            {
                new CalendarItem
                {
                    Name = "2009",
                    Row = 0,
                    Col = 0,
                },
                new CalendarItem
                {
                    Name = "2010",
                    Row = 0,
                    Col = 1,
                }
            });

            InitializeComponent();
        }
    }
}
