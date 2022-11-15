﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Утворити клас Storage, полем якого визначити масив продуктів.
//Для цього класу описати наступні методи:
//наповнення інформацією даних у режимі діалогу з користувачем,
//наповнення інформацією даних шляхом ініціалізації,
//друку повної інформації про всі товари,
//метод знаходження всіх м’ясних продуктів.
//Метод зміни ціни для всіх товарів на заданий відсоток.

//Створити індексатор для повного доступу за номером до масиву товарів.


namespace Homework_3_KravchukSophia
{
    public class Storage
    {// Порушення інкапсуляції
        public List<Product> productsInStorage;

//Навіть, якщо поле private це дозволить здійснювати вкладення ззовні в список без належної перевірки.
        public List<Product> ProductsInStorage { 
            get { return productsInStorage; }
            set 
            {
                foreach (Product product in value)
                    {
                        this.AddProduct(product);
                    }
                
            }
        }

        public Storage()
        {
            this.productsInStorage = new List<Product>();
        }
        public Storage(Product product)
        {
            this.productsInStorage = new List<Product>();
            this.productsInStorage.Add(product);
        }

        public Storage(Product[] products)
        {

            this.productsInStorage = new List <Product>(products);
        }

        public Storage(List<Product> products)
        {
           this.productsInStorage = new List<Product>(products.Count);
            foreach (Product product in products)
            {// Не може бути не Product
                if ((product != null) && product is Product)
                {
                    this.productsInStorage.Add(product);
                }
                
            }
            
        }

        public Product this[int flag]
        {
            get
            {
                Product product = this.ProductsInStorage[flag];
                return product.Clone() as Product;
            }

            set
            {
                this.ProductsInStorage[flag] = value;
            }
        }
        public void AddProduct(Product product)
        {// Аналогічно! Також користуйтесь ? та ??.
            if ((product != null) && product is Product)
            {
                productsInStorage.Add(product);
            }
            else
            {
                throw new Exception("Object is not a product");
            }
                
        }
        public List<Product> GetAllMeat()
        {
            List<Product> allMeat = new List<Product>();
            foreach (Product product in this.ProductsInStorage)
            {
                if ((product != null) && product is Meat)
                {
                    allMeat.Add((Product)product.Clone());
                }

            }
            return allMeat;
        }

        public void ChangePriceForAllProducts(int percentage)
        {
            foreach (Product product in this.ProductsInStorage)
            {
                if (product != null)
                {
                    product.ChangePrice(percentage);
                }

            }
        }

        public override string ToString()
        {
            if (this.productsInStorage.Count >= 1)
            {
                string storageText = "";
                foreach (Product product in this.ProductsInStorage)
                {
                    if (product != null)
                    {
                        storageText += product.ToString() +"\n\n";
                    }
                }
                return storageText;
            }
            else
            {
                return "\nStorage is empty";
            }

        }
    }
}
