using AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Specifications
{
    public sealed class PeopleSpecification : BaseSpecification<Person>
    {
        public PeopleSpecification(string email, string passphrase)
            : base(b => b.Email == email && b.Passphrase == passphrase)
        {
        }
    }
}
