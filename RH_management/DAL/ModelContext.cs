namespace App
{
    using App.DAL;
    using App.Gwin.Entities.Logging;
    using App.Gwin.Entities.Secrurity.Authentication;
    using App.Gwin.Entities.Secrurity.Autorizations;
    using App.Gwin.GwinApplication.BLL.Configuration;
    using RH_managementSolution.Entities;
    using Gwin.Entities.Application;
    using Gwin.Entities.ContactInformations;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        //(LocalDb)\MSSQLLocalDB
        public ModelContext() : base(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=RH_management;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            //  Database.SetInitializer<ModelContext>(new CreateDatabaseIfNotExists<ModelContext>());

        }


        //public ModelContext() : base(LocalDB.GetLocalDBConnectionString("SportClubManagement"))
        //{
        //   // Database.SetInitializer<ModelContext>(new CreateDatabaseIfNotExists<ModelContext>());

        //}

        public ModelContext(string connectionString) : base(connectionString)
        {

        }

        //
        // Gwin : Entites
        //
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
       
    


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        /// <summary>
        /// trouver la liste des type des objets dans le context
        /// </summary>
        /// <returns></returns>
        public List<Type> GetTypesSets()
        {
            var sets = from p in typeof(ModelContext).GetProperties() where p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) let entityType = p.PropertyType.GetGenericArguments().First() select p.PropertyType.GetGenericArguments()[0];
            return sets.ToList<Type>();
        }

    }




}