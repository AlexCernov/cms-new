using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class WrittenBy
    {
        [Key, Column(Order = 0)]
        public int AuthorId { get; set; }
        [Key, Column(Order = 1)]
        public int PaperId { get; set; }
    }
}