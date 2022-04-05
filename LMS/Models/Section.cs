using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_m_section")]
    public class Section
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Chapter { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey("Class")]
        public int Class_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual Class Class { get; set; }
    }
}
