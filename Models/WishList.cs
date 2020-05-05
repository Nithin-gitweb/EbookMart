namespace EBookMart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WishList")]
    public partial class WishList
    {
        public int id { get; set; }

        public int Bookid { get; set; }

        public int CustomerId { get; set; }
    }
}
