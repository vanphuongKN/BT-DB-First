using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BT_DB_First.Models;

public partial class QlVanphongphamContext : DbContext
{
    public QlVanphongphamContext()
    {
    }

    public QlVanphongphamContext(DbContextOptions<QlVanphongphamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TbDanhmucvanphongpham> TbDanhmucvanphongphams { get; set; }

    public virtual DbSet<TbVanphongpham> TbVanphongphams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=QL_VANPHONGPHAM;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbDanhmucvanphongpham>(entity =>
        {
            entity.HasKey(e => e.Maloai).HasName("PK__tbDANHMU__2F633F23618E01C4");

            entity.ToTable("tbDANHMUCVANPHONGPHAM");

            entity.Property(e => e.Maloai)
                .ValueGeneratedNever()
                .HasColumnName("MALOAI");
            entity.Property(e => e.Mota).HasColumnName("MOTA");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(200)
                .HasColumnName("TENLOAI");
        });

        modelBuilder.Entity<TbVanphongpham>(entity =>
        {
            entity.HasKey(e => e.Mavanphongpham).HasName("PK__tbVANPHO__F9F789F959FDC65B");

            entity.ToTable("tbVANPHONGPHAM");

            entity.Property(e => e.Mavanphongpham)
                .ValueGeneratedNever()
                .HasColumnName("MAVANPHONGPHAM");
            entity.Property(e => e.Maloai).HasColumnName("MALOAI");
            entity.Property(e => e.Mota).HasColumnName("MOTA");
            entity.Property(e => e.Tenvanphongpham)
                .HasMaxLength(200)
                .HasColumnName("TENVANPHONGPHAM");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.TbVanphongphams)
                .HasForeignKey(d => d.Maloai)
                .HasConstraintName("FK__tbVANPHON__MALOA__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
