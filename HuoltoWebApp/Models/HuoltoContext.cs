using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;


namespace HuoltoWebApp.Models
{
    public partial class HuoltoContext : DbContext
    {
        public HuoltoContext()
        {
        }

        public HuoltoContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public virtual DbSet<Auto> Autos { get; set; } = null!;
        public virtual DbSet<AutoHuollot> AutoHuollots { get; set; } = null!;
        public virtual DbSet<AutoHuoltopyyntö> AutoHuoltopyyntös { get; set; } = null!;
        public virtual DbSet<AutoInfo> AutoInfos { get; set; } = null!;
        public virtual DbSet<AutoMuistutu> AutoMuistutus { get; set; } = null!;
        public virtual DbSet<Huoltopaikat> Huoltopaikats { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Muistutustyyppi> Muistutustyyppis { get; set; } = null!;
        public virtual DbSet<Pv> Pvs { get; set; } = null!;
        public virtual DbSet<PvHuollot> PvHuollots { get; set; } = null!;
        public virtual DbSet<PvHuoltopyyntö> PvHuoltopyyntös { get; set; } = null!;
        public virtual DbSet<PvInfo> PvInfos { get; set; } = null!;
        public virtual DbSet<PvMuistutu> PvMuistutus { get; set; } = null!;
        public virtual DbSet<Säiliö> Säiliös { get; set; } = null!;
        public virtual DbSet<SäiliöHuollot> SäiliöHuollots { get; set; } = null!;
        public virtual DbSet<SäiliöHuoltopyyntö> SäiliöHuoltopyyntös { get; set; } = null!;
        public virtual DbSet<SäiliöInfo> SäiliöInfos { get; set; } = null!;
        public virtual DbSet<SäiliöMuistutu> SäiliöMuistutus { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.ToTable("Auto");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.Adr)
                    .HasColumnType("date")
                    .HasColumnName("ADR");

                entity.Property(e => e.Alkolukko).HasColumnType("date");

                entity.Property(e => e.AutoInfoId).HasColumnName("AutoInfoID");

                entity.Property(e => e.Katsastus).HasColumnType("date");

                entity.Property(e => e.Nopeudenrajoitin).HasColumnType("date");

                entity.Property(e => e.Piirturi).HasColumnType("date");

                entity.Property(e => e.RekNro)
                    .HasMaxLength(10)
                    .HasColumnName("REK-NRO");

                entity.Property(e => e.SäiliöId).HasColumnName("SäiliöID");

                entity.HasOne(d => d.Säiliö)
                    .WithMany(p => p.Autos)
                    .HasForeignKey(d => d.SäiliöId)
                    .HasConstraintName("FK_Auto_Säiliö");
            });

