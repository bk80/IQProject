using IQMVCProject.DAL;
using IQMVCProject.Model;

using System.Collections.Generic;

namespace IQMVCProject.BAL
{
    public class ProductHelper
    {
        public List<Product> GetProducts(string searchString) => new ProductDataHandler().GetProducts(searchString);
        public List<Product> GetProducts(int numb) => new ProductDataHandler().GetProducts(numb);
        public void AddProduct(Product product) => new ProductDataHandler().AddProduct(product);
    }
}