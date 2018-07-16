using AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Specifications
{
    public class ResidencialPropertySpecification : BaseSpecification<ResidencialProperty>
    {
        public ResidencialPropertySpecification(int personId)
           : base(b => b.PersonId == personId)
        {
        }
    }
}
