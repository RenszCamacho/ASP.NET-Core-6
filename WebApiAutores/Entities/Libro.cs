using System.ComponentModel.DataAnnotations;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 250)]
        public string Title { get; set; }
    }
}
