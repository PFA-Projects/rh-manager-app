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
    [Menu(Group = "managements")]
    public class StaffGrade : BaseEntity
    {
        public StaffGrade()
        {
            this.Description = new LocalizedString();
            this.NumberOfGrade = new LocalizedString();
        }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NumberOfGrade { get; set; }

        [EntryForm]
        [DataGrid]
        public LocalizedString Description { get; set; }

        //[EntryForm]
        //[DataGrid]
        //[Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        //public List<Staff> stafflist { get; set; }
    }
}
