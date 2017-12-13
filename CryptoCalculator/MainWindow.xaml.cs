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



        /*    private void Button_Click(object sender, RoutedEventArgs e)
            {
                // Получаем текст кнопки
                string s = (string)((Button)e.OriginalSource).Content;
                // Добавляем его в текстовое поле
                MSCR.Text += s;
                decimal num;
                // Пытаемся преобразовать его в число
                bool result = Decimal.TryParse(s, out num);
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
                        RESULT.Text += rightop;
                        operation = "";
                    }

                    // Очищаем поле и переменные
                    else if (s == "CE")
                    {
                        leftop = "";
                        rightop = "";
                        operation = "";
                        MSCR.Text = "";
                        RESULT.Text = "";
                    }

                    //Удаляем один символ
                    else if (s == "X")
                    {

                            try
                            {
                                MSCR.Text = MSCR.Text.Remove((int)MSCR.Text.Length - 2, 2);
                            if (MSCR.Text.Contains("X"))
                                MSCR.Text.Remove(0, 1);

                            }
                            catch
                            {
                            }


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
                decimal num1 = Decimal.Parse(leftop);
                decimal num2 = Decimal.Parse(rightop);
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
            */


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

/*
             string arg;
            Stack<double> st = new Stack<double>();
 
            while ((arg = Console.ReadLine()) != "exit")
            {
                double num;
                bool isNum = double.TryParse(arg, out num);
                if (isNum)
                    st.Push(num);
                else
                {
                    double op2;
                    switch(arg)
                    {
                        case "+":
                            st.Push(st.Pop() + st.Pop());
                            break;
                        case "*":
                            st.Push(st.Pop() * st.Pop());
                            break;
                        case "-":
                            op2 = st.Pop();
                            st.Push(st.Pop() - op2);
                            break;
                        case "/":
                            op2 = st.Pop();
                            if (op2 != 0.0)
                                st.Push(st.Pop() / op2);
                            else
                                Console.WriteLine("Ошибка. Деление на ноль");
                            break;
                        case "calc":
                            Console.WriteLine("Результат: " + st.Pop());
                            break;
                        default:
                            Console.WriteLine("Ошибка. Неизвестная команда");
                            break;
                    }
                }
            }
     */
