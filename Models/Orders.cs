namespace EBookMart.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Orders : DbContext
    {
        public Orders()
            : base("name=OrdersConfig")
        {
        }

        public virtual DbSet<Order> OrderData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
