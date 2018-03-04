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

namespace SQLiteSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            var button1 = new Button() { Content = "New" };
            button1.Click += button1Click;
            button1.SetValue(Grid.RowProperty, 0);
            button1.SetValue(Grid.ColumnProperty, 0);
            grid1.Children.Add(button1);

            var button2 = new Button() { Content = "Update" };
            button2.Click += button2Click;
            button2.SetValue(Grid.RowProperty, 0);
            button2.SetValue(Grid.ColumnProperty, 1);
            grid1.Children.Add(button2);

            var button3 = new Button() { Content = "Delete" };
            button3.Click += button3Click;
            button3.SetValue(Grid.RowProperty, 0);
            button3.SetValue(Grid.ColumnProperty, 2);
            grid1.Children.Add(button3);
        }

        private void button1Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button2Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button3Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
