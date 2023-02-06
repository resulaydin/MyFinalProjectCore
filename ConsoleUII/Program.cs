﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUII
{
    // SOLID 
        /*
           - Bu yaptıklarımız " O (Open Closed) - Gelişime açık Değişime Kapalı " 
           - Yani; yaptığın yazılıma yeni bir özellik ekliyorsan mevcuttaki hiç bir koduna DOKUNAMAZSIN
         */
    internal class Program
    {
        static void Main(string[] args)
        {
            /* -------------  1. Yöntem InMemory ------------------- */
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());

            /* -------------  2. Yöntem EntityFramework -------------
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(product.ProductName + "   -   " + product.UnitPrice);
            }

            Console.WriteLine("---------------------------------------------------");
            foreach (var product in productManager.GetAll().Where(p=>p.ProductId==25).ToList())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.ReadLine();
        */

            /* -------------  3. Yöntem EntityFramework -------------
                Burada aşağıdaki method içerisindeki veriler (metod olmadan önce) seçilerek 
                    sağtık -> Quick Actions and Refactorion -> Extract Metod -> ProductTest
                yazılarak otomatik test metodu oluşturuldu.
             */
            
            //ProductTest();
            CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }

            Console.WriteLine("---------------------------------------------------");
            Console.ReadLine();
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(product.ProductName + "   -   " + product.UnitPrice);
            }

            Console.WriteLine("---------------------------------------------------");
        }
    }
}