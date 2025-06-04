using EquiposORM.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EquiposORM.Persistencia
{
    public class RepositorioTecnico
    {
        private readonly AppDbContext _context;

        public RepositorioTecnico(AppDbContext context)
        {
            _context = context;
        }

        public List<Tecnico> ObtenerTodos()
        {
            return _context.Tecnicos.Include(t => t.Equipos).ToList();
        }

        public Tecnico? ObtenerPorId(int id)
        {
            return _context.Tecnicos.Include(t => t.Equipos).FirstOrDefault(t => t.Id == id);
        }

        public void Agregar(Tecnico tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            _context.SaveChanges();
        }

        public void Eliminar(Tecnico tecnico)
        {
            _context.Tecnicos.Remove(tecnico);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var tecnico = _context.Tecnicos.FirstOrDefault(t => t.Id == id);
            if (tecnico != null)
            {
                _context.Tecnicos.Remove(tecnico);
                _context.SaveChanges();
            }
        }

        public void Editar(Tecnico tecnico)
        {
            var original = _context.Tecnicos.FirstOrDefault(t => t.Id == tecnico.Id);
            if (original != null)
            {
                original.Nombre = tecnico.Nombre;
                // Agrega aquí otros campos si los tuviera
                _context.SaveChanges();
            }


            //_context.Tecnicos.Update(tecnico);
            //_context.SaveChanges();
        }

    }
}
