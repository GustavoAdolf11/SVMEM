
using Xunit;
using EquiposORM.Dominio;

namespace EquiposORMTests
{
    public class EquipoTests
    {
        [Fact]
        public void EstadoValido_DeberiaRetornarFalso_CuandoAsignadoSinTecnico()
        {
            var equipo = new Equipo { Estado = "Asignado", Tecnico = null };
            Assert.False(equipo.EstadoValido());
        }

        [Fact]
        public void EstadoValido_DeberiaRetornarVerdadero_CuandoAsignadoConTecnico()
        {
            var equipo = new Equipo { Estado = "Asignado", Tecnico = new Tecnico() };
            Assert.True(equipo.EstadoValido());
        }

        [Fact]
        public void EstadoValido_DeberiaRetornarVerdadero_CuandoEstadoDisponible()
        {
            var equipo = new Equipo { Estado = "Disponible", Tecnico = null };
            Assert.True(equipo.EstadoValido());
        }

        [Theory]
        [InlineData("EquipoAlpha", "Servidor", "Operativo", "Carlos", true)]
        [InlineData("EQ1", "Servidor", "Operativo", "Carlos", false)] // nombre corto
        [InlineData("Equipo9", "Servidor", "Operativo", "Carlos", false)] // contiene dígito
        [InlineData("EquipoAlpha", "Demo", "Operativo", "Carlos", false)] // tipo inválido
        [InlineData("EquipoAlpha", "Prototipo", "Operativo", "Carlos", false)] // tipo inválido
        [InlineData("EquipoAlpha", "Estación", "FueraDeServicio", "Carlos", false)] // estado inválido
        [InlineData("EquipoAlpha", "Estación", "StandBy", "Carlos", true)] // estado alternativo válido
        [InlineData("EquipoAlpha", "Estación", "Operativo", "", false)] // técnico sin nombre
        [InlineData("EquipoAlpha", "Estación", "Operativo", "Al", false)] // nombre de técnico muy corto
        [InlineData("EquipoBeta", "Industrial", "Operativo", "María", true)] // todo correcto
        public void EsEquipoCritico_PruebasCompletas(string nombre, string tipo, string estado, string nombreTecnico, bool esperado)
        {
            var equipo = new Equipo
            {
                Nombre = nombre,
                Tipo = tipo,
                Estado = estado,
                Tecnico = new Tecnico { Nombre = nombreTecnico }
            };

            var resultado = equipo.EsEquipoCritico();

            Assert.Equal(esperado, resultado);
        }


    }
}
