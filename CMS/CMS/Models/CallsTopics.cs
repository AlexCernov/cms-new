using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class CallsTopics
    {
        [Key, Column(Order= 0)]
        public int TopicId { get; set; }
        [Key, Column(Order = 1)]
        public int CallForPapersId { get; set; }

    }
}