using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;

namespace EquiposORM.Dominio
{
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

        public bool PuedeAsignarOtroEquipo() => Equipos.Count < 5;
        public bool TieneEquipoCritico() => Equipos.Any(e => e.Estado == "Crítico");
        public bool TodosOperativos() => Equipos.All(e => e.Estado == "Operativo");
        public bool TieneEquiposDuplicados() => Equipos.GroupBy(e => e.Nombre).Any(g => g.Count() > 1);
    }
}


