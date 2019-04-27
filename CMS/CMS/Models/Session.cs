using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Conference Conference { get; set; }
        public PCMember SessionChair { get; set; }
        public Room Room { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartingTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndingTime { get; set; }

    }
}