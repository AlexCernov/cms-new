using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Building { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Capacity { get; set; }


        public Room(int id, string build, int num, int cap)
        {
            Id = id;
            Building = build;
            Number = num;
            Capacity = cap;
        }

    }
}