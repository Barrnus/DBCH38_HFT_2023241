using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DBCH38_HFT_2023241.Models
{
    public class Priority
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Value { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
