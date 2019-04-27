using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public virtual ICollection<CallForPapers> CallForPapers { get; set; }
        public virtual ICollection<Paper> Papers { get; set; }

    }
}