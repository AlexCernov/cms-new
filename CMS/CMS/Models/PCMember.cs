using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CMS.Models
{
    public class PCMember
    {
        public PCMember(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public PCMember()
        {
            this.Role = new Role();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(254)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(250)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Affiliation { get; set; }
        [Required]
        [StringLength(100)]
        public string WebPage { get; set; }

        public Role Role { get; set; }


        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Comitee> Comitees { get; set; }

    }
}