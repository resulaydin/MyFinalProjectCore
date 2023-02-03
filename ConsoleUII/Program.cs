using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            productManager.GetAll();
        }
    }
}