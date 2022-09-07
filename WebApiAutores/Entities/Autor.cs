using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAutores.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} no debe de tener mas de {1} caracteres.")]
        public string Name { get; set; }
        [Range(18,120)]
        [NotMapped]
        public int Age { get; set; }
        [CreditCard]
        [NotMapped]
        public string CreditCard { get; set; }
        [Url]
        [NotMapped]
        public string URL { get; set; }
        public List<Libro> Libros { get; set; }

    }
}
