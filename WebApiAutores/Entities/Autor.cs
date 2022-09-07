using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entities
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener mas de {1} caracteres.")]
        //[PrimeraLetraMayuscula]
        public string Name { get; set; }
        //[Range(18,120)]
        //[NotMapped]
        //public int Age { get; set; }
        //[CreditCard]
        //[NotMapped]
        //public string CreditCard { get; set; }
        //[Url]
        //[NotMapped]
        //public string URL { get; set; }
        //public int Mayor { get; set; }
        //public int Menor { get; set; }
        public List<Libro> Libros { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var primeraLetra = Name[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula", new string[] { nameof(Name) });
                }
            }

            //if (Menor > Mayor)
            //{
            //    yield return new ValidationResult("Este valor no puede ser mas grande que el campo Mayor", new string[] { nameof(Menor) });
            //}
        }
    }
}
