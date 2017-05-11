using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;

namespace RH_managementSolution.Entities
{
    [GwinEntity(DisplayMember = "FirstName" + " " + "LastName", Localizable = true)]
    [Menu(Group = "Information")]

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

        [EntryForm(Ordre = 1, WidthControl = 300)]
        [DataGrid]
        [Filter]
        public LocalizedString FirstName { get; set; }

        [EntryForm(Ordre = 2, WidthControl = 300)]
        [DataGrid]
        [Filter]
        public LocalizedString LastName { get; set; }

        [EntryForm(Ordre = 3, WidthControl = 300)]
        [DataGrid]
        public DateTime BirthDate { get; set; }

        [EntryForm(Ordre = 4, WidthControl = 300)]
        [DataGrid]
        [Filter]
        public DateTime RecruitementDate { get; set; }

        [EntryForm(Ordre = 5, WidthControl = 300)]
        [DataGrid]
        [Filter]
        public DateTime InvolvementDate { get; set; }

        [EntryForm(Ordre = 6, WidthControl = 300)]
        [DataGrid]
        public LocalizedString PhoneNumber { get; set; }

        [EntryForm(Ordre = 7, WidthControl = 300)]
        [DataGrid(WidthColonne =100)]
        public LocalizedString address { get; set; }

        [EntryForm(Ordre = 8, WidthControl = 300)]
        [DataGrid]
        [Filter]
        public LocalizedString departement { get; set; }

        //done
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public StaffGrade grade { get; set; }
        

        //done
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public List<StaffSpecialty> specialties { get; set; }


        //done
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public StaffCategory category { get; set; }

        //done
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public List<Absenteeism> absences { get; set; }
        

        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public List<Leave> leaves { get; set; }
        

    }
}
