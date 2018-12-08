using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MilitaryRegion.DAO.Repositories;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;
using System;

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
            Database.SetInitializer<ApplicationDbContext>(new StoreDbInitializer());
            return new ApplicationDbContext();
        }

    }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        {
           
            protected override void Seed(ApplicationDbContext db)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    var user = new ApplicationUser();
                    user.UserName = "admin";
                    user.Email = "admin@gmail.com";
                    user.PhoneNumber = "+380695630697";

                    string userPWD = "Admin123@com";

                    var checkUser = UserManager.Create(user, userPWD);

                    if (checkUser.Succeeded)
                    {
                        var result = UserManager.AddToRole(user.Id, "Admin");
                    }

                    // армії
                    ArmyRepository dbArmies = new ArmyRepository(db);
                    Army[] armies = new Army[] {
                        new Army { Number = 1 },
                        new Army { Number = 2 },
                        new Army { Number = 3 }
                    };

                    for (int i = 0; i < armies.Length; i++)
                    {
                        dbArmies.Create(armies[i]);
                        db.SaveChanges();
                    }

                    // корпуси
                    CorpRepository dbCorps = new CorpRepository(db);
                    Corp[] corps = new Corp[] {
                        new Corp { Number = 1, ArmyId = 1 },
                        new Corp { Number = 2, ArmyId = 1 },
                        new Corp { Number = 3, ArmyId = 2 }
                    };

                    for (int i = 0; i < corps.Length; i++)
                    {
                        dbCorps.Create(corps[i]);
                        db.SaveChanges();
                    }

                    // дивізії
                    DivisionRepository dbDivisions = new DivisionRepository(db);
                    Division[] divisions = new Division[] {
                        new Division { Number = 1, CorpId =  1, Name = "Мотострілкова"},
                        new Division { Number = 2, CorpId = 2, Name = "Десант" },
                        new Division { Number = 3, CorpId = 3 , Name = "Пограничники"}
                    };

                    for (int i = 0; i < divisions.Length; i++)
                    {
                        dbDivisions.Create(divisions[i]);
                        db.SaveChanges();
                    }

                    // дислокації
                    DislocationRepository dbDislocations = new DislocationRepository(db);
                    Dislocation[] dislocations = new Dislocation[]
                    {
                        new Dislocation { City = "Київ"},
                        new Dislocation {City = "Львів"},
                        new Dislocation {City = "Одеса" },
                        new Dislocation {City = "Дніпро" }
                    };

                    for (int i = 0; i < dislocations.Length; i++)
                    {
                        dbDislocations.Create(dislocations[i]);
                        db.SaveChanges();
                    }

                    // звання
                    RankRepository dbRanks = new RankRepository(db);
                    Rank[] ranks = new Rank[]
                    {
                        new Rank {Name = "Генерал"},
                        new Rank {Name = "Полковник"},
                        new Rank {Name = "Підполковник"},
                        new Rank {Name = "Майор"},
                        new Rank {Name = "Лейтенант"},
                        new Rank {Name = "Старшина"},
                        new Rank {Name = "Сержант"},
                        new Rank {Name = "Прапорщик"},
                        new Rank {Name = "Єфрейтор"},
                        new Rank {Name = "Солдат"}
                    };

                    for (int i = 0; i < ranks.Length; i++)
                    {
                        dbRanks.Create(ranks[i]);
                        db.SaveChanges();
                    }

                    // транспорт
                    MachineryRepository dbMachineries = new MachineryRepository(db);
                    Machinery[] machineries = new Machinery[]
                    {
                        new Machinery { Name = "МАЗ", Model = "537", CrewAmount = 5, Weight = 21.6},
                        new Machinery { Name = "КрАЗ", Model = "6446", CrewAmount = 3, Weight = 20},
                        new Machinery {Name = "Bradley", Model = "M2", CrewAmount = 3, Weight = 21.3},
                        new Machinery {Name = "Stryker", Model = "M1126 ICV", CrewAmount = 2, Weight = 16.47},
                        new Machinery {Name = "Volkswagen", Model = "Amarok", CrewAmount = 4, Weight = 2.0 },
                        new Machinery {Name = "УАЗ", Model = "469", CrewAmount = 7, Weight = 1.65 }
                    };

                    for (int i = 0; i < machineries.Length; i++)
                    {
                        dbMachineries.Create(machineries[i]);
                        db.SaveChanges();
                    }

                    // тягачі
                    TractorRepository dbTractors = new TractorRepository(db);
                    Tractor[] tractors = new Tractor[]
                    {
                        new Tractor { LoadCapacity = 65.0, MachineryId = 1},
                        new Tractor { LoadCapacity = 34.0, MachineryId = 2}
                    };

                    for (int i = 0; i < tractors.Length; i++)
                    {
                        dbTractors.Create(tractors[i]);
                        db.SaveChanges();
                    }

                    // БМП
                    IFVRepository dbIFVs = new IFVRepository(db);
                    IFV[] ifvs = new IFV[]
                    {
                        new IFV { Landing = 6, MainCaliber = 25.0, MachineryId = 3},
                        new IFV { Landing = 9, MainCaliber = 12.7, MachineryId = 4}
                    };

                    for (int i = 0; i < ifvs.Length; i++)
                    {
                        dbIFVs.Create(ifvs[i]);
                        db.SaveChanges();
                    }

                    // автотранспорт
                    MotorTransportRepository dbMotors = new MotorTransportRepository(db);
                    MotorTransport[] motors = new MotorTransport[]
                    {
                        new MotorTransport {MaxSpeed =  190, Range = 1000, MachineryId = 5},
                        new MotorTransport {MaxSpeed =  100, Range = 730, MachineryId = 6}
                    };

                    for (int i = 0; i < motors.Length; i++)
                    {
                        dbMotors.Create(motors[i]);
                        db.SaveChanges();
                    }

                    // озброєння
                    WeaponryRepository dbWeaponries = new WeaponryRepository(db);
                    Weaponry[] weapons = new Weaponry[]
                    {
                        new Weaponry {Name = "Сайга", Model = "410", Ammunition = 10, Caliber = 10.25 },
                        new Weaponry {Name = "Сайга", Model = "MK", Ammunition = 10, Caliber = 5.45 },
                        new Weaponry {Name = "АКС", Model = "74", Ammunition = 30, Caliber = 5.45 },
                        new Weaponry {Name = "М", Model = "16", Ammunition = 30, Caliber = 5.56},
                        new Weaponry {Name = "Гіацинт-С", Model = "2C5", Ammunition = 60, Caliber = 152},
                        new Weaponry { Name = "МСТА-С", Model = "2С19", Ammunition = 60, Caliber = 152},
                        new Weaponry { Name = "Вільха", Model = "1", Ammunition = 24, Caliber = 300 },
                        new Weaponry { Name = "Смерч", Model = "БМ-30", Ammunition = 22, Caliber = 300 }

                    };

                    for (int i = 0; i < weapons.Length; i++)
                    {
                        dbWeaponries.Create(weapons[i]);
                        db.SaveChanges();
                    }

                    // карабіни
                    CarbineRepository dbCarbines = new CarbineRepository(db);
                    Carbine[] carbines = new Carbine[]
                    {
                        new Carbine {Length = 1170, WeaponryId = 1},
                        new Carbine {Length = 1110, WeaponryId = 2}
                    };

                    for (int i = 0; i < carbines.Length; i++)
                    {
                        dbCarbines.Create(carbines[i]);
                        db.SaveChanges();
                    }

                    // автоматична зброя
                    AutomaticRepository dbAutomatics = new AutomaticRepository(db);
                    Automatic[] automatics = new Automatic[]
                    {
                        new Automatic {FiringSpeed = 600, WeaponryId = 3 },
                        new Automatic {FiringSpeed = 800, WeaponryId = 4 }
                    };

                    for (int i = 0; i < automatics.Length; i++)
                    {
                        dbAutomatics.Create(automatics[i]);
                        db.SaveChanges();
                    }

                    // артилерія
                    ArtilleryRepository dbArtillery = new ArtilleryRepository(db);
                    Artillery[] artillery = new Artillery[]
                    {
                        new Artillery {ShootingRange = 40, WeaponryId = 5 },
                        new Artillery {ShootingRange = 30, WeaponryId = 6 }
                    };

                    for (int i = 0; i < artillery.Length; i++)
                    {
                        dbArtillery.Create(artillery[i]);
                        db.SaveChanges();
                    }

                    // ракетне озброєння
                    MissileArmamentRepository dbArmament = new MissileArmamentRepository(db);
                    MissileArmament[] armaments = new MissileArmament[]
                    {
                        new MissileArmament {ShellSpeed = 183, WeaponryId = 7 },
                        new MissileArmament {ShellSpeed = 200, WeaponryId = 8 }
                    };

                    for (int i = 0; i < armaments.Length; i++)
                    {
                        dbArmament.Create(armaments[i]);
                        db.SaveChanges();
                    }

                    // воєнні частини
                    MilitaryBaseRepository dbMilitaryBases = new MilitaryBaseRepository(db);
                    MilitaryBase[] mBases = new MilitaryBase[]
                    {
                        new MilitaryBase { Name = "Мотострілкова-2T", Number = 1, DislocationId =  1, DivisionId = 1},
                        new MilitaryBase { Name = "Десантна частина", Number = 2, DislocationId =  2, DivisionId = 2},
                        new MilitaryBase { Name = "Захід-кордон", Number = 3, DislocationId =  2, DivisionId = 3}
                    };

                    for (int i = 0; i < mBases.Length; i++)
                    {
                        dbMilitaryBases.Create(mBases[i]);
                        db.SaveChanges();
                    }

                    // транспорт воєнних частин
                    MilitaryBaseMachineryRepository dbMilitaryBaseMachineries = new MilitaryBaseMachineryRepository(db);
                    MilitaryBaseMachinery[] mMachineries = new MilitaryBaseMachinery[]
                    {
                        new MilitaryBaseMachinery { MilitaryBaseId = 1, MachineryId = 1, Amount = 20},
                        new MilitaryBaseMachinery { MilitaryBaseId = 1, MachineryId = 2, Amount = 19},
                        new MilitaryBaseMachinery { MilitaryBaseId = 2, MachineryId = 3, Amount = 40},
                        new MilitaryBaseMachinery { MilitaryBaseId = 2, MachineryId = 4, Amount = 35},
                        new MilitaryBaseMachinery { MilitaryBaseId = 3, MachineryId = 5, Amount = 5},
                        new MilitaryBaseMachinery { MilitaryBaseId = 3, MachineryId = 6, Amount = 8}
                    };

                    for (int i = 0; i < mMachineries.Length; i++)
                    {
                        dbMilitaryBaseMachineries.Create(mMachineries[i]);
                        db.SaveChanges();
                    }

                    // озброєння воєнних частин
                    MilitaryBaseWeaponryRepository dbMilitaryBaseWeaponries = new MilitaryBaseWeaponryRepository(db);
                    MilitaryBaseWeaponry[] mWeaponries = new MilitaryBaseWeaponry[]
                    {
                        new MilitaryBaseWeaponry { MilitaryBaseId = 1, WeaponryId = 1, Amount = 150},
                        new MilitaryBaseWeaponry { MilitaryBaseId = 1, WeaponryId = 2, Amount = 200},
                        new MilitaryBaseWeaponry { MilitaryBaseId = 1, WeaponryId = 3, Amount = 259},
                        new MilitaryBaseWeaponry { MilitaryBaseId = 2, WeaponryId = 4, Amount = 167},
                        new MilitaryBaseWeaponry { MilitaryBaseId = 2, WeaponryId = 5, Amount = 180},
                        new MilitaryBaseWeaponry { MilitaryBaseId = 2, WeaponryId = 6, Amount = 196},
                        new MilitaryBaseWeaponry { MilitaryBaseId = 3, WeaponryId = 7, Amount = 207},
                        new MilitaryBaseWeaponry { MilitaryBaseId = 3, WeaponryId = 8, Amount = 140},
                    };

                    for (int i = 0; i < mMachineries.Length; i++)
                    {
                        dbMilitaryBaseMachineries.Create(mMachineries[i]);
                        db.SaveChanges();
                    }

                    // роти
                    SquadRepository dbSquads = new SquadRepository(db);
                    Squad[] squads = new Squad[]
                    {
                        new Squad { Number = 1, MilitaryBaseId = 1 },
                        new Squad { Number = 2, MilitaryBaseId = 1 },
                        new Squad { Number = 3, MilitaryBaseId = 2 },
                        new Squad { Number = 4, MilitaryBaseId = 2 },
                        new Squad { Number = 5, MilitaryBaseId = 3 },
                        new Squad { Number = 6, MilitaryBaseId = 3 },
                    };

                    for (int i = 0; i < squads.Length; i++)
                    {
                        dbSquads.Create(squads[i]);
                        db.SaveChanges();
                    }

                    // взводи
                    TroopRepository dbTroops = new TroopRepository(db);
                    Troop[] troops = new Troop[]
                    {
                        new Troop { Number = 1, SquadId = 1},
                        new Troop { Number = 2, SquadId = 2},
                        new Troop { Number = 3, SquadId = 3},
                        new Troop { Number = 4, SquadId = 4},
                        new Troop { Number = 5, SquadId = 5},
                        new Troop { Number = 6, SquadId = 6}
                    };

                    for (int i = 0; i < troops.Length; i++)
                    {
                        dbTroops.Create(troops[i]);
                        db.SaveChanges();
                    }

                    // відділи
                    DepartmentRepository dbDepartments = new DepartmentRepository(db);
                    Department[] departments = new Department[]
                    {
                        new Department {Number = 1, TroopId = 1 },
                        new Department {Number = 2, TroopId = 2 },
                        new Department {Number = 3, TroopId = 3 },
                        new Department {Number = 4, TroopId = 4 },
                        new Department {Number = 5, TroopId = 5 },
                        new Department {Number = 6, TroopId = 6 }
                    };

                    for (int i = 0; i < departments.Length; i++)
                    {
                        dbDepartments.Create(departments[i]);
                        db.SaveChanges();
                    }
                
                // будівлі
                BuildingRepository dbBuildings = new BuildingRepository(db);
                Building[] buildings = new Building[]
                {
                    new Building {Square = 200, Height = 20, Purpose = "Житлова будівля", FloorAmount =  6},
                    new Building {Square = 300, Height = 18, Purpose = "Житлова будівля", FloorAmount =  5},
                    new Building {Square = 150, Height = 15, Purpose = "Житлова будівля", FloorAmount =  4},
                    new Building {Square = 200, Height = 10, Purpose = "Ангар", FloorAmount =  1},
                    new Building {Square = 150, Height = 6, Purpose = "Гараж", FloorAmount =  1},
                    new Building {Square = 150, Height = 12, Purpose = "Адміністративна будівля", FloorAmount =  3}
                };

                for (int i = 0; i < buildings.Length; i++)
                {
                    dbBuildings.Create(buildings[i]);
                    db.SaveChanges();
                }

                // будівлі військових частин
                MilitaryBaseBuildingRepository dbMBuildings = new MilitaryBaseBuildingRepository(db);
                MilitaryBaseBuilding[] mBuildings = new MilitaryBaseBuilding[]
                {
                    new MilitaryBaseBuilding { MilitaryBaseId = 1, BuildingId = 1, SquadId = 1, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 1, BuildingId = 1, SquadId = 2, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 2, BuildingId = 2, SquadId = 3, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 2, BuildingId = 2, SquadId = 4, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 3, BuildingId = 3, SquadId = 5, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 3, BuildingId = 3, SquadId = 6, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 1, BuildingId = 4, SquadId = 0, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 2, BuildingId = 5, SquadId = 0, TroopId = 0, DepartmentId = 0 },
                    new MilitaryBaseBuilding { MilitaryBaseId = 3, BuildingId = 6, SquadId = 0, TroopId = 0, DepartmentId = 0 }
                };

                for (int i = 0; i < mBuildings.Length; i++)
                {
                    dbMBuildings.Create(mBuildings[i]);
                    db.SaveChanges();
                }

                // спеціальності
                SpecialtyRepository dbSpecialties = new SpecialtyRepository(db);
                Specialty[] specialties = new Specialty[]
                {
                    new Specialty { Name = "Кухар" },
                    new Specialty { Name = "Водій" },
                    new Specialty { Name = "Механік" },
                    new Specialty { Name = "Сапер" },
                    new Specialty { Name = "Оператор котельні" }
                };

                for (int i = 0; i < specialties.Length; i++)
                {
                    dbSpecialties.Create(specialties[i]);
                    db.SaveChanges();
                }

                // військовослужбовці
                ServicemanRepository dbServiceman = new ServicemanRepository(db);
                Serviceman[] serviceman = new Serviceman[]
                {
                    // військовослужбовці генерали - командири армій
                    new Serviceman { FirstName = "Іван", SecondName = "Іванов", DateOfBirth = Convert.ToDateTime("26.11.1957"), RankId = 1,
                        ArmyId = 1, CorpId = 0, DivisionId = 0, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Петро", SecondName = "Іванов", DateOfBirth = Convert.ToDateTime("26.11.1965"), RankId = 1,
                        ArmyId = 2, CorpId = 0, DivisionId = 0, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Василь", SecondName = "Іванов", DateOfBirth = Convert.ToDateTime("26.11.1963"), RankId = 1,
                        ArmyId = 3, CorpId = 0, DivisionId = 0, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },

                    // полковники - командири корпусів
                    new Serviceman { FirstName = "Степан", SecondName = "Петров", DateOfBirth = Convert.ToDateTime("26.11.1978"), RankId = 2,
                        ArmyId = 1, CorpId = 1, DivisionId = 0, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Іван", SecondName = "Петров", DateOfBirth = Convert.ToDateTime("26.11.1979"), RankId = 2,
                        ArmyId = 2, CorpId = 2, DivisionId = 0, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Василь", SecondName = "Петров", DateOfBirth = Convert.ToDateTime("26.11.1977"), RankId = 2,
                        ArmyId = 3, CorpId = 3, DivisionId = 0, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },

                    // підполковники - командири дивізій
                    new Serviceman { FirstName = "Василь", SecondName = "Піддубний", DateOfBirth = Convert.ToDateTime("26.11.1980"), RankId = 3,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Максим", SecondName = "Піддубний", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 3,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Володимир", SecondName = "Піддубний", DateOfBirth = Convert.ToDateTime("26.11.1982"), RankId = 3,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 0, SquadId = 0, TroopId = 0, DepartmentId = 0  },

                    // майори - командири військових частин
                    new Serviceman { FirstName = "Василь", SecondName = "Микитин", DateOfBirth = Convert.ToDateTime("26.11.1983"), RankId = 4,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Олег", SecondName = "Микитин", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 4,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 0, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Віктор", SecondName = "Микитин", DateOfBirth = Convert.ToDateTime("26.11.1985"), RankId = 4,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 0, TroopId = 0, DepartmentId = 0  },

                    // лейтенанти - командири рот
                    new Serviceman { FirstName = "Ігор", SecondName = "Вовк", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 5,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 1, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Костянтин", SecondName = "Вовк", DateOfBirth = Convert.ToDateTime("26.11.1985"), RankId = 5,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 2, TroopId = 0, DepartmentId = 0  },

                    new Serviceman { FirstName = "Валерій", SecondName = "Вовк", DateOfBirth = Convert.ToDateTime("26.11.1983"), RankId = 5,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 3, TroopId = 0, DepartmentId = 0  },
                    new Serviceman { FirstName = "Василь", SecondName = "Вовк", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 5,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 4, TroopId = 0, DepartmentId = 0  },

                    new Serviceman { FirstName = "Микита", SecondName = "Вовк", DateOfBirth = Convert.ToDateTime("26.11.1976"), RankId = 5,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 5, TroopId = 0, DepartmentId = 0  },
                     new Serviceman { FirstName = "Роман", SecondName = "Вовк", DateOfBirth = Convert.ToDateTime("26.11.1980"), RankId = 5,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 6, TroopId = 0, DepartmentId = 0  },

                     // сержанти - командири взводів
                    new Serviceman { FirstName = "Ігор", SecondName = "Антонов", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 7,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 1, TroopId = 1, DepartmentId = 0  },
                    new Serviceman { FirstName = "Костянтин", SecondName = "Антонов", DateOfBirth = Convert.ToDateTime("26.11.1985"), RankId = 7,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 2, TroopId = 2, DepartmentId = 0  },

                    new Serviceman { FirstName = "Валерій", SecondName = "Антонов", DateOfBirth = Convert.ToDateTime("26.11.1983"), RankId = 7,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 3, TroopId = 3, DepartmentId = 0  },
                    new Serviceman { FirstName = "Василь", SecondName = "Аентонов", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 7,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 4, TroopId = 4, DepartmentId = 0  },

                    new Serviceman { FirstName = "Микита", SecondName = "Антонов", DateOfBirth = Convert.ToDateTime("26.11.1976"), RankId = 7,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 5, TroopId = 5, DepartmentId = 0  },
                     new Serviceman { FirstName = "Роман", SecondName = "Антонов", DateOfBirth = Convert.ToDateTime("26.11.1980"), RankId = 7,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 6, TroopId = 6, DepartmentId = 0  },

                      // єфрейтори - командири відділів
                    new Serviceman { FirstName = "Ігор", SecondName = "Гаврилів", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 9,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 1, TroopId = 1, DepartmentId = 1  },
                    new Serviceman { FirstName = "Костянтин", SecondName = "Гаврилів", DateOfBirth = Convert.ToDateTime("26.11.1985"), RankId = 9,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 2, TroopId = 2, DepartmentId = 2  },

                    new Serviceman { FirstName = "Валерій", SecondName = "Гаврилів", DateOfBirth = Convert.ToDateTime("26.11.1983"), RankId = 9,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 3, TroopId = 3, DepartmentId = 3  },
                    new Serviceman { FirstName = "Василь", SecondName = "Гаврилів", DateOfBirth = Convert.ToDateTime("26.11.1981"), RankId = 9,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 4, TroopId = 4, DepartmentId = 4  },

                    new Serviceman { FirstName = "Микита", SecondName = "Гаврилів", DateOfBirth = Convert.ToDateTime("26.11.1976"), RankId = 9,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 5, TroopId = 5, DepartmentId = 5  },
                     new Serviceman { FirstName = "Роман", SecondName = "Гаврилів", DateOfBirth = Convert.ToDateTime("26.11.1980"), RankId = 9,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 6, TroopId = 6, DepartmentId = 6  },

                     // рядові
                    new Serviceman { FirstName = "Ігор", SecondName = "Якимів", DateOfBirth = Convert.ToDateTime("26.11.1993"), RankId = 10,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 1, TroopId = 1, DepartmentId = 1  },
                    new Serviceman { FirstName = "Костянтин", SecondName = "Якимів", DateOfBirth = Convert.ToDateTime("26.11.1996"), RankId = 10,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 2, TroopId = 2, DepartmentId = 2  },

                    new Serviceman { FirstName = "Валерій", SecondName = "Якимів", DateOfBirth = Convert.ToDateTime("26.11.1991"), RankId = 10,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 3, TroopId = 3, DepartmentId = 3  },
                    new Serviceman { FirstName = "Василь", SecondName = "Якимів", DateOfBirth = Convert.ToDateTime("26.11.1995"), RankId = 10,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 4, TroopId = 4, DepartmentId = 4  },

                    new Serviceman { FirstName = "Микита", SecondName = "Якимів", DateOfBirth = Convert.ToDateTime("26.11.1994"), RankId = 10,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 5, TroopId = 5, DepartmentId = 5  },
                     new Serviceman { FirstName = "Роман", SecondName = "Якимів", DateOfBirth = Convert.ToDateTime("26.11.1996"), RankId = 10,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 6, TroopId = 6, DepartmentId = 6  },

                      // рядові
                    new Serviceman { FirstName = "Ігор", SecondName = "Рубашний", DateOfBirth = Convert.ToDateTime("26.11.1993"), RankId = 10,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 1, TroopId = 1, DepartmentId = 1  },
                    new Serviceman { FirstName = "Костянтин", SecondName = "Рубашний", DateOfBirth = Convert.ToDateTime("26.11.1992"), RankId = 10,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 2, TroopId = 2, DepartmentId = 2  },

                    new Serviceman { FirstName = "Валерій", SecondName = "Рубашний", DateOfBirth = Convert.ToDateTime("26.11.1995"), RankId = 10,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 3, TroopId = 3, DepartmentId = 3  },
                    new Serviceman { FirstName = "Василь", SecondName = "Рубашний", DateOfBirth = Convert.ToDateTime("26.11.1997"), RankId = 10,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 4, TroopId = 4, DepartmentId = 4  },

                    new Serviceman { FirstName = "Микита", SecondName = "Рубашний", DateOfBirth = Convert.ToDateTime("26.11.1996"), RankId = 10,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 5, TroopId = 5, DepartmentId = 5  },
                     new Serviceman { FirstName = "Роман", SecondName = "Рубашний", DateOfBirth = Convert.ToDateTime("26.11.1994"), RankId = 10,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 6, TroopId = 6, DepartmentId = 6  },

                      // рядові
                    new Serviceman { FirstName = "Ігор", SecondName = "Понюк", DateOfBirth = Convert.ToDateTime("26.11.1995"), RankId = 10,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 1, TroopId = 1, DepartmentId = 1  },
                    new Serviceman { FirstName = "Костянтин", SecondName = "Понюк", DateOfBirth = Convert.ToDateTime("26.11.1993"), RankId = 10,
                        ArmyId = 1, CorpId = 1, DivisionId = 1, MilitaryBaseId = 1, SquadId = 2, TroopId = 2, DepartmentId = 2  },

                    new Serviceman { FirstName = "Валерій", SecondName = "Понюк", DateOfBirth = Convert.ToDateTime("26.11.1995"), RankId = 10,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 3, TroopId = 3, DepartmentId = 3  },
                    new Serviceman { FirstName = "Василь", SecondName = "Понюк", DateOfBirth = Convert.ToDateTime("26.11.1992"), RankId = 10,
                        ArmyId = 2, CorpId = 2, DivisionId = 2, MilitaryBaseId = 2, SquadId = 4, TroopId = 4, DepartmentId = 4  },

                    new Serviceman { FirstName = "Микита", SecondName = "Понюк", DateOfBirth = Convert.ToDateTime("26.11.1991"), RankId = 10,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 5, TroopId = 5, DepartmentId = 5  },
                     new Serviceman { FirstName = "Рман", SecondName = "Понюк", DateOfBirth = Convert.ToDateTime("26.11.1990"), RankId = 10,
                        ArmyId = 3, CorpId = 3, DivisionId = 3, MilitaryBaseId = 3, SquadId = 6, TroopId = 6, DepartmentId = 6  },

                };

                for (int i = 0; i < serviceman.Length; i++)
                {
                    dbServiceman.Create(serviceman[i]);
                    db.SaveChanges();
                }

                // спеціальності військовослужбовців
                ServicemanSpecialtyRepository dbSSpecialties = new ServicemanSpecialtyRepository(db);
                ServicemanSpecialty[] mSpecialties = new ServicemanSpecialty[]
                {
                    new ServicemanSpecialty {   ServicemanId = ,  SpecialtyId =  }
                };





            }
        }


    }
}