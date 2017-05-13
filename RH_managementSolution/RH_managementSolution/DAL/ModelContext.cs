namespace RH_managementSolution.DAL
{
    using App.Gwin.Entities.Application;
    using App.Gwin.Entities.ContactInformations;
    using App.Gwin.Entities.Logging;
    using App.Gwin.Entities.Secrurity.Authentication;
    using App.Gwin.Entities.Secrurity.Autorizations;
    using App.Gwin.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Entities;

    public class ModelContext : DbContext
    {
        //Votre contexte a été configuré pour utiliser une chaîne de connexion « ModelContext » du fichier
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « RH_managementSolution.DAL.ModelContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « ModelContext » dans le fichier de configuration de l'application.
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<GwinActivity> GwinActivities { get; set; }
        public virtual DbSet<MenuItemApplication> MenuItemApplications { get; set; }
        public virtual DbSet<Country> Countrys { get; set; }
        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<ContactInformation> ContactInformations { get; set; }
        public virtual DbSet<ApplicationName> ApplicationNames { get; set; }



        // RH_management System
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffCategory> StaffCategories { get; set; }
        public virtual DbSet<StaffGrade> StaffGrades { get; set; }
        public virtual DbSet<StaffSpecialty> StaffSpecialties { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<LeaveCategory> LeaveCategories { get; set; }
        public virtual DbSet<Absenteeism> Absenteeisms { get; set; }
        public virtual DbSet<LeaveAsk> LeaveAsks { get; set; }


        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}