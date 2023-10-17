namespace SAADS.BAS.API.DTOs
{
    public class DireccionAreaDTO
    {
        public short Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public short? IdFacultad { get; set; }
        public string FacultadNombre { get; set; } = string.Empty;
        public DateTime? FechaRegistro { get; set; }
        public short? IdEstado { get; set; }
        public string EstadoNombre { get; set; } = string.Empty;
        public short? IdCargo { get; set; }
        public string CargoNombre { get; set; } = string.Empty;

    }
}
