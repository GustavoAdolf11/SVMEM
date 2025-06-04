using System;
using System.Windows.Forms;
using EquiposORMServicios;

namespace EquiposORMPresentacion
{
    public class FrmTecnicos : Form
    {
        
        private readonly ServicioBase< TecnicoDTO> _servicio;
        private ListBox lstTecnicos;
        private TextBox txtNombre;
        private Button btnAgregar, btnEditar, btnEliminar;

        public FrmTecnicos(ServicioBase<TecnicoDTO> servicio)
        {
            _servicio = servicio;
            Text = "Técnicos";
            Width = 400;
            Height = 300;

            lstTecnicos = new ListBox { Top = 10, Left = 10, Width = 360, Height = 100 };
            txtNombre = new TextBox { Top = 120, Left = 10, Width = 360 };
            btnAgregar = new Button { Text = "Agregar", Top = 160, Left = 10 , Height = 50 };
            btnEditar = new Button { Text = "Editar", Top = 160, Left = 110 , Height = 50 };
            btnEliminar = new Button { Text = "Eliminar", Top = 160, Left = 210 , Height = 50 };

            btnAgregar.Click += (s, e) =>
            {
                _servicio.Agregar(new TecnicoDTO { Nombre = txtNombre.Text });
                Cargar();
            };

            btnEditar.Click += (s, e) =>
            {
                if (lstTecnicos.SelectedItem is TecnicoDTO t)
                {
                    t.Nombre = txtNombre.Text;
                    _servicio.Editar(t);
                    Cargar();
                }
            };

            btnEliminar.Click += (s, e) =>
            {
                if (lstTecnicos.SelectedItem is TecnicoDTO t)
                {
                    _servicio.Eliminar(t.Id ?? 0);
                    Cargar();
                }
            };

            lstTecnicos.SelectedIndexChanged += (s, e) =>
            {
                if (lstTecnicos.SelectedItem is TecnicoDTO t)
                    txtNombre.Text = t.Nombre;
            };

            Controls.Add(lstTecnicos);
            Controls.Add(txtNombre);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);

            Cargar();
        }

        private void Cargar()
        {
            lstTecnicos.DataSource = null;
            lstTecnicos.DataSource = _servicio.ObtenerTodos();
            lstTecnicos.DisplayMember = "Nombre";
        }
    }
}