using AutoMapper;
using CityEventsAPI.Application.DTO;
using CityEventsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<Reservation, ReservationDTO>();
        }
    }
}
