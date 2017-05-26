namespace RH_managementSolution.Migrations
{
    using App.Gwin.Application.BAL;
    using App.Gwin.Entities.Application;
    using App.Gwin.Entities.ContactInformations;
    using App.Gwin.Entities.MultiLanguage;
    using App.Gwin.Entities.Secrurity.Authentication;
    using App.Gwin.Entities.Secrurity.Autorizations;
    using DAL;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "RH_managementSolution";
        }

        protected override void Seed(ModelContext context)
        {

            //-- Gwin Application Name
            context.ApplicationNames.AddOrUpdate(
                           r => r.Reference
                        ,
                        new App.Gwin.Entities.Application.ApplicationName
                        {
                            Reference = "RH_managementSolution",
                            Name = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير الموارد البشرية   ", English = "Human ressources management", French = "Gestion des ressources humaines" }
                        }

                      );


            //
            // Gwin Roles
            //
            Role RoleGuest = null;
            Role RoleRoot = null;
            Role RoleAdmin = null;
            context.Roles.AddOrUpdate(
                 r => r.Reference
                        ,
              new Role { Reference = nameof(Role.Roles.Guest), Name = new App.Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Guest) } },
              new Role { Reference = nameof(Role.Roles.User), Name = new App.Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.User) } },
              new Role { Reference = nameof(Role.Roles.Admin), Name = new App.Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Admin) } },
              new Role { Reference = nameof(Role.Roles.Root), Name = new App.Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Root) }, Hidden = true }
            );
            // Save Change to Select RoleRoot and RoleGuest
            context.SaveChanges();
            RoleRoot = context.Roles.Where(r => r.Reference == nameof(Role.Roles.Root)).SingleOrDefault();
            RoleGuest = context.Roles.Where(r => r.Reference == nameof(Role.Roles.Guest)).SingleOrDefault();
            RoleAdmin = context.Roles.Where(r => r.Reference == nameof(Role.Roles.Admin)).SingleOrDefault();

            // 
            // Giwn Autorizations
            //
            // Guest Autorization
            Authorization FindUserAutorization = new Authorization();
            FindUserAutorization.BusinessEntity = typeof(User).FullName;
            FindUserAutorization.ActionsNames = new List<string>();
            FindUserAutorization.ActionsNames.Add(nameof(IGwinBaseBLO.Recherche));

            RoleGuest.Authorizations = new List<Authorization>();
            RoleGuest.Authorizations.Add(FindUserAutorization);

            // Admin Autorization
            RoleAdmin.Authorizations = new List<Authorization>();

            Authorization UserAutorization = new Authorization();
            UserAutorization.BusinessEntity = typeof(User).FullName;
            RoleAdmin.Authorizations.Add(UserAutorization);


            ////ChampionshipRanking

            // Authorization ChampionshipRankingAutorization = new Authorization();
            // ChampionshipRankingAutorization.BusinessEntity = typeof(TournamentRanking).FullName;
            // RoleAdmin.Authorizations.Add(ChampionshipRankingAutorization);
            // //

            Authorization CityAutorization = new Authorization();
            CityAutorization.BusinessEntity = typeof(City).FullName;
            RoleAdmin.Authorizations.Add(CityAutorization);


            Authorization CountryAutorization = new Authorization();
            CountryAutorization.BusinessEntity = typeof(Country).FullName;
            RoleAdmin.Authorizations.Add(CountryAutorization);



            context.SaveChanges();

            //-- Giwn Users
            context.Users.AddOrUpdate(
                u => u.Reference,
                new User() { Reference = nameof(User.Users.Root), Login = nameof(User.Users.Root), Password = nameof(User.Users.Root), LastName = new LocalizedString() { Current = nameof(User.Users.Root) }, Roles = new List<Role>() { RoleRoot } },
                new User() { Reference = nameof(User.Users.Admin), Login = nameof(User.Users.Admin), Password = nameof(User.Users.Admin), LastName = new LocalizedString() { Current = nameof(User.Users.Admin) }, Roles = new List<Role>() { RoleAdmin } },
                new User() { Reference = nameof(User.Users.Guest), Login = nameof(User.Users.Guest), Password = nameof(User.Users.Guest), LastName = new LocalizedString() { Current = nameof(User.Users.Guest) }, Roles = new List<Role>() { RoleGuest } }
                );
            //-- Gwin  Menu
            context.MenuItemApplications.AddOrUpdate(
                            r => r.Code
                         ,
                         new MenuItemApplication { Id = 1, Code = "Configuration", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "إعدادات", English = "Configuration", French = "Configuration" } },
                         new MenuItemApplication { Id = 2, Code = "Admin", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير البرنامج", English = "Admin", French = "Administration" } },
                         new MenuItemApplication { Id = 3, Code = "Root", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "مصمم اليرنامج", English = "Application Constructor", French = "Rélisateur de l'application" } },
                         new MenuItemApplication { Id = 4, Code = "AbseenteismManagement", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير الغياب", English = "Absenteeism Management", French = "Gestion d'Absentéisme" } },
                         new MenuItemApplication { Id = 5, Code = "LeaveManagement", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير الاجازات", English = "Leave Management", French = "Gestion des congés" } },
                         new MenuItemApplication { Id = 6, Code = "Staff", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير الموظفين", English = "Staff Management", French = "Gestion des personnels" } }

                         );
            context.StaffSpecialties.AddOrUpdate(r => r.Reference,
                new StaffSpecialty
                {
                    Reference = "Administrateur",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "", English = "", French = "Administrateur" },
                    Description = new LocalizedString { Arab = "", English = "", French = "" }
                },
                new StaffSpecialty
                {
                    Reference = "Polyvalent",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "متعدد الأهداف", English = "Polyvalent", French = "Polyvalent" },
                    Description = new LocalizedString { Arab = " تؤدي عدة وظائف", English = "Has several abilities, can fulfill several functions", French = "possède plusieurs aptitudes ou capacités, peut remplir plusieurs fonctions" }
                },
                new StaffSpecialty
                {
                    Reference = "Interniste",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "الطبيب الباطني", English = "Internist", French = "Interniste" },
                    Description = new LocalizedString { Arab = "", English = "", French = "description du specialité interniste" }
                },
                new StaffSpecialty
                {
                    Reference = "MedTravail",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "", English = "Physician", French = "Medecin de travail" },
                    Description = new LocalizedString { Arab = "", English = "", French = "descriptin du medecin du travail" }
                },
                new StaffSpecialty
                {
                    Reference = "Pharmacie",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "صيدلي", English = "pharmacist", French = "Pharmacien" },
                    Description = new LocalizedString { Arab = "", English = "", French = "descriptin du specialité de pharmacie" }
                },
                new StaffSpecialty
                {
                    Reference = "Pneumo",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "اختصاصي الرئة", English = "lung specialist", French = "pneumologue" },
                    Description = new LocalizedString { Arab = "", English = "", French = "description de pneumologie" }
                },
                new StaffSpecialty
                {
                    Reference = "Keni",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "العلاج الطبيعي", English = "Physiotherapy", French = "Kinésithérapie" },
                    Description = new LocalizedString { Arab = "", English = "", French = "description de kénisitherapie" }
                },
                new StaffSpecialty
                {
                    Reference = "MedGeneral",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "طبيب عام", English = "General practitioner", French = "Medecin génerale" },
                    Description = new LocalizedString { Arab = "", English = "", French = "" }
                },
                new StaffSpecialty
                {
                    Reference = "Infaux",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "ممرض مساعد", English = "Auxiliary nurse", French = "Infirmier auxiliaire" },
                    Description = new LocalizedString { Arab = "", English = "", French = "description infirmier auxiliaire" }
                },
                new StaffSpecialty
                {
                    Reference = "Hema",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "أمراض الدم", English = "Hematologist", French = "Hématologue" },
                    Description = new LocalizedString { Arab = "", English = "", French = "description de hematalogie" }
                },
                new StaffSpecialty
                {
                    Reference = "MalInfectueuse",
                    NameOfStaffSpecialty = new LocalizedString { Arab = "امراض معدية", English = "Infectuous disease", French = "Maladie infectueuse" },
                    Description = new LocalizedString { Arab = "", English = "", French = "description du maladie infectueuse" }
                },
               new StaffSpecialty
               {
                   Reference = "AssistSoc",
                   NameOfStaffSpecialty = new LocalizedString { Arab = "مساعد الاجتماعي", English = "Social Worker", French = "Assistant sociale" },
                   Description = new LocalizedString { Arab = "", English = "", French = "description d'assistant sociale" }
               },
              new StaffSpecialty
              {
                  Reference = "Cardio",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "طبيب القلب", English = "Cardiologist", French = "Cardiologue" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description du cardiologie" }
              },
              new StaffSpecialty
              {
                  Reference = "Encologie",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "طبيب الأورام", English = "Oncologist", French = "Oncologue" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description d'encologie" }
              },
              new StaffSpecialty
              {
                  Reference = "Endocrinologie",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "طبيب الغدد الصماء", English = "Endocrinologist", French = "Endocrinologue" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description d'endocrinologie" }
              },
              new StaffSpecialty
              {
                  Reference = "Adjadmin",
                  NameOfStaffSpecialty = new LocalizedString { Arab = " مساعد اداري", English = "Administrative Assistant", French = "Adjoint administratif" },
                  Description = new LocalizedString { Arab = "", English = "", French = "Description d'adjoint Ad" }
              },
              new StaffSpecialty
              {
                  Reference = "admindiv",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "مدير قسم", English = "Divisional Officer", French = "Administrateur divisionnaire" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description d'administrateur divisionnaire" }
              },
              new StaffSpecialty
              {
                  Reference = "MedNucleaire",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "الطبيب النووي", English = "Nuclear medicine", French = "Médecin nucléaire" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description du medecin nucleaire" }
              },
              new StaffSpecialty
              {
                  Reference = "TechnRadio",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "تقني الاشعة", English = "Radiology Technician", French = "Technicien de radiologie" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description du medecin nucleaire" }
              }, new StaffSpecialty
              {
                  Reference = "Radiotherapie",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "المعالجة بالإشعاع", English = "Radiotherapy", French = "Radiothérapie" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description du radiotherapie" }
              }, new StaffSpecialty
              {
                  Reference = "preppharmacie",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "تحضيرات صيدلية", English = "medicine preparation", French = "Préparatrice de pharmacie" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description de préparatrice de pharmacie" }
              }, new StaffSpecialty
              {
                  Reference = "gastrologie",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "الجهاز الهضمي", English = "Gastrology", French = "Gastrologie" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description de gastrologie" }
              }, new StaffSpecialty
              {
                  Reference = "Diet",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "التغذية", English = "Dietitian", French = "Diététicien" },
                  Description = new LocalizedString { Arab = "", English = "", French = "description de dieticien" }
              }, new StaffSpecialty
              {
                  Reference = "Tech",
                  NameOfStaffSpecialty = new LocalizedString { Arab = "تقني", English = "technician", French = "Technicien" },
                  Description = new LocalizedString { Arab = "", English = "", French = "" }
              }
             );
            //admin 22j ouvrable  excep 10j/a maladie 
            //departement medecine medecine homme medecine femme cardiologie pneumologie centre  diagnostique centre de reference hopital de jour
            context.StaffFunctions.AddOrUpdate(r => r.Reference,
                new StaffFunction
                {
                    Reference = "Administrateurs",
                    NameOfStaffFunction = new LocalizedString { Arab = "", French = "Administrateur", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                },
                new StaffFunction
                {
                    Reference = "PH",
                    NameOfStaffFunction = new LocalizedString { Arab = "صيدلي", French = "Pharmacien", English = "Pharmacist" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new StaffFunction
                {
                    Reference = "DOC",
                    NameOfStaffFunction = new LocalizedString { Arab = "طبيب", French = "Médecin", English = "Doctor" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new StaffFunction
                {
                    Reference = "NURSERY",
                    NameOfStaffFunction = new LocalizedString { Arab = "ممرض", French = "Infirmier", English = "Nurse" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new StaffFunction
                {
                    Reference = "DIRECTOR",
                    NameOfStaffFunction = new LocalizedString { Arab = "مدير", French = "Directeur", English = "Director" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new StaffFunction
                {
                    Reference = "ASSISTANT",
                    NameOfStaffFunction = new LocalizedString { Arab = "مساعد اجتماعي", French = "Assistant sociale", English = "Social worker" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new StaffFunction
                {
                    Reference = "ADJOINT",
                    NameOfStaffFunction = new LocalizedString { Arab = "مساعد اداري ", French = "adjoint administratif", English = "Administrative Assistant" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new StaffFunction
                {
                    Reference = "ADMINDIV",
                    NameOfStaffFunction = new LocalizedString { Arab = "مدير قسم", French = "Administrateur divisionnaire", English = "Divisional Officer" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new StaffFunction
                {
                    Reference = "TECHN",
                    NameOfStaffFunction = new LocalizedString { Arab = "تقني ", French = "Technicien", English = "Technician" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }
            );

            context.Departement.AddOrUpdate(r => r.Reference,
                new Departement
                {
                    Reference = "Medecine",
                    name = new LocalizedString { Arab = "", French = "Medecine", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new Departement
                {
                    Reference = "MedecineHomme",
                    name = new LocalizedString { Arab = "", French = "Medecine homme", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new Departement
                {
                    Reference = "MedecineFemme",
                    name = new LocalizedString { Arab = "", French = "Medecine femme ", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new Departement
                {
                    Reference = "Cardiologie",
                    name = new LocalizedString { Arab = "", French = "Cardiologie", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new Departement
                {
                    Reference = "Pneumologie",
                    name = new LocalizedString { Arab = "", French = "Pneumologie", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new Departement
                {
                    Reference = "CentreReference",
                    name = new LocalizedString { Arab = "", French = "Centre de référence", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new Departement
                {
                    Reference = "CentreDiagnostique",
                    name = new LocalizedString { Arab = "", French = "Centre de diagnostique", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }, new Departement
                {
                    Reference = "Hopitaldujour",
                    name = new LocalizedString { Arab = "", French = "Hopital du jour", English = "" },
                    Description = new LocalizedString { Arab = "", French = "", English = "" }
                }
                );

            context.LeaveCategories.AddOrUpdate(r => r.Reference,
                new LeaveCategory
                {
                    Reference = "Administrativeleave",
                    NameOfLeaveCategory = new LocalizedString { Arab = "اجازة ادارية", English = "Administrative leave", French = "Congé administratif" },
                    Description = new LocalizedString() { Arab = " شرح الاجازة الادارية", English = "description of Administrative leave", French = "descriptin du Congé administratif" },
                    nbDays = 22,
                },
                new LeaveCategory
                {
                    Reference = "Congéexceptionnel",
                    NameOfLeaveCategory = new LocalizedString { Arab = "اجازة خاصة", English = "Exceptional leave", French = "Congé exceptionnel" },
                    Description = new LocalizedString() { Arab = " شرح الاجازة الخاصة", English = "description of Exceptional leave", French = "descriptin du Congé exceptionnel" },
                    nbDays = 10,
                },
                new LeaveCategory
                {
                    Reference = "Congédemaladie",
                    NameOfLeaveCategory = new LocalizedString { Arab = "اجازة مرضية", English = "Sickness leave", French = "Congé de maladie" },
                    Description = new LocalizedString() { Arab = " شرح الاجازة المرضية", English = "description of Sickness leave", French = "descriptin du Congé de maladie" }
                }
                );

            context.StaffGrades.AddOrUpdate(r => r.Reference,
                new StaffGrade
                {
                    Reference = "Administrateurss",
                    Name = new LocalizedString { Arab = " ", English = "", French = "Administrateur" },
                    Description = new LocalizedString { Arab = "", English = "", French = "" }
                },
                new StaffGrade
                {
                    Reference = "IDE",
                    Name = new LocalizedString { Arab = " ", English = "IDE 1 grade", French = "IDE 1 grade" },
                    Description = new LocalizedString { Arab = "", English = "llkl", French = "Description IDE 1 grade" }
                },
            new StaffGrade
            {
                Reference = "llk",
                Name = new LocalizedString { Arab = "لعتمه", English = "khk", French = "IDE 2 grade" },
                Description = new LocalizedString { Arab = "كنكمن", English = "llk", French = "Description IDE 2 grade" }
            },
            new StaffGrade
            {
                Reference = "Medecin1",
                Name = new LocalizedString { Arab = "", English = "", French = "Medecin 1 grade" },
                Description = new LocalizedString { Arab = "", English = "", French = "Description medecin 1 grade" }
            },
             new StaffGrade
             {
                 Reference = "Medecin2",
                 Name = new LocalizedString { Arab = "", English = "", French = "Medecin grade principal" },
                 Description = new LocalizedString { Arab = "", English = "", French = "Description Medecin grade principal" }
             },
              new StaffGrade
              {
                  Reference = "Medecin3",
                  Name = new LocalizedString { Arab = "", English = "", French = "Medecin grade exceptionnel" },
                  Description = new LocalizedString { Arab = "", English = "", French = "Description Medecin grade exceptionnel" }
              },
               new StaffGrade
               {
                   Reference = "Medecin4",
                   Name = new LocalizedString { Arab = "", English = "", French = "Medecin hors grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description medecin hors grade" }
               },
               new StaffGrade
               {
                   Reference = "Pharmacien",
                   Name = new LocalizedString { Arab = "", English = "", French = "Pharmacien 1 grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Descriptin pharmacien 1 grade" }
               }, new StaffGrade
               {
                   Reference = "Infaux1",
                   Name = new LocalizedString { Arab = "", English = "", French = "Infirmier auxiliaire 1 grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description Infirmier auxiliaire 1 grade" }
               }, new StaffGrade
               {
                   Reference = "Infaux2",
                   Name = new LocalizedString { Arab = "", English = "", French = "Infirmier auxiliaire 2 grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description Infirmier auxiliaire 2 grade" }
               }, new StaffGrade
               {
                   Reference = "Admin",
                   Name = new LocalizedString { Arab = "", English = "", French = "Administrateur 3 grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description administrateur 3 grade" }
               }, new StaffGrade
               {
                   Reference = "Infaux3",
                   Name = new LocalizedString { Arab = "", English = "", French = "Infirmier auxiliaire 1 grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description Infirmier auxiliaire 1 grade" }
               }, new StaffGrade
               {
                   Reference = "AdjTech",
                   Name = new LocalizedString { Arab = "", English = "", French = "Adjoint technique 4 grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description adjoint technique 4 grade" }
               }, new StaffGrade
               {
                   Reference = "AdminDiv",
                   Name = new LocalizedString { Arab = "", English = "", French = "Administrateur divisionnaire" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description Administrteur divisionnaire" }
               }, new StaffGrade
               {
                   Reference = "Technicien",
                   Name = new LocalizedString { Arab = "", English = "", French = "Technicien 4 grade" },
                   Description = new LocalizedString { Arab = "", English = "", French = "Description technicien 4 grade" }
               });
            // 
            // admin to StaffAutorization
            //
            Authorization StaffAutorization = new Authorization();
            StaffAutorization.BusinessEntity = typeof(Staff).FullName;
            RoleAdmin.Authorizations.Add(StaffAutorization);
            context.SaveChanges();

            Authorization GradeCategoryAutorization = new Authorization();
            GradeCategoryAutorization.BusinessEntity = typeof(GradeCategory).FullName;
            RoleAdmin.Authorizations.Add(GradeCategoryAutorization);
            context.SaveChanges();

            Authorization advgradeAutorization = new Authorization();
            advgradeAutorization.BusinessEntity = typeof(AdvancementGrade).FullName;
            RoleAdmin.Authorizations.Add(advgradeAutorization);
            context.SaveChanges();

            //AbsenteeismAutorization
            Authorization AbsenteeismAutorization = new Authorization();
            AbsenteeismAutorization.BusinessEntity = typeof(Absenteeism).FullName;
            RoleAdmin.Authorizations.Add(AbsenteeismAutorization);
            context.SaveChanges();

            //AdvancementGradesAutorization
            Authorization AdvancementGrades = new Authorization();
            AdvancementGrades.BusinessEntity = typeof(Absenteeism).FullName;
            RoleAdmin.Authorizations.Add(AdvancementGrades);
            context.SaveChanges();

            //DepartementAutorization
            Authorization DepartementAutorization = new Authorization();
            DepartementAutorization.BusinessEntity = typeof(Departement).FullName;
            RoleAdmin.Authorizations.Add(DepartementAutorization);
            context.SaveChanges();

            //LeaveAutorization
            Authorization LeaveAutorization = new Authorization();
            LeaveAutorization.BusinessEntity = typeof(Leave).FullName;
            RoleAdmin.Authorizations.Add(LeaveAutorization);
            context.SaveChanges();

            //LeaveAsk Autorization
            Authorization LeaveAskAutorization = new Authorization();
            LeaveAskAutorization.BusinessEntity = typeof(LeaveAsk).FullName;
            RoleAdmin.Authorizations.Add(LeaveAskAutorization);
            context.SaveChanges();

            //LeaveCategory Autorization
            Authorization LeaveCategoryAutorization = new Authorization();
            LeaveCategoryAutorization.BusinessEntity = typeof(LeaveCategory).FullName;
            RoleAdmin.Authorizations.Add(LeaveCategoryAutorization);
            context.SaveChanges();

            //StaffGradeAutorization
            Authorization StaffGradeAutorization = new Authorization();
            StaffGradeAutorization.BusinessEntity = typeof(StaffGrade).FullName;
            RoleAdmin.Authorizations.Add(StaffGradeAutorization);
            context.SaveChanges();

            //StaffCateoryAutorization
            Authorization StaffCateoryAutorization = new Authorization();
            StaffCateoryAutorization.BusinessEntity = typeof(StaffFunction).FullName;
            RoleAdmin.Authorizations.Add(StaffCateoryAutorization);
            context.SaveChanges();

            //StaffSPecialtyAutorization
            Authorization StaffSPecialtyAutorization = new Authorization();
            StaffSPecialtyAutorization.BusinessEntity = typeof(StaffSpecialty).FullName;
            RoleAdmin.Authorizations.Add(StaffSPecialtyAutorization);
            context.SaveChanges();
        }
    }
}