            modelBuilder.Entity<AutoHuollot>(entity =>
            {
                entity.HasKey(e => e.HuollonId)
                    .HasName("PK__AutoHuol__5FD7B1EA7BC416AB");

                entity.ToTable("AutoHuollot");

                entity.Property(e => e.HuollonId).HasColumnName("HuollonID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.HuoltoPvm).HasColumnType("datetime");

                entity.Property(e => e.HuoltopaikkaId)
                    .HasMaxLength(50)
                    .HasColumnName("HuoltopaikkaID");

                entity.HasOne(d => d.Auto)
                    .WithMany(p => p.AutoHuollots)
                    .HasForeignKey(d => d.AutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoHuollot_Auto");
            });

            modelBuilder.Entity<AutoHuoltopyyntö>(entity =>
            {
                entity.HasKey(e => e.HuoltoId)
                    .HasName("PK__AutoHuol__BE746FF02A295F37");

                entity.ToTable("AutoHuoltopyyntö");

                entity.Property(e => e.HuoltoId)
                    .ValueGeneratedNever()
                    .HasColumnName("HuoltoID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.HuollonKuvaus).HasMaxLength(2000);

                entity.HasOne(d => d.Auto)
                    .WithMany(p => p.AutoHuoltopyyntös)
                    .HasForeignKey(d => d.AutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoHuoltopyyntö_Auto");
            });

            modelBuilder.Entity<AutoInfo>(entity =>
            {
                entity.ToTable("AutoInfo");

                entity.HasIndex(e => e.AutoId, "UQ__AutoInfo__6B232964F93818B5")
                    .IsUnique();

                entity.Property(e => e.AutoInfoId).HasColumnName("AutoInfoID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.InfoTxt).HasColumnName("InfoTXT");

                entity.HasOne(d => d.Auto)
                    .WithOne(p => p.AutoInfo)
                    .HasForeignKey<AutoInfo>(d => d.AutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoInfo_Auto");
            });

            modelBuilder.Entity<AutoMuistutu>(entity =>
            {
                entity.HasKey(e => e.AutoMuistutusId)
                    .HasName("PK__AutoMuis__37A01D1C38893DA6");

                entity.Property(e => e.AutoMuistutusId).HasColumnName("AutoMuistutusID");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.MuistutusPvm)
                    .HasColumnType("date")
                    .HasColumnName("MuistutusPVM");

                entity.HasOne(d => d.Auto)
                    .WithMany(p => p.AutoMuistutus)
                    .HasForeignKey(d => d.AutoId)
                    .HasConstraintName("FK_AutoMuistutus_Auto");

                entity.HasOne(d => d.MuistutustyyppiNavigation)
                    .WithMany(p => p.AutoMuistutus)
                    .HasForeignKey(d => d.Muistutustyyppi)
                    .HasConstraintName("FK_AutoMuistutus_Muistutustyyppi");
            });

            modelBuilder.Entity<Huoltopaikat>(entity =>
            {
                entity.HasKey(e => e.HuoltoPaikkaId)
                    .HasName("PK__Huoltopa__DADB2282F9D2430F");

                entity.ToTable("Huoltopaikat");

                entity.Property(e => e.HuoltoPaikkaId).HasColumnName("HuoltoPaikkaID");

                entity.Property(e => e.Huoltopaikka).HasMaxLength(50);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.Käyttäjätunnus).HasMaxLength(50);

                entity.Property(e => e.Salasana).HasMaxLength(50);
            });

            modelBuilder.Entity<Muistutustyyppi>(entity =>
            {
                entity.ToTable("Muistutustyyppi");

                entity.Property(e => e.MuistutustyyppiId).HasColumnName("MuistutustyyppiID");

                entity.Property(e => e.MuistutustyyppiNimi).HasMaxLength(50);
            });

            modelBuilder.Entity<Pv>(entity =>
            {
                entity.ToTable("PV");

                entity.Property(e => e.PvId).HasColumnName("PvID");

                entity.Property(e => e.Adr)
                    .HasColumnType("date")
                    .HasColumnName("ADR");

                entity.Property(e => e.Katsastus).HasColumnType("date");

                entity.Property(e => e.Määräaikaistarkastus).HasColumnType("date");

                entity.Property(e => e.PvInfoId).HasColumnName("PvInfoID");

                entity.Property(e => e.RekNro)
                    .HasMaxLength(10)
                    .HasColumnName("REK-NRO");

                entity.Property(e => e.Välitarkastus).HasColumnType("date");
            });

            modelBuilder.Entity<PvHuollot>(entity =>
            {
                entity.HasKey(e => e.HuoltoId)
                    .HasName("PK__PvHuollo__BE746FF09B0C99D1");

                entity.ToTable("PvHuollot");

                entity.Property(e => e.HuoltoId)
                    .ValueGeneratedNever()
                    .HasColumnName("HuoltoID");

                entity.Property(e => e.HuollonKuvaus).HasMaxLength(2000);

                entity.Property(e => e.HuoltoPaikkaId).HasColumnName("HuoltoPaikkaID");

                entity.Property(e => e.HuoltoPvm).HasColumnType("date");

                entity.Property(e => e.PvId).HasColumnName("PvID");

                entity.HasOne(d => d.Pv)
                    .WithMany(p => p.PvHuollots)
                    .HasForeignKey(d => d.PvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PvHuollot_Pv");
            });

            modelBuilder.Entity<PvHuoltopyyntö>(entity =>
            {
                entity.HasKey(e => e.HuoltoId)
                    .HasName("PK__PvHuolto__BE746FF0B0DE434F");

                entity.ToTable("PvHuoltopyyntö");

                entity.Property(e => e.HuoltoId)
                    .ValueGeneratedNever()
                    .HasColumnName("HuoltoID");

                entity.Property(e => e.HuollonKuvaus).HasMaxLength(2000);

                entity.Property(e => e.PvId).HasColumnName("PvID");

                entity.HasOne(d => d.Pv)
                    .WithMany(p => p.PvHuoltopyyntös)
                    .HasForeignKey(d => d.PvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PvHuoltopyyntö_PV");
            });

            modelBuilder.Entity<PvInfo>(entity =>
            {
                entity.ToTable("PvInfo");

                entity.HasIndex(e => e.PvId, "UQ__PvInfo__9A008323337D0F32")
                    .IsUnique();

                entity.Property(e => e.PvInfoId).HasColumnName("PvInfoID");

                entity.Property(e => e.InfoTxt).HasColumnName("InfoTXT");

                entity.Property(e => e.PvId).HasColumnName("PvID");

                entity.HasOne(d => d.Pv)
                    .WithOne(p => p.PvInfo)
                    .HasForeignKey<PvInfo>(d => d.PvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PvInfo_Pv");
            });

            modelBuilder.Entity<PvMuistutu>(entity =>
            {
                entity.HasKey(e => e.PvMuistutusId)
                    .HasName("PK__PvMuistu__1BD388FDD942EBB5");

                entity.Property(e => e.PvMuistutusId).HasColumnName("PvMuistutusID");

                entity.Property(e => e.MuistutusPvm)
                    .HasColumnType("date")
                    .HasColumnName("MuistutusPVM");

                entity.Property(e => e.PvId).HasColumnName("PvID");

                entity.HasOne(d => d.MuistutustyyppiNavigation)
                    .WithMany(p => p.PvMuistutus)
                    .HasForeignKey(d => d.Muistutustyyppi)
                    .HasConstraintName("FK_PvMuistutus_Muistutustyyppi");

                entity.HasOne(d => d.Pv)
                    .WithMany(p => p.PvMuistutus)
                    .HasForeignKey(d => d.PvId)
                    .HasConstraintName("FK_PvMuistutus_PV");
            });

            modelBuilder.Entity<Säiliö>(entity =>
            {
                entity.ToTable("Säiliö");

                entity.Property(e => e.SäiliöId).HasColumnName("SäiliöID");

                entity.Property(e => e.Määräaikaistarkastus).HasColumnType("date");

                entity.Property(e => e.SäiliöInfoId).HasColumnName("SäiliöInfoID");

                entity.Property(e => e.Vakaus).HasColumnType("date");

                entity.Property(e => e.Välitarkastus).HasColumnType("date");
            });

            modelBuilder.Entity<SäiliöHuollot>(entity =>
            {
                entity.HasKey(e => e.HuoltoId)
                    .HasName("PK__SäiliöHu__BE746FF042AD424C");

                entity.ToTable("SäiliöHuollot");

                entity.Property(e => e.HuoltoId)
                    .ValueGeneratedNever()
                    .HasColumnName("HuoltoID");

                entity.Property(e => e.HuollonKuvaus).HasMaxLength(200);

                entity.Property(e => e.HuoltoPaikkaId).HasColumnName("HuoltoPaikkaID");

                entity.Property(e => e.HuoltoPvm).HasColumnType("date");

                entity.Property(e => e.SäiliöId).HasColumnName("SäiliöID");

                entity.HasOne(d => d.Säiliö)
                    .WithMany(p => p.SäiliöHuollots)
                    .HasForeignKey(d => d.SäiliöId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SäiliöHuollot_Säiliö");
            });

            modelBuilder.Entity<SäiliöHuoltopyyntö>(entity =>
            {
                entity.HasKey(e => e.HuoltoId)
                    .HasName("PK__SäiliöHu__BE746FF078774EDD");

                entity.ToTable("SäiliöHuoltopyyntö");

                entity.Property(e => e.HuoltoId)
                    .ValueGeneratedNever()
                    .HasColumnName("HuoltoID");

                entity.Property(e => e.HuollonKuvaus).HasMaxLength(2000);

                entity.Property(e => e.SäiliöId).HasColumnName("SäiliöID");

                entity.HasOne(d => d.Säiliö)
                    .WithMany(p => p.SäiliöHuoltopyyntös)
                    .HasForeignKey(d => d.SäiliöId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SäiliöHuoltopyyntö_Säiliö");
            });

            modelBuilder.Entity<SäiliöInfo>(entity =>
            {
                entity.ToTable("SäiliöInfo");

                entity.HasIndex(e => e.SäiliöId, "UQ__SäiliöIn__21300E71C1C62E57")
                    .IsUnique();

                entity.Property(e => e.SäiliöInfoId).HasColumnName("SäiliöInfoID");

                entity.Property(e => e.InfoTxt).HasColumnName("InfoTXT");

                entity.Property(e => e.SäiliöId).HasColumnName("SäiliöID");

                entity.HasOne(d => d.Säiliö)
                    .WithOne(p => p.SäiliöInfo)
                    .HasForeignKey<SäiliöInfo>(d => d.SäiliöId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SäiliöInfo_Säiliö");
            });

            modelBuilder.Entity<SäiliöMuistutu>(entity =>
            {
                entity.HasKey(e => e.SäiliöMuistutusId)
                    .HasName("PK__SäiliöMu__41E798D7F1E7485D");

                entity.Property(e => e.SäiliöMuistutusId).HasColumnName("SäiliöMuistutusID");

                entity.Property(e => e.MuistutusPvm)
                    .HasColumnType("date")
                    .HasColumnName("MuistutusPVM");

                entity.Property(e => e.SäiliöId).HasColumnName("SäiliöID");

                entity.HasOne(d => d.MuistutustyyppiNavigation)
                    .WithMany(p => p.SäiliöMuistutus)
                    .HasForeignKey(d => d.Muistutustyyppi)
                    .HasConstraintName("FK_SäiliöMuistutus_Muistutustyyppi");

                entity.HasOne(d => d.Säiliö)
                    .WithMany(p => p.SäiliöMuistutus)
                    .HasForeignKey(d => d.SäiliöId)
                    .HasConstraintName("FK_SäiliöMuistutus_Säiliö");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
