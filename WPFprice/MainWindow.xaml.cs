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

namespace WPFprice
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\data.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                item item = new item();

                item.Date.Text = parts[0];
                item.itemName.Text = parts[1];
                item.itemPrice.Text = parts[2];

                toDoList.Children.Add(item);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            List<string> Texts = new List<string>();

            foreach (item item in toDoList.Children)
            {
                string data = "";

                data += item.Date.Text + "|" + item.itemName.Text + "|" + item.itemPrice.Text;
                Texts.Add(data);
            }
            System.IO.File.WriteAllLines(@"D:\data.txt", Texts);
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {

            int totalprice = 0;
            
            if (e.Key == Key.Return)
            {
            
                foreach (item item in toDoList.Children)
                {
                    totalprice += item.itemPriceValue;
                }

                total.Text = totalprice.ToString();
            }
            
        }

        private void addItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            item item = new item();

            toDoList.Children.Add(item);

        }
    }
}
