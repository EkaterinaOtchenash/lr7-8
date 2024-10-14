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
    /// Interaction logic for AddWeatherWindow.xaml
    /// </summary>
    public partial class AddWeatherWindow : Window
    {
        public AddWeatherWindow()
        {
            InitializeComponent();
        }
		public partial class AddWeatherWindow: Window
// Приватные переменные для удобной работы с окном
private ModelEF model = new ModelEF();
private List<ComplexWeather Info> listweather = new List<ComplexWeatherInfo>(); private DateTime? selectdate;
//Изменённый конструктор окна
Ссылок: 1
public AddWeatherWindow()
InitializeComponent();
ComboBoxDataLoad();
calendar1.SelectedDate = DateTime.Now.Date;
selectdate = calendar1.SelectedDate;
// загрузка данных в элементы Combobox
//в том числе из БД
Ссылок: 1
private void ComboBoxDataLoad()
}
comboboxTypes.Items.Clear();
model. Type_of_weather. ToList().ForEach(type => comboboxTypes.Items.Add(type.Name)); comboboxTypes.SelectedIndex = 0;
comboboxTime.Items.Clear();
for (int i = 0; i < 24; i++)
combobox 11me.SelectedIndex
// Метода для создания объекта из данных полученных с окна
Ссылок: 2
private Prognosis CreatePrognosis()
{
//Сереализация объекта класса в объект Xml
XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ComplexWeatherInfo>)); string serializedXML;
using (StringWriter writer = new StringWriter())
{
XmlSerializer.Serialize(writer, listweather.OrderBy(x => x.Time).ToList()); serializedXML = writer.ToString();
return new Prognosis (calendar1.SelectedDate, serializedXML);
// Метода для обновления данных объекта полученных с окна
Ссылок: 1
private void UpdatePrognosis (ref Prognosis prognosis)
{
// Сереализация объекта класса List<ComplexWeatherInfo> в объект Xml
XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ComplexWeatherInfo>)); string serializedXML;
using (StringWriter writer = new StringWriter())
{
XmlSerializer.Serialize(writer, listweather.OrderBy(x => x.Time).ToList()); serializedXML = writer.ToString();
prognosis.Date = calendar1.SelectedDate;
prognosis.Time = serializedXML;
// Очищение списка погоды и выбор первого элемента в comboboxTime Ссылок: 1
private void RemoveSelect()
{
listweather = new List<ComplexWeatherInfo>();
comboboxTime.SelectedIndex = 0;

private void buttonSave_Click(object sender, RoutedEventArgs e)
if (listweather.Count == 0)
MessageBox.Show("Добавьте данные!");
return;
// Ищем выбранную дату в БД если нашли
//Уточняем у пользователя хочет ли он её перезаписать
//И в зависимотси от ответа заносим новые или перезаписываем данные
Prognosis prognosis = model. Prognosis. FirstOrDefault(x => x.Date == calendar1.SelectedDate); if (prognosis != null)
MessageBoxResult messageBox = MessageBox.Show("Ha sмбраннуо дату уже найдена зanиcь!\n" + "Xoтитo пopeзanиcaть оö?", "Cooбшние", MessageBoxButton. YesNoCancel, MessageBoxImage.Warning); switch (messageBox)
case MessageBoxResult.Yes:
UpdatePrognosis (rof prognosis);
break;
case MessageBoxResult.No:
return;
case MessageBoxResult.Cancel:
return;
else
try
model.Prognosis.Add(CreatePrognosis());
model.SaveChanges();
catch (Exception ex)
MessageBox.Show(ex.Message);
return;
MessageBox.Show("Данные сохранены");
RemoveSelect();

private void buttonShowweather_Click(object sender, RoutedEventArgs e)
if (listweather.Count == 0)
MessageBox.Show($"Noгoдa нa {calendar1.SelectedDate.Value.ToShortDateString()} Hе добалена!");
return;
ShowWeatherAtTimeWindow window = new ShowweatherAtTimeWindow(CreatePrognosis()); window.ShowDialog();
Ссылок: 0
private void buttonBack_Click(object sender, RoutedEventArgs e)
{
Close();
Ссылок 1
private void buttonAdd_Click(object sender, RoutedEventArgs e)
private void buttonAdd_Click(object sender, RoutedEventArgs e)
//проверка наличие данных полей
if (!double. TryParse(textBoxTemperature. Text, out double n1))
{
}
MessageBox.Show("В поле Температура данные вводятся в вещественном формате!");
return;
if (!double.TryParse(textBoxHumidity.Text, out double n2))
{
MessageBox.Show("В поле Влажность данные вводятся в вещественном формате!");
return;
if (double.Parse(textBoxHumidity.Text) > 100 || double.Parse(textBoxHumidity. Text) < 0) MessageBox.Show("В поле Влажность можно вводить данные от 0 до 100!");
{
return;
// Занесение данных в объект класса СomplexWeatherInfo при его помощи конструктора ComplexWeatherInfo complexWeatherInfo = new ComplexWeatherInfo(
combobox Time. SelectedValue. ToString(),
model. Туре_of_weather.First(x => comboboxTypes. SelectedItem. ToString() == x.Name), double. Parse(textBoxTemperature. Text),
double. Parse(textBoxHumidity. Text));
//проверка добавлялись ли элементы с одинаковым временем в listweather
// если добавлялись то автоматически заменяим их на новые
for (int i = 0; i < listweather.Count; i++)
if (listweather[i].Time == complexweatherInfo. Time)
{
listweather[i] = complexWeatherInfo;
return;
listweather.Add(complexweatherInfo);
return;

private void calendar1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
{
if (selectdate != calendari.SelectedDate && listweather.Count != 0)
{
MessageBox Result messageBox = MessageBox.Show("При изменении даты не сохранённые данные удалятся!\" +
"Вы действительно хотите выбрать новую дату?", "Сообщение", MessageBoxButton. YesNo, MessageBoxImage. Warning); if (MessageBoxResult.No == messageBox)
{
}
calendar1.SelectedDate = selectdate;
else if (MessageBoxResult.Yes == messageBox)
{
listweather = new List<ComplexWeatherInfo>(); selectdate = calendar1.SelectedDate;
    }
}