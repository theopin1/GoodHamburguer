using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GoodHamburger.Infra.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    { 
            public DataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                optionsBuilder.UseMySql(
                    "Server=localhost;Port=3306;Database=goodHamburger;User=root;Password=1234;AllowPublicKeyRetrieval=true;SslMode=None;",
                    new MySqlServerVersion(new Version(8, 4, 4))
                );

                return new DataContext(optionsBuilder.Options);
            }
        
    }
}
