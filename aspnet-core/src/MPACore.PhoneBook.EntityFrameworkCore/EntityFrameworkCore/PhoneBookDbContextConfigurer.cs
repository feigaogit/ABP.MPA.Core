using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MPACore.PhoneBook.EntityFrameworkCore
{
    public static class PhoneBookDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PhoneBookDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseSqlServer(connectionString, b => b.UseRowNumberForPaging());//解决sqlserver2008不支持FETCH、NEXT
        }

        public static void Configure(DbContextOptionsBuilder<PhoneBookDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseSqlServer(connection, b => b.UseRowNumberForPaging());
        }
    }
}
