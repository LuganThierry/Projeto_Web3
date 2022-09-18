using CityEventsAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Domain.Entities
{
    public sealed class Reservation
    {
        public uint Reservation_Id { get; private set; }
        public uint Event_Id { get; private set; }
        public string Person_Name { get; private set; }
        public uint Quantity { get; private set; }
        // 
        public Event Event { get; private set; }
        //

        public Reservation()
        {

        }

        public Reservation
            (uint eventId,
            string personName,
            uint quantity)
        {
            Validation(eventId, personName, quantity);
        }

        public Reservation
            (uint id,
            uint eventId,
            string personName,
            uint quantity)
        {
            DomainValidationException.When(id <= 0, "Reservation Identity is an integer!");
            Reservation_Id = id;
            Validation(eventId, personName, quantity);
        }

        public void Validation
            (uint eventId,
            string personName,
            uint quantity)
        {
            DomainValidationException.When(eventId <= 0, "Event Identity is an integer!");
            DomainValidationException.When(string.IsNullOrEmpty(personName), "A person's name must be informed!");
            DomainValidationException.When(quantity <= 0, "A quantity must be informed!");

            Event_Id = eventId;
            Person_Name = personName;
            Quantity = quantity;
        }
    }
}
