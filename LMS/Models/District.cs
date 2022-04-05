using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_m_district")]
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("City")]
        public int City_Id { get; set; }

        // Relation
        [JsonIgnore]
        public virtual ICollection<SubDistrict> SubDistricts { get; set; }

        [JsonIgnore]
        public virtual City City { get; set; }
    }
}
