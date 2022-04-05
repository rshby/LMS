using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_m_city")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Province")]
        public int Province_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual ICollection<District> Districts { get; set; }

        [JsonIgnore]
        public virtual Province Province { get; set; }
    }
}
