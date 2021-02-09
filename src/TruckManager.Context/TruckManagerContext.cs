using Microsoft.EntityFrameworkCore;
using System;
using TruckManager.Context.Mapping;
using TruckManager.Domain;

namespace TruckManager.Context
{
    public class TruckManagerContext : DbContext
    {

        public TruckManagerContext(DbContextOptions<TruckManagerContext> options ) 
            : base(options)
        {

        }

        #region [ DbSets ]
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckModel> TruckModels { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new TruckMap());
            builder.ApplyConfiguration(new TruckModelMap());
            
        }
    }
}
