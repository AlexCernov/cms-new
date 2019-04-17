using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Review
    {
        [Key, Column(Order = 0)]
        public int Reviewer { get; set; }
        [Key, Column(Order = 1)]
        public int PaperId { get; set; }
        [Required, Column(Order = 2)]
        [StringLength(100)]
        public string Result { get; set; }
        [StringLength(250), Column(Order = 3)]
        public string Justification { get; set; }
    }
}