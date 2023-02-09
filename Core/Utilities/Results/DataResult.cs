using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public T Data { get; }

        /*Burada DataResult kızardı ve sonuç olarak bize dedi ki madem ben bir 'Result' um
            bak 'Result' un CTOR ları var bunları da implemente etsene bizde hemen oluşturdur.
         */
        public DataResult(T data, bool succes, string message) : base(succes, message)
        {
            /*  Normalde aynı kodu birden fazla yere yazmak adet değil ancak yukarıda :this(data,succes)
                şeklinde yazarak nested invoke yapılabilecekken, :base(succes,message) yazılarak bir üst
                sınıf CTOR çağırma görevini yerine getirdiğindne biz bu CTOR içine de " Data = data; " kodunu
                tekrarlı olarak yazmak zorunda kaldık.Efenim :))
             */

            Data = data;
        }

        // Aşağıda eğer mesajı CTOR da göndermek istemezse
        public DataResult(T data, bool succes) : base(succes)
        {
            Data = data;
        }

    }
}
