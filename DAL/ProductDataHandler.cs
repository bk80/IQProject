using IQMVCProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMVCProject.DAL
{
    public class ProductDataHandler
    {

        private iqmvcprojectdbContext db = new iqmvcprojectdbContext();
        public List<Product> GetProducts(string searchString)
        {

            using (db)
            {
                return (from c in db.Product
                        where c.CustomerName.Contains(searchString)
                        select c)
                .ToList();
            }
        }
        public List<Product> GetProducts(int numb)
        {
            using (db)
            {
                return (from c in db.Product
                        select c).Take(numb)
                .ToList();
            }
        }

        public void AddProduct(Product product)
        {
            using (db)
            {
                // db.Entry(product.Id).State = EntityState.Unchanged;
                // db.Entry(product.CustomerName).State = EntityState.Unchanged;
                // db.Entry(product.ProductName).State = EntityState.Unchanged;
                // db.Entry(product.PhoneNumber).State = EntityState.Unchanged;
                // db.Entry(product.CustomerNotes).State = EntityState.Unchanged;
                db.Product.Add(product);
                db.SaveChanges();
            }
        }


        public void UpdateCamera(Product product)
        {
            using (db)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


    }
}