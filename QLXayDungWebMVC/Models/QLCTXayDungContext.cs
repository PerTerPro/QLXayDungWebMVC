namespace QLXayDungWebMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLCTXayDungContext : DbContext
    {
        public QLCTXayDungContext()
            : base("name=QLCTXayDungContext")
        {
        }

        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<CongTrinh> CongTrinhs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ChiTietNgayCong> ChiTietNgayCongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChamCong>()
                .HasMany(e => e.ChiTietNgayCongs)
                .WithRequired(e => e.ChamCong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CongTrinh>()
                .HasMany(e => e.ChamCongs)
                .WithRequired(e => e.CongTrinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ChamCongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.PhongBan)
                .WillCascadeOnDelete(false);
        }
    }
}
