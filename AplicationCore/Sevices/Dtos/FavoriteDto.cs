using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Sevices.Dtos
{
    public class FavoriteDto : BaseDto
    {
        public int FavoriteId { get; set; }
        public int PersonID { get; set; }
        public int ResidencialPropertyId { get; set; }

        public PersonDto Person { get; set; }
        public ResidencialPropertyGetDto ResidecialProperty { get; set; }
    }
}
