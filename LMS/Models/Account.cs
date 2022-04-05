using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("tb_tr_account")]
    public class Account
    {
        [Key]
        [ForeignKey("User")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
                
        public int OTP { get; set; }

        public DateTime ExpiredToken { get; set; }

        public bool IsUsed { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int Role_Id { get; set; }

        //Relation
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
