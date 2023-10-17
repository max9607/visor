using System.ComponentModel.DataAnnotations;

namespace PLVISORTELERIK.DTOs
{
    public class MateriaContenidoCreacionDTO
    {

        [Required(ErrorMessage = "El campo sigla es requerido")]
        public string Sigla { get; set; } = null!;
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo dirección es requerido")]
        public short? IdDireccionArea { get; set; }
        [Required(ErrorMessage = "El campo costo es requerido")]
        public decimal? Costo { get; set; }
        [Required(ErrorMessage = "El campo crédito es requerido")]
        public short? Creditos { get; set; }
        [Required(ErrorMessage = "El campo Hrs. Teóricas es requerido")]
        public short? HorasTeoricasSemanal { get; set; }
        [Required(ErrorMessage = "El campo Hrs. Prácticas es requerido")]
        public short? HorasPracticasSemanal { get; set; }


        [Required(ErrorMessage = "El campo modelo es requerido")]
        public int? IdModeloEstudio { get; set; }
        public string? Competencia { get; set; }
        [Required(ErrorMessage = "El campo tipo es requerido")]
        public int? IdTipoMateriaContenido { get; set; }
        [Required(ErrorMessage = "El campo grupo es requerido")]
        public short? GrupoAcademicoId { get; set; }

    }
    public class MateriaContenidoIdiomaCreacionDTO
    {
        public short IdiomaId { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo competencia es requerido")]
        public string Competencia { get; set; } = string.Empty;
    }
}
