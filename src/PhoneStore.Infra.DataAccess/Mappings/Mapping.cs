using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneStory.Domain.Entities;
using PhoneStory.Domain.Shared.ValueObject;
using System;

namespace PhoneStore.Infra.DataAccess.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);            

            builder.OwnsOne(x => x.Dimensions, y =>
            {
                y.Property(p => p.Length)
                 .HasColumnName("Length")
                 .HasDefaultValue(0)
                .HasColumnType("decimal(15, 2)");

                y.Property(p => p.Width)
                 .HasColumnName("Width")
                 .HasDefaultValue(0)
                .HasColumnType("decimal(15, 2)");

                y.Property(p => p.Depth)
                 .HasColumnName("Depth")
                 .HasDefaultValue(0)
                .HasColumnType("decimal(15, 2)");
            });

            builder.HasDiscriminator<string>("Type")
                  .HasValue<CellPhone>(typeof(CellPhone).Name)
                  .HasValue<Accessory>(typeof(Accessory).Name);

            builder.Property(c => c.DisplayName)
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Description)
                   .HasColumnType("varchar(300)");

            builder.Property(c => c.Price)
                   .HasColumnType("decimal(15, 2)");
        }
    }

    public class CellPhoneMap : IEntityTypeConfiguration<CellPhone>
    {
        public void Configure(EntityTypeBuilder<CellPhone> builder)
        {           
        }
    }

    public class AccessoryMap : IEntityTypeConfiguration<Accessory>
    {
        public void Configure(EntityTypeBuilder<Accessory> builder)
        {            
        }
    }
}
