using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

        public class ErrorDataResult<T> : DataResult<T>
        {
            //Not: aşağıda 'default' olarak yazılan aslında hangi veri tipi gönderilmişse onun default değerini geri dönderir.
            //     örneğin int için 0 ' dır.
            public ErrorDataResult(T data, string message) : base(data, false, message)
            {

            }

            public ErrorDataResult(T data) : base(data, false)
            {

            }

            /*Aşağıdaki iki ctor çok fazlar kullanılmaz ancak alternatifleri için iyi*/
            public ErrorDataResult(string message) : base(default, false, message)
            {

            }

            public ErrorDataResult() : base(default, false)
            {

            }
        }
    
}
