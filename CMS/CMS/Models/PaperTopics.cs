using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class PaperTopics
    {
        [Key, Column(Order = 0)]
        public int PaperId { get; set; }
        [Key, Column(Order = 1)]
        public int TopicId { get; set; }
    }
}