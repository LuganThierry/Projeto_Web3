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
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("CityEvent");

            builder.HasKey(x => x.Event_Id);

            builder.Property(x => x.Event_Id)
                    .HasColumnName("Event_Id")
                    .UseIdentityColumn();

            builder.Property(x => x.Event_Title)
                    .HasColumnName("Event_Title");

            builder.Property(x => x.Event_Description)
                    .HasColumnName("Event_Description");

            builder.Property(x => x.Event_DataHour)
                    .HasColumnName("Event_DateHour");

            builder.Property(x => x.Event_Local)
                    .HasColumnName("Event_Local");

            builder.Property(x => x.Event_Address)
                    .HasColumnName("Event_Address");

            builder.Property(x => x.Event_Price)
                    .HasColumnName("Event_Price");

            builder.HasMany(x => x.Reservations)
                    .WithOne(x => x.Event)
                    .HasForeignKey(x => x.Event_Id);
        }
    }
}
