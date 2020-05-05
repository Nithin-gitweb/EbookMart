namespace EBookMart.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RequestSectionConfig : DbContext
    {
        public RequestSectionConfig()
            : base("name=RequestSectionConfig")
        {
        }

        public virtual DbSet<RequestSection> RequestSections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
