using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll().Where(p=>p.ProductId>2))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}