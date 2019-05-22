using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CMS.Models
{
    public class Conference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public CallForPapers CallForPapers { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EndDate { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime BiddingDeadline { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        public Comitee Comitee { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}