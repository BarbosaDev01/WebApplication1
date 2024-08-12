using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class instituicoes
    {
        [Key]
        public int instid { get; set; }
        [Required]
        public string instnome { get; set; }
        [Required]
        public string instendereco { get; set; }
        public virtual ICollection<departamento> departamento { get; set; }
    }
}
