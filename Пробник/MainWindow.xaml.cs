using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Пробник.Context;
using Пробник.Models;
using Пробник.ViewModels;

namespace Пробник
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                int id = int.Parse(ProductIdTextBox.Text);
                string productName = ProductNameTextBox.Text;
                string description = DescriptionTextBox.Text;
                int price = int.Parse(PriceTextBox.Text);
                viewModel.AddProduct(id, productName, description, price);
            }
        }


    }
}
