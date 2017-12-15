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
using HtmlAgilityPack;
using System.Data;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace CryptoCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object bitcoin;
        object ethereum;
        object ethereumclassic;
        object euro;
        object dollar;
        object bitcoincash;
        object ripple;
        object litecoin;
        object waves;
        object dash;
        object zcash;

        
        public MainWindow()
        {
            InitializeComponent();

        }


        //Parsing---------------------------------------------------


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                usdinfo.Text = await Task.Run(() => USDParse());
                dollar = usdinfo.Text;

                eurinfo.Text = await Task.Run(() => EURParse());
                euro = eurinfo.Text;

                await Task.Run(PostRequestAsync);

                btcinfo.Text = bitcoin.ToString();
                bchinfo.Text = bitcoincash.ToString();
                ethinfo.Text = ethereum.ToString();
                etcinfo.Text = ethereumclassic.ToString();
            }
            catch { }

        }

        private  async Task PostRequestAsync()
        {
            WebRequest request = WebRequest.Create("https://api.exmo.com/v1/ticker/");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = "";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                FilterJSON f = new FilterJSON();
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(f.GetType());
                var obj = (FilterJSON)jsonFormatter.ReadObject(stream);
                bitcoin = obj.BTC.buy_price;
                bitcoincash = obj.BCH.buy_price;
                ethereum = obj.ETH.buy_price;
                ethereumclassic = obj.ETС.buy_price;
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close(); 
        }



        #region Parsing
        private string USDParse()
        {
            while (true)
            {
                try
                {
                    var website = new HtmlWeb();
                    website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
                    var doc = website.Load("https://finance.rambler.ru/currencies/USD/");
                    HtmlNode usdC = doc.DocumentNode.SelectSingleNode("//div[@class='exr-top-info__val']");


                    return usdC.InnerHtml;
                }
                catch
                {
                   
                }
                 
            }
        }

        private string EURParse()
        {
            while (true)
            {
                try
                {
                    var website = new HtmlWeb();
                    website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
                    var doc = website.Load("https://finance.rambler.ru/currencies/EUR/");
                    HtmlNode eurC = doc.DocumentNode.SelectSingleNode("//div[@class='exr-top-info__val']");


                    return eurC.InnerText;
                }
                catch
                {

                    return "Error!";
                }
            }
        }
        #endregion

        #region Buttons
        //Calculating

        private void one_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 1;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 2;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 3;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 4;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 5;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 6;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 7;
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 8;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 9;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += 0;
        }

       


        //Functions-----------------------------------------------


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MSCR.Text = MSCR.Text.Remove((int)MSCR.Text.Length - 1, 1);
                RESULT.Text = "";


            }
            catch
            {
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text = "";
            RESULT.Text = "";
        }


        //Just one symbol
        void CheckLastAndReplaceIfSymbol(string newSymb)
        {
            try
            {
                switch (MSCR.Text.Last())
                {
                    case '/':
                    case '+':
                    case '-':
                    case '*':
                    case ',':
                        MSCR.Text = MSCR.Text.Remove(MSCR.Text.Length - 1) + newSymb;
                        break;
                    default:

                        MSCR.Text += newSymb;
                        break;
                }
            }
            catch { }

        }


        private void minus_Click(object sender, RoutedEventArgs e)
        {


            //MSCR.Text += "-";
            CheckLastAndReplaceIfSymbol("-");


        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfSymbol("+");
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfSymbol("*");
        }

        private void devision_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfSymbol("/");
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfSymbol(",");
        }

        private void lefts_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "(";
        }

        private void rights_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += ")";
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            Calculating();
        }

        //Currency
        #region CurrencyButtons
        void CheckLastAndReplaceIfCurrency(string newCurrency)
        {
            try
            {
                switch (MSCR.Text.Substring(MSCR.Text.Length-3))
                {
                    case "USD":
                    case "EUR":
                    case "BTC":
                    case "BCH":
                    case "ETH":
                        MSCR.Text = MSCR.Text.Remove(MSCR.Text.Length - 3) + newCurrency;
                        break;
                    default:

                        MSCR.Text += newCurrency;
                        break;
                }
            }
            catch {
                MSCR.Text += newCurrency;
            }

        }

        
        private void usd_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfCurrency("USD");
        }

        private void eur_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfCurrency("EUR");
        }

        private void BCH_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfCurrency("BCH");
        }

        private void btc_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfCurrency("BTC");
        }

        private void eth_Click(object sender, RoutedEventArgs e)
        {
            CheckLastAndReplaceIfCurrency("ETH");
        }
        #endregion

       
        #endregion

        private void Calculating()
        {
            if (MSCR.Text.Contains("/0"))
            {
                
                RESULT.Text = "ERROR";
            }
            else
            {
                try
                {
                    string task = MSCR.Text;
                    ReversePolishNotation.Calculate(task); //Считываем, и выводим результат
                    RESULT.Text = ReversePolishNotation.Calculate(task).ToString();
                }
                catch
                {
                }
            }
        }
    }
    
}