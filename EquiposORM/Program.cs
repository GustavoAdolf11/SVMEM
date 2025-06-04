using System;
using EquiposORM.Persistencia;
using EquiposORMServicios;
using EquiposORMPresentacion;


namespace EquiposORM
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();



            var servicioT = new ServicioTecnico(new RepositorioTecnico(context));
            var servicioE = new ServicioEquipo(new RepositorioEquipo(context));

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(servicioT, servicioE));
        }
    }
}