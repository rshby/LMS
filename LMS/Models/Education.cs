using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_tr_education")]
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Major { get; set; }

        [Required]
        [ForeignKey("University")]
        public int University_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual University University { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
