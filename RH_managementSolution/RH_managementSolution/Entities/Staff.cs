using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using RH_managementSolution.BAL;
using RH_managementSolution.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RH_managementSolution.Entities
{
    [GwinEntity(DisplayMember = "Name", Localizable = true, isMaleName = true)]
    [Menu(Group = "Staff")]
    [ManagementForm(Width = 1000, Height = 600)]
    [PresentationLogic(TypePLO = typeof(StaffPLO))]

    public class Staff : BaseEntity
    {

        public Staff()
        {
            this.nbTotalDaysAdmin = 22;
            this.nbTotalDaysExcep = 10;
        }
        [NotMapped]
        public string Name
        {
            get
            {
                return this.FirstName.Current + " " + this.LastName.Current;
            }
        }

        [EntryForm(isRequired = true, GroupeBox = "EtatCivil")]
        [DataGrid]
        [Filter]
        public LocalizedString FirstName { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "EtatCivil")]
        [DataGrid]
        [Filter]
        public LocalizedString LastName { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "EtatCivil")]
        [DataGrid]
        public DateTime BirthDate { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "Recruitement")]
        [DataGrid]
        public DateTime RecruitementDate { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "Recruitement")]
        [DataGrid]
        public DateTime InvolvementDate { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "EtatCivil")]
        [DataGrid]
        public LocalizedString PhoneNumber { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "EtatCivil")]
        [DataGrid]
        public LocalizedString address { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "Deepartement")]
        [DataGrid]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public Departement departement { get; set; }

        ////done
        [EntryForm( GroupeBox = "Graade")]
        //  [Filter(isValeurFiltreVide = true)]
        [DataGrid]
        [NotMapped]
        //  [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public StaffGrade grade
        {
            get
            {
                List<AdvancementGrade> lstadvgrade = new ModelContext().AdvancementGrades.Where(r => r.staff.Id == this.Id).OrderByDescending(r => r.advancementDate).ToList();
                if (lstadvgrade.Count > 0)
                    return lstadvgrade[0].grade;
                else
                    return null;
            }
            set { }
        }
        [NotMapped]
        public virtual AdvancementGrade Advancementgrade
        {
            get
            {
                if (grade != null)
                    return Advancementgrade;

                else
                    return new AdvancementGrade();
            }

        }


        ////done
        [EntryForm(isRequired = true, GroupeBox = "Spécialités")]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        //  [DataGrid]
        public List<StaffSpecialty> specialties { get; set; }


        ////done
        [EntryForm(isRequired = true, GroupeBox = "Fonction")]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [DataGrid]
        public StaffFunction Function { get; set; }

        [DataGrid]
        public int nbTotalDaysAdmin { get; set; }

        [DataGrid]
        public int nbTotalDaysExcep { get; set; }

    }
}
