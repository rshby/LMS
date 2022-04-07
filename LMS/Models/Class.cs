using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_m_class")]
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string urlPic { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        public int TotalChapter { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [ForeignKey("Level")]
        public int Level_Id { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int Category_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual ICollection<TakenClass> TakenClasses { get; set; }

        [JsonIgnore]
        public virtual Level Level { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<Section> Sections { get; set; }
    }
}
