using EquiposORM.Dominio;
using EquiposORM.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace EquiposORMServicios
{
    public class ServicioEquipo : ServicioBase< EquipoDTO>
    {
        private readonly RepositorioEquipo _repo;

        public ServicioEquipo(RepositorioEquipo repo)
        {
            _repo = repo;
        }

        public override void Agregar(EquipoDTO dto)
        {
            var equipo = new Equipo
            {
                Nombre = dto.Nombre,
                Tipo = dto.Tipo,
                Estado = dto.Estado,
                TecnicoId = dto.TecnicoId
            };
            _repo.Agregar(equipo);
        }

        public override void Editar(EquipoDTO dto)
        {
            var equipo = new Equipo
            {
                Id = dto.Id ?? 0,
                Nombre = dto.Nombre,
                Tipo = dto.Tipo,
                Estado = dto.Estado,
                TecnicoId = dto.TecnicoId
            };
            _repo.Editar(equipo);
        }

        public override void Eliminar(int id)
        {
            _repo.Eliminar(id);
        }

        public override List<EquipoDTO> ObtenerTodos()
        {
            return _repo.ObtenerTodos()
                        .Select(e => new EquipoDTO
                        {
                            Id = e.Id,
                            Nombre = e.Nombre,
                            Tipo = e.Tipo,
                            Estado = e.Estado,
                            TecnicoId = e.TecnicoId
                        })
                        .ToList();
        }
    }
}
