using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(DisplayMember = "name", Localizable = true, isMaleName = true)]
    [Menu(Group = "Staff")]
    [ManagementForm(Width = 1000, Height = 600)]
    public class GradeCategory: BaseEntity
    {
        [EntryForm]
        [DataGrid]
        [Filter]
        public string name { get; set; }


        [EntryForm]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]
        public List<StaffGrade>grades { get; set; }
    }
}
