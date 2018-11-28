using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MilitaryRegion.DAO.Repositories;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

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

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        {
            /*private int GetNetworkId(string name, IRepository<NeuralNetwork> dbNetworks)
            {
                return dbNetworks.Find(net => net.Name.Equals(name)).FirstOrDefault().Id;
            }

            private int GetTaskId(string taskName, IRepository<TaskNetwork> dbTasks)
            {
                return dbTasks.Find(task => task.Name.Equals(taskName)).FirstOrDefault().Id;
            }*/

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









                    /* const int kerogenAmount = 19;
                     const int layerAmount = 15;
                     const int typesAmount = 2;
                     const int networkAmount = 2;

                     KerogenRepository dbKerogens = new KerogenRepository(db);
                     Kerogen[] kerogens = new Kerogen[kerogenAmount] {
                     new Kerogen { Carbon = 0.765, Hydrogen = 0.1, Oxygen = 0.103, Nitrogen = 0.6, Sulfur = 0.026, Type = 1},
                     new Kerogen { Carbon = 0.759, Hydrogen = 0.091, Oxygen = 0.084, Nitrogen = 0.039, Sulfur = 0.026, Type = 1},
                     new Kerogen { Carbon = 0.809, Hydrogen = 0.086, Oxygen = 0.044, Nitrogen = 0.038, Sulfur = 0.023, Type = 1},
                     new Kerogen { Carbon = 0.726, Hydrogen = 0.079, Oxygen = 0.124, Nitrogen = 0.021, Sulfur = 0.049, Type = 2},
                     new Kerogen { Carbon = 0.854, Hydrogen = 0.079, Oxygen = 0.05, Nitrogen = 0.023, Sulfur = 0.002, Type = 2},
                     new Kerogen { Carbon = 0.806, Hydrogen = 0.059, Oxygen = 0.064, Nitrogen = 0.034, Sulfur = 0.038, Type = 2},
                     new Kerogen { Carbon = 0.727, Hydrogen = 0.06, Oxygen = 0.19, Nitrogen = 0.023, Sulfur = 0.0, Type = 3},
                     new Kerogen { Carbon = 0.833, Hydrogen = 0.046, Oxygen = 0.095, Nitrogen = 0.021, Sulfur = 0.005, Type = 3},
                     new Kerogen { Carbon = 0.916, Hydrogen = 0.032, Oxygen = 0.029, Nitrogen = 0.02, Sulfur = 0.003, Type = 3},
                     new Kerogen { Carbon = 0.827, Hydrogen = 0.041, Oxygen = 0.083, Nitrogen = 0.017, Sulfur = 0.032, Type = 1},
                     new Kerogen { Carbon = 0.854, Hydrogen = 0.035, Oxygen = 0.056, Nitrogen = 0.021, Sulfur = 0.033, Type = 2},
                     new Kerogen { Carbon = 0.686, Hydrogen = 0.051, Oxygen = 0.212, Nitrogen = 0.026, Sulfur = 0.025, Type = 3},
                     new Kerogen { Carbon = 0.775, Hydrogen = 0.108, Oxygen = 0.093, Nitrogen = 0.004, Sulfur = 0.02, Type = 1},
                     new Kerogen { Carbon = 0.735, Hydrogen = 0.083, Oxygen = 0.18, Nitrogen = 0.026, Sulfur = 0.018, Type = 2},
                     new Kerogen { Carbon = 0.883, Hydrogen = 0.05, Oxygen = 0.039, Nitrogen = 0.02, Sulfur = 0.008, Type = 3},
                     new Kerogen { Carbon = 0.759, Hydrogen = 0.094, Oxygen = 0.088, Nitrogen = 0.021, Sulfur = 0.038, Type = 1},
                     new Kerogen { Carbon = 0.693, Hydrogen = 0.083, Oxygen = 0.18, Nitrogen = 0.026, Sulfur = 0.018, Type = 2},
                     new Kerogen { Carbon = 0.913, Hydrogen = 0.032, Oxygen = 0.032, Nitrogen = 0.018, Sulfur = 0.005, Type = 3},
                     new Kerogen { Carbon = 0.822, Hydrogen = 0.099, Oxygen = 0.013, Nitrogen = 0.013, Sulfur = 0.025, Type = 1}
                 };

                     for (int i = 0; i < kerogenAmount; i++)
                     {
                         dbKerogens.Create(kerogens[i]);
                         db.SaveChanges();
                     }

                     LayerRepository dbLayers = new LayerRepository(db);
                     Layer[] layers = new Layer[layerAmount]
                     {
                     new Layer {Porosity = 0.189, Clayness = 0.1, Carbonate = 0.86, Amplitude = 0.22, Type = 1},
                     new Layer {Porosity = 0.141, Clayness = 0.078, Carbonate = 0.123, Amplitude = 0.12, Type = 1},
                     new Layer {Porosity = 0.15, Clayness = 0.095, Carbonate = 0.128, Amplitude = 0.08, Type = 1},
                     new Layer {Porosity = 0.126, Clayness = 0.401, Carbonate = 0.085, Amplitude = 0.04, Type = 2},
                     new Layer {Porosity = 0.109, Clayness = 0.156, Carbonate = 0.179, Amplitude = 0.08, Type = 2},
                     new Layer {Porosity = 0.095, Clayness = 0.278, Carbonate = 0.124, Amplitude = 0.05, Type = 2},
                     new Layer {Porosity = 0.156, Clayness = 0.124, Carbonate = 0.09, Amplitude = 0.17, Type = 1},
                     new Layer {Porosity = 0.178, Clayness = 0.167, Carbonate = 0.075, Amplitude = 0.05, Type = 1},
                     new Layer {Porosity = 0.107, Clayness = 0.222, Carbonate = 0.119, Amplitude = 0.14, Type = 1},
                     new Layer {Porosity = 0.115, Clayness = 0.174, Carbonate = 0.182, Amplitude = 0.07, Type = 1},
                     new Layer {Porosity = 0.126, Clayness = 0.151, Carbonate = 0.144, Amplitude = 0.1, Type = 1},
                     new Layer {Porosity = 0.088, Clayness = 0.189, Carbonate = 0.25, Amplitude = 0.03, Type = 2},
                     new Layer {Porosity = 0.12, Clayness = 0.335, Carbonate = 0.086, Amplitude = 0.03, Type = 2},
                     new Layer {Porosity = 0.09, Clayness = 0.147, Carbonate = 0.197, Amplitude = 0.07, Type = 2},
                     new Layer {Porosity = 0.085, Clayness = 0.15, Carbonate = 0.224, Amplitude = 0.04, Type = 2}
                     };

                     for (int i = 0; i < layerAmount; i++)
                     {
                         dbLayers.Create(layers[i]);
                         db.SaveChanges();
                     }

                     NetworkTypeRepository dbTypes = new NetworkTypeRepository(db);
                     NetworkType[] types = new NetworkType[typesAmount]
                     {
                     new NetworkType {Name = "Supervised leraning", Description = "парам"},
                     new NetworkType {Name = "Unsupervised leraning", Description = "парам"}
                     };

                     for (int i = 0; i < typesAmount; i++)
                     {
                         dbTypes.Create(types[i]);
                         db.SaveChanges();
                     }

                     NeuralNetworkRepository dbNetworks = new NeuralNetworkRepository(db);
                     NeuralNetwork[] networks = new NeuralNetwork[networkAmount]
                     {
                     new NeuralNetwork {Name = "BPN", Description = "param", NetworkTypeId = 1 },
                     new NeuralNetwork {Name = "LVQ", Description = "param", NetworkTypeId = 2 }
                     };

                     for (int i = 0; i < networkAmount; i++)
                     {
                         dbNetworks.Create(networks[i]);
                         db.SaveChanges();
                     }

                     AvailableNetworksRepository dbANet = new AvailableNetworksRepository(db);
                     AvailableNetwork[] aNetworks = new AvailableNetwork[]
                     {
                     new AvailableNetwork {NeuralNetworkId = GetNetworkId("BPN", dbNetworks), TaskId =  GetTaskId("Kerogen", dbTasks)},
                     new AvailableNetwork {NeuralNetworkId = GetNetworkId("BPN", dbNetworks), TaskId =  GetTaskId("Layer", dbTasks)},
                     new AvailableNetwork {NeuralNetworkId = GetNetworkId("LVQ", dbNetworks), TaskId =  GetTaskId("Kerogen", dbTasks)},
                     new AvailableNetwork {NeuralNetworkId = GetNetworkId("LVQ", dbNetworks), TaskId =  GetTaskId("Layer", dbTasks)}
                     };

                     for (int i = 0; i < aNetworks.Length; i++)
                     {
                         dbANet.Create(aNetworks[i]);
                         db.SaveChanges();
                     }

                 }*/
                    /*
                    if (!roleManager.RoleExists("User"))
                    {
                        var role = new IdentityRole();
                        role.Name = "User";
                        roleManager.Create(role);
                    }


                    db.SaveChanges();*/
                }
        }


    }
}