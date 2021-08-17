using System.Collections.Generic;

namespace LibraryAPI.Data.Converter.Contract
{
    public interface IParser<O, D> //origin, destiny
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
        
    }
}
