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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        class WeatherControl : DependencyObject
        {
            private string windDirection;
            private int windSpeed;
            public static readonly DependencyProperty TemperatureProperty;

            public string WindDirection
            {
                get => windDirection;
                set => windDirection = value;

            }

            public int WindSpeed
            {
                get => windSpeed;
                set => windSpeed = value;

            }
            enum rainfall
            {
                Солнечно = 1,
                Облачно = 2,
                Дождь = 3,
                Снег = 4,
                Град = 5
            }


            public int Temperature
            {

                get => (int)GetValue(TemperatureProperty);
                set => SetValue(TemperatureProperty, value);
            }
            static WeatherControl()
            {
                TemperatureProperty = DependencyProperty.Register(
                    nameof(Temperature),
                    typeof(int),
                    typeof(WeatherControl),
                     new FrameworkPropertyMetadata(
                       0,
                       FrameworkPropertyMetadataOptions.AffectsMeasure |
                       FrameworkPropertyMetadataOptions.AffectsRender,
                       null,
                       new CoerceValueCallback(CourseTemperature)),
                       new ValidateValueCallback(ValidateTemperature));



            }

            private static bool ValidateTemperature(object value)
            {
                int t = (int)value;
                if (t > -50 && t < 50)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private static object CourseTemperature(DependencyObject d, object baseValue)
            {
                int t = (int)baseValue;
                if (t > -50 && t < 50)
                {
                    return t;
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}
