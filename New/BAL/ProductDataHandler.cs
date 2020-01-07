using IQMVCProject.Models.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMVCProject.BAL
{
    public class ProductDataHandler
    {

        private inquirydetailsdbContext db = new inquirydetailsdbContext();
        public List<Products> GetProducts(string searchString)
        {

            using (db)
            {
                return (from c in db.Products
                        where c.ProductName.Contains(searchString)
                        select c)
                .ToList();
            }
        }
        public List<Products> GetProducts(int numb)
        {
            using (db)
            {
                return (from c in db.Products
                        select c).Take(numb)
                .ToList();
            }
        }

        public void AddUser(Users user)
        {
            using (db)
            {

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public void AddProduct(Products product)
        {
            using (db)
            {
                // db.Entry(product.Id).State = EntityState.Unchanged;
                // db.Entry(product.CustomerName).State = EntityState.Unchanged;
                // db.Entry(product.ProductName).State = EntityState.Unchanged;
                // db.Entry(product.PhoneNumber).State = EntityState.Unchanged;
                // db.Entry(product.CustomerNotes).State = EntityState.Unchanged;
                db.Products.Add(product);
                db.SaveChanges();
            }
        }


        public void UpdateCamera(Products product)
        {
            using (db)
            {
                //db.Entry(products).State = EntityState.Modified;
                //db.SaveChanges();
            }
        }


    }
}