using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Comitee
    {

        public Comitee()
        {

        }

        public Comitee(string Name, ICollection<PCMember> PCMembers)
        {
            this.Name = Name;
            this.PCMembers = PCMembers;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<PCMember> PCMembers { get; set; }
    }
}