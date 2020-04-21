using System;
using System.Collections.Generic;
using System.Text;

namespace MyOrange.IServices
{
    public interface ICountryService
    {
        IEnumerable<string> Get();
    }
}
