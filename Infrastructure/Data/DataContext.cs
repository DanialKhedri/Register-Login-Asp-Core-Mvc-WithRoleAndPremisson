using Domain.Entities.Role;
using Domain.Entities.SelectedRole;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        #region OnConfig

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@$"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");
        }

        #endregion




        #region Dbsets
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<SelectedRole> SelectedRoles { get; set; }

        #endregion



    }
}
