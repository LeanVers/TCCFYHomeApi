using AplicationCore.Sevices.Dtos;
using System;

namespace AplicationCore.Entities
{
    public class Person : BaseEntity
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Passphrase { get; set; }
        public string KeyPassphrase { get; set; }
    }
}
