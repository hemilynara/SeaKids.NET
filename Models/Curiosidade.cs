using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaKids.Models
{
    [Table("Curiosidades")]
    public class Curiosidade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Imagem")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo Texto é obrigatório.")]
        [Display(Name = "Texto")]
        public string Texto { get; set; }
    }
}


