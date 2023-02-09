using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //Not: aşağıda 'default' olarak yazılan aslında hangi veri tipi gönderilmişse onun default değerini geri dönderir.
        //     örneğin int için 0 ' dır.
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }

        public SuccessDataResult(T data):base(data,true)
        {

        }

        /*Aşağıdaki iki ctor çok fazlar kullanılmaz ancak alternatifleri için iyi*/
        public SuccessDataResult(string message):base(default,true,message)
        {

        }

        public SuccessDataResult():base(default,true)
        {

        }
    }
}
