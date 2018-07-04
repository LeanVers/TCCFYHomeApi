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

            var students = new Person[]
            {
                //new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                //new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                //new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                //new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                //new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                //new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                //new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                //new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Person s in students)
            {
                //context.Students.Add(s);
            }
            context.SaveChanges();

        }
    }
}
