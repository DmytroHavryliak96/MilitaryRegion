using MilitaryRegion.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;

        public EFUnitOfWork()
        {
            db = new ApplicationDbContext();
        }

        private ArmyRepository armyRepository;
        private ArtilleryRepository artilleryRepository;
        private AutomaticRepository automaticRepository;
        private BuildingRepository buildingRepository;
        private CarbineRepository carbineRepository;
        private CorpRepository corpRepository;
        private DepartmentRepository departmentRepository;
        private DislocationRepository dislocationRepository;
        private DivisionRepository divisionRepository;
        private IFVRepository ifvRepository;
        private MachineryRepository machineryRepository;
        private MilitaryBaseRepository militaryBaseRepository;
        private MilitaryBaseBuildingRepository militaryBaseBuildingRepository; 
        private MilitaryBaseMachineryRepository militaryBaseMachineryRepository;
        private MilitaryBaseWeaponryRepository militaryBaseWeaponryRepository;
        private MissileArmamentRepository missileArmamentRepository;
        private MotorTransportRepository motorTransportRepository;
        private OfficerRepository officerRepository;
        private RankRepository ranksRepository;
        private SergeantRepository sergeantRepository;
        private ServicemanRepository servicemanRepository;
        private ServicemanSpecialtyRepository servicemanSpecialtyRepository;
        private SpecialtyRepository specialtyRepository;
        private SoldierRepository soldierRepository;
        private SquadRepository squadRepository;
        private TractorRepository tractorRepository;
        private TroopRepository troopRepository;
        private WeaponryRepository weaponryRepository;


        public IRepository<Army> Armies
        {
            get
            {
                if (armyRepository == null)
                    armyRepository = new ArmyRepository(db);
                return armyRepository;
            }
        }

        public IRepository<Artillery> Artilleries
        {
            get
            {
                if (artilleryRepository == null)
                    artilleryRepository = new ArtilleryRepository(db);
                return artilleryRepository;
            }
        }

        public IRepository<Automatic> Automatics
        {
            get
            {
                if (automaticRepository == null)
                    automaticRepository = new AutomaticRepository(db);
                return automaticRepository;
            }
        }

        public IRepository<Building> Buildings
        {
            get
            {
                if (buildingRepository == null)
                    buildingRepository = new BuildingRepository(db);
                return buildingRepository;
            }
        }

        public IRepository<Carbine> Carbines
        {
            get
            {
                if (carbineRepository == null)
                    carbineRepository = new CarbineRepository(db);
                return carbineRepository;
            }
        }

        public IRepository<Corp> Corps
        {
            get
            {
                if (corpRepository == null)
                    corpRepository = new CorpRepository(db);
                return corpRepository;
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(db);
                return departmentRepository;
            }
        }

        public IRepository<Dislocation> Dislocations
        {
            get
            {
                if (dislocationRepository == null)
                    dislocationRepository = new DislocationRepository(db);
                return dislocationRepository;
            }
        }

        public IRepository<Division> Divisions
        {
            get
            {
                if (divisionRepository == null)
                    divisionRepository = new DivisionRepository(db);
                return divisionRepository;
            }
        }

        public IRepository<IFV> IFVs
        {
            get
            {
                if (ifvRepository == null)
                    ifvRepository = new IFVRepository(db);
                return ifvRepository;
            }
        }

        public IRepository<Machinery> Machineries
        {
            get
            {
                if (machineryRepository == null)
                    machineryRepository = new MachineryRepository(db);
                return machineryRepository;
            }
        }

        public IRepository<MilitaryBaseBuilding> MilitaryBaseBuildings
        {
            get
            {
                if (militaryBaseBuildingRepository == null)
                    militaryBaseBuildingRepository = new MilitaryBaseBuildingRepository(db);
                return militaryBaseBuildingRepository;
            }
        }

        public IRepository<MilitaryBaseMachinery> MilitaryBaseMachineries
        {
            get
            {
                if (militaryBaseMachineryRepository == null)
                    militaryBaseMachineryRepository = new MilitaryBaseMachineryRepository(db);
                return militaryBaseMachineryRepository;
            }
        }

        public IRepository<MilitaryBase> MilitaryBases
        {
            get
            {
                if (militaryBaseRepository == null)
                    militaryBaseRepository = new MilitaryBaseRepository(db);
                return militaryBaseRepository;
            }
        }

        public IRepository<MilitaryBaseWeaponry> MilitaryBaseWeaponries
        {
            get
            {
                if (militaryBaseWeaponryRepository == null)
                    militaryBaseWeaponryRepository = new MilitaryBaseWeaponryRepository(db);
                return militaryBaseWeaponryRepository;
            }
        }

        public IRepository<MissileArmament> MissileArmament
        {
            get
            {
                if (missileArmamentRepository == null)
                    missileArmamentRepository = new MissileArmamentRepository(db);
                return missileArmamentRepository;
            }
        }

        public IRepository<MotorTransport> MotorTransports
        {
            get
            {
                if (motorTransportRepository == null)
                    motorTransportRepository = new MotorTransportRepository(db);
                return motorTransportRepository;
            }
        }

        public IRepository<Officer> Officers
        {
            get
            {
                if (officerRepository == null)
                    officerRepository = new OfficerRepository(db);
                return officerRepository;
            }
        }

        public IRepository<Rank> Ranks
        {
            get
            {
                if (ranksRepository == null)
                    ranksRepository = new RankRepository(db);
                return ranksRepository;
            }
        }

        public IRepository<Sergeant> Sergeants
        {
            get
            {
                if (sergeantRepository == null)
                    sergeantRepository = new SergeantRepository(db);
                return sergeantRepository;
            }

        }

        public IRepository<ServicemanSpecialty> ServicemanSpecialties
        {
            get
            {
                if (servicemanSpecialtyRepository == null)
                    servicemanSpecialtyRepository = new ServicemanSpecialtyRepository(db);
                return servicemanSpecialtyRepository;
            }
        }

        public IRepository<Specialty> Specialties
        {
            get
            {
                if (specialtyRepository == null)
                    specialtyRepository = new SpecialtyRepository(db);
                return specialtyRepository;
            }
        }

        public IRepository<Serviceman> Servicemen
        {
            get
            {
                if (servicemanRepository == null)
                    servicemanRepository = new ServicemanRepository(db);
                return servicemanRepository;
            }
        }

        public IRepository<Squad> Squads
        {
            get
            {
                if (squadRepository == null)
                    squadRepository = new SquadRepository(db);
                return squadRepository;
            }
        }

        public IRepository<Soldier> Soldiers
        {
            get
            {
                if (soldierRepository == null)
                    soldierRepository = new SoldierRepository(db);
                return soldierRepository;
            }
        }

        public IRepository<Tractor> Tractors
        {
            get
            {
                if (tractorRepository == null)
                    tractorRepository = new TractorRepository(db);
                return tractorRepository;
            }
        }

        public IRepository<Troop> Troops
        {
            get
            {
                if (troopRepository == null)
                    troopRepository = new TroopRepository(db);
                return troopRepository;
            }
        }

        public IRepository<Weaponry> Weaponry
        {
            get
            {
                if (weaponryRepository == null)
                    weaponryRepository = new WeaponryRepository(db);
                return weaponryRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
    }
}