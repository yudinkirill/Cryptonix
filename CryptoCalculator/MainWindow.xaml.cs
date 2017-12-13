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
        object euro;
        object dollar;

        //Calculating--------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

        }


        //Parsing---------------------------------------------------


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btcinfo.Text = await Task.Run(() => BTCParse());
            bitcoin = btc.Content;

            ethinfo.Text = await Task.Run(() => ETHParse());
            ethereum = eth.Content;

            eurinfo.Text = await Task.Run(() => EURParse());
            euro = eur.Content;

            usdinfo.Text = await Task.Run(() => USDParse());
            dollar = usd.Content;


        }

        private string BTCParse()
        {
            var website = new HtmlWeb();
            website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
            var doc = website.Load("https://exmo.me/ru/trade#?pair=BTC_USD");
            HtmlNode btcC = doc.DocumentNode.SelectSingleNode("//li[@pair='BTC_RUB']//div[@class='pair_price sprice hide']");

            if (btcC != null)
            {
                return btcC.InnerText;
            }
            else
            {
                return "Error!";
            }
        }

        private string ETHParse()
        {
            var website = new HtmlWeb();
            website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
            var doc = website.Load("https://exmo.me/ru/trade#?pair=BTC_USD");
            HtmlNode ethC = doc.DocumentNode.SelectSingleNode("//li[@pair='ETH_RUB']//div[@class='pair_price sprice hide']");

            if (ethC != null)
            {
                return ethC.InnerText;
            }
            else
            {
                return "Error!";
            }
        }

        private string EURParse()
        {
            var website = new HtmlWeb();
            website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
            var doc = website.Load("https://finance.rambler.ru/currencies/EUR/");
            HtmlNode eurC = doc.DocumentNode.SelectSingleNode("//div[@class='exr-top-info__val']");

            if (eurC != null)
            {
                return eurC.InnerText;

            }
            else
            {
                return "Error!";
            }
        }

        private string USDParse()
        {
            var website = new HtmlWeb();
            website.OverrideEncoding = Encoding.GetEncoding("windows-1251");
            var doc = website.Load("https://finance.rambler.ru/currencies/USD/");
            HtmlNode usdC = doc.DocumentNode.SelectSingleNode("//div[@class='exr-top-info__val']");

            if (usdC != null)
            {
                return usdC.InnerHtml;
            }
            else
            {
                return "Error!";
            }
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

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            
                
                MSCR.Text += "-";
            
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "+";
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "*";
        }

        private void devision_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "/";
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += ",";
        }

        private void lefts_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "(";
        }

        private void rights_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += ")";
        }

        private void usd_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "USD";
        }

        private void eur_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "EUR";
        }

        private void BCH_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "BCH";
        }

        private void btc_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "BTC";
        }

        private void eth_Click(object sender, RoutedEventArgs e)
        {
            MSCR.Text += "ETH";
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

