using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Laboratorna_3_pz
{
    public class Context : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public string DbPath { get; set; }  
        
        public Context()
        {
            var directory = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(directory);
            DbPath = Path.Join(path, "Storage.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
