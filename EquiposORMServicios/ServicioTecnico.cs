using EquiposORM.Dominio;
using EquiposORM.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace EquiposORMServicios
{
    public class ServicioTecnico : ServicioBase< TecnicoDTO>
    {
        private readonly RepositorioTecnico _repo;

        public ServicioTecnico(RepositorioTecnico repo)
        {
            _repo = repo;
        }

        public override void Agregar(TecnicoDTO dto)
        {
            var tecnico = new Tecnico { Nombre = dto.Nombre };
            _repo.Agregar(tecnico);
        }

        public override void Editar(TecnicoDTO dto)
        {
            var tecnico = new Tecnico { Id = dto.Id ?? 0, Nombre = dto.Nombre };
            _repo.Editar(tecnico);
        }

        public override void Eliminar(int id)
        {
            _repo.Eliminar(id);
        }

        public override List<TecnicoDTO> ObtenerTodos()
        {
            return _repo.ObtenerTodos()
                        .Select(t => new TecnicoDTO { Id = t.Id, Nombre = t.Nombre })
                        .ToList();
        }
    }
}
