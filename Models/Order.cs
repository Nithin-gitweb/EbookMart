namespace EBookMart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int id { get; set; }

        public int bookid { get; set; }

        public int customerid { get; set; }
    }
}
