namespace DealerVehicle
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DealerVehicleContext : DbContext
    {
        // Your context has been configured to use a 'DealerVehicleContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DealerVehicle.DealerVehicleContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DealerVehicleContext' 
        // connection string in the application configuration file.
        public DealerVehicleContext()
            : base("name=DealerVehicleContext")
        {
            Database.SetInitializer<DealerVehicleContext>(new DropCreateDatabaseIfModelChanges<DealerVehicleContext>());
        }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<DealerVehicles> DealerVehicle { get; set; }

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DealerVehicles>()
                    .HasRequired<Dealer>(s => s.Dealer) 
                    .WithMany(s => s.DealerVehicles).HasForeignKey(d => d.DealerId).WillCascadeOnDelete(true);

            modelBuilder.Entity<DealerVehicles>()
                   .HasRequired<Vehicle>(s => s.Vehicle)
                   .WithMany(s => s.DealerVehicles).HasForeignKey(d => d.VehicleId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Vehicle>()
                   .HasRequired<Brand>(s => s.Brand)
                   .WithMany(s => s.Vehicles).HasForeignKey(d => d.BrandId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Model>()
                   .HasRequired<Brand>(s => s.Brand)
                   .WithMany(s => s.Models).HasForeignKey(d => d.BrandId).WillCascadeOnDelete(false);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}