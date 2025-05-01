using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sistema_De_Citas_Medicas.Models;

namespace Sistema_De_Citas_Medicas.Data
{
    public static class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<Sistema_De_Citas_MedicasContextSQLServer>();

            // Verificar si ya existe algún usuario
            if (!context.Usuario.Any())
            {
                // Crear un nuevo usuario administrador
                context.Usuario.Add(new Usuario
                {
                    Correo = "josueadmin@ejemplo.com",
                    Contrasena = "josuemullo10", 
                    Rol = RolUsuario.Administrador
                });

                // Guardar cambios en la base de datos
                context.SaveChanges();
            }
        }
    }
}
