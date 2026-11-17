using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Service
{
    public interface INavegacionService
    {
        Task GoToAsync(string uri);
        Task GoToAsync(string uri, IDictionary<string, object> parameters);
    }
}