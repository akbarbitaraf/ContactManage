using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ContanctManageEntities.DB
{
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Family { get; set; }
        public string FullName { get { return Name + ' ' + Family; } }
        public string? Email { get; set; }
        public List<Phone>? Phone { get; set; }
        public string? Address { get; set; }
        [ForeignKey("ContactType_ID")]
        public int ContactType_ID { get; set; }
        public ContactTypes? ContactType { get; set; }
    }

}
