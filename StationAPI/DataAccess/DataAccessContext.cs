
using StationAPI.Models;

using Microsoft.EntityFrameworkCore;


namespace StationAPI.DataAccess
{
    public partial class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
        {


        }

        public DataAccessContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=PetrolStationData;Trusted_Connection=True;");
            }
        }

        public virtual DbSet<PetrolStation> PetrolStation { get; set; }
        public virtual DbSet<FuelInfo> FuelInfo { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");


            modelBuilder.Entity<FuelInfo>(entity =>
            {

                entity.Property(e => e. FuelId).HasColumnName("FuelId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}