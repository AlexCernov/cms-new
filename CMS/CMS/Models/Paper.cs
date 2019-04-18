using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Paper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public CallForPapers CallForPapers { get; set; }
        [StringLength(250)]
        public string FilePath { get; set; }

        public virtual ICollection<PaperTopics> Topics { get; set; }
        public virtual ICollection<WrittenBy> Authors { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}