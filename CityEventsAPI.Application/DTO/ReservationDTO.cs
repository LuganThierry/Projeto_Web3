using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.DTO
{
    public class ReservationDTO
    {
        public uint Reservation_Id { get; set; }
        public uint Event_Id { get; set; }
        public string Person_Name { get; set; }
        public uint Quantity { get; set; }
    }
}
