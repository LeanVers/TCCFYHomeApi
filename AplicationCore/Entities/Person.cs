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

        public void AddPerson(PersonDto person)
        {
            if(person != null)
            {
                this.Name = person.Name;
                this.Email = person.Email;
                this.BirthdayDate = DateTime.Parse(person.BirthdayDate);
                this.CPF = person.CPF;
                this.Phone = person.Phone;
                this.Passphrase = person.Passphrase;
                this.KeyPassphrase = person.Passphrase;
                this.RecordDate = DateTime.Now;
                this.Active = true;
            }
        }

        public void AddPerson(PersonDto person, int personId)
        {
            if (person != null)
            {
                this.PersonId = personId;
                AddPerson(person);
            }
        }
    }
}
