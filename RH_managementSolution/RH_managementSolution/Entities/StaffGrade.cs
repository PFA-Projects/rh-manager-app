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
    [GwinEntity(DisplayMember = "Name", isMaleName =true,Localizable = true)]
    [Menu(Group = "Staff")]
    public class StaffGrade : BaseEntity
    {
        public StaffGrade()
        {
            this.Description = new LocalizedString();
            this.Name = new LocalizedString();
        }

        [EntryForm(GroupeBox ="Grades",isRequired =true, WidthControl =150)]
        [DataGrid(WidthColonne =180)]
        [Filter]
        public LocalizedString Name { get; set; }

        [EntryForm(WidthControl = 250, MultiLine = true, NumberLine = 5, GroupeBox = "Grades")]
        [DataGrid(WidthColonne = 250)]
        public LocalizedString Description { get; set; }

        //[EntryForm]
        //[DataGrid]
        //[Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        //public List<Staff> staffs { get; set; }
    }
}
