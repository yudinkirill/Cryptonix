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

        //Calculating--------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

        }


        //Parsing---------------------------------------------------


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            usdinfo.Text = await Task.Run(() => USDParse());
            dollar = usdinfo.Text;

            eurinfo.Text = await Task.Run(() => EURParse());
            euro = eurinfo.Text;

            btcinfo.Text = await Task.Run(() => BTCParse());
            bitcoin = btcinfo.Text;

            bchinfo.Text = await Task.Run(() => BCHParse());
            bitcoincash = bchinfo.Text;

            ethinfo.Text = await Task.Run(() => ETHParse());
            ethereum = ethinfo.Text;

            etcinfo.Text = await Task.Run(() => ETCParse());
            ethereumclassic = etcinfo.Text;
        }




        private string USDParse()
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
                return "Error!";
            }
        }

        private string EURParse()
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

        private string BTCParse()
        {
            try
            {
                var website = new HtmlWeb();
                website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
                var doc = website.Load("https://exmo.me/ru/trade#?pair=BTC_USD");
                HtmlNode btcC = doc.DocumentNode.SelectSingleNode("//li[@pair='BTC_RUB']//div[@class='pair_price sprice hide']");


                return btcC.InnerText;


            }
            catch { return "Error!"; }
        }

        private string BCHParse()
        {
            try
            {
                var website = new HtmlWeb();
                website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
                var doc = website.Load("https://exmo.me/ru/trade#?pair=BTC_USD");
                HtmlNode bchC = doc.DocumentNode.SelectSingleNode("//li[@pair='BCH_RUB']//div[@class='pair_price sprice hide']");


                return bchC.InnerText;


            }
            catch { return "Error!"; }
        }

        private string ETHParse()
        {
            try
            {
                var website = new HtmlWeb();
                website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
                var doc = website.Load("https://exmo.me/ru/trade#?pair=BTC_USD");
                HtmlNode ethC = doc.DocumentNode.SelectSingleNode("//li[@pair='ETH_RUB']//div[@class='pair_price sprice hide']");


                return ethC.InnerText;
            }
            catch { return "Error!"; }

        }

        private string ETCParse()
        {
            try
            {
                var website = new HtmlWeb();
                website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
                var doc = website.Load("https://exmo.me/ru/trade#?pair=BTC_USD");
                HtmlNode etcC = doc.DocumentNode.SelectSingleNode("//li[@pair='ETC_RUB']//div[@class='pair_price sprice hide']");


                return etcC.InnerText;
            }
            catch { return "Error!"; }

        }


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


        //Currency

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


        private void equal_Click(object sender, RoutedEventArgs e)
        {
            Calculating();
        }


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

