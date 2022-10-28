using FranMotors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.DB.Mapping
{
    public class MotoMap: IEntityTypeConfiguration<Motocicleta>
    {
        public void Configure(EntityTypeBuilder<Motocicleta> builder)
        {
            builder.ToTable("Motocicleta");
            builder.HasKey(o => o.Id);

            //builder.HasOne(o => o.)
            //    .WithMany()
            //    .HasForeignKey(o => o.);
        }

    }
}
