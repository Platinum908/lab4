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

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Price<int>[] Prices { get; set; } = null;
        private bool isIdsort = true;
        public MainWindow()
        {
            InitializeComponent();
            mmCopy.IsEnabled = false;
            mmCreate.IsEnabled = false;
            tbCreate.IsEnabled = false;
            tbCopy.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbCount.Text.Length != 0)
            {
                Prices = null;
                Prices = new Price<int>[int.Parse(tbCount.Text)];
                MessageBox.Show("Массив размером " + Prices.Length + " элемента создан");
                Price<int>.Count = 0;
                mmCopy.IsEnabled = true;
                mmCreate.IsEnabled = true;
                tbCreate.IsEnabled = true;
                tbCopy.IsEnabled = true;
                monsterList.ItemsSource = null;
                stCount.Content = "Создано " + Price<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Введите размер массива");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void mmCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }
        void GridViewColumnHeaderClickedHandler(object sender,
                                        RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked.Content.ToString() == "ID")
            {
                if (isIdsort)
                {
                    Array.Sort(Prices);
                }
                else
                {
                    Prices = Prices.OrderByDescending(p => p.id).ToArray();
                }
                isIdsort = !isIdsort;
            }
        
            monsterList.ItemsSource = null;
            monsterList.ItemsSource = Prices;
        }

        private void tbCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        private void tbCreate_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void Copy()
        {
            if (monsterList.SelectedItems.Count != 0)
            {
                Price<int> price = monsterList.SelectedItem as Price<int>;
                Prices[Price<int>.Count] = (Price<int>)price.Clone();
                monsterList.ItemsSource = null;
                monsterList.ItemsSource = Prices;
                Price<int>.Count++;
                stCount.Content = "Создано " + Price<int>.Count + " из " + tbCount.Text;
            }
        }
        private void Add()
        {
            if (Prices.Length > Price<int>.Count)
            {
                AddPrice add = new AddPrice();
                if (add.ShowDialog() == true)
                {
                    Prices[Price<int>.Count] = new Price<int>();
                    Prices[Price<int>.Count].id = add.id;
                    Prices[Price<int>.Count].name = add.name;
                    Prices[Price<int>.Count].cost = add.cost;
                    Price<int>.Count++;
                }
                monsterList.ItemsSource = null;
                monsterList.ItemsSource = Prices;
                stCount.Content = "Создано " + Price<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Массив полностью заполнен");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }
    }
}

