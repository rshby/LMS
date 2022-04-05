
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_tr_takenclass")]
    public class TakenClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string Email { get; set; }

        [Required]
        public int ProgressChapter { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        [ForeignKey("Class")]
        public int Class_Id { get; set; }

        // Relation
        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Class Class { get; set; }

        [JsonIgnore]
        public virtual Certificate Certificate { get; set; }

        [JsonIgnore]
        public virtual FeedBack FeedBack { get; set; }
    }
}
