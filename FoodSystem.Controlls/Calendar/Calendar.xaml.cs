using FoodSystem.Common.Enums;
using FoodSystem.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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



        private DateTime _startInteval;
        private DateTime _endInteval;


        private List<CalendarItem> _dayNames = new List<CalendarItem>
            {
                new CalendarItem
                {
                    Name = "Пн",
                    Row = 0,
                    Col = 0,
                },
                new CalendarItem
                {
                    Name = "Вт",
                    Row = 0,
                    Col = 1,
                },
                new CalendarItem
                {
                    Name = "Ср",
                    Row = 0,
                    Col = 2,
                },
                new CalendarItem
                {
                    Name = "Чт",
                    Row = 0,
                    Col = 3,
                },
                new CalendarItem
                {
                    Name = "Пт",
                    Row = 0,
                    Col = 4,
                },
                new CalendarItem
                {
                    Name = "Сб",
                    Row = 0,
                    Col = 5,
                },
                new CalendarItem
                {
                    Name = "Вс",
                    Row = 0,
                    Col = 6,
                }
            };

        public class CalendarItem : ICloneable
        {
            public string Name { get; set; }
            public DateTime DateTime { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }

            public object Clone()
            {
                return new CalendarItem
                {
                    Name = Name,
                    DateTime = DateTime,
                    Row = Row,
                    Col = Col
                };
            }
        }

        public List<CalendarItem> CalendarItems
        {
            get => GetCalendarItems();
        }

        public CalendarMode Mode
        {
            get { return (CalendarMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(CalendarMode), typeof(Calendar), new PropertyMetadata(CalendarMode.Years));




        public string SelectedText
        {
            get { return (string)GetValue(SelectedTextProperty); }
            set { SetValue(SelectedTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.Register("SelectedText", typeof(string), typeof(Calendar), new PropertyMetadata(string.Empty));




        public bool IsCalendarItemButton
        {
            get { return (bool)GetValue(IsCalendarItemButtonProperty); }
            set { SetValue(IsCalendarItemButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCalendarItemButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCalendarItemButtonProperty =
            DependencyProperty.Register("IsCalendarItemButton", typeof(bool), typeof(Calendar), new PropertyMetadata(true));



        public Calendar()
        {
            InitInterval();
            SelectedText = GetSelectedModeText();
            InitializeComponent();
        }

        private void InitInterval()
        {
            switch (Mode)
            {
                case CalendarMode.Years:
                    {
                        _startInteval = DateTime.Now.ToStartByPeriodicity(Common.Enums.IntervalPeriodicity.Decade);
                        _endInteval = DateTime.Now.ToEndByPeriodicity(Common.Enums.IntervalPeriodicity.Decade);
                        break;
                    }
                case CalendarMode.Months:
                    {
                        _startInteval = DateTime.Now.ToStartByPeriodicity(Common.Enums.IntervalPeriodicity.Month);
                        _endInteval = DateTime.Now.ToEndByPeriodicity(Common.Enums.IntervalPeriodicity.Month);
                        break;
                    }
                case CalendarMode.Days:
                    {
                        _startInteval = DateTime.Now.ToStartByPeriodicity(Common.Enums.IntervalPeriodicity.Day);
                        _endInteval = DateTime.Now.ToEndByPeriodicity(Common.Enums.IntervalPeriodicity.Day);
                        break;
                    }
            }
        }

        private void PrevMode(object sender, RoutedEventArgs e)
        {
            CalendarMode newMode = CalendarMode.Years;
            IsCalendarItemButton = !IsCalendarItemButton;
            IntervalPeriodicity periodicity = IntervalPeriodicity.None;
            switch (Mode)
            {
                case CalendarMode.Years:
                    {
                        IsCalendarItemButton = true;
                        break;
                    }
                case CalendarMode.Months:
                    {
                        IsCalendarItemButton = true;
                        newMode = CalendarMode.Years;
                        periodicity = IntervalPeriodicity.Decade;
                        break;
                    }
                case CalendarMode.Days:
                    {
                        IsCalendarItemButton = true;
                        newMode = CalendarMode.Months;
                        periodicity = IntervalPeriodicity.Year;
                        break;
                    }
            }
            Mode = newMode;
            if(periodicity != IntervalPeriodicity.None)
            {
                _startInteval = _startInteval.ToStartByPeriodicity(periodicity);
                _endInteval = _startInteval.ToEndByPeriodicity(periodicity);
            }
            SelectedText = GetSelectedModeText();
        }
        private void NextMode(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DateTime currentSelectDate = (button.DataContext as CalendarItem).DateTime;

            CalendarMode newMode = CalendarMode.Years;
            IsCalendarItemButton = !IsCalendarItemButton;
            IntervalPeriodicity periodicity = IntervalPeriodicity.None;
            switch (Mode)
            {
                case CalendarMode.Years:
                {
                   newMode = CalendarMode.Months;
                   IsCalendarItemButton = true;
                   periodicity = IntervalPeriodicity.Month;
                   break;
                }
                case CalendarMode.Months:
                    {
                        newMode = CalendarMode.Days;
                        IsCalendarItemButton = false;
                        periodicity = IntervalPeriodicity.Day;
                        break;
                    }
                case CalendarMode.Days:
                    {
                        IsCalendarItemButton = false;
                        break;
                    }
            }
            _startInteval = currentSelectDate.ToStartByPeriodicity(periodicity);
            _endInteval = currentSelectDate.ToEndByPeriodicity(periodicity);

            Mode = newMode;
            SelectedText = GetSelectedModeText();
        }

        private void PrevPeriod(object sender, RoutedEventArgs e)
        {
            IntervalPeriodicity periodicity = MapCalendarMode();
            _startInteval = _startInteval.SubtractPeriodicityPeriods(periodicity, 1);
            _endInteval = _endInteval.SubtractPeriodicityPeriods(periodicity, 1);
            SelectedText = GetSelectedModeText();
            IsCalendarItemButton = !IsCalendarItemButton;
            IsCalendarItemButton = !IsCalendarItemButton;
        }
        private void NextPeriod(object sender, RoutedEventArgs e)
        {
            IntervalPeriodicity periodicity = MapCalendarMode();
            _startInteval = _startInteval.AddPeriodicityPeriods(periodicity, 1);
            _endInteval = _endInteval.AddPeriodicityPeriods(periodicity, 1);
            SelectedText = GetSelectedModeText();
            IsCalendarItemButton = !IsCalendarItemButton;
            IsCalendarItemButton = !IsCalendarItemButton;
        }

        private List<CalendarItem> GetCalendarItems()
        {
            switch (Mode)
            {
                case CalendarMode.Years: return GetYears();
                case CalendarMode.Months: return GetMonths();
                case CalendarMode.Days: return GetDays();
            }
            return new List<CalendarItem>();
            
        }
        private List<CalendarItem> GetYears()
        {

            List<CalendarItem> items = new List<CalendarItem>();

            int index = 0;

            foreach (DateTime year in DateTimeHelper.GetBeetwenDatesByPeriodicities(_startInteval.SubtractPeriodicityPeriods(Common.Enums.IntervalPeriodicity.Year,1), _endInteval.AddPeriodicityPeriods(Common.Enums.IntervalPeriodicity.Year,5), Common.Enums.IntervalPeriodicity.Year))
            {
                var dimensionsalIndex = IndexerHelper.FlatIndexToTwoDimensional(index, 4);
                items.Add(new CalendarItem
                {
                    Name = year.ToString("yyyy"),
                    DateTime = year,
                    Row = dimensionsalIndex.Item1,
                    Col = dimensionsalIndex.Item2,
                });
                index++;
            }

            return items;
        }
        private List<CalendarItem> GetMonths()
        {
            List<CalendarItem> items = new List<CalendarItem>();

            int index = 0;

            var startDate = _startInteval.ToStartByPeriodicity(Common.Enums.IntervalPeriodicity.Year);
            var endDate = _endInteval.ToEndByPeriodicity(Common.Enums.IntervalPeriodicity.Year).AddPeriodicityPeriods(Common.Enums.IntervalPeriodicity.Month, 4);

            foreach (DateTime month in DateTimeHelper.GetBeetwenDatesByPeriodicities(startDate,endDate,Common.Enums.IntervalPeriodicity.Month))
            {
                var dimensionsalIndex = IndexerHelper.FlatIndexToTwoDimensional(index, 4);
                items.Add(new CalendarItem
                {
                    Name = month.ToString("MMM"),
                    DateTime = month,
                    Row = dimensionsalIndex.Item1,
                    Col = dimensionsalIndex.Item2,
                });
                index++;
            }

            return items;
        }
        private List<CalendarItem> GetDays()
        {
            List<CalendarItem> items = new List<CalendarItem>();

            foreach(var dayName in _dayNames)
            {
                items.Add((CalendarItem)dayName.Clone());
            }


            var startDate = _startInteval.ToStartByPeriodicity(Common.Enums.IntervalPeriodicity.Month);
            int index = ((int)startDate.GetDayInWeek()) + 7;

            int offsetDays = index - 7;
            if(offsetDays > 0)
            {
                startDate = startDate.SubtractPeriodicityPeriods(IntervalPeriodicity.Day,offsetDays);
                index = ((int)startDate.GetDayInWeek()) + 7;
            }

            int maxIndex = IndexerHelper.TwoDimensionalToFlatIndex(6, 6, 7);
            int needDays = maxIndex - index - offsetDays + 1;

            var endDate = _startInteval.AddPeriodicityPeriods(IntervalPeriodicity.Day, needDays);// _endInteval.ToEndByPeriodicity(Common.Enums.IntervalPeriodicity.Month);


            foreach (DateTime day in DateTimeHelper.GetBeetwenDatesByPeriodicities(startDate, endDate, Common.Enums.IntervalPeriodicity.Day))
            {
                var dimensionsalIndex = IndexerHelper.FlatIndexToTwoDimensional(index, 7);
                items.Add(new CalendarItem
                {
                    Name = day.ToString("dd"),
                    DateTime = day,
                    Row = dimensionsalIndex.Item1,
                    Col = dimensionsalIndex.Item2,
                });
                index++;
            }

            return items;
        }
        private string GetSelectedModeText()
        {
            switch (Mode)
            {
                case CalendarMode.Years: return $"{_startInteval.Year} - {_endInteval.Year}";
                case CalendarMode.Months: return $"{_startInteval.ToString("yyyy")} г.";
                case CalendarMode.Days: return _startInteval.ToString("Y");
            }
            return "";
        }

        private IntervalPeriodicity MapCalendarMode()
        {
            switch (Mode)
            {
                case CalendarMode.Years: return IntervalPeriodicity.Decade;
                case CalendarMode.Months: return IntervalPeriodicity.Year;
                case CalendarMode.Days: return IntervalPeriodicity.Month;
            }
            return IntervalPeriodicity.None;
        }
    }
}
