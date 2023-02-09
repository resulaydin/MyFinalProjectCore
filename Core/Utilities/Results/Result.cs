using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        /// <summary>
        /// Aşağıdaki yeni nesil kullanımdır.
        /// public bool Success => throw new NotImplementedException();
        /// </summary>
        public bool Success { get; }

        public string? Message { get; }

        /// <summary>
        /// Aşağıdaki yapıda aynı kodu (X) iki kere yazdığımızdan dolayı bu bizim kendini tekrar eden kod 
        /// kuralımıza aykırı bir durum olmaktadır. Dolayısıyla C#' ın ctor nimetlerinden faydalanacağız.
        /// 
        /// </summary>
        /*
             public Result(bool success, string? message)
             {
               (X)Success = success;
                  Message = message;
             }      
             public Result(bool success)
             {
                (X)Success = success;
             }
         */
        public Result(bool success, string? message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }



    }
}
