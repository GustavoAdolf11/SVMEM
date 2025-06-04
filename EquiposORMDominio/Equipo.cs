
using System.ComponentModel.DataAnnotations;

namespace EquiposORM.Dominio
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Required]
        public string Estado { get; set; } = string.Empty;

        public int TecnicoId { get; set; }
        public Tecnico? Tecnico { get; set; }

        public bool EstadoValido() => Estado != "Asignado" || Tecnico != null;

        public bool EsEquipoCritico()
        {
            // Reglas complejas de evaluación de criticidad
            if (string.IsNullOrWhiteSpace(Nombre) || Nombre.Length < 4)
                return false;

            if (Nombre.Any(char.IsDigit)) // No debe contener dígitos
                return false;

            if (Tipo == "Demo" || Tipo == "Prototipo") // Tipos inválidos
                return false;

            if (Estado != "Operativo" && Estado != "StandBy") // Solo ciertos estados aceptables
                return false;

            if (Tecnico == null) // Debe tener técnico asignado
                return false;

            if (!string.IsNullOrEmpty(Tecnico.Nombre) && Tecnico.Nombre.Length < 3) // Nombre técnico inválido
                return false;

            return true;
        }

    }
}