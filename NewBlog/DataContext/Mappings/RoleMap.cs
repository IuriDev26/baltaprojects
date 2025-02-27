using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBlog.Models;

namespace NewBlog.DataContext.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn()
            .IsRequired();
        
        builder.Property(p => p.Name)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();
        
        builder.Property(r => r.Slug)
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();
    }
}