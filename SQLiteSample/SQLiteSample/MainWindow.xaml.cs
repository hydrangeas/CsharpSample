using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

        private TextBox textBox1;

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            var button1 = new Button() { Content = "New" };
            button1.Click += button1Click;
            button1.SetValue(Grid.RowProperty, 0);
            grid1.Children.Add(button1);

            var button2 = new Button() { Content = "Add" };
            button2.Click += button2Click;
            button2.SetValue(Grid.RowProperty, 1);
            grid1.Children.Add(button2);

            var button3 = new Button() { Content = "Get" };
            button3.Click += button3Click;
            button3.SetValue(Grid.RowProperty, 2);
            grid1.Children.Add(button3);

            textBox1 = new TextBox() {
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Height = 100
            };
            textBox1.SetValue(Grid.RowProperty, 3);
            grid1.Children.Add(textBox1);
        }

        private const string connectionString = @"Data Source=sample.sqlite3";

        private void button1Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE T_MEMO(ID INTEGER PRIMARY KEY AUTOINCREMENT,MEMO TEXT) ";
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button2Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO T_MEMO (MEMO) VALUES (@p_memo)";
                    command.Parameters.Add(new SQLiteParameter("@p_memo", DateTime.Now.ToLongTimeString()));

                    command.ExecuteNonQuery();
                }
            }
        }

        private void button3Click(object sender, RoutedEventArgs e)
        {
            var list = new List<string>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ID,MEMO FROM T_MEMO";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(string.Format("ID:{0}, MEMO:{1}", reader.GetInt64(0), reader.GetString(1)));
                        }
                    }
                }
            }
            textBox1.Clear();
            textBox1.AppendText(string.Join("\n", list));
        }
    }
}
