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
        object etherium;
        object euro;
        object dollar;

        string leftop = ""; // Левый операнд
        string operation = ""; // Знак операции
        string rightop = ""; // Правый операнд

        //Calculating
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст кнопки
            string s = (string)((Button)e.OriginalSource).Content;
            // Добавляем его в текстовое поле
            MSCR.Text += s;
            int num;
            // Пытаемся преобразовать его в число
            bool result = Int32.TryParse(s, out num);
            // Если текст - это число
            if (result == true)
            {
                // Если операция не задана
                if (operation == "")
                {
                    // Добавляем к левому операнду
                    leftop += s;
                }
                else
                {
                    // Иначе к правому операнду
                    rightop += s;
                }
            }
            // Если было введено не число
            else
            {
                // Если равно, то выводим результат операции
                if (s == "=")
                {
                    Update_RightOp();
                    MSCR.Text += rightop;
                    operation = "";
                }
                // Очищаем поле и переменные
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    MSCR.Text = "";
                }
                // Получаем операцию
                else
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }
        // Обновляем значение правого операнда
        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
            }
        }
    

    //Parsing

    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btcinfo.Text = BTCParse();
            bitcoin = btc.Content;

            ethinfo.Text = ETHParse();
            etherium = eth.Content;

            eurinfo.Text = EURParse();
            euro = eur.Content;

            usdinfo.Text = USDParse();
            dollar = usd.Content;
        }

        private string BTCParse ()
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



        private void Clear_click(object sender, RoutedEventArgs e)
        {
            MSCR.Text = null;
        }
    }
}

