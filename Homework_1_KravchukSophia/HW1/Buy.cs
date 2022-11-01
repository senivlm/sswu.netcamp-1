﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW1
{
    internal class Buy
    {
        private Product product;
        private int amountOfItems;

        public int AmountOfItems { get; set; }
        public Product Product { get { return product; } }

        public Buy(Product product, int amountOfItems)
        {// Не глибока копія
            this.product = product;
            this.amountOfItems = amountOfItems;

        }

        public Buy()
        {
            this.product = new Product();
            this.amountOfItems = 0;
        }

        public double getFinalPrice() 
        {
            return this.amountOfItems * this.product.Price;
        }

        public override string ToString()
        {
            string separator = "---------------------------------------\n";
            return separator + this.product.ToString() + "\n" + separator + "Number of items: " + 
                this.amountOfItems + "\nPrice: " + this.getFinalPrice()+ "\n";
        }
    }
}
