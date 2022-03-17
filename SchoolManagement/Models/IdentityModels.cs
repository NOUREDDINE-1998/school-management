using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolManagement.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Etudiant> Etudiants { get; set; }
         public DbSet<Filliere> Fillieres { get; set; }
        public DbSet<Classe> classes { get; set; }
        public DbSet<Examen> examens { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<paiement> Paiements { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<Etudiant>()
        //        .HasMany(c => c.Fillieres).WithMany(i => i.Etudiants)
        //        .Map(t => t.MapLeftKey("Id")
        //            .MapRightKey("Id")
        //            .ToTable("FilliereEtudiants"));
        //}
    }
}