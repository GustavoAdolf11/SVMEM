using EquiposORM.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EquiposORM.Persistencia
{
    public class RepositorioEquipo
    {
        private readonly AppDbContext _context;

        public RepositorioEquipo(AppDbContext context)
        {
            _context = context;
        }

        public List<Equipo> ObtenerTodos()
        {
            return _context.Equipos.Include(e => e.Tecnico).ToList();
        }

        public Equipo? ObtenerPorId(int id)
        {
            return _context.Equipos.Include(e => e.Tecnico).FirstOrDefault(e => e.Id == id);
        }

        public void Agregar(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            _context.SaveChanges();
        }

        public void Eliminar(Equipo equipo)
        {
            _context.Equipos.Remove(equipo);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var equipo = _context.Equipos.FirstOrDefault(e => e.Id == id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
                _context.SaveChanges();
            }
        }

        public void Editar(Equipo equipo)
        {

            var existente = _context.Equipos.FirstOrDefault(e => e.Id == equipo.Id);
            if (existente != null)
            {
                existente.Nombre = equipo.Nombre;
                existente.Tipo = equipo.Tipo;
                existente.Estado = equipo.Estado;
                existente.TecnicoId = equipo.TecnicoId;
                _context.SaveChanges();
            }

            /*
            _context.Equipos.Update(equipo);
            _context.SaveChanges();*/
        }

    }
}
