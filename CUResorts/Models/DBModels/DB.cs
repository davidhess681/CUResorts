namespace CUResorts.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=HotelDB")
        {
        }

        public virtual DbSet<anemity> anemities { get; set; }
        public virtual DbSet<charge> charges { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<employee_roles> employee_roles { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<roomtype> roomtypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<anemity>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<anemity>()
                .Property(e => e.StandardCost)
                .HasPrecision(10, 0);

            modelBuilder.Entity<charge>()
                .Property(e => e.DateCharged)
                .HasPrecision(0);

            modelBuilder.Entity<charge>()
                .Property(e => e.Void)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.EmpRoleID)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<employee_roles>()
                .Property(e => e.EmpRoleID)
                .IsUnicode(false);

            modelBuilder.Entity<employee_roles>()
                .Property(e => e.Permissions)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.DatePaid)
                .HasPrecision(0);

            modelBuilder.Entity<invoice>()
                .Property(e => e.PaymentType)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.Void)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.LNAME)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.FNAME)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reservation>()
                .Property(e => e.DateReserved)
                .HasPrecision(0);

            modelBuilder.Entity<reservation>()
                .Property(e => e.CheckIN)
                .HasPrecision(0);

            modelBuilder.Entity<reservation>()
                .Property(e => e.CheckOUT)
                .HasPrecision(0);

            modelBuilder.Entity<roomtype>()
                .Property(e => e.Style)
                .IsUnicode(false);

            modelBuilder.Entity<roomtype>()
                .Property(e => e.Smoking)
                .IsUnicode(false);

            modelBuilder.Entity<roomtype>()
                .HasMany(e => e.rooms)
                .WithRequired(e => e.roomtype)
                .WillCascadeOnDelete(false);
        }
    }
}
