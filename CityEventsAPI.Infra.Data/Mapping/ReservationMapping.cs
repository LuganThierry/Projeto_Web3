using CityEventsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Infra.Data.Mapping
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("EventReservation");

            builder.HasKey(x => x.Reservation_Id);

            builder.Property(x => x.Reservation_Id)
                    .HasColumnName("Reservation_Id")
                    .UseIdentityColumn();

            builder.Property(x => x.Event_Id)
                    .HasColumnName("Event_Id");

            builder.Property(x => x.Person_Name)
                    .HasColumnName("Person_Name");

            builder.Property(x => x.Quantity)
                    .HasColumnName("Quantity");

            builder.HasOne(x => x.Event)
                    .WithMany(x => x.Reservations);
        }
    }
}
