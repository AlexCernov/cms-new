using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class CallForPapers
    {

        public CallForPapers()
        {

        }

        public CallForPapers(int Id,string Acronym, string Name, DateTime StartDate, DateTime DeadlineAbstract, DateTime DeadlineProposal,ICollection<Topic> Topics)
        {
            this.Id = Id;
            this.Acronym = Acronym;
            this.Name = Name;
            this.StartDate = StartDate;
            this.DeadlineAbstract = DeadlineAbstract;
            this.DeadlineProposal = DeadlineProposal;   
            this.Topics = Topics;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Acronym { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter the issued date.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter the issued date.")]
        public DateTime DeadlineAbstract { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter the issued date.")]
        public DateTime DeadlineProposal { get; set; }

		public virtual ICollection<Topic> Topics { get; set; }
    }
}