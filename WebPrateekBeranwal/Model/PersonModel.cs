using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        [Required]
        [MaxLength(50), MinLength(3)]
        public string ForeName { get; set; }
        [Required]
        [MaxLength(50), MinLength(3)]
        public string SurName { get; set; }
        
        [Required(ErrorMessage = "Entered DOB format is not valid should be mm/dd/yyyy")]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        public List<PersonNumber> Number { get; set; }
    }

    public class PersonNumber
    {
        [Required]
        public string Number { get; set; }
        public string Type { get; set; }
    }
}
