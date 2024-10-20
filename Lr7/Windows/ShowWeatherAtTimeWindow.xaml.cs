using Lr7.Classes;
using Lr7.CustomControls;
using Lr7.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Lr7.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowWeatherAtTimeWindow.xaml
    /// </summary>
    public partial class ShowWeatherAtTimeWindow : Window
    {
        public ShowWeatherAtTimeWindow()
        {
            InitializeComponent();
        }

        private Prognosis prognosis;
        //Изменённый конструктор окна
        public ShowWeatherAtTimeWindow(Prognosis prog)
        {
            InitializeComponent();
            prognosis = prog;
            labelContent.Content += " " + prognosis.Date.Value.ToShortDateString(); LoadDataWrapPanel(prog.Time);
        }
        private void LoadDataWrapPanel(string info)
        {
            List<ComplexWeatherInfo> infos;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ComplexWeatherInfo>)); using (StringReader reader = new StringReader(info))
            {
                infos = xmlSerializer.Deserialize(reader) as List<ComplexWeatherInfo>;
            }
            infos.ForEach(item => wrapPanelWeather.Children.Add(new WeatherCustomControl(item)));
        }
    }
}
