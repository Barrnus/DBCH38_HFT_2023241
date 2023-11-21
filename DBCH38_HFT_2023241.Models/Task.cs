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
    public class Task
    {

        public Task()
        {
            Workers = new List<Worker>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

        [MaxLength(100)]
        [Required]
        public string Type { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Worker> Workers { get; set; }

        [NotMapped]
        public virtual Priority Priority { get; set; }

        [ForeignKey(nameof(Priority))]
        public int PriorityId { get; set; }

    }
}
