using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Пробник.Context;
using Пробник.Models;

namespace Пробник.ViewModels
{
    internal class MainViewModel: INotifyPropertyChanged
    {

        public ObservableCollection<Product> Products { get; set; }
        public ICommand DeleteCommand { get; }
        public MainViewModel() 
        {
            LoadProducts();
            DeleteCommand = new Icommand(DeleteProduct);
        }

        public void LoadProducts()
        {
            using (var dbContext = new AppDBContext())
            {
                Products = new ObservableCollection<Product>(dbContext.Products.ToList());
            }
        }

        private void DeleteProduct(object parameter)
        {
            if (parameter is Product productToDelete)
            {
                using (var dbContext = new AppDBContext())
                {
                    var product = dbContext.Products.FirstOrDefault(p => p.ProductId == productToDelete.ProductId);
                    if (product != null)
                    {
                        dbContext.Products.Remove(product);
                        dbContext.SaveChanges();
                        Products.Remove(productToDelete);
                    }
                }
            }
        }

        public void AddProduct(int id, string productName, string description, int price)
        {
            using (var dbContext = new AppDBContext())
            {
                // Создание и добавление нового продукта
                Product newProduct = new Product
                {
                    ProductId = id,
                    ProductName = productName,
                    Description = description,
                    Price = price
                };
                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();

                // Обновление списка продуктов на интерфейсе
                LoadProducts();
                RefreshProducts();
            }
        }

        public void RefreshProducts()
        {
            using (var dbContext = new AppDBContext())
            {
                Products = new ObservableCollection<Product>(dbContext.Products.ToList());
                OnPropertyChanged(nameof(Products)); // Уведомляем интерфейс о изменении данных
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyname)
        {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
