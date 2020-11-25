using System;
using System.Collections.Generic;
using System.Text;

namespace BDH.IoC
{
    public static class Container
    {
        public static IServiceProvider Services { get; private set; }
        public static void SetProvider(IServiceProvider serviceProvider)
        {
            Services = serviceProvider;
        }
    }
}
