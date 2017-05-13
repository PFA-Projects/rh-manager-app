using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;

namespace RH_managementSolution.Entities
{
    [GwinEntity(DisplayMember = "FirstName" + " " + "LastName", Localizable = true)]
    [Menu(Group = "Staff information management")]

    public class Staff : BaseEntity
    {

        public Staff()
        {
            this.FirstName = new LocalizedString();
            this.LastName = new LocalizedString();
            this.address = new LocalizedString();
            this.departement = new LocalizedString();
            this.PhoneNumber = new LocalizedString();
        }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString FirstName { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString LastName { get; set; }

        [EntryForm]
        [DataGrid]
        public DateTime BirthDate { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public DateTime RecruitementDate { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public DateTime InvolvementDate { get; set; }

        [EntryForm]
        [DataGrid]
        public LocalizedString PhoneNumber { get; set; }

        [EntryForm]
        [DataGrid]
        public LocalizedString address { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString departement { get; set; }

        //done
        [EntryForm]
        [Filter]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public StaffGrade grade { get; set; }


        //done
        [EntryForm]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public List<StaffSpecialty> specialties { get; set; }


        //done
        [EntryForm]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public StaffCategory category { get; set; }

        ////done
        //[EntryForm]
        //[Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        //public List<Absenteeism> absences { get; set; }

        //[EntryForm]
        //[Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        //public List<Leave> leaves { get; set; }
    }
}
