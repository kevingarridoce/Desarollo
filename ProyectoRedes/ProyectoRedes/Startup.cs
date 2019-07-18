using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ProyectoRedes.Models;

[assembly: OwinStartupAttribute(typeof(ProyectoRedes.Startup))]
namespace ProyectoRedes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolUsuario();
        }
        private void CrearRolUsuario()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@redes.com";
                user.Email = "admin@redes.com";
                string userPWD = "Administrador123-";
                userManager.Create(user, userPWD);

                userManager.AddToRole(user.Id, "Admin");
            }
            if (!roleManager.RoleExists("Profesor"))
            {
                var role = new IdentityRole();
                role.Name = "Profesor";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "profesor@redes.com";
                user.Email = "profesor@redes.com";
                string userPWD = "Profesor123-";
                userManager.Create(user, userPWD);

                userManager.AddToRole(user.Id, "Profesor");
            }
        }
    }
}
