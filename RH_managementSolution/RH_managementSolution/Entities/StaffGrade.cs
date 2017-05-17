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
    [GwinEntity(DisplayMember = "NumberOfGrade", Localizable = true)]
    [Menu(Group = "Staff")]
    public class StaffGrade : BaseEntity
    {
        public StaffGrade()
        {
            this.Description = new LocalizedString();
            this.NumberOfGrade = new LocalizedString();
        }

        [EntryForm(GroupeBox ="Grades",isRequired =true)]
        [DataGrid]
        [Filter]
        public LocalizedString NumberOfGrade { get; set; }

        [EntryForm(WidthControl = 500, MultiLine = true, NumberLine = 5, GroupeBox = "Grades")]
        [DataGrid(WidthColonne = 500)]
        public LocalizedString Description { get; set; }

        //[EntryForm]
        //[DataGrid]
        //[Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        //public List<Staff> staffs { get; set; }
    }
}
