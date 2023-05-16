using System;
using System.Collections.Generic;
using System.Text;

namespace P04.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public IReadOnlyList<Product> Products
        {
            get { return products; }

        }

        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public bool BayProduct(Product product)
        {
            if (product.Cost <= this.money)
            {
                this.money -= product.Cost;
                this.products.Add(product);
                return true;
            }
            return false;
        }

    }
}
