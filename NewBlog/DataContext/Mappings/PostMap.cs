using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBlog.Models;

namespace NewBlog.DataContext.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn()
            .IsRequired();

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasConstraintName("FK_Post_Category")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Author)
            .WithMany()
            .HasConstraintName("FK_Post_Author")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(p => p.Title)
            .HasColumnName("Title")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160)
            .IsRequired();
        
        builder.Property(p => p.Summary)
            .HasColumnName("Summary")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(p => p.Body)
            .HasColumnName("Body")
            .HasColumnType("TEXT")
            .IsRequired();
        
        builder.Property(p=>p.Slug)
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();
        
        builder.Property(p=>p.CreateDate)
            .HasColumnName("CreateDate")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
        
        builder.Property(p=>p.LastUpdateDate)
            .HasColumnName("LastUpdateDate")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
            
    }
}