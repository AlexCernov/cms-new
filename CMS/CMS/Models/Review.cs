using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Column(Order = 0)]
        public PCMember PCMember { get; set; }


        [Required, Column(Order = 1)]
        public Paper Paper { get; set; }

        [Required, Column(Order = 2)]
        [StringLength(100)]
        public string Result { get; set; }


        [StringLength(250), Column(Order = 3)]
        public string Justification { get; set; }


    }
}