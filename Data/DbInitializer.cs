using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebApiContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
