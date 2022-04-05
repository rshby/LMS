using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_tr_certificate")]
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [ForeignKey("TakenClass")]
        public int TakenClass_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual TakenClass TakenClass { get; set; }
    }
}
