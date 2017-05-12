using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(DisplayMember = "NameOfStaffCategory", Localizable = true)]
    [Menu(Group = "managements")]
    public class StaffCategory : BaseEntity
    {

        public StaffCategory()
        {
            this.Description = new LocalizedString();
            this.NameOfStaffCategory = new LocalizedString();
        }
        [EntryForm(Ordre = 1, WidthControl = 300)]
        [DataGrid]
        [Filter]
        public LocalizedString NameOfStaffCategory { get; set; }

        [EntryForm(Ordre = 2, WidthControl = 400)]
        [DataGrid (WidthColonne =400)]
        public LocalizedString Description { get; set; }

        //[EntryForm]
        //[Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        //public List<Staff> staffList { get; set; }
    }
}
