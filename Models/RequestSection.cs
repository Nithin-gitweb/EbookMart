namespace EBookMart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestSection")]
    public partial class RequestSection
    {
        public int id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string RequestDesc { get; set; }
    }
}
