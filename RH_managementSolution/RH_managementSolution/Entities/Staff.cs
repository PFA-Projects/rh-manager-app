using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;

namespace RH_managementSolution.Entities
{
    [GwinEntity(DisplayMember = "FirstName" + " " + "LastName", Localizable = true)]
    [Menu(Group = "Staff")]
    [ManagementForm(Width = 1000, Height = 600)]

    public class Staff : BaseEntity
    {

        public Staff()
        {
            this.FirstName = new LocalizedString();
            this.LastName = new LocalizedString();
            this.address = new LocalizedString();
            this.PhoneNumber = new LocalizedString();
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
        [Filter]
        public DateTime RecruitementDate { get; set; }

        [EntryForm(isRequired = true, GroupeBox = "Recruitement")]
        [DataGrid]
        [Filter]
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

        //done
        [EntryForm(isRequired = true, GroupeBox = "Graade")]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public StaffGrade grade { get; set; }


        //done
        [EntryForm(isRequired = true, GroupeBox = "Spécialités")]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public List<StaffSpecialty> specialties { get; set; }


        //done
        [EntryForm(isRequired = true, GroupeBox = "Fonction")]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public StaffFunction Function { get; set; }

    }
}
