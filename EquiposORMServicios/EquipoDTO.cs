namespace EquiposORMServicios
{
    public class EquipoDTO
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public int TecnicoId { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}