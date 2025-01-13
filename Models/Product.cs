using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        public string PName { get; set; }

        public int CatId { get; set; }


        [ForeignKey("CatId")]
        public Category Category { get; set; }
    }
}