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
using lr7.Classes;

namespace lr7-8.CustomControls
{
    public sealed partial class WeatherCustomControl : UserControl
    {
        public WeatherCustomControl()
        {
            this.InitializeComponent();
        }

		public WeatherCustomControl(ComplexWeatherInfo complex){
			this.InitializeComponent();
			Fill(complex);
		}

		public void Fill(ComplexWeather Info complex)
		{
			_weather = complex ?? throw new ArgumentNullException(nameof(_weather));
			label_Humidity.Content = _weather.Humidity;
			label_Temperature. Content = _weather. Temperature;
			label_Time.Content = _weather.Time;
			label_Type.Content = _weather.Weather.Name;
    	}
}