using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EBookMart.Models
{
    public class WishListContext : DbContext
    {
        public WishListContext() : base("name=WishListConfig")
        {
        }

        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
       
    }
}