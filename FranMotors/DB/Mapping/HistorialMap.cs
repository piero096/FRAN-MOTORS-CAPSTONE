using FranMotors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.DB.Mapping
{
    public class HistorialMap : IEntityTypeConfiguration<Historial>
    {
        public void Configure(EntityTypeBuilder<Historial> builder)
        {
            builder.ToTable("Historial");
            builder.HasKey(o => o.Id);

            //builder.HasOne(o => o.)
            //    .WithMany()
            //    .HasForeignKey(o => o.);
        }

    }
}
