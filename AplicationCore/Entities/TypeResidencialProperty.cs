using AplicationCore.Sevices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Entities
{
    public class TypeResidencialProperty : BaseEntity
    {
        public int TypeResidencialPropertyId { get; set; }
        public string Description { get; set; }
    }
}
