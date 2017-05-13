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
    [GwinEntity(DisplayMember = "NameOfSpecialty", Localizable = true)]
    [Menu(Group = "Configuration")]
    public class StaffSpecialty : BaseEntity
    {
        public StaffSpecialty()
        {
            this.Description = new LocalizedString();
            this.NameOfStaffSpecialty = new LocalizedString();
        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameOfStaffSpecialty { get; set; }

        [EntryForm(WidthControl = 500)]
        [DataGrid(WidthColonne = 500)]
        public LocalizedString Description { get; set; }

        //[EntryForm]
        //[DataGrid]
        //[Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        //public List<Staff> Staffs { get; set; }
    }
}
