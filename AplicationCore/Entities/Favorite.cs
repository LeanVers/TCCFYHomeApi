﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Entities
{
    public class Favorite : BaseEntity
    {
        public int FavoriteId { get; set; }
        public int PersonID { get; set; }
        public int ResidencialPropertyId { get; set; }

        public Person Person { get; set; }
        public ResidencialProperty ResidecialProperty { get; set; }
    }
}
