using System.ComponentModel.DataAnnotations;

namespace PLVISORTELERIK.DTOs
{
    public class ExampleDTO
    {
        [Required]
        public string cadena { get; set; }

        public int entero { get; set; }

        public DateTime fecha { get; set; }
    }
}
