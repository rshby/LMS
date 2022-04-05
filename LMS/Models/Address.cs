using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_tr_address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Street { get; set; }

        [Required]
        [ForeignKey("SubDistrict")]
        public int Subdistrict_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual SubDistrict SubDistrict { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
