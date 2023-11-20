using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DBCH38_HFT_2023241.Models
{
    public class Worker
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Position { get; set; }

        [Range(16,60)]
        [Required]
        public string Age { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Task Task { get; set; }

        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }

    }
}
