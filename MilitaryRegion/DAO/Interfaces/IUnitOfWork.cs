using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Army> Armies { get; }
        IRepository<Artillery> Artilleries { get; }
        IRepository<Automatic> Automatics { get; }
        IRepository<Building> Buildings { get; }
        IRepository<Carbine> Carbines { get; }
        IRepository<Corp> Corps { get; }
        IRepository<Department> Departments { get; }
        IRepository<Dislocation> Dislocations { get; }
        IRepository<Division> Divisions { get; }
        IRepository<IFV> IFVs { get; }
        IRepository<Machinery> Machineries { get; }
        IRepository<MilitaryBase> MilitaryBases { get; }
        IRepository<MilitaryBaseBuilding> MilitaryBaseBuildings { get; }
        IRepository<MilitaryBaseMachinery> MilitaryBaseMachineries { get; }
        IRepository<MilitaryBaseWeaponry> MilitaryBaseWeaponries { get; }
        IRepository<MissileArmament> MissileArmament { get; }
        IRepository<MotorTransport> MotorTransports { get; }
        IRepository<Officer> Officers { get; }
        IRepository<Rank> Ranks { get; }
        IRepository<Sergeant> Sergeants { get; }
        IRepository<Serviceman> Servicemen { get; }
        IRepository<ServicemanSpecialty> ServicemanSpecialties { get; }
        IRepository<Specialty> Specialties { get; }
        IRepository<Soldier> Soldiers { get; }
        IRepository<Squad> Squads { get; }
        IRepository<Tractor> Tractors { get; }
        IRepository<Troop> Troops { get; }
        IRepository<Weaponry> Weaponry { get; }
        void Save();
    }
}
