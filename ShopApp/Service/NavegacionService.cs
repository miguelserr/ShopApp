using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Service
{
    public class NavegacionService : INavegacionService
    {
        public Task GoToAsync(string uri)
        {
            return Shell.Current.GoToAsync(uri);
        }

        public Task GoToAsync(string uri, IDictionary<string, object> parameters)
        {
            return Shell.Current.GoToAsync(uri, parameters);
        }
    }
}