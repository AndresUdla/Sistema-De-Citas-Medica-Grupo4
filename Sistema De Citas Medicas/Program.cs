using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sistema_De_Citas_Medicas.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<Sistema_De_Citas_MedicasContextSQLServer>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sistema_De_Citas_MedicasContextSQLServer")
        ?? throw new InvalidOperationException("Connection string 'Sistema_De_Citas_MedicasContextSQLServer' not found.")));

// Añadir los servicios de MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Crear un alcance para el servicio de la base de datos y ejecutar el seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    Seeder.Initialize(services); //
}

// Configuración del pipeline de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Definir la ruta del controlador y acción predeterminados
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
