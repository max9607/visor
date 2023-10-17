namespace SAADS.BAS.API.DTOs
{
    public class GrupoAcademicoDTO
    {
        public short Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public short? IdEstado { get; set; }
        public int? Cod { get; set; }
    }
}
