
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
        [InlineData("Equipo9", "Servidor", "Operativo", "Carlos", false)] // contiene d�gito
        [InlineData("EquipoAlpha", "Demo", "Operativo", "Carlos", false)] // tipo inv�lido
        [InlineData("EquipoAlpha", "Prototipo", "Operativo", "Carlos", false)] // tipo inv�lido
        [InlineData("EquipoAlpha", "Estaci�n", "FueraDeServicio", "Carlos", false)] // estado inv�lido
        [InlineData("EquipoAlpha", "Estaci�n", "StandBy", "Carlos", true)] // estado alternativo v�lido
        [InlineData("EquipoAlpha", "Estaci�n", "Operativo", "", false)] // t�cnico sin nombre
        [InlineData("EquipoAlpha", "Estaci�n", "Operativo", "Al", false)] // nombre de t�cnico muy corto
        [InlineData("EquipoBeta", "Industrial", "Operativo", "Mar�a", true)] // todo correcto
        [InlineData("Equipo9", "Servidor", "Operativo", "Juan Carlos Sesarego", false)] // contiene d�gito
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
// intentando probar el bloqueo
// 2do intento de test block