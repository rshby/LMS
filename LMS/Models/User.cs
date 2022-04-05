using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_m_user")]
    public class User
    {
        [Key]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [ForeignKey("Education")]
        public int Education_Id { get; set; }
        
        [Required]
        [ForeignKey("Address")]
        public int Address_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual Account Account { get; set; }

        [JsonIgnore]
        public virtual Education Education { get; set; }
        
        [JsonIgnore]
        public virtual Address Address { get; set; }

        [JsonIgnore]
        public virtual ICollection<TakenClass> TakenClasses { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
