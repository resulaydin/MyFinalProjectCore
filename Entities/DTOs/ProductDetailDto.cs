﻿using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    /*
         public class ProductDetailDto: IEntity

    Not:    Yukarıdaki gibi bir kullanım yapmadık çünkü EO Kural eğer bir sınıf IEntity 'i implement ediyorsa bu bir 
         Veritabanı tablosu olmalıdır. Aksi takdirde implement EDEMEZ.
            Bu yüzden DTOs klasöründe bulunanlar bir join tablosu gibi olacaklar. Dinamik, Bu yüzden IDto' yu implement 
         etmelidirler.
     
     */
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
