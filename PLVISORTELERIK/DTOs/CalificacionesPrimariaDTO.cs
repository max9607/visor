using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace PLVISORTELERIK.DTOs
{
    public class EstudiantePrimaria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public virtual List<CalificacionPrimaria> Calificaciones { get; set; } = new List<CalificacionPrimaria>();
        public string Conducta { get; set; } = string.Empty;
    }

    public class ActividadPrimaria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Abreviatura { get; set; } = string.Empty;
        public int Orden { get; set; }
    }
    public class CalificacionPrimaria
    {
        public int EstudianteId { get; set; }
        public int ActividadId { get; set; }
       public int DimensionId { get; set; }
      
        public int? Nota { get; set; } = 0;
    }


    public class DimensionesPrimariaDTO /*: ValidationAttribute*/
    {
        public int Id { get; set; }
       
        public string Nombre { get; set; } = string.Empty;
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public int? NotaTotal { get; set; }
 
        //[DimensionesPrimariaDTO]
        private static int? Nota { get; set; } = 0;
        private static int? contador { get; set; } = 0;
        public virtual List<ActividadPrimaria> Actividades { get; set; }
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{

        //    DimensionesPrimariaDTO context = validationContext.ObjectInstance as DimensionesPrimariaDTO;


        //    if (contador < context.Minimo || contador > context.Maximo)
        //        return new ValidationResult(ErrorMessage, new[] { $"La propiedad {validationContext.MemberName} debe estar entre {Minimo} y {Maximo}." });
        //    if (contador % 1 != 0)
        //        return new ValidationResult(ErrorMessage, new[] { $"La propiedad {validationContext.MemberName} debe ser un número entero." });
        //    return null;
        //}
    }

    public class FormularioNotasModelPrimaria
    {
        public List<EstudiantePrimaria> Estudiantes { get; set; } = new List<EstudiantePrimaria>();
        public List<DimensionesPrimariaDTO> Dimensiones { get; set; } = new List<DimensionesPrimariaDTO>();
    }

    public class DimensionesPrimariaViewDTO 
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public int? NotaTotal { get; set; }

        private static int? Nota { get; set; } = 0;
        private static int? contador { get; set; } = 0;
        public virtual List<ActividadPrimaria> Actividades { get; set; }

    }


}
