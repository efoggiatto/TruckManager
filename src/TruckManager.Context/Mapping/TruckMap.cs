using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Domain;

namespace TruckManager.Context.Mapping
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {

            builder.HasKey(x => x.Chassis);

            builder.Property(x => x.Chassis)
                .ValueGeneratedNever()
                .HasMaxLength(17)
                .IsRequired();

            builder.Property(x => x.TruckModelId)
                .IsRequired();

            builder.Property(x => x.ModelYear)
                .IsRequired();

            builder.Property(x => x.BuildingYear)
                .IsRequired();

            builder.HasOne(x => x.TruckModel)
                .WithMany(y => y.Trucks)
                .HasForeignKey(fk => fk.TruckModelId);
                
        }
    }
}
