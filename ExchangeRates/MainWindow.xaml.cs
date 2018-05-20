using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace ExchangeRates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
   /* Написать приложение (UI), которое служит для получения официальной 
    информации о курсе валют на текущее время(по кнопке)
    с интернета в дополнительном рабочем потоке, а также отображать
     их в таблице.Данные можно взять c https://data.egov.kz/*/

    public partial class MainWindow : Window
    {
        private delegate IList<EgovData> MyDelegateGetAsyncList();
        public MainWindow()
        {
            InitializeComponent();
        }
      private void GetCurrencyList(object i)
        {
                List<EgovData> search = new List<EgovData>();
                WebClient wc = new WebClient();
                var json = wc.DownloadString("https://data.egov.kz/api/v2/valutalar_bagamdary4/v314?pretty");
             
            Dispatcher.Invoke(() =>
            {
                List<EgovData> list = JsonConvert.DeserializeObject<List<EgovData>>(json);
                view.ItemsSource = list;
            });
        }
        private void Button_Clik(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(GetCurrencyList));
            thread.Start(view);
        }

        
     }   
}
