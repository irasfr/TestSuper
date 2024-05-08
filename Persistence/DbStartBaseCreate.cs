using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbStartBaseCreate
    {
        public static void StartBaseCreate(PerDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
