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
    [Menu(Group = "managements")]
    public class StaffSpecialty : BaseEntity
    {
        public StaffSpecialty()
        {
            this.Description = new LocalizedString();
            this.NameOfStaffSpecialty = new LocalizedString();
        }
        [EntryForm(Ordre = 1, WidthControl = 300)]
        [DataGrid(WidthColonne =300)]
        [Filter]
        public LocalizedString NameOfStaffSpecialty { get; set; }

        [EntryForm]
        [DataGrid(WidthColonne =400)]
        public LocalizedString Description { get; set; }

        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public List<Staff> staffList { get; set; }
    }
}
