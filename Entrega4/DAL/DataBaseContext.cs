using Microsoft.EntityFrameworkCore;
using _3ra_entrega.DAL.Entities;

namespace _3ra_entrega.DAL
{
    public class DataBaseContext : DbContext

    {
        //asi me conecto a la base de datos por medio de este constructor 
        public DataBaseContext(DbContextOptions<DataBaseContext>options): base(options)
        {
            
        }

        //para configurar indices en cada campo en la tabla en la base de datos 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }

        #region DbSets  
        // es el set de cada tabla, por cada entidad se crea un set  

        public DbSet<Country> Countries { get; set; }// asi se identifica que es una base de datos 

        #endregion
    }
}