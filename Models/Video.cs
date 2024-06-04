using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaKids.Models
{
    [Table("Vídeo")]
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Link é obrigatório.")]
        [Display(Name = "Link do Vídeo")]
        public string Link { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [Display(Name = "Título do Vídeo")]
        public string Titulo { get; set; }

        public ICollection<Curiosidade>? Curiosidades { get; set; }
    }
}
