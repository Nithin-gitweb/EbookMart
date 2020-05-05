using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EBookMart.Models
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext() : base("name=AuthenticationConfig")
        {
        }

        public virtual DbSet<Authentication> Authentications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        
    }
}