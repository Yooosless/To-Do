using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Notes.Models
{
    public class Noting
    {
        [Key]
        public  int   Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Priority")]
        [Range(1,100,ErrorMessage ="Priority must be between 1-100")]
        public int DisplayOrder { get; set; }

        public DateTime CreateDateTime { get; set; }= DateTime.Now;
            
     }
}
