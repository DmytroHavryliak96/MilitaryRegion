using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MilitaryRegion.DAO.Repositories;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Army> Armies { get; set; }
        public DbSet<Artillery> Artilleries { get; set; }
        public DbSet<Automatic> Automatics { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Carbine> Carbines { get; set; }
        public DbSet<Corp> Corps { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dislocation> Dislocations { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<IFV> IFVs { get; set; }
        public DbSet<Machinery> Machineries { get; set; }
        public DbSet<MilitaryBase> MilitaryBases { get; set; }
        public DbSet<MilitaryBaseBuilding> MilitaryBaseBuildings { get; set; }
        public DbSet<MilitaryBaseMachinery> MilitaryBaseMachineries { get; set; }
        public DbSet<MilitaryBaseWeaponry> MilitaryBaseWeaponries { get; set; }
        public DbSet<MissileArmament> MissileArmaments { get; set; }
        public DbSet<MotorTransport> MotorTransports { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Sergeant> Sergeants { get; set; }
        public DbSet<Serviceman> Servicemen { get; set; }
        public DbSet<ServicemanSpecialty> ServicemanSpecialties { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Tractor> Tractors { get; set; }
        public DbSet<Troop> Troops { get; set; }
        public DbSet<Weaponry> Weaponries { get; set; }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}