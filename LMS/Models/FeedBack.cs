using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_tr_feedback")]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]
        [ForeignKey("TakenClass")]
        public int TakenClass_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual TakenClass TakenClass { get; set; }
    }
}
