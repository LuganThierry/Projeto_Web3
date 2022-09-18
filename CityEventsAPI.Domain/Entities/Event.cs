using CityEventsAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Domain.Entities
{
    public sealed class Event
    {
        public uint Event_Id { get; private set; }
        public string Event_Title { get; private set; }
        public string Event_Description { get; private set; }
        public DateTime Event_DataHour { get; private set; }
        public string Event_Local { get; private set; }
        public string Event_Address { get; private set; }
        public decimal Event_Price { get; private set; }
        //
        public ICollection<Reservation> Reservations { get; private set; }
        //

        public Event()
        {

        }

        public Event 
            (string title, 
            string description, 
            DateTime datehour, 
            string local, 
            string address, 
            decimal price)
        {
            Validation(title, description, datehour, local, address, price);
            Reservations = new List<Reservation>();
        }

        public Event
        (uint id,
        string title,
        string description,
        DateTime datehour,
        string local,
        string address,
        decimal price)
        {
            DomainValidationException.When(id <= 0, "Eventy Identity is an integer!");
            Event_Id = id;
            Validation(title, description, datehour, local, address, price);
            Reservations = new List<Reservation>();
        }

        public void Validation
        (string title,
        string description,
        DateTime? datehour,
        string local,
        string address,
        decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(title), "A title must be informed!");
            DomainValidationException.When(string.IsNullOrEmpty(description), "A description must be informed!");
            DomainValidationException.When(!datehour.HasValue, "A date must be informed!");
            DomainValidationException.When(string.IsNullOrEmpty(local), "A local must be informed!");
            DomainValidationException.When(string.IsNullOrEmpty(address), "A adress must be informed!");
            DomainValidationException.When(price <= 0, "A price must be informed!");

            Event_Title = title;
            Event_Description = description;
            Event_DataHour = datehour.Value;
            Event_Local = local;
            Event_Address = address;
            Event_Price = price;
        }

    }
}
