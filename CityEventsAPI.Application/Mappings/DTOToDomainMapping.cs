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
    public class DTOToDomainMapping : Profile
    {
        public DTOToDomainMapping()
        {
            CreateMap<EventDTO, Event>();
            CreateMap<ReservationDTO, Reservation>();
        }
    }
}
