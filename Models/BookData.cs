namespace EBookMart.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookData : DbContext
    {
        public BookData()
            : base("name=BookDataConfig")
        {
        }

        public virtual DbSet<BookDb> BookDbs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
