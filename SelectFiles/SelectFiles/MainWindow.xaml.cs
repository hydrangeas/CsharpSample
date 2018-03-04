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
using Microsoft.Win32;

namespace SelectFiles
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

        private ListBox listBox1;
        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            //grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            var button1 = new Button() { Content = "Select.." };
            button1.Click += button1Click;
            button1.SetValue(Grid.RowProperty, 0);
            grid1.Children.Add(button1);

            listBox1 = new ListBox();
            listBox1.SetValue(Grid.RowProperty, 1);
            listBox1.Items.Add("ファイルを選択してください..");
            grid1.Children.Add(listBox1);
        }

        private void button1Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() {
                Filter = "画像ファイル|*.jpg;*.gif;*.png",
                Multiselect = true
            };

            listBox1.Items.Clear();
            if (dialog.ShowDialog() == true)
            {
                foreach (String file in dialog.FileNames)
                {
                    listBox1.Items.Add(file);
                }
            }
            if(listBox1.Items.Count == 0)
            {
                listBox1.Items.Add("ファイルを選択してください..");
            }
        }
    }
}
