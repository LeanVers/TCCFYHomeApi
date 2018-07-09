using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AplicationCore.Entities;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FYHomeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Person.Any())
            {
                return;
            }

            context.SaveChanges();

        }
    }
}
