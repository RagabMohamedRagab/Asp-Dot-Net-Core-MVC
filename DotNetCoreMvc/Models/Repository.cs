using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMvc.Models
{
    public static class Repository
    {
        static List<Product> Products = new List<Product>();
        public static ICollection<Product> AllProducts { get => Products; }
        public static void Create(Product product )
        {
            Products.Add(product);
        }
        public static void Delete(int id)
        {
            Products.Remove(Repository.AllProducts.Where(p=>p.Id==id).FirstOrDefault());
        }
        public static List<Product> Search(string Name)
        {
            return Repository.AllProducts.Where(product => product.Name == Name).ToList();
        }
        
    }
}
