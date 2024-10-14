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

namespace lr7-8.Windows
{
    /// <summary>
    /// Interaction logic for ShowWeatherAtTimeWindow.xaml
    /// </summary>
    public partial class ShowWeatherAtTimeWindow : Window
    {
        public ShowWeatherAtTimeWindow()
        {
            InitializeComponent();
        }

		private Prognosis prognosis;
//Изменённый конструктор окна
		public ShowweatherAtTimeWindow(Prognosis prog)
			{
				InitializeComponent(); 
				prognosis = prog;
				labelContent.Content += " " + prognosis.Date.Value.ToShortDateString(); LoadDataWrapPanel (prog. Time);
			}
		private void LoadDataWrapPanel(string info)
		{
			List<ComplexweatherInfo> infos;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ComplexWeatherInfo>)); using (StringReader reader = new StringReader(info))
			{
				infos = xmlSerializer.Deserialize(reader) as List<ComplexweatherInfo>;
			}
			infos.ForEach(item => wrapPanelWeather.Children.Add(new WeatherCustomControl(item)));
        }
	}
}