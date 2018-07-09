using System;
using System.Collections.Generic;
using System.Text;
using AplicationCore.Entities;

namespace AplicationCore.Entities
{

    public class BaseEntity
    {
        public System.DateTime RecordDate { get; set; }
        public bool Active { get; set; }

        public void SetValuesBase()
        {
            this.RecordDate = DateTime.Now;
            this.Active = true;
        }
    }
}
