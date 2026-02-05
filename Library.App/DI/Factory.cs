using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.App.DI
{
    public class Factory<T> : IFactory<T> where T : class
    {
        private readonly IServiceProvider _serviceProvider;

        public Factory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Create()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
