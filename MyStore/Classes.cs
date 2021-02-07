using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore
{
    internal class Product : IProduct
    {
        public int Id { get; private set; } = 0;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description { get; set; }

        public Product()
        {
            Id++;
        }

        public Product(string name, string description)
        {
            Id++;
            Name = name;
            Description = description;
        }
    }

    internal class ProductList
    {
        private List<Product> _products;

        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public ProductList()
        {
            Products = new List<Product>();
        }

        //public void Add (Product product)
        //{
        //    Products.Add(product);
        //}
    }
}