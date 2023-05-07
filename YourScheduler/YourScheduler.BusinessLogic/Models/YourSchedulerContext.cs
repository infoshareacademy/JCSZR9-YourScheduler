using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace YourScheduler.BusinessLogic.Models;

public partial class YourSchedulerContext : DbContext
{
    public YourSchedulerContext()
    {
    }

    public YourSchedulerContext(DbContextOptions<YourSchedulerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersEvent> UsersEvents { get; set; }

    public virtual DbSet<UsersTeam> UsersTeams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AOTP4FT\\SQLEXPRESS;database=YourScheduler;Trusted_Connection=true;Encrypt=false");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Event>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__Events__3214EC072233EF22");

    //        entity.Property(e => e.Date).HasColumnType("datetime");
    //        entity.Property(e => e.Description)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //        entity.Property(e => e.Name)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //    });

    //    modelBuilder.Entity<Team>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__Teams__3214EC07F3F35233");

    //        entity.Property(e => e.Name)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //    });

    //    modelBuilder.Entity<User>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07D8918F66");

    //        entity.HasIndex(e => e.Password, "UQ__Users__87909B15F0492F36").IsUnique();

    //        entity.HasIndex(e => e.Email, "UQ__Users__A9D105347317E004").IsUnique();

    //        entity.Property(e => e.Displayname)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //        entity.Property(e => e.Email)
    //            .HasMaxLength(255)
    //            .IsUnicode(false);
    //        entity.Property(e => e.Name)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //        entity.Property(e => e.Password)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //        entity.Property(e => e.Surname)
    //            .HasMaxLength(50)
    //            .IsUnicode(false);
    //    });

    //    modelBuilder.Entity<UsersEvent>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__UsersEve__3214EC07FE098E4C");

    //        entity.HasOne(d => d.Event).WithMany(p => p.UsersEvents)
    //            .HasForeignKey(d => d.EventId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__UsersEven__Event__4AB81AF0");

    //        entity.HasOne(d => d.User).WithMany(p => p.UsersEvents)
    //            .HasForeignKey(d => d.UserId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__UsersEven__UserI__49C3F6B7");
    //    });

    //    modelBuilder.Entity<UsersTeam>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__UsersTea__3214EC0796B6A3AC");

    //        entity.HasOne(d => d.Team).WithMany(p => p.UsersTeams)
    //            .HasForeignKey(d => d.TeamId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__UsersTeam__TeamI__3F466844");

    //        entity.HasOne(d => d.User).WithMany(p => p.UsersTeams)
    //            .HasForeignKey(d => d.UserId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__UsersTeam__UserI__3E52440B");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    

}
