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
    [Menu(Group = "Staff")]
    public class StaffFunction : BaseEntity
    {

        public StaffFunction()
        {
            this.Description = new LocalizedString();
            this.NameOfStaffCategory = new LocalizedString();
        }
        [EntryForm(GroupeBox ="Fonctions",isRequired =true)]
        [DataGrid]
        [Filter]
        public LocalizedString NameOfStaffCategory { get; set; }

        [EntryForm(WidthControl = 500,MultiLine = true, NumberLine = 5, GroupeBox = "Fonctions")]
        [DataGrid(WidthColonne =500)]
        public LocalizedString Description { get; set; }

        //[EntryForm]
        //[Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        //public List<Staff> staffList { get; set; }
    }
}
