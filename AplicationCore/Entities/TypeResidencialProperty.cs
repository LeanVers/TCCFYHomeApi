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

        public void AddTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialProperty)
        {
            if (typeResidencialProperty != null)
            {
                this.Description = typeResidencialProperty.Description;
                this.RecordDate = DateTime.Now;
                this.Active = true;
            }
        }

        public void AddTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialProperty, int typeResidencialPropertyId)
        {
            if (typeResidencialProperty != null)
            {
                this.TypeResidencialPropertyId = typeResidencialPropertyId;
                AddTypeResidencialProperty(typeResidencialProperty);
            }
        }
    }
}
