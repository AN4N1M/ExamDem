using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Пробник.Models;

namespace Пробник.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-82GJJHS\\SQLEXPRESS01;Initial Catalog=probnik;Integrated Security=True;Pooling=False;Encrypt=True; TrustServerCertificate=True");
            
        }

        
    }
    
}
