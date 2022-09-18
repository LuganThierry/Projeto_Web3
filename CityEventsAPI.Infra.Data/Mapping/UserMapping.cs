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
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("ApiUser");

            builder.HasKey(x => x.ApiUser_Id);

            builder.Property(x => x.ApiUser_Id)
                        .HasColumnName("ApiUser_Id");

            builder.Property(x => x.ApiUser_Email)
                        .HasColumnName("ApiUser_Email");

            builder.Property(x => x.ApiUser_Password)
                        .HasColumnName("ApiUser_Password");
        }
    }
}
