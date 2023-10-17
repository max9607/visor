namespace PLVISORTELERIK.DTOs
{
    public class IdiomaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        //getIdiomasDefault

        public static List<IdiomaDTO> getDefaults()
        {
            return new List<IdiomaDTO>
            {
                new IdiomaDTO { Id = 2, Nombre = "Español" },
                new IdiomaDTO { Id = 3, Nombre = "Inglés" }
            };
        }
    }

}
