using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class departamento
    {
        [Key]
        public int depid { get; set; }
        [Required]
        public string depnome { get; set; }
        [Required]
        public int instid { get; set; }
        public instituicoes instituicoes { get; set; }

    }
}
