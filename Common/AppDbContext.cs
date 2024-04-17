using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Common
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> User { get; set; }
        //public DbSet<LoginRecord> LoginRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Normalde burada Entity bazında ayarlar yapılır mesela 
            //modelBuilder.Entity<Address>().HasKey(x => x.Id);
            //gibi, ama o zaman da AppDbContext nesnemin içerisi dolacaktır. Bu yüzden her bir Entity ayarını
            //farklı EntitySettings sınıflarında yaparız.  Repository.Configurations klasöründe yaptık.

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Kod içerisinde IEntityTypeConfiguration interface'ine sahip tüm sınıfları "Reflection" ile buldu ve Ayarlarını ekledi.

            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration()); Tek tek elle yapmak istersek bunu kullanırız. Ama 100 tane olursa yazmak zor iş. 

            base.OnModelCreating(modelBuilder);
        }
    }
}
