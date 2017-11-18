using KolejDenemeProjesi.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.BusinessLayer.Result
{
    public class BusinessLayerResult<T>
    {
        public T Result { get; set; }
        public List<ErrorMessageObj> Errors { get; set; }

        public void AddError(ErrorMessages code,string  message)
        {
            Errors.Add(new ErrorMessageObj { Code=code,Message=message});
        }
    }
}
