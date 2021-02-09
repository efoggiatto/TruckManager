using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruckManager.Domain;

namespace TruckManager.Context.Mapping
{
    public class TruckModelMap : IEntityTypeConfiguration<TruckModel>
    {
        public void Configure(EntityTypeBuilder<TruckModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.ModelCode)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
