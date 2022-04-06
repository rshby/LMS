using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_m_subdistrict")]
    public class SubDistrict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        [ForeignKey("District")]
        public int District_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual District District { get; set; }

        [JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
