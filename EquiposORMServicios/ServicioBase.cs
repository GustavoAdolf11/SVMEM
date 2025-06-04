using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquiposORMServicios
{
    public abstract class ServicioBase<DTO>
    {
        public abstract void Agregar(DTO dto);
        public abstract void Editar(DTO dto);
        public abstract void Eliminar(int id);
        public abstract List<DTO> ObtenerTodos();
    }
}
