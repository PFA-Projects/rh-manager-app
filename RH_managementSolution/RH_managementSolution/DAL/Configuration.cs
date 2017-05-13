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
                            Name = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير الموارد البشرية   ", English = "Human ressources management", French = "Application de gestion des ressources humaines" }
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
                         new MenuItemApplication { Id = 3, Code = "Root", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "مصمم اليرنامج", English = "Application Constructor", French = "Rélisateur de l'application" } }
                         //new MenuItemApplication { Id = 4, Code = "Admin", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير معلومات الموظفين", English = "Staff information management", French = "Gestion des informations des personnels" } },
                         //new MenuItemApplication { Id = 5, Code = "Admin", Title = new App.Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدابير", English = "Managements", French = "Gestions" } }
                       );

            context.LeaveCategories.AddOrUpdate(r => r.Id,
                new LeaveCategory
                {
                    NameOfLeaveCategory = new LocalizedString { Arab = "اجازة ادارية", English = "Administrative leave", French = "Congé administratif" },
                    Description = new LocalizedString() { Arab = " شرح الاجازة الادارية", English = "description of Administrative leave", French = "descriptin du Congé administratif" }
                },
                new LeaveCategory
                {
                    NameOfLeaveCategory = new LocalizedString { Arab = "اجازة خاصة", English = "Exceptional leave", French = "Congé exceptionnel" },
                    Description = new LocalizedString() { Arab = " شرح الاجازة الخاصة", English = "description of Exceptional leave", French = "descriptin du Congé exceptionnel" }
                },
                new LeaveCategory
                {
                    NameOfLeaveCategory = new LocalizedString { Arab = "اجازة مرضية", English = "Sickness leave", French = "Congé de maladie" },
                    Description = new LocalizedString() { Arab = " شرح الاجازة المرضية", English = "description of Sickness leave", French = "descriptin du Congé de maladie" }
                }
                );
            // 
            // admin to StaffAutorization
            //
            Authorization StaffAutorization = new Authorization();
            StaffAutorization.BusinessEntity = typeof(Staff).FullName;
            RoleAdmin.Authorizations.Add(StaffAutorization);
            context.SaveChanges();

            //AbsenteeismAutorization
            Authorization AbsenteeismAutorization = new Authorization();
            AbsenteeismAutorization.BusinessEntity = typeof(Absenteeism).FullName;
            RoleAdmin.Authorizations.Add(AbsenteeismAutorization);
            context.SaveChanges();

            //LeaveAutorization
            Authorization LeaveAutorization = new Authorization();
            LeaveAutorization.BusinessEntity = typeof(Leave).FullName;
            RoleAdmin.Authorizations.Add(LeaveAutorization);
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
            StaffCateoryAutorization.BusinessEntity = typeof(StaffCategory).FullName;
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
