using System;
using System.Windows.Forms;
using EquiposORMServicios;

namespace EquiposORMPresentacion
{
    public class MainForm : Form
    {

        private readonly ServicioBase< TecnicoDTO> _servicioTecnico;
        private readonly ServicioBase< EquipoDTO> _servicioEquipo;

        public MainForm(ServicioBase< TecnicoDTO> servicioTecnico,ServicioBase< EquipoDTO> servicioEquipo)
        {
            _servicioTecnico = servicioTecnico;
            _servicioEquipo = servicioEquipo;

            Text = "Gestión de Técnicos y Equipos";
            Width = 450;
            Height = 250;

            var btnTecnicos = new Button { Text = "Administrar Técnicos", Left = 100, Top = 30, Width = 180 , Height=60};
            var btnEquipos = new Button { Text = "Administrar Equipos", Left = 100, Top = 100, Width = 180 , Height= 60};

            btnTecnicos.Click += (s, e) =>
            {
                var frm = new FrmTecnicos(_servicioTecnico);
                frm.ShowDialog();
            };

            btnEquipos.Click += (s, e) =>
            {
                var frm = new FrmEquipos(_servicioEquipo, _servicioTecnico);
                frm.ShowDialog();
            };

            Controls.Add(btnTecnicos);
            Controls.Add(btnEquipos);
        }
    }
}