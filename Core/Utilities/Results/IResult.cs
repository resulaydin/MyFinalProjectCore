using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel void' ler için başlangıç
    //Buradaki başlangıç temel amacımız bazı işlemlerin sonucunu true-false ve mesajını geri döndürecektir.
    public interface IResult
    {
        // get olduğu zaman sadece okumak için kullanılacaktır.
        // set işlemi için constructor da yapılacaktır.
        bool Success { get; }
        string? Message { get; }
    }
}
