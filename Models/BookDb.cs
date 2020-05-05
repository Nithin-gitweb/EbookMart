namespace EBookMart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookDb")]
    public partial class BookDb
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string BookName { get; set; }

        [Required]
        [StringLength(50)]
        public string BookAuthor { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }
        [Required]
        public double GoodReadRatings { get; set; }

        [Required]
        public string BookDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }

        [Required]
        public string BookCover { get; set; }

        [Required]
        public string BookLink { get; set; }
        [Required]
        public double BookPrice { get; set; }
    }
}
