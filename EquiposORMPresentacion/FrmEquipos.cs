using System;
using System.Windows.Forms;
using EquiposORMServicios;
using System.Linq;


namespace EquiposORMPresentacion
{
    public class FrmEquipos : Form
    {

        private readonly ServicioBase< EquipoDTO> _servicioEquipo;
        private readonly ServicioBase< TecnicoDTO> _servicioTecnico;

        private ListBox lstEquipos;
        private TextBox txtNombre, txtTipo;
        private ComboBox cboTecnicos, cboEstado;
        private Button btnAgregar, btnEditar, btnEliminar;

        public FrmEquipos( ServicioBase< EquipoDTO> se,  ServicioBase< TecnicoDTO> st)
        {
            _servicioEquipo = se;
            _servicioTecnico = st;

            Text = "Equipos";
            Width = 450;
            Height = 400;

            lstEquipos = new ListBox { Top = 10, Left = 10, Width = 400, Height = 100 };
            txtNombre = new TextBox { Top = 120, Left = 10, Width = 400, PlaceholderText = "Nombre del equipo" };
            txtTipo = new TextBox { Top = 160, Left = 10, Width = 400, PlaceholderText = "Tipo (Medico, Mecanico...)" };
            cboEstado = new ComboBox { Top = 200, Left = 10, Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };
            cboEstado.Items.AddRange(new string[] { "Activo", "Inactivo", "Mantenimiento" });

            cboTecnicos = new ComboBox { Top = 240, Left = 10, Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };

            btnAgregar = new Button { Text = "Agregar", Top = 280, Left = 10 , Height=50};
            btnEditar = new Button { Text = "Editar", Top = 280, Left = 110 ,  Height = 50 };
            btnEliminar = new Button { Text = "Eliminar", Top = 280, Left = 210 , Height = 50 };

            btnAgregar.Click += (s, e) =>
            {
                var dto = new EquipoDTO
                {
                    Nombre = txtNombre.Text,
                    Tipo = txtTipo.Text,
                    Estado = cboEstado.SelectedItem?.ToString() ?? "Activo",
                    TecnicoId = ((TecnicoDTO)cboTecnicos.SelectedItem).Id ?? 0
                };
                _servicioEquipo.Agregar(dto);
                CargarEquipos();
            };

            btnEditar.Click += (s, e) =>
            {
                if (lstEquipos.SelectedItem is EquipoDTO eq)
                {
                    eq.Nombre = txtNombre.Text;
                    eq.Tipo = txtTipo.Text;
                    eq.Estado = cboEstado.SelectedItem?.ToString() ?? "Activo";
                    eq.TecnicoId = ((TecnicoDTO)cboTecnicos.SelectedItem).Id ?? 0;
                    _servicioEquipo.Editar(eq);
                    CargarEquipos();
                }
            };

            btnEliminar.Click += (s, e) =>
            {
                if (lstEquipos.SelectedItem is EquipoDTO eq)
                {
                    _servicioEquipo.Eliminar(eq.Id ?? 0);
                    CargarEquipos();
                }
            };

            lstEquipos.SelectedIndexChanged += (s, e) =>
            {
                if (lstEquipos.SelectedItem is EquipoDTO eq)
                {
                    txtNombre.Text = eq.Nombre;
                    txtTipo.Text = eq.Tipo;
                    cboEstado.SelectedItem = eq.Estado;
                    cboTecnicos.SelectedValue = eq.TecnicoId;
                }
            };

            Controls.Add(lstEquipos);
            Controls.Add(txtNombre);
            Controls.Add(txtTipo);
            Controls.Add(cboEstado);
            Controls.Add(cboTecnicos);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);

            CargarTecnicos();
            CargarEquipos();
        }

        private void CargarTecnicos()
        {
            var tecnicos = _servicioTecnico.ObtenerTodos();
            cboTecnicos.DataSource = tecnicos;
            cboTecnicos.DisplayMember = "Nombre";
            cboTecnicos.ValueMember = "Id";
        }

        private void CargarEquipos()
        {
            lstEquipos.DataSource = null;
            lstEquipos.DataSource = _servicioEquipo.ObtenerTodos();
            lstEquipos.DisplayMember = "Nombre";
        }
    }
}