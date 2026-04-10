namespace CRMHitssBack.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string NombreFinca { get; set; } = string.Empty;
        public string Hectareas { get; set; } = string.Empty;
    }
}
