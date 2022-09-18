using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.DTO
{
    public class EventDTO
    {
        public uint Event_Id { get; set; }
        public string Event_Title { get; set; }
        public string Event_Description { get; set; }
        public DateTime Event_DataHour { get; set; }
        public string Event_Local { get; set; }
        public string Event_Address { get; set; }
        public decimal Event_Price { get; set; }
    }
}
