using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class DBConfig
    {
        public static DbContextOptions<Db_Connection> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<Db_Connection>();
            builder.UseSqlServer("Data Source=.; Initial Catalog=BD_ORIGIN_S; Integrated Security=True; TrustServerCertificate=True");
            return builder.Options;
        }
    }
}
