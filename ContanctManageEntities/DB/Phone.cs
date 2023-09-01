using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContanctManageEntities.DB
{
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [ForeignKey("ContactId")]
        public int ContactId { get; set; }
        public Contacts Contact { get; set; }








    }

}
