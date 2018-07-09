using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Sevices.Dtos
{
    public class PersonDto : BaseDto
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthdayDate { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Passphrase { get; set; }
    }
}
