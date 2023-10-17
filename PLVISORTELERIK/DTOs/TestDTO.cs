using System.ComponentModel.DataAnnotations;

namespace PLVISORTELERIK.DTOs
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();

        public string Conducta { get; set; } = string.Empty;
    }

    public class Actividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Abreviatura { get; set; } = string.Empty;

  
        public int Orden { get; set; }
    }

   
    public class Calificacion
    {
        public int EstudianteId { get; set; }
        public int ActividadId { get; set; }
        [Required]
        [StringLength(2)]
        public string Nota { get; set; } = string.Empty;
    }

    public class FormularioNotasModel
    {
        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public List<Actividad> Actividades { get; set; } = new List<Actividad>();
    }
}
